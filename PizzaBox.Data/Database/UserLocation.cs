using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Database
{
    public partial class UserLocation
    {
        public int RelationshipId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

        public virtual StoreLocation Location { get; set; }
        public virtual Person User { get; set; }
    }
}
