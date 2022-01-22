using System;
using System.Collections.Generic;
using ShoppingCart.Domain.Services;
using ShoppingCart.Domain;
using Xunit;

namespace ShoppingCart.Tests
{
    public class DiscountServiceTests
    {
        [Fact]
        public void ShouldApplyDiscountAtTenPercentLessThanCompetitors()
        {
            DiscountService discountService = new DiscountService();
            Product appleIPadPro = new Product("iPad Pro", discountService.GetDiscountedPrice("iPad Pro", new Price(50000, Currency.INR)));
            Assert.True(45000.00 == appleIPadPro.Price.Denomination);
        }
    }
}
