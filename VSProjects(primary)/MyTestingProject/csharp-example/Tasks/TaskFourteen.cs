using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38599
    /// </summary>
    public class TaskFourteen : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.LoginToAdmintools();
        }

        [Test]
        public void Windows()
        {
            //Driver.Url = @"http://localhost/litecart/admin/?app=countries&doc=countries";
            Driver.ClickElement("#box-apps-menu #app-:nth-of-type(3)");
            Driver.ClickElement("#content .button");

            var allExternalLinks = Driver.ByCSSAll(@"form[method=""post""] [target=""_blank""]");
            foreach (var link in allExternalLinks)
                MagickWithWindows(link);
        }

        private void MagickWithWindows(IWebElement link)
        {
            var previousWindow = Driver.CurrentWindowHandle;
            link.Click();
            Wait.Until(d => d.WindowHandles.Count > 1);
            var newWindow = Driver.WindowHandles.ToList();
            newWindow.RemoveAt(newWindow.IndexOf(previousWindow));
            Driver.SwitchTo().Window(newWindow[0]);
            Assert.AreNotEqual("Add New Country | My Store", Driver.Title);
            Driver.Close();
            Driver.SwitchTo().Window(previousWindow);
        }
    }
}