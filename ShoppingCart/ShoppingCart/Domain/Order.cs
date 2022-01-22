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

        public double GetTotalCost()
        {
            //cost of all products in order + (weightIngrams of each product *.01)
            double totalCost = 0.0;
            foreach (Product product in Products)
            {
                totalCost += product.Price.Denomination + (0.01 * product.WeightInGrams);
            }

            return totalCost;
        }
    }
}
