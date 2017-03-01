using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MyTestingProject.Utils
{
    public static class WebElementExtensions
    {
        public static bool IsElementPresent(this IWebElement element, string cssSelector)
        {
            try
            {
                element.FindElement(By.CssSelector(cssSelector));
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }
    }
}
