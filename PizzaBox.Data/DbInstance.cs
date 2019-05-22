using PizzaBox.Data.Database;

namespace PizzaBox.Data
{
    public sealed class DbInstance
    {
        private static PizzaBoxContext instance = null;
        private DbInstance()
        {
        }
        public static PizzaBoxContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PizzaBoxContext();
                    return instance;
                }
                else
                {
                    return instance;
                }
            }
        }

    }
}
