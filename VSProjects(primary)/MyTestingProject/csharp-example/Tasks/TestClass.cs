using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38582
    /// </summary>
    public class TestClass : ChromeTestBase
    {
        private readonly string namePassword = "admin";
        private readonly string baseUrl = @"http://localhost/litecart/admin/";

        [Test]
        public void LoginToAdmintools()
        {
            Driver.Url = baseUrl;

            var userName = Driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys(namePassword);

            var passwor = Driver.FindElement(By.Name("password"));
            passwor.Clear();
            passwor.SendKeys(namePassword);

            Driver.FindElement(By.CssSelector(".footer button")).Click();
        }
    }
}