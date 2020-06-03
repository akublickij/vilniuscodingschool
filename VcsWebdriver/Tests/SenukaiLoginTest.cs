using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;
using ScreenCapture = VcsWebdriver.Drivers.ScreenCapture;

namespace VcsWebdriver.Tests
{
    public class SenukaiLoginTest
    {
        private static IWebDriver _driver;
        private static SenukaiLoginPage _senukaiLoginPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _driver = CustomDrivers.GetChromeDriver();

            _senukaiLoginPage = new SenukaiLoginPage(_driver);
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
            if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
                ScreenCapture.Shot(_driver);

            _senukaiLoginPage.CloseBrowser();
        }
    }
}
