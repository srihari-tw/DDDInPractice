using System;
using System.Collections.Generic;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        private List<LineItem> items = new List<LineItem>();
        private List<string> removedItems = new List<string>();
        private readonly Guid cartId = Guid.NewGuid();
        private bool isCheckedOut = false;

        public bool IsCheckedOut
        {
            get { return isCheckedOut; }
        }
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
            isCheckedOut = false;
        }

        public void RemoveMatchingItem(string itemName)
        {
            removedItems.Add(itemName);
            var itemsClone = new List<LineItem>(items);
            foreach (LineItem item in items)
            {
                if (item.Product.Name == itemName)
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

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
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
            isCheckedOut = true;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            foreach (LineItem item in items)
            {
                products.Add(item.Product);
            }

            return products;
        }
    }
}
