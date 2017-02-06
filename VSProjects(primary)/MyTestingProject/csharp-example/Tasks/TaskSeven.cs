using NUnit.Framework;

namespace MyTestingProject
{
    /// <summary>
    ///     Задание http://software-testing.ru/lms/mod/assign/view.php?id=38588
    /// </summary>
    public class TaskSeven : ChromeTestBase
    {
        public override void SetUp()
        {
            base.SetUp();
            Driver.LoginToAdmintools();
        }

        [Test]
        public void FindThemAll()
        {
            var i = 1;
            while (IsLinkExist(i))
            {
                var j = 1;
                Driver.ByCSS($"#app-:nth-of-type({i})").Click();
                var hasSublinks = false;
                while (IsSublinkExist(j))
                {
                    hasSublinks = true;
                    Driver.ByCSS($"ul.docs li:nth-of-type({j})").Click();
                    Assert.True(HeaderIsPresent());
                    j++;
                }
                if (!hasSublinks) Assert.True(HeaderIsPresent());
                i++;
            }
        }

        private bool IsLinkExist(int i)
        {
            return Driver.IsElementPresent($"#app-:nth-of-type({i})");
        }

        private bool IsSublinkExist(int j)
        {
            return Driver.IsElementPresent($"ul.docs li:nth-of-type({j})");
        }

        private bool HeaderIsPresent()
        {
            return Driver.IsElementPresent("#content h1");
        }
    }
}