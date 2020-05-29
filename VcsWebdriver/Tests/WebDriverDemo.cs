using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VcsWebdriver.Tests
{
    public class WebDriverDemo
    {
        private static IWebDriver _driver;

        [Test]
        public static void TryChrome()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://login.yahoo.com/";
        }

        [Test]
        public static void TryFireFox()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "https://login.yahoo.com/";

            //IWebElement pamirsauVarda = _driver.FindElement(By.LinkText("Pamiršote naudotojo vardą?"))
            //pamirsauVarda.Click();

            IWebElement prisijungimoVardasPagalId = _driver.FindElement(By.Id("login-username"));
            IWebElement prisijungimoVardas = _driver.FindElement(By.Name("username"));
            IWebElement prisijungimoVardasPagalClassname = _driver.FindElement(By.ClassName("phone-no"));
            IWebElement prisijungimoVardasPagalXpath = _driver.FindElement(By.XPath("//*[@id='login-username']"));

            //prisijungimoVardas.SendKeys("TEST");
            Thread.Sleep(5000);
        }

        [Test]
        public static void TestMessage()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

           
            var inputField = _driver.FindElement(By.Id("user-message"));

            var messageText = "testmessage";
            inputField.SendKeys(messageText);

            _driver.FindElement(By.XPath("//*[@id='get-input']/button")).Click();

            var displayMessageLabel = _driver.FindElement(By.Id("display"));

            Assert.AreEqual(messageText, displayMessageLabel.Text, "text does not match");
        }

        [TearDown]
        public static void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
