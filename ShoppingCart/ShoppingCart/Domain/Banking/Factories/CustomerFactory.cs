namespace ShoppingCart.Domain.Banking.Factories
{
    public class CustomerFactory
    {
        public static Customer Get(Accounts accounts, Address address)
        {
            return new(accounts, address);
        }
    }
}
