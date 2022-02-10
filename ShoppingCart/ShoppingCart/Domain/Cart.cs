using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Domain.Events;
using ShoppingCart.Exceptions;

namespace ShoppingCart.Domain
{
    public class Cart
    {
        private List<IDomainEvent> events = new();
        private List<LineItem> items = new();
        private readonly Guid cartId = Guid.NewGuid();

        public bool IsCheckedOut { get; private set; }

        public int ItemCount
        {
            get
            {
                return items.Sum(item => item.Quantity);
            }
        }

        public void AddItem(LineItem item)
        {
            if (item == null)
            {
                throw new InvalidItemException("Invalid item");
            }

            ItemAddedEvent itemAddedEvent = new(item.Product, item.Quantity);
            Apply(itemAddedEvent);
        }

        private void Apply(ItemAddedEvent itemAddedEvent)
        {
            events.Add(itemAddedEvent);
            items.Add(new LineItem(itemAddedEvent.Product, itemAddedEvent.Quantity));
            IsCheckedOut = false;
        }

        public void RemoveMatchingItem(string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                throw new InvalidItemException("Invalid item");
            }

            ItemRemovedEvent itemRemovedEvent = new(itemName);
            Apply(itemRemovedEvent);
        }

        private void Apply(ItemRemovedEvent itemRemovedEvent)
        {
            events.Add(itemRemovedEvent);


            List<LineItem> itemsClone = new(items);
            foreach (LineItem item in items)
            {
                if (item.Product.Name == itemRemovedEvent.ItemName)
                {
                    _ = itemsClone.Remove(item);
                }
            }

            items = itemsClone;
        }

        public List<string> GetRemovedItems()
        {
            List<ItemRemovedEvent> itemRemovedEvents
                = events
                    .FindAll(item => item is ItemRemovedEvent)
                    .ConvertAll(domainEvent => domainEvent as ItemRemovedEvent);

            return itemRemovedEvents.ConvertAll<string>(itemRemovedEvent => itemRemovedEvent.ItemName);
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
