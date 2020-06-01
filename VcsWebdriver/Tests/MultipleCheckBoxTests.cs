using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class MultipleCheckBoxTests
    {
        private static MultipleCheckBoxPage _page;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _page = new MultipleCheckBoxPage(driver);
        }

        [Test]
        public static void TestFirstCheckBoxExactWait()
        {
            _page
                .CheckSingleCheckBox()
                .AssertSingleCheckBoxSuccessMessage()
                .UncheckSingleCheckBox();
        }

        [Test]
        public static void TestFirstCheckBoxExplicitWait()
        {
            _page
                .CheckSingleCheckBox()
                .AssertSingleCheckBoxSuccessMessageWithWait()
                .UncheckSingleCheckBox();
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _page.CloseBrowser();
        }
    }
}
