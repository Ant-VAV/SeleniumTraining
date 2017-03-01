using System;
using MyTestingProject.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38607
    /// </summary>
    public class TaskNineteen : TestBase
    {
        [Test]
        public void BuyOrNot()
        {
            for (int i = 0; i < 3; i++)
            {
                App.AddFirstMostpopularDuckToCart(i);
            }

            App.GoToCart();

            for (int i = 2; i >= 0; i--)
            {
                App.DeleteDuck(i);
            }

            var warning = "There are no items in your cart.";
            App.WaitWarningMessage(warning);
        }

    }
}