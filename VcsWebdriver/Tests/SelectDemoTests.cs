using System;
using NUnit.Framework;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class SelectDemoTests
    {
        private static SelectDemoPage _demoPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = CustomDrivers.GetChromeDriver();
            _demoPage = new SelectDemoPage(driver);
        }

        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Friday)]
        public static void TestFirstCheckBoxExactWait(DayOfWeek testDay)
        {
            _demoPage.SelectDay(testDay).AssertSelectedDay(testDay);
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _demoPage.CloseBrowser();
        }

    }
}
