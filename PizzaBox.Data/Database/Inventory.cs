using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryToppings = new HashSet<InventoryToppings>();
        }

        public int InventoryId { get; set; }
        public int? Quantity { get; set; }
        public int LocationId { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual ICollection<InventoryToppings> InventoryToppings { get; set; }
    }
}
