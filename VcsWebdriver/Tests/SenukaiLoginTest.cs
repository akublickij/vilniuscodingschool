using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    public class SenukaiLoginTest
    {
        private static SenukaiLoginPage _senukaiLoginPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _senukaiLoginPage = new SenukaiLoginPage(driver);
        }

        [Test]
        public static void TestFirstCheckBoxExactWait()
        {
            _senukaiLoginPage
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
