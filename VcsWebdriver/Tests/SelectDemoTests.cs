using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class SelectDemoTests
    {
        private static SelectDemoPage _demoPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _demoPage = new SelectDemoPage(driver);
        }

        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Friday)]
        public static void TestFirstCheckBoxExactWait(DayOfWeek testDay)
        {
            _demoPage
                .SelectByValue(testDay)
                .AssertSelectedDay(testDay);

        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _demoPage.CloseBrowser();
        }

    }
}
