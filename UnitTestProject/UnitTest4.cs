using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR26.Pages;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest4
    {
        #region пустые значения 1-2
        [TestMethod]
        public void RegistrationTestSuccess1()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("","","", "Cashier"));//пустые значения      
        }

        [TestMethod]
        public void RegistrationTestSuccess2()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("  ", "", "", "Cashier"));//пустые значения      
        }
        #endregion

        #region Логин занят 3
        [TestMethod]
        public void RegistrationTestSuccess3()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root1", "   ", "   ", "Cashier")); // Логин занят
        }
        #endregion

        #region Неверный пароль 4-8
        [TestMethod]
        public void RegistrationTestSuccess4()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root555", "qw", "qw", "Cashier"));// маленький пароль
        }

        [TestMethod]
        public void RegistrationTestSuccess5()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root555", "йцукен", "йцукен", "Cashier"));// русские буквы
        }

        [TestMethod]
        public void RegistrationTestSuccess6()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root555", "qwerty", "qwerty", "Cashier"));// нет спец символа
        }

        [TestMethod]
        public void RegistrationTestSuccess7()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root555", "qwerty!", "qwerty!", "Cashier"));// нет цифры
        }

        [TestMethod]
        public void RegistrationTestSuccess8()
        {
            var page = new Registration();
            Assert.IsFalse(page.Reg("root555", "qwerty1!ww", "qwerty1!", "Cashier"));// пароли не совпали
        }
        #endregion

        #region успешная регистрация пользователя 9-11
        [TestMethod]
        public void RegistrationTestSuccess9()
        {
            var page = new Registration();
            Assert.IsTrue(page.Reg("root555", "qwerty1!", "qwerty1!", "Cashier"));// регистрация кассира пройдена
        }

        [TestMethod]
        public void RegistrationTestSuccess10()
        {
            var page = new Registration();
            Assert.IsTrue(page.Reg("root556", "qwerty1!", "qwerty1!", "Admin"));// регистрация админа пройдена
        }

        [TestMethod]
        public void RegistrationTestSuccess11()
        {
            var page = new Registration();
            Assert.IsTrue(page.Reg("root557", "qwerty1!", "qwerty1!", "Accountant"));// регистрация бухгалтера пройдена
        }
        #endregion
    }
}
