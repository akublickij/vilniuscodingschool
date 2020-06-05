using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class SenukaiLoginPage : PageBase
    {
        private IWebElement _elPastas => Driver.FindElement(By.Id("user_email"));
        private IWebElement _slaptazodis => Driver.FindElement(By.Id("user_password"));
        private IWebElement _prisijungtiButton => Driver.FindElement(By.CssSelector(".main-button.button-full-width.button-size-lg"));
        private IWebElement _profileNamePart => Driver.FindElement(By.ClassName("user-block__title--strong"));


        private IWebElement _acceptSelectedCookiesButton => Driver.FindElement(By.CssSelector(".c-button-inverse"));

        public SenukaiLoginPage(IWebDriver webdriver) : base(webdriver) { }

        public SenukaiLoginPage GoToLoginPage()
        {
            Driver.Url = "https://www.senukai.lt/users/sign_in";
            return this;
        }

        public SenukaiLoginPage AddAdvertisingConsentCookies()
        {
            Driver.Manage().Cookies.AddCookie(new Cookie(
                "CookieConsent",
                "{stamp:'uk4yIFiHZoyRtDRuksvHM8U6IIEfg/w+u9NFYELnNZEMMOITyWPlqA=='%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1591301970136%2Cregion:'lt'}",
                "www.senukai.lt", "/", DateTime.Now.AddDays(2)));

            Driver.Navigate().Refresh();

            return this;
        }

        public SenukaiLoginPage AddSessionCookies()
        {
            Driver.Manage().Cookies.AddCookie(new Cookie(
                "remember_user_token",
                "eyJfcmFpbHMiOnsibWVzc2FnZSI6IlcxczJPVEl4T0RkZExDSWtNbUVrTVRFa2EycDFkREpKV0hKdmIzZFlVM0ZHTkdJM2JsbFRaU0lzSWpFMU9URXpNRE00TURRdU9Ea3hOamN3TnlKZCIsImV4cCI6IjIwMjAtMDYtMThUMjA6NTA6MDQuODkxWiIsInB1ciI6ImNvb2tpZS5yZW1lbWJlcl91c2VyX3Rva2VuIn19--5a2eca271d5ce3981789a5b527a91d513123c4d3",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddDays(2)));

            Driver.Navigate().Refresh();

            return this;
        }

        public SenukaiLoginPage AddCookieConsent()
        {
            Cookie myCookie = new Cookie(
                "CookieConsent",
                "value",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddYears(1));

            Driver.Manage().Cookies.AddCookie(myCookie);

            Driver.Navigate().Refresh();

            return this;
        }



        public SenukaiLoginPage ClearAllCookies()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().Refresh();

            return this;
        }

        public SenukaiLoginPage AssertLoggedIn()
        {
            var loggedInProfileNamePart = _profileNamePart.Text;
            Assert.True(loggedInProfileNamePart.Contains("vcs_auto"), "me not logged in");
            return this;
        }

        public SenukaiLoginPage AssertLoggedOut()
        {
            var loggedInProfileNamePart = _profileNamePart.Text;
            Assert.True(loggedInProfileNamePart.Contains("Prisijungti"), "me not logged out");
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
