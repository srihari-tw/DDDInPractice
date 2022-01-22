using System;
namespace ShoppingCart.Domain.Services
{
    public class CheckoutService
    {
        public Order CheckOut(Cart cart)
        {
            cart.CheckOut();
            return new Order(cart.GetProducts());
        }
    }
}
