using System;
using ShoppingCart.Domain;
using Xunit;

namespace ShoppingCart.Tests
{
    public class PriceTests
    {
        [Fact]
        public void ShouldReturnTrueWhenTwoPriceInstancesWithSameDenominationAndCurrencyAreCompared()
        {
            Price price1 = new Price(25, Currency.INR);
            Price price2 = new Price(25, Currency.INR);
            Assert.True(price1.Equals(price2));
        }

        [Fact]
        public void ShouldReturnFalseWhenTwoPriceInstancesWithDifferentDenominationOrCurrencyAreCompared()
        {
            Price price1 = new Price(25, Currency.INR);
            Price price2 = new Price(25, Currency.USD);
            Assert.False(price1.Equals(price2));
            Price price3 = new Price(25, Currency.INR);
            Price price4 = new Price(35, Currency.INR);
            Assert.False(price3.Equals(price4));
        }
    }
}
