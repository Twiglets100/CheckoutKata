using CheckoutKata.Models;
using NUnit.Framework;

namespace CheckoutKata.Test
{
    [TestFixture]
    public class CheckoutTests
    {
        [Test]
        public void WhenProductAIsAdded_GetTotalReturns50()
        {
            ICheckout checkout = new Checkout(new FileLoader());
            var totalPrice = 0;

            checkout.Scan("A");
            totalPrice = checkout.GetTotalPrice();
            
            Assert.AreEqual(50,totalPrice);
        }
    }
}