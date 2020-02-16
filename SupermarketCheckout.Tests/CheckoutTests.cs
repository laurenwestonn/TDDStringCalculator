using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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
        [DataRow(new string[] { "A" }, "A", 15, 15)]
        [DataRow(new string[] { "A", "A", "A" }, "A", 10, 30)]
        public void AddingPricingRule_GetsCorrectPrice(string[] items, string itemName, int itemPrice, int expectedPrice)
        {
            Checkout c = new Checkout();

            c.ApplyPricingRules(new Dictionary<string, int>
                {
                    { itemName, itemPrice }
                }
            );
            
            foreach(string item in items)
            {
                c.Scan(item);
            }
            Assert.AreEqual(expectedPrice, c.Total);
        }
    }
}
