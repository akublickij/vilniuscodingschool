using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VcsWebdriver.Tests
{
    public class BasicCheckBoxDemo
    {
        private static IWebDriver _chromeDriver;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            
            _chromeDriver.Manage().Window.Maximize();
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            if (Exists(By.XPath("//*[@id='at-cv-lightbox-button-holder']/a[2]")))
                _chromeDriver.FindElement(By.XPath("//*[@id='at-cv-lightbox-button-holder']/a[2]")).Click();
        }

        private static bool Exists(By by)
        {
            if (_chromeDriver.FindElements(by).Count > 0)
            {
                return true;
            }

            return false;
        }

        [Order(1)]
        [TestCase(TestName = "Pazymime 'Click on this check box'")]
        public static void CheckSuccessMessage()
        {
            var element = _chromeDriver.FindElement(By.Id("isAgeSelected"));
            element.Click();

            var pranesimas = _chromeDriver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", pranesimas.Text,
                "Pazymejome varnele, pranesimas neteisingas");

            element.Click();
        }

        [Order(2)]
        [TestCase(TestName = "Pazymime visas varneles, patikriname kad mygtukas pakeicia pavadinima")]
        public static void CheckAllboxes()
        {
            var elements = _chromeDriver.FindElements(By.ClassName("cb1-element"));
            foreach (var element in elements)
            {
                element.Click();
            }

            var mygtukoPavadinimas = _chromeDriver.FindElement(By.Id("check1")).GetAttribute("value");
            Assert.AreEqual("Uncheck All", mygtukoPavadinimas, "Tekstas neatitinka to ka ivedziau");
        }

        [Order(3)]
        [TestCase(TestName = "Spaudziame 'Uncheck All' mygtuka")]
        public static void TryUncheckButton()
        {
            _chromeDriver.FindElement(By.Id("check1")).Click();

            var elements = _chromeDriver.FindElements(By.CssSelector("input[class='cb1-element']"));
            foreach (var element in elements)
            {
                Assert.AreEqual(false, element.Selected, "Viena is varneliu vis tiek pazymeta");
            }
        }


        [OneTimeTearDown]
        public static void CloseDriver()
        {
            _chromeDriver.Quit();
        }
    }
}
