using System;
using ShoppingCart.Exceptions;
using ShoppingCart.Domain;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingCart.Tests
{
    public class CartTests
    {
        [Theory]
        [InlineData("iPad Prod")]
        [InlineData("Hero ink Pen")]
        public void ShouldAddItemToTheCart(string itemName)
        {
            Cart cart = new Cart();
            LineItem item = new LineItem(itemName);
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
        public void ShouldReturnTrueWhenItemNamesAreSame()
        {
            LineItem item1 = new LineItem("iPad");
            LineItem item2 = new LineItem("iPad");
            Assert.True(item1.Equals(item2));
        }

        [Fact]
        public void ShouldReturnFalseWhenItemNamesAreDifferent()
        {
            LineItem item1 = new LineItem("iPad");
            LineItem item2 = new LineItem("iPad Pro");
            Assert.False(item1.Equals(item2));
        }

        [Fact]
        public void ShouldReturnFalseWhenTypesAreDifferent()
        {
            LineItem item = new LineItem("iPad");
            Assert.False(item.Equals("iPad"));
        }

        [Fact]
        public void ShouldReturnGetHashCodeAsExpected()
        {
            LineItem item = new LineItem("iPad");
            Assert.True("iPad".GetHashCode().Equals(item.GetHashCode()));
        }

        [Fact]
        public void ShouldAddItemWithQuantityAnMatchCount()
        {
            LineItem item = new LineItem("GM Cricket bat", 2);
            Cart cart = new Cart();
            cart.AddItem(item);
            Assert.Equal(2, cart.ItemCount);
        }

        [Fact]
        public void ShouldRemoveAllQuantitiesOfAnItem()
        {
            LineItem item1 = new LineItem("iPad Pro");
            LineItem item2 = new LineItem("GM Cricket Bat",5);
            LineItem item3 = new LineItem("iPad Pro",2);
            LineItem item4 = new LineItem("Hero Ink Pen", 2);
            Cart cart = new Cart();
            cart.AddItem(item1);
            cart.AddItem(item2);
            cart.AddItem(item3);
            cart.AddItem(item4);
            cart.RemoveMatchingItem("iPad Pro");
            Assert.Equal(7, cart.ItemCount);
        }

        [Fact]
        public void ShouldMaintainListOfRemovedItems()
        {
            LineItem item1 = new LineItem("iPad Pro");
            LineItem item2 = new LineItem("GM Cricket Bat", 5);
            LineItem item3 = new LineItem("iPad Pro", 2);
            LineItem item4 = new LineItem("Hero Ink Pen", 2);
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

            LineItem item = new LineItem("iPad");
            Console.WriteLine(item.ToString());
            Assert.True("Item(ItemName:iPad)".Equals(item.ToString()));
        }
    }
}
