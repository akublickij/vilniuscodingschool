using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class MultipleCheckBoxTests
    {
        private static MultipleCheckBoxPage _page;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = CustomDrivers.GetChromeDriver();
            _page = new MultipleCheckBoxPage(driver);
        }

        [Test]
        public static void SingleCheckBoxTest()
        {
            _page
                .CheckSingleCheckBox()
                .AssertSingleCheckBoxDemoSuccessMessage()
                .UnCheckSingleCheckBox();
        }

        [Test]
        public static void MultipleCheckBoxTest()
        {
            _page.CheckAllMultipleCheckBoxes().AssertButtonName("Uncheck All");
        }

        [Test]
        public static void UncheckMultipleCheckBoxesTest()
        {
            _page
                .CheckAllMultipleCheckBoxes()
                .ClickGroupButton()
                .AssertMultipleCheckBoxesUnchecked();
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _page.CloseBrowser();
        }
    }
}
