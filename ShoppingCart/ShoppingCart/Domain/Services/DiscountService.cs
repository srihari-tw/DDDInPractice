using System.Collections.Generic;

namespace ShoppingCart.Domain.Services
{
    public class DiscountService : IDiscountService
    {
        // TODO: This is can come from an application service and fed into a domain service as an input!
        private readonly Dictionary<string, Price> competitorPriceMap = new()
        {
            { "iPad Pro", new Price(50000,Currency.INR) },
            { "Hero Ink Pen", new Price(35,Currency.INR) },
            { "GM Cricket Bat", new Price(500,Currency.INR) },
        };

        public Price GetDiscountedPrice(string productName, Price price)
        {
            if (competitorPriceMap.ContainsKey(productName))
            {
                Price competitorPrice = competitorPriceMap[productName];
                return competitorPrice.ReduceBy(10);
            }
            else
            {
                return price;
            }
        }
    }
}
