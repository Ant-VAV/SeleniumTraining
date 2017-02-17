using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38591
    /// </summary>
    public class TaskNine : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.LoginToAdmintools();
        }

        [Test]
        public void CheckCountries()
        {
            Driver.Url = @"http://localhost/litecart/admin/?app=countries&doc=countries";
            var allRows = Driver.ByCSSAll(".dataTable .row");

            var listOfCountries = new List<string>();
            var listOfCountryWZones = new List<string>();
            foreach (var row in allRows)
            {
                var link = row.FindElement(By.CssSelector("td:nth-of-type(5) a"));
                listOfCountries.Add(link.Text);
                var zonesCount = Convert.ToInt32(row.FindElement(By.CssSelector("td:nth-of-type(6)")).Text);
                if (zonesCount > 0) listOfCountryWZones.Add(link.Text);
            }
            CheckAlphabetOrder(listOfCountries);

            CheckZonesForListOfCountries(listOfCountryWZones, @"#table-zones td:nth-of-type(3) [type=""hidden""]");
        }

        [Test]
        public void CheckGeoZones()
        {
            Driver.Url = @"http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            var allRows = Driver.ByCSSAll(".dataTable td:nth-of-type(3)");

            var listOfCountries = new List<string>();
            foreach (var row in allRows)
            {
                var text = row.Text;
                listOfCountries.Add(text);
            }

            CheckZonesForListOfCountries(listOfCountries, "#table-zones td:nth-of-type(3) option[selected=selected]");
        }

        private void CheckZonesForListOfCountries(List<string> listOfCountries, string locatorOfCountry)
        {
            foreach (var country in listOfCountries)
            {
                var listOfZones = new List<string>();
                Driver.FindElement(By.LinkText(country)).Click();
                var allZoneRows = Driver.ByCSSAll(locatorOfCountry);
                foreach (var zoneRow in allZoneRows)
                {
                    var zone = zoneRow.Text;
                    listOfZones.Add(zone);
                }
                CheckAlphabetOrder(listOfZones);
                Driver.ByCSS("button[name=cancel]").Click();
            }
        }

        private void CheckAlphabetOrder(List<string> countries)
        {
            var listToSort = new List<string>(countries);
            listToSort.Sort();
            Assert.True(countries.SequenceEqual(listToSort));
        }
    }
}