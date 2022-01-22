namespace ShoppingCart.Domain.Banking
{
    public class Address
    {
        public string City { get; private set; }

        public Address(string city)
        {
            City = city;
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Address address = (Address)obj;
                return City == address.City;
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}", City);
        }

    }
}
