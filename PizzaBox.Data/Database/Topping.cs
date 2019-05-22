using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class Topping
    {
        public Topping()
        {
            InventoryToppings = new HashSet<InventoryToppings>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<InventoryToppings> InventoryToppings { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
