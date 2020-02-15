using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordVerifier.Test
{
    [TestClass]
    public class PasswordVerifierTest
    {
        [TestMethod]
        [DataRow("12345678", false)]
        [DataRow("123456789", true)]
        public void MustBeLargerThan8Chars(string password, bool expected)
        {
            Assert.AreEqual(PasswordVerifier.Verify(password), expected);
        }

        [TestMethod]
        [DataRow(null, false)]
        public void MustNotBeNull(string password, bool expected)
        {
            Assert.AreEqual(PasswordVerifier.Verify(password), expected);
        }
    }
}
