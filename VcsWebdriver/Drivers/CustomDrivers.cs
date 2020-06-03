using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace VcsWebdriver.Drivers
{
    public static class CustomDrivers
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browser.Chrome);
        }

        public static IWebDriver GetFireFoxDriver()
        {
            return GetDriver(Browser.FireFox);
        }

        private static IWebDriver GetDriver(Browser browserName)
        {
            IWebDriver webDriver = null;

            switch (browserName)
            {
                case Browser.FireFox:
                    webDriver = new FirefoxDriver();
                    break;
                case Browser.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case Browser.Explorer:
                    webDriver = new InternetExplorerDriver();
                    break;
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webDriver;
        }
    }
}
