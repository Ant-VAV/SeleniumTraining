﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace csharp_example
{
    public class FirefoxTestBase
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        [SetUp]
        public void SetUp()
        {
            Driver = new FirefoxDriver();
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