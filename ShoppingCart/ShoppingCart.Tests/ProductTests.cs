using ShoppingCart.Domain;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ShouldCreateANewProductWithProductName()
        {
            Product product = new Product("iPad Pro", new Price(50000, Currency.INR));
            Assert.Equal("iPad Pro", product.Name);
        }

        [Fact]
        public void ShouldReturnTrueWhenComparingTwoProductsWithSameName()
        {
            Product product1 = new Product("iPad Pro", new Price(50000,Currency.INR));
            Product product2 = new Product("iPad Pro", new Price(50000, Currency.INR));
            Assert.Equal(product1,product2);
        }

        [Fact]
        public void ShouldReturnTrueWhenItemNamesAreSame()
        {
            Product product1 = new Product("iPad", new Price(50000, Currency.INR));
            Product product2 = new Product("iPad", new Price(50000, Currency.INR));
            Assert.True(product1.Equals(product2));
        }

        [Fact]
        public void ShouldReturnFalseWhenItemNamesAreDifferent()
        {
            Product product1 = new Product("iPad", new Price(50000, Currency.INR));
            Product product2 = new Product("iPad Pro", new Price(50000, Currency.INR));
            Assert.False(product1.Equals(product2));
        }

        [Fact]
        public void ShouldReturnFalseWhenTypesAreDifferent()
        {
            Product product = new Product("iPad", new Price(50000, Currency.INR));
            Assert.False(product.Equals("iPad"));
        }

        [Fact]
        public void ShouldReturnGetHashCodeAsExpected()
        {
            Product product = new Product("iPad", new Price(50000, Currency.INR));
            Assert.True(product.GetHashCode().Equals(product.GetHashCode()));
        }
    }
}
