using System;
using NUnit.Framework;
using OpenQA.Selenium;


namespace VcsWebdriver.Pages
{
    public class AlertPage : PageBase
    {
        // elementai
        private static IWebElement AlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private static IWebElement Confirmation => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private static IWebElement PromptButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));
        private static IWebElement EnteredTextLabel => Driver.FindElement(By.Id("prompt-demo"));



        // konstruktorius
        public AlertPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public AlertPage GotoPage()
        {
            Driver.Url = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
            return this;
        }

        public AlertPage ClickAlert()
        {
            AlertButton.Click();
            return this;
        }

        public AlertPage ClickConfirmationButton()
        {
            Confirmation.Click();
            return this;
        }

        public AlertPage ClickPromptButton()
        {
            PromptButton.Click();
            return this;
        }

        public AlertPage AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();

            Console.WriteLine($"Alert says {alert.Text}");

            alert.Accept();
            return this;
        }

        public AlertPage DismissAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();

            Console.WriteLine($"Alert says {alert.Text}");

            alert.Dismiss();
            return this;
        }

        public AlertPage AcceptAlertWithText(string textToEnter)
        {
            var alert = Driver.SwitchTo().Alert();
            Console.WriteLine($"Alert says {alert.Text}");

            alert.SendKeys(textToEnter);

            alert.Accept();
            return this;
        }

        public AlertPage CheckEnteredText(string enteredText)
        {
            Assert.That(EnteredTextLabel.Text.Contains(enteredText));
            return this;
        }

        
    }
}
