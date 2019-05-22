using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class PizzaTopping
    {
        public int RelationshipId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
