using System;

namespace ShoppingCart.Domain
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product product = (Product)obj;
                return Name == product.Name;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Product(Name:{0})", Name);
        }
    }
}
