using System;
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

        [Test]
        public void WhenInvalidProductIsScanned_ThrowArgumentOutOfRangeException()
        {
            ICheckout checkout = new Checkout(new FileLoader());
            
            Assert.Throws<ArgumentOutOfRangeException>(() => checkout.Scan("invalidItem"));
        }

        [Test]
        public void WhenTwoDifferentProductsAreScanned_GetTotalPriceReturnsTheSumOfTheirPrice()
        {
            ICheckout checkout = new Checkout(new FileLoader());
            var totalPrice = 0;
            
            checkout.Scan("A");
            checkout.Scan("B");
            totalPrice = checkout.GetTotalPrice();
            
            Assert.AreEqual(80, totalPrice);
        }

        [Test]
        public void WhenThreeProductAsAreScanned_GetTotalPriceReturnsOfferPrice()
        {
            ICheckout checkout = new Checkout(new FileLoader());
            var totalPrice = 0;
            
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            totalPrice = checkout.GetTotalPrice();
            
            Assert.AreEqual(130, totalPrice);
        }
        
        [Test]
        public void WhenFourProductAsAreScanned_GetTotalPriceReturnsOfferPriceSummedWithIndividualPrice()
        {
            ICheckout checkout = new Checkout(new FileLoader());
            var totalPrice = 0;
            
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");
            totalPrice = checkout.GetTotalPrice();
            
            Assert.AreEqual(180, totalPrice);
        }
    }
}