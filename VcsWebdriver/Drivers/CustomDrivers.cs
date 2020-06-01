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
            return GetDriver("chrome");
        }

        public static IWebDriver GetFireFoxDriver()
        {
            return GetDriver("firefox");
        }

        private static IWebDriver GetDriver(string browserName)
        {
            IWebDriver webDriver = null;

            switch (browserName)
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "explorer":
                    webDriver = new InternetExplorerDriver();
                    break;
            }

            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webDriver;
        }
    }
}
