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
    }
}
