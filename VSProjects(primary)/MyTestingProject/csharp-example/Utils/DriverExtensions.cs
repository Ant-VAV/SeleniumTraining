using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace MyTestingProject
{
    public static class DriverExtensions
    {
        private static readonly string baseUrl = @"http://localhost/litecart/";
        private static readonly string namePassword = "admin";

        public static void LoginToAdmintools(this IWebDriver driver)
        {
            driver.Url = baseUrl + @"admin/";

            var userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys(namePassword);

            var passwor = driver.FindElement(By.Name("password"));
            passwor.Clear();
            passwor.SendKeys(namePassword);

            driver.FindElement(By.CssSelector(".footer button")).Click();
        }

        public static void OpenIndexPage(this IWebDriver driver)
        {
            driver.Url = baseUrl;
        }

        public static bool IsElementPresent(this IWebDriver driver, string cssSelector)
        {
            try
            {
                driver.FindElement(By.CssSelector(cssSelector));
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public static IWebElement ByCSS(this IWebDriver driver, string cssSelector)
        {
            return driver.FindElement(By.CssSelector(cssSelector));
        }

        public static ReadOnlyCollection<IWebElement> ByCSSAll(this IWebDriver driver, string cssSelector)
        {
            return driver.FindElements(By.CssSelector(cssSelector));
        }
    }
}