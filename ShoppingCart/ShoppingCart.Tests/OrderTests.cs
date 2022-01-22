using System;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Factories;
using ShoppingCart.Domain.Services;
using Xunit;

namespace ShoppingCart.Tests
{
    public class OrderTests
    {
        [Fact]
        public void ShouldReturnTotalCostAsExpected()
        {
            Cart cart = new Cart();
            Product product1 = ProductFactory.Get("iPad", 50000, Currency.INR, 430);
            Product product2 = ProductFactory.Get("Hero Ink Pen", 35, Currency.INR, 10);
            LineItem lineItem1 = new LineItem(product1, 2);
            LineItem lineItem2 = new LineItem(product2);
            cart.AddItem(lineItem1);
            cart.AddItem(lineItem2);
            CheckoutService checkoutService = new CheckoutService();
            Order order = checkoutService.CheckOut(cart);
            double totalCost = order.GetTotalCost();
            Assert.Equal(100043.70, Math.Round(totalCost, 2));
        }
    }
}
