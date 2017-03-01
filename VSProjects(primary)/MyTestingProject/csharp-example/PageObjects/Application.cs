using OpenQA.Selenium;

namespace MyTestingProject.PageObjects
{
    public class Application
    {
        private readonly CartPage CartPage;
        private readonly GooditemPage GooditemPage;
        private readonly MainPage MainPage;

        private readonly Page Page;
        private IWebDriver driver;

        public Application(IWebDriver Driver)
        {
            driver = Driver;
            Page = new Page(Driver);
            MainPage = new MainPage(Driver);
            GooditemPage = new GooditemPage(Driver);
            CartPage = new CartPage(Driver);
        }

        public void AddFirstMostpopularDuckToCart(int indexOfAddableDuck)
        {
            MainPage.GoToFirstMostpopularDuck();
            if (GooditemPage.HasSizeSelector())
                GooditemPage.SelectNthElement(1);

            GooditemPage.AddGooditemToCart(indexOfAddableDuck + 1);
            GooditemPage.BackToMainPage();
        }

        public void GoToCart()
        {
            Page.OpenCart();
        }

        public void DeleteDuck(int numberOfRemainingDucks)
        {
            CartPage.DeleteGooditemFromCart(numberOfRemainingDucks);
        }

        public void WaitWarningMessage(string expactedMessage)
        {
            CartPage.WaitWarningMessage(expactedMessage);
        }
    }
}