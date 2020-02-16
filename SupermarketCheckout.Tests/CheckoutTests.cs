using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
