﻿using System;
using System.Collections.Generic;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        private List<LineItem> items = new List<LineItem>();
        private List<string> removedItems = new List<string>();

        public int ItemCount
        {
            get
            {
                int itemCount = 0;
                foreach (LineItem item in items)
                {
                    itemCount += item.Quantity;
                }

                return itemCount;
            }
        }

        public void AddItem(LineItem item)
        {
            if (item == null)
            {
                throw new InvalidItemException("Invalid item");
            }

            items.Add(item);
        }

        public void RemoveMatchingItem(string itemName)
        {
            removedItems.Add(itemName);
            var itemsClone = new List<LineItem>(items);
            foreach (LineItem item in items)
            {
                if (item.ItemName == itemName)
                {
                    itemsClone.Remove(item);
                }
            }

            items = itemsClone;
        }

        public List<string> GetRemovedItems()
        {
            return removedItems;
        }
    }
}