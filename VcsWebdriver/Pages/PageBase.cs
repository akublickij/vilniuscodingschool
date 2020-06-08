﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class PageBase
    {
        protected static IWebDriver Driver;

        public PageBase(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }

        public WebDriverWait GetWait(int seconds = 5)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }

        public DefaultWait<IWebDriver> GetFluentWait()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(Driver);

            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            return fluentWait;
        }

    }
}
