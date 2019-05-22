using System;
using System.Collections.Generic;
using System.Text;
using PizzaBox.Data;
using PizzaBox.Data.Database;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Client
{
    public class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Hello World!");
            Crud c = new Crud();
            string type;
            Person currentUser = null;
            bool isLoggedIn = false;
            do
            {
                Console.WriteLine("Welcome to the Pizza Box Console main menu. These are your options: ");
                Console.WriteLine("0: Quit");
                Console.WriteLine("1: User Registration");
                Console.WriteLine("2: User Sign In");
                Console.WriteLine("3: View Locations");
                Console.WriteLine("4: Place An Order");
                Console.WriteLine("5: View Order History");
                Console.WriteLine("6: Sign Out");
                Console.WriteLine("Please make a selection: ");
                type = Console.ReadLine();
                switch (type)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        break;
                    case "1":
                        Person newPerson = new Person();
                        Console.WriteLine("Thank you for registering with us. We will need several items of information.");
                        Console.WriteLine("Enter your first name: ");
                        newPerson.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter your last name: ");
                        newPerson.LastName = Console.ReadLine();
                        Console.WriteLine("Enter your city: ");
                        newPerson.City = Console.ReadLine();
                        Console.WriteLine("Enter your email: ");
                        newPerson.Email = Console.ReadLine();
                        bool isTaken = true;
                        while (isTaken)
                        {
                            Console.WriteLine("Choose a username: ");
                            string username = Console.ReadLine();
                            if (PersonLogic.CheckUsername(username))
                            {
                                Console.WriteLine("That username is already taken.");
                            }
                            else
                            {
                                newPerson.Username = username;
                                isTaken = false;
                            }
                        }
                        Console.WriteLine("Choose a password: ");
                        newPerson.Pass = Console.ReadLine();
                        Console.WriteLine("You have successfully registered. Please Sign in for more options.");
                        
                        c.AddPerson(newPerson);
                        c.LinkUserToLocation(newPerson);
                        break;
                    case "2":
                        if (isLoggedIn)
                        {
                            Console.WriteLine($"{currentUser.Username} is already logged in");
                            break;
                        }
                        Console.WriteLine("This is the Login Option");
                        string loginUN = "";
                        string loginPW;
                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.WriteLine("Enter your username: ");
                            loginUN = Console.ReadLine();
                            if (PersonLogic.CheckUsername(loginUN)) isValid = true;
                            else Console.WriteLine("That username does not exist in the database. Please try again.");
                        }
                        while (!isLoggedIn)
                        {
                            Console.WriteLine("Enter your password");
                            loginPW = Console.ReadLine();
                            if (PersonLogic.CheckCredentials(loginUN, loginPW))
                            {
                                isLoggedIn = true;
                                currentUser = c.GetPerson(loginUN);
                                Console.WriteLine($"Log in successful. Welcome {loginUN}");
                            }
                            else Console.WriteLine("Incorrect password. Please try again.");
                        }
                        break;
                    case "3":
                        if (!isLoggedIn)
                        {
                            Console.WriteLine("You cannot view locations without signing in. Please sign in first.");
                            break;
                        }
                        Console.WriteLine("These are the locations in your city: ");
                        List<StoreLocation> locationList = c.GetLocations(currentUser);
                        foreach (var loc in locationList)
                        {
                            Console.WriteLine(loc.ToString());
                        }
                        break;
                    case "4":
                        if (!isLoggedIn)
                        {
                            Console.WriteLine("You need to sign in to place an order");
                            break;
                        }
                        List<Requisition> orders = c.GetRequisitions();
                        DateTime date = DateTime.Now;
                        date.AddHours(-2);
                        foreach (var r in orders)
                        {
                            DateTime check = (DateTime)r.OrderTime;
                            if (date.Hour < check.Hour)
                            {
                                Console.WriteLine("You have placed an order recently. Try again later");
                                break;
                            }
                        }
                        string orderChoice;
                        float price = 0;
                        Requisition currentOrder = new Requisition();
                        Pizza currentPizza = new Pizza();
                        List<Topping> toppingsAdded = new List<Topping>();
                        do
                        {
                            Console.WriteLine("Welcome to the order choice menu. These are your options: ");
                            Console.WriteLine("0: Quit");
                            Console.WriteLine("1: Select Preset Pizza");
                            Console.WriteLine("2: Select Size");
                            Console.WriteLine("3: Select Toppings");
                            Console.WriteLine("4: Add Current Custom Pizza");
                            Console.WriteLine("5: Select a Location");
                            Console.WriteLine("6: Preview Order");
                            Console.WriteLine("7: Confirm Order");
                            Console.WriteLine("Select An Option: ");
                            orderChoice = Console.ReadLine();
                            switch (orderChoice)
                            {
                                case "0":
                                    Console.Write("Goodbye");
                                    break;
                                case "1":
                                    if(currentOrder.LocationId == 0)
                                    {
                                        Console.WriteLine("Please choose a location first");
                                        break;
                                    }
                                    if (currentOrder.Pizza.Count == 100)
                                    {
                                        Console.WriteLine("You cannot add any more pizzas to this order");
                                        break;
                                    }
                                    Console.WriteLine("Currently the only preset option is a medium cheese. This pizza has been added to your order.");
                                    Topping top1 = c.GetTopping("Mozarella Cheese");
                                    price += (float) top1.Price;
                                    Topping top2 = c.GetTopping("Marinara Sauce");
                                    price += (float)top2.Price;
                                    currentPizza.Size = "Medium";
                                    price += 7.5F;
                                    currentPizza.UserId = currentUser.PersonId;
                                    currentPizza.OrderId = currentOrder.OrderId;
                                    c.AddPizza(currentPizza);
                                    c.LinkToppingToPizza(top1, currentPizza);
                                    c.LinkToppingToPizza(top2, currentPizza);
                                    currentPizza = new Pizza();
                                    break;
                                case "2":
                                    if (currentPizza.Size != null)
                                    {
                                        Console.WriteLine("You have already chosen a size.");
                                        break;
                                    }
                                    bool isSizeVal = false;
                                    while (!isSizeVal)
                                    {
                                        Console.WriteLine("Select a size: Small, Medium, or Large");
                                        string pSize = Console.ReadLine();
                                        if (pSize == "Small")
                                        {
                                            currentPizza.Size = pSize;
                                            price += 5F;
                                            break;
                                        }
                                        else if (pSize == "Medium")
                                        {
                                            currentPizza.Size = pSize;
                                            price += 7.5F;
                                            break;
                                        }
                                        else if (pSize == "Large")
                                        {
                                            currentPizza.Size = pSize;
                                            price += 10F;
                                            break;
                                        }
                                        else Console.WriteLine("Invalid Size. Please Try again.");
                                    }
                                    break;
                                case "3":
                                    if (currentOrder.LocationId == 0)
                                    {
                                        Console.WriteLine("please select a location");
                                        break;
                                    }
                                    if (toppingsAdded.Count == 5)
                                    {
                                        Console.WriteLine("you already have the max number of toppings");
                                        break;
                                    }
                                    bool isValTop = false;
                                    while (!isValTop)
                                    {
                                        Console.WriteLine("Here are all the possible toppings: ");
                                        List<Topping> toppings = c.GetToppings();
                                        foreach (var top in toppings)
                                        {
                                            Console.WriteLine(top.ToppingName);
                                        }
                                        Console.WriteLine("Please Enter the name of the topping you want to add: ");
                                        Topping t = c.GetTopping(Console.ReadLine());
                                        if (t != null)
                                        {
                                            toppingsAdded.Add(t);
                                            price += (float)t.Price;
                                            isValTop = true;
                                        }
                                        else Console.WriteLine("That's an invalid topping. Please try again.");
                                    }
                                    break;
                                case "4":
                                    if (currentOrder.LocationId == 0)
                                    {
                                        Console.WriteLine("please enter a location");
                                    }
                                    if (toppingsAdded.Count < 2)
                                    {
                                        Console.WriteLine("You need at least 2 toppings.");
                                        break;
                                    }
                                    if (price > 5000)
                                    {
                                        Console.WriteLine("If you add this pizza your price will exceed $5000");
                                        break;
                                    }
                                    if (currentOrder.Pizza.Count == 100)
                                    {
                                        Console.WriteLine("You cannot add any more pizzas to this order");
                                        break;
                                    }
                                    currentPizza.OrderId = currentOrder.OrderId;
                                    currentPizza.UserId = currentUser.PersonId;
                                    c.AddPizza(currentPizza);
                                    foreach (var t in toppingsAdded)
                                    {
                                        c.LinkToppingToPizza(t, currentPizza);
                                    }
                                    break;
                                case "5":
                                    
                                    bool isValLoc = false;
                                    while (!isValLoc)
                                    {
                                        Console.WriteLine("These are the current Locations where you can place an order: ");
                                        List<StoreLocation> locList = c.GetLocations(currentUser);
                                        foreach (var loc in locList)
                                        {
                                            Console.WriteLine(loc.ToString());
                                        }
                                        Console.WriteLine("Please enter the Address of the location where you want to place your order: ");
                                        string add = Console.ReadLine();
                                        StoreLocation location = c.GetLocation(add);
                                        if (location != null)
                                        {
                                            List<Requisition> rs = c.GetRequisitions();
                                            DateTime date1 = DateTime.Now;
                                            foreach (var r in rs)
                                            {
                                                DateTime check = (DateTime)r.OrderTime;
                                                if (date1.Date == check.Date && r.LocationId == location.LocationId)
                                                {
                                                    Console.WriteLine("You already placed an order at this location today.");
                                                    break;
                                                }

                                            }
                                            StringBuilder sb = new StringBuilder();
                                            currentOrder.LocationId = location.LocationId;
                                            currentOrder.UserId = currentUser.PersonId;
                                            c.AddRequisition(currentOrder);
                                            isValLoc = true;
                                        }
                                        else Console.WriteLine("invalid address.");
                                    }
                                    break;
                                case "6":
                                    if (currentOrder.Pizza.Count == 0)
                                    {
                                        Console.WriteLine("You haven't added any pizzas yet.");
                                        break;
                                    }
                                    
                                    Console.WriteLine("This is your current Order: ");
                                    Console.WriteLine(currentOrder.ToString());
                                    Console.WriteLine($"The total price of your order is: ${price}");
                                    break;
                                case "7":
                                    if (currentOrder.Pizza.Count == 0)
                                    {
                                        Console.WriteLine("You haven't added any pizzas yet.");
                                        break;
                                    }
                                    
                                    if (currentOrder.LocationId == 0)
                                    {
                                        Console.WriteLine("You haven't chosen a location for this order");
                                        break;
                                    }
                                    if (currentOrder.Pizza.Count == 100)
                                    {
                                        Console.WriteLine("You cannot add any more pizzas to this order");
                                        break;
                                    }
                                    Console.WriteLine("Your order has been placed.");
                                    currentOrder = new Requisition();

                                    break;
                                default:
                                    Console.WriteLine("Invalid Entry. Please Try Again.");
                                    break;
                            }

                        } while (orderChoice != "0");
                        break;
                    case "5":
                        if (!isLoggedIn)
                        {
                            Console.WriteLine("You need to be logged in to view orders.");
                            break;
                        }
                        List<Requisition> orderList = c.GetRequisitions(currentUser);
                        Console.WriteLine("These are your orders: \n");
                        foreach (var o in orderList)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case "6":
                        if (!isLoggedIn)
                        {
                            Console.WriteLine("You are not logged in.");
                            break;
                        }
                        Console.WriteLine($"{currentUser.Username} is now logged out.");
                        isLoggedIn = false;
                        currentUser = null;
                        break;

                    default:
                        Console.WriteLine("Invalid Entry. Please Try Again.");
                        break;
                }
            } while (type != "0");
        }

    }
}
