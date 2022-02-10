namespace ShoppingCart.Domain.Events
{
    public class ItemAddedEvent : IDomainEvent
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public ItemAddedEvent(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
