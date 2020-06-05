using System;
using NUnit.Framework;
using OpenQA.Selenium;


namespace VcsWebdriver.Pages
{
    public class ModalPage : PageBase
    {
        // elementai
        private static IWebElement ModalButton => Driver.FindElement(By.LinkText("Launch modal"));
        private static IWebElement SaveChangesButton => Driver.FindElement(By.LinkText("Save changes"));

        private static IWebElement ModalButton2 => Driver.FindElement(By.XPath("(//a[contains(text(),'Launch modal')])[2]"));



        // konstruktorius
        public ModalPage(IWebDriver webdriver) : base(webdriver)
        {
            
        }

        public ModalPage GotoPage()
        {
            Driver.Url = "https://www.seleniumeasy.com/test/bootstrap-modal-demo.html";
            return this;
        }

        public ModalPage LaunchModal()
        {
            ModalButton.Click();
            return this;
        }

        public ModalPage LaunchSecondModal()
        {
            ModalButton2.Click();
            return this;
        }

        public ModalPage SaveChanges()
        {
            SaveChangesButton.Click();
            return this;
        }

      
    }
}
