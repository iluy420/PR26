using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR26.Pages;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void AuthTest()
        {
            var page = new Login();
            Assert.IsTrue(page.Auth("root1", "111111"));
            Assert.IsFalse(page.Auth("root2", "12345"));
            Assert.IsFalse(page.Auth("", ""));
            Assert.IsFalse(page.Auth(" ", " "));
        }
    }
}
