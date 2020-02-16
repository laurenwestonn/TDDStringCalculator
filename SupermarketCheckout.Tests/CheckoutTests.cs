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
            c.Total = 15;
        }
    }
}
