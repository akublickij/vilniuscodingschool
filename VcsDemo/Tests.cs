using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VcsDemo
{
    class Tests
    {
        private IWebDriver _webDriver;

        [TestCase("https://www.vilniuscoding.lt/")]
        public void TestChrome(string address)
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(address);
        }

        [TestCase(TestName = "Paleidziam Firefox")]
        public void TestFireFox()
        {
            _webDriver = new FirefoxDriver();
            _webDriver.Navigate().GoToUrl("https://www.vilniuscoding.lt/");
        }

        [TearDown]
        public void CloseBrowser()
        {
            _webDriver.Quit();
        }
    }
}
