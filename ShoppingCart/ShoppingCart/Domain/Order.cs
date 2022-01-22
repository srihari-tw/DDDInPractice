using System.Collections.Generic;

namespace ShoppingCart.Domain
{
    public class Order
    {
        public List<Product> Products { get; private set; }

        public Order(List<Product> products)
        {
            Products = products;
        }
    }
}
