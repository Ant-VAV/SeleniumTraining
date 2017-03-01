using MyTestingProject.PageObjects;
using NUnit.Framework;

namespace MyTestingProject
{
    public class TestBase : ChromeTestBase
    {
        protected Application App;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Driver.OpenIndexPage();
            App = new Application(Driver);
        }
    }
}