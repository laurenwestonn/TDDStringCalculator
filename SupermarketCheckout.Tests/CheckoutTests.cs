using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SupermarketCheckout.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void ScanningOneItem_AddsToTotal()
        {
            Checkout c = new Checkout();
            c.Scan("A");
            Assert.AreEqual(15, c.Total);
        }
        [TestMethod]
        public void ScanningMultipleItems_AddsToTotal()
        {
            Checkout c = new Checkout();
            c.Scan("A");
            c.Scan("A");
            c.Scan("A");
            Assert.AreEqual(45, c.Total);
        }

        [TestMethod]
        public void AddingPricingRule_GetsCorrectPrice()
        {
            Checkout c = new Checkout();
            Dictionary<string, int> pricingRules = new Dictionary<string, int>
            {
                { "A", 15 }
            };
            c.ApplyPricingRules(pricingRules);
            c.Scan("A");
            Assert.AreEqual(15, c.Total);

            pricingRules = new Dictionary<string, int>
            {
                { "A", 10 }
            };
            c.ApplyPricingRules(pricingRules);
            c.Scan("A");
            Assert.AreEqual(10, c.Total);

        }
    }
}
