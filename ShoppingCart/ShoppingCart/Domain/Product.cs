namespace ShoppingCart.Domain
{
    public class Product
    {
        public Product(string name, Price price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, Price price, double weight)
        {
            Name = name;
            Price = price;
            WeightInGrams = weight;
        }

        public double WeightInGrams { get; private set; }
        public string Name { get; private set; }
        public Price Price { get; private set; }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Product product = (Product)obj;
                return Name == product.Name && Price.Equals(product.Price);
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Product(Name:{0},Price:{1})", Name, Price.ToString());
        }
    }
}
