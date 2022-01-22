using System;
namespace ShoppingCart.Domain.Factories
{
    public class ProductFactory
    {
        public ProductFactory()
        {
        }

        public static Product Get(string productName, double denomination, Currency currency)
        {
            return new Product(productName, new Price(denomination, currency));
        }
    }
}
