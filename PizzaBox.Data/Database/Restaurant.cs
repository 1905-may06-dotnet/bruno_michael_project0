using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            StoreLocation = new HashSet<StoreLocation>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public virtual ICollection<StoreLocation> StoreLocation { get; set; }
    }
}
