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
            Assert.AreEqual(new NoLongerThanVerifier(8).Verify(password), expected);
        }

        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", true)]
        public void MustNotBeNull(string password, bool expected)
        {
            Assert.AreEqual(new NotNullVerifier().Verify(password), expected);
        }

        [TestMethod]
        [DataRow("123kjh", false)]
        [DataRow("123kj33hffgfg", false)]
        [DataRow("A123kjh", true)]
        [DataRow("123fgfA", true)]
        [DataRow("12A3fRgfg", true)]
        [DataRow("qwertY", true)]
        public void AtLeastOneUpperCase(string password, bool expected)
        {
            Assert.AreEqual(new AtLeastOneUpperCaseVerifier().Verify(password), expected);
        }

        [TestMethod]
        [DataRow("A", false)]
        [DataRow("1A", false)]
        [DataRow("1A1", false)]
        [DataRow("AaA", true)]
        [DataRow("1w1", true)]
        [DataRow("1Ww", true)]
        [DataRow("w", true)]
        public void AtLeastOneLowerCase(string password, bool expected)
        {
            Assert.AreEqual(new AtLeastOneLowerCaseVerifier().Verify(password), expected);
        }

        [TestMethod]
        [DataRow("", false)]
        [DataRow("abc", false)]
        [DataRow("abc,./", false)]
        [DataRow("0", true)]
        [DataRow("0a", true)]
        [DataRow("a0a", true)]
        public void AtLeastOneNumber(string password, bool expected)
        {
            Assert.AreEqual(new AtLeastOneNumberVerifier().Verify(password), expected);
        }

        [TestMethod]
        [DataRow(null, false)]
        [DataRow("", true)]
        public void PasswordVerifier_CanUseOneVerifier(string password, bool expected)
        {
            Assert.AreEqual(
                new PasswordVerifier(
                    new CombineVerifiers(
                        new IVerifier[] { new NotNullVerifier() }
                    )
                ).Verify(password),
                expected
            );
        }

        [TestMethod]
        [DataRow("12345678", false)]
        [DataRow(null, false)]
        [DataRow("123kjh", false)]
        [DataRow("123kj33hffgfg", false)]
        [DataRow("A", false)]
        [DataRow("1A", false)]
        [DataRow("1A1", false)]
        [DataRow("", false)]
        [DataRow("abc", false)]
        [DataRow("abc,./", false)]
        [DataRow("1aA456789", true)]
        [DataRow("12345AAAa", true)]
        public void PasswordVerifier_CanUseManyVerifiers(string password, bool expected)
        {
            Assert.AreEqual(
                new PasswordVerifier(
                    new CombineVerifiers(
                        new IVerifier[] {
                            new NoLongerThanVerifier(8),
                            new NotNullVerifier(),
                            new AtLeastOneLowerCaseVerifier(),
                            new AtLeastOneUpperCaseVerifier(),
                            new AtLeastOneNumberVerifier()
                        }
                    )
                ).Verify(password),
                expected
            );
        }




    }
}
