using ShoppingCart.Domain;

namespace ShoppingCart
{
    public interface IDiscountService
    {
        Price GetDiscountedPrice(string productName, Price price);
    }
}