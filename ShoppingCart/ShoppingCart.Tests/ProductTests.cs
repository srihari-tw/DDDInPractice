using ShoppingCart.Domain;
using Xunit;

namespace ShoppingCart.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ShouldCreateANewProductWithProductName()
        {
            Product product = new Product("iPad Pro");
            Assert.Equal("iPad Pro", product.Name);
        }

        [Fact]
        public void ShouldReturnTrueWhenComparingTwoProductsWithSameName()
        {
            Product product1 = new Product("iPad Pro");
            Product product2 = new Product("iPad Pro");
            Assert.Equal(product1,product2);
        }

        [Fact]
        public void ShouldReturnTrueWhenItemNamesAreSame()
        {
            Product product1 = new Product("iPad");
            Product product2 = new Product("iPad");
            Assert.True(product1.Equals(product2));
        }

        [Fact]
        public void ShouldReturnFalseWhenItemNamesAreDifferent()
        {
            Product product1 = new Product("iPad");
            Product product2 = new Product("iPad Pro");
            Assert.False(product1.Equals(product2));
        }

        [Fact]
        public void ShouldReturnFalseWhenTypesAreDifferent()
        {
            Product product = new Product("iPad");
            Assert.False(product.Equals("iPad"));
        }

        [Fact]
        public void ShouldReturnGetHashCodeAsExpected()
        {
            Product product = new Product("iPad");
            Assert.True("iPad".GetHashCode().Equals(product.GetHashCode()));
        }
    }
}
