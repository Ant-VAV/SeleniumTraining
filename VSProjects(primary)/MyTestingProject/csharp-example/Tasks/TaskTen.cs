using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38592
    /// </summary>
    public class TaskTen : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.OpenIndexPage();
        }

        [Test]
        public void CheckGood()
        {
            var firstDuck = Driver.ByCSS("#box-campaigns .product:nth-of-type(1)");
            var name = firstDuck.FindElement(By.CssSelector(".name")).Text;
            var regularPrice = firstDuck.FindElement(By.CssSelector(".regular-price")).Text;
            var campaignPrice = firstDuck.FindElement(By.CssSelector(".campaign-price")).Text;

            CheckFontsAndColors(firstDuck.FindElement(By.CssSelector(".price-wrapper")), false);

            firstDuck.Click();

            var firstDuckInside = Driver.ByCSS("#box-product");
            var nameInside = firstDuckInside.FindElement(By.CssSelector(".title")).Text;
            var regularPriceInside = firstDuckInside.FindElement(By.CssSelector(".regular-price")).Text;
            var campaignPriceInside = firstDuckInside.FindElement(By.CssSelector(".campaign-price")).Text;

            CheckFontsAndColors(firstDuckInside.FindElement(By.CssSelector(".price-wrapper")), true);

            Assert.AreEqual(name, nameInside);
            Assert.AreEqual(regularPrice, regularPriceInside);
            Assert.AreEqual(campaignPrice, campaignPriceInside);
        }

        private bool CheckFontsAndColors(IWebElement priceWrapper, bool isInsideOfDuck)
        {
            var regularPrice = priceWrapper.FindElement(By.CssSelector(".regular-price"));
            var sTag = regularPrice.GetAttribute("tagName");
            var grayColor = regularPrice.GetCssValue("color");
            Assert.AreEqual(sTag.ToUpper(), "S");
            var expectedColor = isInsideOfDuck ? "rgba(102, 102, 102, 1)" : "rgba(119, 119, 119, 1)";
            Assert.AreEqual(NormolizeColor(grayColor), NormolizeColor(expectedColor));

            var campaignPrice = priceWrapper.FindElement(By.CssSelector(".campaign-price"));
            var strongTag = campaignPrice.GetAttribute("tagName");
            var redColor = campaignPrice.GetCssValue("color");
            Assert.AreEqual(strongTag.ToUpper(), "STRONG");
            Assert.AreEqual(NormolizeColor(redColor), NormolizeColor("rgba(204, 0, 0, 1)"));
            return true;
        }

        private List<string> NormolizeColor(string color)
        {
            var list = color.Remove(0, color.IndexOf('('))
                .Replace("(", "")
                .Replace(")", "")
                .Replace(" ", "")
                .Split(',')
                .ToList();
            list.RemoveAll(x => list.IndexOf(x) > 2);
            return list;
        }
    }
}