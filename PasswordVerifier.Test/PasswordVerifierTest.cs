using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordVerifier.Test
{
    [TestClass]
    public class PasswordVerifierTest
    {
        [TestMethod]
        [DataRow("12345678", false)]
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

        // This new rule makes the test for the first one break
        // 12345678 would pass. Now it would fail as no uppercase letters..
        // We can't test for positives (i.e. if rule met, pw verified)
        // as the verification relies on many rules
        // We can only test for fails (only 6 characters should always fail
        // regardless of other rules)
        // BUT! We can't be sure of which rule failed it.
        // e.g. "dfgb" would break this rule, but the code would actually fail
        // that password based on the first rule, so it wouldn't be a test for this rule
        //
        // The only way I can think of testing this is to test each rule separately
        // by extracting each into separate classes + calling them all within Verify()
        // But this sounds mighty inefficient
        [TestMethod]
        [DataRow("123kjh", false)]
        public void AtLeastOneUpperCase(string password, bool expected)
        {
            Assert.AreEqual(PasswordVerifier.Verify(password), expected);
        }
    }
}
