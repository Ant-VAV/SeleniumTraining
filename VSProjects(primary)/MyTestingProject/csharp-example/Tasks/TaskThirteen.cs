using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38597
    /// </summary>
    public class TaskThirteen : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.OpenIndexPage();
        }

        [Test]
        public void BuyOrNot()
        {
            for (int i = 0; i < 3; i++)
            {
                AddDuck(i+1);
            }

            Driver.ClickElement("#cart .link");

            for (int i = 2; i > 0; i--)
            {
                DeleteDuck(i);
            }

            Driver.ClickElement(@"button[name=""remove_cart_item""]");

            var warning = "There are no items in your cart.";
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#checkout-cart-wrapper em")).Text == warning);
        }

        private void AddDuck(int numberOfDuck)
        {
            Driver.ClickElement("#box-most-popular .product:nth-of-type(1)");
            var sizeSelector = @"select[name=""options[Size]""]";
            if (Driver.IsElementPresent(sizeSelector)) //for sizable ducks
            {
                Driver.ClickElement(sizeSelector);
                Driver.ClickElement($@"{sizeSelector} option:nth-of-type(2)");
            }

            Driver.ClickElement(@"button[name=""add_cart_product""]");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#cart .quantity"), numberOfDuck.ToString()));

            Driver.ClickElement("#logotype-wrapper");
        }

        private void DeleteDuck(int numberOfRows)
        {
            Driver.ClickElement(@"button[name=""remove_cart_item""]");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>(d.FindElements(By.CssSelector("#order_confirmation-wrapper td.item")).Count == numberOfRows));
        }
    }
}