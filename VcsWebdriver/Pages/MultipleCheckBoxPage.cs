using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class MultipleCheckBoxPage : PageBase
    {
        private IWebElement _singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));
        private const string SingleCheckBoxMessageText = "Success - Check box is checked";

        public MultipleCheckBoxPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }

        public MultipleCheckBoxPage CheckSingleCheckBox()
        {
            if (!_singleCheckBox.Selected)
                _singleCheckBox.Click();

            return this;
        }

        public MultipleCheckBoxPage UncheckSingleCheckBox()
        {
            if (_singleCheckBox.Selected)
                _singleCheckBox.Click();

            return this;
        }

        public MultipleCheckBoxPage AssertSingleCheckBoxSuccessMessage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.AreEqual(SingleCheckBoxMessageText, _singleCheckBoxMessage.Text, "Bad single checkbox section message");
            return this;
        }

        public MultipleCheckBoxPage AssertSingleCheckBoxSuccessMessageWithWait()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElement(_singleCheckBoxMessage, SingleCheckBoxMessageText));

            Assert.AreEqual(SingleCheckBoxMessageText, _singleCheckBoxMessage.Text, "Bad single checkbox section message");
            return this;
        }

        
    }
}
