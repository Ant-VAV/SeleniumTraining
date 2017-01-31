using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class IETestBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        [SetUp]
        public void SetUp()
        {
            Driver = new InternetExplorerDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}