using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38604
    /// </summary>
    public class TaskSeventeen : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.LoginToAdmintools();
        }

        [Test]
        public void BrowserLogs()
        {
            Driver.Url = @"http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";

            var allDuckLinks = Driver.ByCSSAll(@".dataTable td:nth-of-type(3) img + a");
            foreach (var link in allDuckLinks)
                MagickWithWindows(link.GetAttribute("href"));
        }

        private void MagickWithWindows(string url)
        {
            var previousWindow = Driver.OpenEmptyWindow();

            Driver.Url = url;
            Driver.WaitForElement("#content h1"); // ждём догрузки страницы

            var browserLogs = Driver.Manage().Logs.GetLog("browser");
            Assert.AreEqual(0, browserLogs.Count);

            Driver.GoBackToWindow(previousWindow);
        }
    }
}