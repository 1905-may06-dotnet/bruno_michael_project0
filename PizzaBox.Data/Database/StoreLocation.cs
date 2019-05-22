using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class StoreLocation
    {
        public StoreLocation()
        {
            Inventory = new HashSet<Inventory>();
            Requisition = new HashSet<Requisition>();
            UserLocation = new HashSet<UserLocation>();
        }

        public int LocationId { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public int? LocationZip { get; set; }
        public int RestaurantId { get; set; }
        public override string ToString()
        {
            Crud c = new Crud();
            string rName = c.GetRestaurant(RestaurantId).RestaurantName;
            return $"{rName}: {LocationAddress}, {LocationCity}, {LocationState} {LocationZip}";
        }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Requisition> Requisition { get; set; }
        public virtual ICollection<UserLocation> UserLocation { get; set; }
    }
}
