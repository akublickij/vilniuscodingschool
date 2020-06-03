using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class SenukaiLoginPage : PageBase
    {
        private IWebElement _elPastas => Driver.FindElement(By.Id("user_email"));
        private IWebElement _slaptazodis => Driver.FindElement(By.Id("user_password"));
        private IWebElement _prisijungtiButton => Driver.FindElement(By.CssSelector(".main-button.button-full-width.button-size-lg"));

        private IWebElement _acceptSelectedCookiesButton => Driver.FindElement(By.CssSelector(".c-button-inverse"));

        public SenukaiLoginPage(IWebDriver webdriver) : base(webdriver) { }

        public SenukaiLoginPage GoToLoginPage()
        {
            Driver.Url = "https://www.senukai.lt/users/sign_in";
            return this;
        }

        public SenukaiLoginPage AcceptSelectedCookies()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(_acceptSelectedCookiesButton));

            _acceptSelectedCookiesButton.Click();
            return this;
        }

        public SenukaiLoginPage PerformLogin(string username, string password)
        {
            _elPastas.Clear();
            _elPastas.SendKeys(username);
            _slaptazodis.Clear();
            _slaptazodis.SendKeys(password);
            _prisijungtiButton.Click();

            return this;
        }

    }

}
