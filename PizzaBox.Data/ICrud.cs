using System;
using System.Collections.Generic;
using PizzaBox.Data.Database;

namespace PizzaBox.Data
{
    public interface ICrud
    {
        List<Topping> GetToppings();
        Topping GetTopping(int id);
        void AddTopping(Topping t);
        void DeleteTopping(Topping t);

        //List<Crust> GetCrusts();
        //Crust GetCrust(int id);
        //void AddCrust(Crust c);
        //void DeleteCrust(Crust c);

        List<Pizza> GetPizzas();
        Pizza GetPizza(int id);
        void AddPizza(Pizza p);
        void DeletePizza(Pizza p);

        List<Requisition> GetRequisitions();
        Requisition GetRequisition(int id);
        void AddRequisition(Requisition r);
        void DeleteRequisition(Requisition r);

        List<Person> GetPersons();
        Person GetPerson(int id);
        void AddPerson(Person p);
        void DeletePerson(Person p);

        List<StoreLocation> GetLocations();
        List<StoreLocation> GetLocations(Person p);
        StoreLocation GetLocation(int id);
        void AddLocation(StoreLocation l);
        void DeleteLocation(StoreLocation l);

        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
        void AddRestaurant(Restaurant r);
        void DeleteRestaurant(Restaurant r);

        void LinkUserToLocation(Person p);
    }
}