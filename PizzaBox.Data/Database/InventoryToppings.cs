using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class InventoryToppings
    {
        public int RelationshipId { get; set; }
        public int InventoryId { get; set; }
        public int ToppingId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
