using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class Person
    {
        public Person()
        {
            Pizza = new HashSet<Pizza>();
            Requisition = new HashSet<Requisition>();
            UserLocation = new HashSet<UserLocation>();
        }

        public int PersonId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pass { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
        public virtual ICollection<Requisition> Requisition { get; set; }
        public virtual ICollection<UserLocation> UserLocation { get; set; }
    }
}
