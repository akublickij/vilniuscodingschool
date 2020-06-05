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

        public static IWebDriver GetChromeIncognitoDriver()
        {
            return GetDriver(Browser.ChromeIncognito);
        }

        public static IWebDriver GetFireFoxDriver()
        {
            return GetDriver(Browser.FireFox);
        }

        public static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("incognito");


            return new ChromeDriver(options);
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
                    webDriver = GetChromeWithOptions();
                    break;
                case Browser.ChromeIncognito:
                    webDriver = GetCustomChrome();
                    break;
                case Browser.Explorer:
                    webDriver = new InternetExplorerDriver();
                    break;
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return webDriver;
        }

        private static ChromeDriver GetCustomChrome( )
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--incognito");
            
            var chrome = new ChromeDriver(chromeOptions);
            
            return chrome;
        }
    }
}
