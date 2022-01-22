using System;

namespace ShoppingCart.Domain.Banking
{
    public delegate void AddressChanged(Address address);

    public class Customer
    {
        private Accounts accounts;
        private readonly Guid customerId = Guid.NewGuid();
        public event AddressChanged AddressChanged;

        public Address Address { get; private set; }
        public Accounts Accounts { get { return accounts; } }


        public Customer(Accounts accounts, Address address)
        {
            this.accounts = accounts;
            Address = address;

            foreach (Account account in this.accounts)
            {
                AddressChanged += account.ChangeAddress;
            }
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
                Customer customer = (Customer)obj;
                return customerId == customer.customerId;
            }
        }

        public override int GetHashCode()
        {
            return customerId.GetHashCode();
        }

        public void ChangeAddress(Address address)
        {
            Address = address;
            AddressChanged(address);
        }
    }
}
