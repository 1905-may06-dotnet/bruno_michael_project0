using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PizzaBox.Data.Database;

namespace PizzaBox.Data
{
    public class Crud : ICrud
    {
        public List<Topping> GetToppings()
        {
            var toppings = DbInstance.Instance.Topping.ToList();
            return toppings;
        }
        public Topping GetTopping(int id)
        {
            var topping = DbInstance.Instance.Topping.Where<Topping>(r => r.ToppingId == id).FirstOrDefault();
            return topping;
        }
        public Topping GetTopping(string name)
        {
            var topping = DbInstance.Instance.Topping.Where(x => x.ToppingName == name).FirstOrDefault();
            return topping;
        }
        public void AddTopping(Topping t)
        {
            DbInstance.Instance.Topping.Add(t);
            DbInstance.Instance.SaveChanges();
        }
        public void DeleteTopping(Topping t)
        {
            var topping = DbInstance.Instance.Topping.Where<Topping>(x => x.ToppingId == t.ToppingId).FirstOrDefault();
            DbInstance.Instance.Topping.Remove(topping);
            DbInstance.Instance.SaveChanges();
        }

        //public List<Crust> GetCrusts()
        //{
        //    var crusts = DbInstance.Instance.Crust.ToList();
        //    return crusts;
        //}
        //public Crust GetCrust(int id)
        //{
        //    var crust = DbInstance.Instance.Crust.Where<Crust>(r => r.CrustId == id).FirstOrDefault();
        //    return crust;
        //}
        //public void AddCrust(Crust c)
        //{
        //    DbInstance.Instance.Crust.Add(c);
        //    DbInstance.Instance.SaveChanges();
        //}
        //public void DeleteCrust(Crust c)
        //{
        //    var crust = DbInstance.Instance.Crust.Where<Crust>(x => x.CrustId == c.CrustId).FirstOrDefault();
        //    DbInstance.Instance.Crust.Remove(crust);
        //    DbInstance.Instance.SaveChanges();
        //}

        public List<Pizza> GetPizzas()
        {
            var pizzas = DbInstance.Instance.Pizza.ToList();
            return pizzas;
        }
        public List<Pizza> GetPizzas(Requisition o)
        {
            var pizzas = DbInstance.Instance.Pizza.Where(x => x.OrderId == o.OrderId).ToList();
            return pizzas;
        }
        public Pizza GetPizza(int id)
        {
            var pizza = DbInstance.Instance.Pizza.Where<Pizza>(r => r.PizzaId == id).FirstOrDefault();
            return pizza;
        }
        public void AddPizza(Pizza p)
        {
            DbInstance.Instance.Pizza.Add(p);
            DbInstance.Instance.SaveChanges();
        }
        public void DeletePizza(Pizza p)
        {
            var pizza = DbInstance.Instance.Pizza.Where<Pizza>(x => x.PizzaId == p.PizzaId).FirstOrDefault();
            DbInstance.Instance.Pizza.Remove(pizza);
            DbInstance.Instance.SaveChanges();
        }

        public List<Requisition> GetRequisitions()
        {
            var requisitions = DbInstance.Instance.Requisition.ToList();
            return requisitions;
        }
        public List<Requisition> GetRequisitions(Person p)
        {
            var orders = DbInstance.Instance.Requisition.Where(x => x.UserId == p.PersonId).ToList();
            return orders;
        }
        public Requisition GetRequisition(int id)
        {
            var requisition = DbInstance.Instance.Requisition.Where<Requisition>(r => r.UserId == id).FirstOrDefault();
            return requisition;
        }
        public void AddRequisition(Requisition c)
        {
            DbInstance.Instance.Requisition.Add(c);
            DbInstance.Instance.SaveChanges();
        }
        public void DeleteRequisition(Requisition r)
        {
            var requisition = DbInstance.Instance.Requisition.Where<Requisition>(x => x.UserId == r.UserId).FirstOrDefault();
            DbInstance.Instance.Requisition.Remove(requisition);
            DbInstance.Instance.SaveChanges();
        }

