using System;

namespace ShoppingCart.Domain
{
    public class LineItem
    {
        private readonly Product product;
        private readonly int quantity = 1;        

        public LineItem(Product product)
        {
            this.product = product;
        }

        public LineItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }

        public Product Product
        {
            get { return product; }
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
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
            return String.Format("{0}:{1})", product.ToString(),quantity);
        }
    }
}
