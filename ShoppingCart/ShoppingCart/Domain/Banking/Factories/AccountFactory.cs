namespace ShoppingCart.Domain.Banking.Factories
{
    public class AccountFactory
    {
        public static Account Get(Address address)
        {
            return new(address);
        }
    }
}
