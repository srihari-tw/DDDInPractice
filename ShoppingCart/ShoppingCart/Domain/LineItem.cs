namespace ShoppingCart.Domain
{
    public class LineItem
    {
        public LineItem(Product product)
        {
            Product = product;
        }

        public LineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }

        public int Quantity { get; } = 1;

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                LineItem item = (LineItem)obj;
                return Product.Equals(item.Product) && Quantity == item.Quantity;
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1})", Product.ToString(),Quantity);
        }
    }
}
