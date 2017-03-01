using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject.PageObjects
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-most-popular .product:nth-of-type(1)")]
        private IWebElement FirstMostpopularDuckLink;

        public void GoToFirstMostpopularDuck()
        {
            FirstMostpopularDuckLink.Click();
        }
    }
}
