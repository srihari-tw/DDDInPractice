using System;
namespace ShoppingCart.Domain.Banking.Factories
{
    public class AccountFactory
    {
        public static Account Get(Address address) => new(address);
    }
}
