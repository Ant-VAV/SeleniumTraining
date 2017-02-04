using System;
using MyTestingProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38589
    /// </summary>
    public class FindTaskTwo : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.OpenIndexPage();
        }

        [Test]
        public void CheckThemAll()
        {
            var allDucks = Driver.ByCSSAll(".product");

            foreach (var duck in allDucks)
            {
                Assert.True(HasExactlyOneSticker(duck));
            }
        }

        private bool HasExactlyOneSticker(IWebElement duck)
        {
            if (duck.IsElementPresent(".new") && duck.IsElementPresent(".sale"))
                return false;
            return duck.IsElementPresent(".sticker");
        }
    }
}