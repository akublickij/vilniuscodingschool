using NUnit.Framework;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    public class SenukaiLoginTest
    {
        private static SenukaiLoginPage _senukaiLoginPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = CustomDrivers.GetChromeDriver();

            _senukaiLoginPage = new SenukaiLoginPage(driver);
        }

        [Test]
        public static void TestFirstCheckBoxExactWait()
        {
            _senukaiLoginPage
                .GoToLoginPage()
                .AcceptSelectedCookies()
                .PerformLogin("user", "pwd");
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _senukaiLoginPage.CloseBrowser();
        }
    }
}
