using System;
using ShoppingCart.Domain.Banking;
using ShoppingCart.Domain.Banking.Factories;
using Xunit;

namespace ShoppingCart.Tests.Banking
{
    public class AccountTests
    {
        [Fact]
        public void ShouldChangeAddressOfAllAccountsWhenCustomerChangesAddress()
        {
            Address address = AddressFactory.Get("Chennai");
            Account account1 = AccountFactory.Get(address);
            Account account2 = AccountFactory.Get(address);
            Accounts accounts = new Accounts() { account1, account2 };
            Customer customer = CustomerFactory.Get(accounts, address);
            Address newAddress = AddressFactory.Get("Pune");
            customer.ChangeAddress(newAddress);
            foreach (Account account in customer.Accounts)
            {
                Assert.True(newAddress.Equals(account.Address));
            }
        }
    }
}
