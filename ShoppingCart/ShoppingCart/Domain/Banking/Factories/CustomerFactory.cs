using System;
using System.Collections.Generic;

namespace ShoppingCart.Domain.Banking.Factories
{
    public class CustomerFactory
    {
        public static Customer Get(Accounts accounts, Address address) => new Customer(accounts, address);
    }
}
