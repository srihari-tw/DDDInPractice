using System;
using ShoppingCart.Domain.Banking.Factories;

namespace ShoppingCart.Domain.Banking
{
    public class Account
    {
        private readonly Guid accountId = Guid.NewGuid();
        public Address Address { get; private set; }

        public Account(Address address)
        {
            Address = address;
        }

        public void ChangeAddress(Address address)
        {
            Address = AddressFactory.Get(address.City);
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Account acount = (Account)obj;
                return accountId == acount.accountId;
            }
        }

        public override int GetHashCode()
        {
            return accountId.GetHashCode();
        }
    }
}
