using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    public class BasicTestForm
    {
        private static IWebDriver _chromeDriver;

        // automatiskai pasileidzia 1 karta PRIES visus testus NEW !!!!
        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            _chromeDriver.Manage().Window.Maximize();
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _chromeDriver.FindElement(By.XPath("//*[@id='at-cv-lightbox-button-holder']/a[2]")).Click();
        }

        [Test]
        public static void EnterMessageTestasWithPageObject()
        {
            string testMessage = "mano pranesimas";

            var page = new BasicFirstFormDemoPage(_chromeDriver);
            page
                .EnterMessage(testMessage).PushShowMessageButton().AssertShownMessage(testMessage);
        }

        [TestCase("testMessage", TestName = "Ivedame reiksme i message lauka, ir spaudziame 'Show Message'")]
        public static void EnterMessageTest(string messageText)
        {
            var tekstoLaukas = _chromeDriver.FindElement(By.Id("user-message"));
            tekstoLaukas.SendKeys(messageText);

            _chromeDriver.FindElement(By.XPath("//*[@id='get-input']/button")).Click();

            var pranesimoParodymas = _chromeDriver.FindElement(By.Id("display"));

            Assert.AreEqual(messageText, pranesimoParodymas.Text, "Tekstas neatitinka to ka ivedziau");
        }

        [TestCase(2, 2, TestName = "Dvieju teigiamu skaiciu suma su PAGE OBJECT")]
        [TestCase(-5, 3, TestName = "Vieno teigiamo, kito neigiamo skaiciu suma SU PAGE OBJECT")]
        public static void TestSumWithPageObject(int a, int b)
        {
            var page = new BasicFirstFormDemoPage(_chromeDriver);
            page.EnterNumbers(a, b);
            page.ClickSumosMygtuka();
            page.PatikrintiRezultata((a+b).ToString());
        }

        [TestCase(2,2, TestName = "Dvieju teigiamu skaiciu suma")]
        [TestCase(-5, 3, TestName = "Vieno teigiamo, kito neigiamo skaiciu suma")]
        public static void TestSum(int a, int b)
        {
            var laukasA = _chromeDriver.FindElement(By.Id("sum1"));
            var laukasB = _chromeDriver.FindElement(By.Id("sum2"));

            laukasA.Clear();
            laukasB.Clear();

            laukasA.SendKeys(a.ToString());
            laukasB.SendKeys(b.ToString());

            _chromeDriver.FindElement(By.CssSelector(".btn:nth-child(3)")).Click();

            var sumosLaukas = _chromeDriver.FindElement(By.Id("displayvalue"));

            Assert.AreEqual((a+b).ToString(), sumosLaukas.Text, "Rodoma skaiciu suma yra neteisinga");
        }

        [TestCase("a", "b", TestName = "Bandome sumuoti raides")]
        public static void TestSumBadNumbers(string a, string b)
        {
            var laukasA = _chromeDriver.FindElement(By.Id("sum1"));
            var laukasB = _chromeDriver.FindElement(By.Id("sum2"));

            laukasA.Clear();
            laukasB.Clear();

            laukasA.SendKeys(a);
            laukasB.SendKeys(b);

            _chromeDriver.FindElement(By.CssSelector(".btn:nth-child(3)")).Click();

            var sumosLaukas = _chromeDriver.FindElement(By.Id("displayvalue"));

            Assert.AreEqual("NaN", sumosLaukas.Text, "Blogas klaidos pranesimas");
        }

        // automatiskai pasileis po visu testu, viena karta !!!
        [OneTimeTearDown]
        public static void CloseDriver()
        {
            _chromeDriver.Quit();
        }
    }
}
