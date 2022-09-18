using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR26.Pages;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void AuthTestSuccess()
        {
            var page = new Login();
            int password = 111111;
            for (int i = 1; i >= 10; i++)
            {
                Assert.IsTrue(page.Auth($"root{i}", Convert.ToString(password++)));
            }
            //Assert.IsTrue(page.Auth("root1", "111111"));
            //Assert.IsTrue(page.Auth("root2", "111112"));
            //Assert.IsTrue(page.Auth("root3", "111113"));
            //Assert.IsTrue(page.Auth("root4", "111114"));
            //Assert.IsTrue(page.Auth("root5", "111115"));
            //Assert.IsTrue(page.Auth("root6", "111116"));
            //Assert.IsTrue(page.Auth("root7", "111117"));
            //Assert.IsTrue(page.Auth("root8", "111118"));
            //Assert.IsTrue(page.Auth("root9", "111119"));
            //Assert.IsTrue(page.Auth("root10", "111120"));
        }
    }
}
