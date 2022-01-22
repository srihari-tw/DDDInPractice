using System;
using System.Collections.Generic;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        private List<LineItem> items = new();
        private readonly List<string> removedItems = new();
        private readonly Guid cartId = Guid.NewGuid();

        public bool IsCheckedOut { get; private set; }

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
            IsCheckedOut = false;
        }

        public void RemoveMatchingItem(string itemName)
        {
            removedItems.Add(itemName);
            List<LineItem> itemsClone = new(items);
            foreach (LineItem item in items)
            {
                if (item.Product.Name == itemName)
                {
                    _ = itemsClone.Remove(item);
                }
            }

            items = itemsClone;
        }

        public List<string> GetRemovedItems()
        {
            return removedItems;
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Cart cart = (Cart)obj;
                return cartId == cart.cartId;
            }
        }

        public override int GetHashCode()
        {
            return cartId.GetHashCode();
        }

        public void CheckOut()
        {
            IsCheckedOut = true;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new();
            foreach (LineItem item in items)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    products.Add(item.Product);
                }
            }

            return products;
        }
    }
}
