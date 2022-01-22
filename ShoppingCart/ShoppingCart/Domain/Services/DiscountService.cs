using System.Collections.Generic;
using ShoppingCart.Domain;

namespace ShoppingCart
{
    public class DiscountService : IDiscountService
    {
        private Dictionary<string, Price> competitorPriceMap = new Dictionary<string, Price>()
        {
            { "iPad Pro", new Price(50000,Currency.INR) },
            { "Hero Ink Pen", new Price(35,Currency.INR) },
            { "GM Cricket Bat", new Price(500,Currency.INR) },
        };

        public Price GetDiscountedPrice(string productName, Price price)
        {
            if (competitorPriceMap.ContainsKey(productName))
            {
                double competitorDenomination = competitorPriceMap[productName].Denomination;
                Price discountedPrice = new Price(competitorDenomination - 0.1 * competitorDenomination, price.Currency);
                return discountedPrice;
            }
            else
            {
                return price;
            }
        }
    }
}
