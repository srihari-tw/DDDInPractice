using System;
namespace ShoppingCart.Exceptions
{
    public class InvalidItemException: Exception
    {
        public InvalidItemException(string message): base(message)
        {
        }
    }
}
