using System;
using ShoppingCart.Exceptions;
using ShoppingCart.Domain;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using ShoppingCart.Domain.Factories;
using ShoppingCart.Domain.Services;

namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Theory]
        [InlineData("iPad Prod",50000.00)]
        [InlineData("Hero ink Pen", 35.00)]
        public void ShouldAddItemToTheCart(string itemName, double price)
        {
            Cart cart = new Cart();
            Product product = ProductFactory.Get(itemName, price, Currency.INR);
            LineItem item = new LineItem(product);
            cart.AddItem(item);
            Assert.Equal(1, cart.ItemCount);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenAddingANullItem()
        {
            Cart cart = new Cart();
            Assert.Throws<InvalidItemException>(() => cart.AddItem(null));
        }


        [Fact]
        public void ShouldAddItemWithQuantityAnMatchCount()
        {
            LineItem item = new LineItem(ProductFactory.Get("GM Cricket bat",500,Currency.INR), 2);
            Cart cart = new Cart();
            cart.AddItem(item);
            Assert.Equal(2, cart.ItemCount);
        }

        [Fact]
        public void ShouldRemoveAllQuantitiesOfAnItem()
        {
            LineItem item1 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR));
            LineItem item2 = new LineItem(ProductFactory.Get("GM Cricket bat", 500, Currency.INR), 2);
            LineItem item3 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR),2);
            LineItem item4 = new LineItem(ProductFactory.Get("Hero Ink Pen",35,Currency.INR), 2);
            Cart cart = new Cart();
            cart.AddItem(item1);
            cart.AddItem(item2);
            cart.AddItem(item3);
            cart.AddItem(item4);
            cart.RemoveMatchingItem("iPad Pro");
            Assert.Equal(4, cart.ItemCount);
        }

        [Fact]
        public void ShouldMaintainListOfRemovedItems()
        {
            LineItem item1 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR));
            LineItem item2 = new LineItem(ProductFactory.Get("GM Cricket bat", 500, Currency.INR), 2);
            LineItem item3 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR), 2);
            LineItem item4 = new LineItem(ProductFactory.Get("Hero Ink Pen", 35, Currency.INR), 2);
            Cart cart = new Cart();
            cart.AddItem(item1);
            cart.AddItem(item2);
            cart.AddItem(item3);
            cart.AddItem(item4);
            cart.RemoveMatchingItem("iPad Pro");
            cart.RemoveMatchingItem("Hero Ink Pen");

            var removedItems = new List<string> { "iPad Pro", "Hero Ink Pen" };

            Assert.True(removedItems.SequenceEqual(cart.GetRemovedItems()));
        }

        [Fact]
        public void ShouldReturnToStringAsExpected()
        {

            LineItem item = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR));
            Console.WriteLine(item.ToString());
            Assert.True("Product(Name:iPad Pro,Price:500000:INR):1)".Equals(item.ToString()));
        }

        [Fact]
        public void ShouldReturnFalseWhenTwoCartsWithSameItemsAreCompared()
        {
            Cart cart1 = new Cart();
            Cart cart2 = new Cart();
            LineItem lineItem1 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR)); ;
            LineItem lineItem2 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR)); ;
            cart1.AddItem(lineItem1);
            cart2.AddItem(lineItem2);
            Assert.False(cart1.Equals(cart2));
        }

        [Fact]
        public void ShouldReturnTrueWhenSameCartIsCompared()
        {
            Cart cart1 = new Cart();
            LineItem lineItem1 = new LineItem(ProductFactory.Get("iPad Pro", 500000, Currency.INR));
            cart1.AddItem(lineItem1);
            Assert.True(cart1.Equals(cart1));
        }
    }
}
