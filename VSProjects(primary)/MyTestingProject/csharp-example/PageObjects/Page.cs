using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject.PageObjects
{
    public class Page
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public Page(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#cart .quantity")]
        private IWebElement CartQuantityLink;

        [FindsBy(How = How.CssSelector, Using = "#cart .link")]
        private IWebElement CheckoutLink;

        [FindsBy(How = How.CssSelector, Using = "#logotype-wrapper")]
        private IWebElement ShopLogotype;

        protected void WaitNewItemsInCart(int itemsCount)
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("#cart .quantity"), itemsCount.ToString()));
        }

        public void BackToMainPage()
        {
            ShopLogotype.Click();
        }

        public void OpenCart()
        {
            CheckoutLink.Click();
        }
    }
}
