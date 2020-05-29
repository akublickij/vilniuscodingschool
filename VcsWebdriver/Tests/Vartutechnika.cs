using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VcsWebdriver.Tests
{
    public class Vartutechnika
    {
        private static IWebDriver _chromeDriver;

        // automatiskai pasileidzia 1 karta PRIES visus testus
        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Url = "http://vartutechnika.lt/";

            _chromeDriver.Manage().Window.Maximize();
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _chromeDriver.FindElement(By.Id("cookiescript_reject")).Click();

        }

        [TestCase(2000, 2000, true, false, "665")]
        [TestCase(4000, 2000, true, true, "1006.43")]
        [TestCase(4000, 2000, false, false, "692.35")]
        public static void EnterMessageTest(int plotis, int aukstis, bool automatika, bool montavimas, string expectedResult)
        {
            var width = _chromeDriver.FindElement(By.Id("doors_width"));
            width.Clear();
            width.SendKeys(plotis.ToString());
            var height = _chromeDriver.FindElement(By.Id("doors_height"));
            height.Clear();
            height.SendKeys(aukstis.ToString());

            var automatikaCheckbox = _chromeDriver.FindElement(By.Name("automatika"));
            if (automatikaCheckbox.Selected != automatika)
                automatikaCheckbox.Click();

            var darbaiCheckBox = _chromeDriver.FindElement(By.Id("darbai"));
            if (darbaiCheckBox.Selected != montavimas)
                darbaiCheckBox.Click();

            _chromeDriver.FindElement(By.Id("calc_submit")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));

            var result = _chromeDriver.FindElement(By.Id("calc_result"));

            Assert.IsTrue(result.Text.Contains(expectedResult),
                $"Neteisinga kaina. Tikejomes {expectedResult}, bet gavome \n{result.Text}");
        }
        

        // automatiskai pasileis po visu testu, viena karta !!!
        [OneTimeTearDown]
        public static void CloseDriver()
        {
            _chromeDriver.Quit();
        }
    }
}
