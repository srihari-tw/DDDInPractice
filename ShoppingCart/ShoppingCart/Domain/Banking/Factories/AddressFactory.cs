namespace ShoppingCart.Domain.Banking.Factories
{
    public class AddressFactory
    {
        public static Address Get(string city)
        {
            return new(city);
        }
    }
}