        public List<Person> GetPersons()
        {
            var persons = DbInstance.Instance.Person.ToList();
            return persons;
        }
        public Person GetPerson(int id)
        {
            var person = DbInstance.Instance.Person.Where<Person>(r => r.PersonId == id).FirstOrDefault();
            return person;
        }
        public Person GetPerson(string username)
        {
            var person = DbInstance.Instance.Person.Where<Person>(r => r.Username == username).FirstOrDefault();
            return person;
        }
        public void AddPerson(Person p)
        {
            DbInstance.Instance.Person.Add(p);
            DbInstance.Instance.SaveChanges();
        }
        public void DeletePerson(Person p)
        {
            var person = DbInstance.Instance.Person.Where<Person>(x => x.PersonId == p.PersonId).FirstOrDefault();
            DbInstance.Instance.Person.Remove(person);
            DbInstance.Instance.SaveChanges();
        }

        public List<StoreLocation> GetLocations()
        {
            var locations = DbInstance.Instance.StoreLocation.ToList();
            return locations;
        }
        public List<StoreLocation> GetLocations(Person p)
        {
            var locationIds = DbInstance.Instance.UserLocation.Where(x => x.UserId == p.PersonId);
            List<StoreLocation> locations = new List<StoreLocation>();
            foreach (var id in locationIds)
            {
                var location = DbInstance.Instance.StoreLocation.Where(x => x.LocationId == id.LocationId).FirstOrDefault();
                locations.Add(location);
            }
            return locations;
        }
        public StoreLocation GetLocation(string address)
        {
            var location = DbInstance.Instance.StoreLocation.Where(x => x.LocationAddress == address).FirstOrDefault();
            return location;
        }
        public StoreLocation GetLocation(int id)
        {
            var location = DbInstance.Instance.StoreLocation.Where<StoreLocation>(r => r.LocationId == id).FirstOrDefault();
            return location;
        }
        public void AddLocation(StoreLocation l)
        {
            DbInstance.Instance.StoreLocation.Add(l);
            DbInstance.Instance.SaveChanges();
        }
        public void DeleteLocation(StoreLocation l)
        {
            var location = DbInstance.Instance.StoreLocation.Where<StoreLocation>(x => x.LocationId == l.LocationId).FirstOrDefault();
            DbInstance.Instance.StoreLocation.Remove(location);
            DbInstance.Instance.SaveChanges();
        }

        public List<Restaurant> GetRestaurants()
        {
            var restaurants = DbInstance.Instance.Restaurant.ToList();
            return restaurants;
        }
        public Restaurant GetRestaurant(int id)
        {
            var restaurant = DbInstance.Instance.Restaurant.Where<Restaurant>(r => r.RestaurantId == id).FirstOrDefault();
            return restaurant;
        }
        public void AddRestaurant(Restaurant r)
        {
            DbInstance.Instance.Restaurant.Add(r);
            DbInstance.Instance.SaveChanges();
        }
        public void DeleteRestaurant(Restaurant r)
        {
            var restaurant = DbInstance.Instance.Restaurant.Where<Restaurant>(x => x.RestaurantId == r.RestaurantId).FirstOrDefault();
            DbInstance.Instance.Restaurant.Remove(restaurant);
            DbInstance.Instance.SaveChanges();
        }

        public void LinkUserToLocation(Person p)
        {
            var matchingTable = DbInstance.Instance.StoreLocation.Where(x => x.LocationCity == p.City);
            foreach (var location in matchingTable)
            {
                UserLocation uL = new UserLocation()
                { UserId = p.PersonId, LocationId = location.LocationId};
                DbInstance.Instance.UserLocation.Add(uL);
            }
                DbInstance.Instance.SaveChanges();
        }
        public void LinkToppingToPizza(Topping t, Pizza p)
        {
            PizzaTopping pt = new PizzaTopping() { PizzaId = p.PizzaId, ToppingId = t.ToppingId };
            DbInstance.Instance.PizzaTopping.Add(pt);
            DbInstance.Instance.SaveChanges();
        }

        public List<Topping> GetToppings(Pizza p)
        {
            var topIds = DbInstance.Instance.PizzaTopping.Where(x => x.PizzaId == p.PizzaId);
            List<Topping> tops = new List<Topping>();
            foreach (var id in topIds)
            {
                var top = DbInstance.Instance.Topping.Where(x => x.ToppingId == id.ToppingId).FirstOrDefault();
                tops.Add(top);
            }
            return tops;
        }

    }
}
