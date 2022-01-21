using System;

namespace ShoppingCart.Domain
{
    public class LineItem
    {
        private readonly string itemName;
        private readonly int quantity = 1;

        public LineItem(string itemName)
        {
            this.itemName = itemName;
        }

        public LineItem(string itemName, int quantity)
        {
            this.itemName = itemName;
            this.quantity = quantity;           
        }

        public string ItemName {
            get { return itemName; }
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                LineItem item = (LineItem)obj;
                return itemName == item.itemName;
            }
        }

        public override int GetHashCode()
        {
            return itemName.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Item(ItemName:{0})", itemName);
        }
    }
}
