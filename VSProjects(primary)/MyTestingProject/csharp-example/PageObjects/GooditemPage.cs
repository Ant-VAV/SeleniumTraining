using MyTestingProject.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MyTestingProject.PageObjects
{
    internal class GooditemPage : Page
    {
        public GooditemPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = @"button[name=""add_cart_product""]")]
        private IWebElement AddToCartButton;

        [FindsBy(How = How.CssSelector, Using = @"select[name=""options[Size]""]")]
        private IWebElement SizeSelector;

        public bool HasSizeSelector()
        {
            return SizeSelector.IsElementPresent();
        }

        public void SelectNthElement(int index)
        {
            SizeSelector.Click();
            Driver.ClickElement($@"select[name=""options[Size]""] option:nth-of-type({index+1})");
        }

        public void AddGooditemToCart(int numberOfItem)
        {
            AddToCartButton.Click();
            WaitNewItemsInCart(numberOfItem);
        }
    }
}
