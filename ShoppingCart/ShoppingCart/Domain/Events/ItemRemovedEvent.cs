namespace ShoppingCart.Domain.Events
{
    public class ItemRemovedEvent : IDomainEvent
    {
        public string ItemName { get; private set; }

        public ItemRemovedEvent(string itemName)
        {
            ItemName = itemName;
        }
    }
}
