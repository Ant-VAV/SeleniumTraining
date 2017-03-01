using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyTestingProject.PageObjects
{
    public class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {
            Driver.Url = @"http://localhost/litecart/en/checkout";
        }

        [FindsBy(How = How.CssSelector, Using = @"button[name=""remove_cart_item""]")]
        private IWebElement RemoveGooditemButton;

        [FindsBy(How = How.CssSelector, Using = "#checkout-cart-wrapper em")]
        private IWebElement WarningMessage;

        public void DeleteGooditemFromCart(int numberOfRemainItems)
        {
            RemoveGooditemButton.Click();
            if (numberOfRemainItems==0)
                WaitLastGooditemDeleted();
            else
                WaitExpectedCountOfGooditems(numberOfRemainItems);
        }
        protected void WaitExpectedCountOfGooditems(int numberOfRemainingRows)
        {
            Wait.Until(d => (d.FindElements(By.CssSelector("#order_confirmation-wrapper td.item")).Count == numberOfRemainingRows));
        }

        protected void WaitLastGooditemDeleted()
        {
            Wait.Until(d => (d.IsElementPresent("#order_confirmation-wrapper td.item") == false));
        }

        public void WaitWarningMessage(string warning)
        {
            Wait.Until(d => d.FindElement(By.CssSelector("#checkout-cart-wrapper em")).Text == warning);
        }
    }
}
