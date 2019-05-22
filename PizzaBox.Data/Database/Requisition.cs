using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Data.Database
{
    public partial class Requisition
    {
        public Requisition()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public override string ToString()
        {
            Crud c = new Crud();
            StringBuilder sb = new StringBuilder();
            List<Pizza> pizzas = c.GetPizzas(this);
            sb.Append($"Order: {OrderId}.\nStarted at: {OrderTime}. Placed at Location: {c.GetLocation(LocationId).ToString()}\nPizzas in this Order:\n");
            foreach (var p in pizzas)
            {
                sb.Append($"{p.ToString()}\n");
            }
            return sb.ToString();
        }
        public virtual StoreLocation Location { get; set; }
        public virtual Person User { get; set; }
        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
