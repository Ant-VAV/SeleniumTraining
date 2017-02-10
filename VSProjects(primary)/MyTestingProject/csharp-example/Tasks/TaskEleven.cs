using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38594
    /// </summary>
    public class TaskEleven : ChromeTestBase
    {
        private const string FirstName = "Name";
        private const string LastName = "Last name";
        private const string Address = "address";
        private const string Postcode = "11111";
        private const string City = "city";
        private const string Country = "United States";
        private static readonly string Email = DateTime.UtcNow.Ticks + "@ay.ru";
        private const string Phone = "+19090000000";
        private const string Pass = "pass";

        public override void SetUp()
        {
            base.SetUp();
            Driver.OpenIndexPage();
        }

        [Test]
        public void NewUserCreation()
        {
            Driver.ByCSS(@"form[name=""login_form""] tr:nth-of-type(5) a").Click();
            MakeBoringInput();
            Driver.ByCSS("#navigation .list-vertical li:nth-of-type(4) a").Click();
            Login();
            Driver.ByCSS(@"button[type=""submit""]").Click();
            Driver.ByCSS(".list-vertical li:nth-of-type(4)").Click();
        }

        private void MakeBoringInput()
        {
            Func<string, string> input = x => $@"input[name=""{x}""]";

            Driver.ByCSS(input("firstname")).SendKeys(FirstName);
            Driver.ByCSS(input("lastname")).SendKeys(LastName);
            Driver.ByCSS(input("address1")).SendKeys(Address);
            Driver.ByCSS(input("postcode")).SendKeys(Postcode);
            Driver.ByCSS(input("city")).SendKeys(City);
            Driver.ByCSS(input("email")).SendKeys(Email);
            Driver.ByCSS(input("phone")).SendKeys(Phone);
            Driver.ByCSS(input("password")).SendKeys(Pass);
            Driver.ByCSS(input("confirmed_password")).SendKeys(Pass);

            Driver.ByCSS(".select2-selection").Click();
            Driver.ByCSS(".select2-search__field").SendKeys(Country + Keys.Enter);

            Driver.ByCSS(@"[type=""submit""]").Click();
        }

        private void Login()
        {
            var emailInput = Driver.ByCSS(@"input[name=""email""]");
            emailInput.Clear();
            emailInput.SendKeys(Email);
            var passwordInput = Driver.ByCSS(@"input[name=""password""]");
            passwordInput.Clear();
            passwordInput.SendKeys(Pass);
        }
    }
}