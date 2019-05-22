using System;
using System.Collections.Generic;
using PizzaBox.Data;
using PizzaBox.Data.Database;

namespace PizzaBox.Domain
{
    public static class PersonLogic
    {
        
        public static bool CheckUsername(string username)
        {
            Crud c = new Crud();
            Person p = c.GetPerson(username);
            if (p == null) return false;
            return true;
        }

        public static bool CheckCredentials(string username, string password)
        {
            Crud c = new Crud();
            Person p = c.GetPerson(username);
            if (p == null) return false;
            if (p.Pass == password) return true;
            return false;
        }
        
    }
}
