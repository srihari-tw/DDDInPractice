namespace ShoppingCart.Domain
{
    public class Price
    {
        public Price(double denomination, Currency currency)
        {
            Denomination = denomination;
            Currency = currency;
        }

        public double Denomination { get; private set; }
        public Currency Currency { get; private set; }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Price price = (Price)obj;
                return Denomination == price.Denomination && Currency == price.Currency;
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Denomination, Currency);
        }

        public Price ReduceBy(double discountPercentage)
        {
            double reduction = Denomination * discountPercentage / 100.00;
            return new Price(Denomination - reduction, Currency);

        }
    }
}
