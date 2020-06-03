using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;
using VcsWebdriver.Tools;

namespace VcsWebdriver.Tests
{
    public class TestBase
    {
        public static IWebDriver _driver;
        public static MultipleCheckBoxPage _multipleCheckBoxes;
        public static SelectDemoPage _demoPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _driver = CustomDrivers.GetChromeDriver();

            _multipleCheckBoxes = new MultipleCheckBoxPage(_driver);
            _demoPage = new SelectDemoPage(_driver);
        }

        // vykdomas kaskart po kiekvieno testo
        [TearDown]
        public static void SingleTestTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                // cia mes padarysime screenshota
                MyScreenshot.MakePhoto(_driver);
            }
        }

        // vykdomas viena karta po visu testu
        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
