using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38589
    /// </summary>
    public class TaskEight : ChromeTestBase
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
                Assert.True(HasExactlyOneSticker(duck));
        }

        private bool HasExactlyOneSticker(IWebElement duck)
        {
            var stickers = duck.FindElements(By.CssSelector(".sticker"));
            return stickers.Count == 1;
        }
    }
}