using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject
{
    public class FirefoxESRTestBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        [SetUp]
        public void SetUp()
        {
            var options = new FirefoxOptions
            {
                UseLegacyImplementation = true,
                BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox ESR\firefox.exe"
            };
            Driver = new FirefoxDriver(options);
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