using CheckoutKata.Interfaces;
using CheckoutKata.Logic;
using NUnit.Framework;

namespace CheckoutKata.Test
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase("A",50)]
        [TestCase("B",30)]
        public void WhenProductIsAdded_GetTotalReturnsItemTypePrice(string item, int expectedResult)
        {
            ICheckout checkout = new Checkout(new FileLoader());
            var totalPrice = 0;

            checkout.Scan(item);
            totalPrice = checkout.GetTotalPrice();
            
            Assert.AreEqual(expectedResult,totalPrice);
        }
    }
}