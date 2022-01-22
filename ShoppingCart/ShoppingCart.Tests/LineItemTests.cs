using ShoppingCart.Domain;
using ShoppingCart.Domain.Factories;
using Xunit;

namespace ShoppingCart.Tests
{
    public class LineItemTests
    {
        [Fact]
        public void ShouldReturnTrueWhenItemNamesAreSame()
        {
            LineItem item1 = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            LineItem item2 = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            Assert.True(item1.Equals(item2));
        }

        [Fact]
        public void ShouldReturnFalseWhenItemNamesAreDifferent()
        {
            LineItem item1 = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            LineItem item2 = new LineItem(ProductFactory.Get("iPad Pro", 50000, Currency.INR));
            Assert.False(item1.Equals(item2));
        }

        [Fact]
        public void ShouldReturnFalseWhenTypesAreDifferent()
        {
            LineItem item = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            Assert.False(item.Equals("iPad"));
        }

        [Fact]
        public void ShouldReturnGetHashCodeAsExpected()
        {
            LineItem item1 = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            LineItem item2 = new LineItem(ProductFactory.Get("iPad", 50000, Currency.INR));
            Assert.True(item1.GetHashCode().Equals(item2.GetHashCode()));
        }
    }
}
