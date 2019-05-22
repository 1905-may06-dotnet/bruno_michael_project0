using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Data.Database
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public string Size { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public override string ToString()
        {
            Crud c = new Crud();
            List<Topping> toppings = c.GetToppings(this);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Pizza: {PizzaId}.\nWith Toppings: ");
            bool first = true;

            foreach (var x in toppings)
            {
                if (first)
                {
                    sb.Append($"{x.ToppingName}");
                    first = false;
                }
                else sb.Append($", {x.ToppingName}");
            }
            return sb.ToString();
        }

        public virtual Requisition Order { get; set; }
        public virtual Person User { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
