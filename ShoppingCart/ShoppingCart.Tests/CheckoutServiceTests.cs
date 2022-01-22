using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Factories;
using ShoppingCart.Domain.Services;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CheckoutServiceTests
    {
        [Fact]
        public void ShouldReturnOrdersOnCheckout()
        {
            Cart cart = new Cart();
            Product product1 = ProductFactory.Get("iPad", 50000, Currency.INR);
            Product product2 = ProductFactory.Get("Hero Ink Pen", 35, Currency.INR);
            LineItem lineItem1 = new LineItem(product1);
            LineItem lineItem2 = new LineItem(product2);
            List<Product> expectedProducts = new List<Product>() { product1, product2 };
            cart.AddItem(lineItem1);
            cart.AddItem(lineItem2);
            CheckoutService checkoutService = new CheckoutService();
            Order order = checkoutService.CheckOut(cart);
            Assert.True(cart.IsCheckedOut);
            Assert.True(expectedProducts.SequenceEqual(order.Products));
        }
    }
}
