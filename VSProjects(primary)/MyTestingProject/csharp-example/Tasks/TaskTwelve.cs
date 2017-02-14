using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38595
    /// </summary>
    public class TaskTwelve : ChromeTestBase
    {
        private static readonly string DuckName = DateTime.Now.Ticks.ToString();

        public override void SetUp()
        {
            base.SetUp();
            Driver.LoginToAdmintools();
        }

        [Test]
        public void NewDuckCreation()
        {
            Driver.ClickElement(@"#box-apps-menu #app-:nth-of-type(2)");
            Driver.ClickElement(@"a.button:nth-child(2)");
            MakeVeryBoringInput();
            Driver.ClickElement(@"[type=""submit""][name=""save""]");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(DuckName)));
        }

        private void MakeVeryBoringInput()
        {
            Action<string, int> dropDown = (selector, index) =>
            {
                Driver.ClickElement(selector);
                Driver.ClickElement($@"{selector} [value=""{index}""]");
            };

            Driver.ClickElement(@"[name=""status""]");
            Driver.InputValue(@"[name=""name[en]""]", DuckName);
            Driver.InputValue(@"[name=""code""]", "Code");
            Driver.ClickElement(@"[name=""categories[]""][value=""1""]");
            dropDown(@"[name=""default_category_id""]", 1);
            Driver.ClickElement(@"[name=""product_groups[]""][value=""1-3""]");
            Driver.InputValue(@"[name=""quantity""]", "100");
            dropDown(@"[name=""quantity_unit_id""]", 1);

            var picture = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks", "Files", "duck.jpg");
            Driver.InputValue(@"[name=""new_images[]""]", picture);

            Driver.ByCSS(@"[name=""date_valid_from""]").SendKeys("2000-01-01");
            Driver.ByCSS(@"[name=""date_valid_to""]").SendKeys("2020-01-01");

            Driver.ClickElement(@"ul.index li:nth-of-type(2)");
            Driver.WaitForElement(@"[name=""manufacturer_id""]");
            dropDown(@"[name=""manufacturer_id""]", 1);
            Driver.InputValue(@"[name=""keywords""]", "keywords");
            Driver.InputValue(@"[name=""short_description[en]""]", "short description");
            Driver.InputValue(@".trumbowyg-editor", "description");
            Driver.InputValue(@"[name=""head_title[en]""]", "head title");
            Driver.InputValue(@"[name=""meta_description[en]""]", "meta");

            Driver.ClickElement(@"ul.index li:nth-of-type(3)");
            Driver.WaitForElement(@"[name=""sku""]");
            Driver.InputValue(@"[name=""sku""]", "sku");
            Driver.InputValue(@"[name=""gtin""]", "gtin");
            Driver.InputValue(@"[name=""weight""]", "42");
            Driver.InputValue(@"[name=""dim_x""]", "5");
            Driver.InputValue(@"[name=""dim_y""]", "5");
            Driver.InputValue(@"[name=""dim_z""]", "5");
            Driver.InputValue(@"[name=""attributes[en]""]", "attributes");
        }
    }
}