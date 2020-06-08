using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace VcsWebdriver.Pages
{
    public class AutopliusResultsPage : PageBase
    {
        private IWebElement RezultatuAntraste => Driver.FindElement(By.ClassName("js-search-title"));
        private IWebElement NoDamageCheckBox => Driver.FindElement(By.CssSelector(".has_damaged_id"));
        private IWebElement SearchButton => Driver.FindElement(By.ClassName("search-button"));
        

        private int RezultatuKiekis =>
            Convert.ToInt32(
                Driver.FindElement(By.ClassName("result-count"))
                    .Text
                    .Replace("(", "")
                    .Replace(")", ""));
        
        public AutopliusResultsPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public AutopliusResultsPage PatikrintiRezultatuAntraste(string ieskomasZodis)
        {
            var wait = GetWait(5);
            wait.Until(c => ExpectedConditions.ElementExists(By.ClassName("js-search-title")));

            Assert.True(RezultatuAntraste.Text.Contains(ieskomasZodis), $"Rezultatu antraste [{RezultatuAntraste.Text}] skiriasi nuo tos kurios tikejomes {ieskomasZodis}");
            return this;
        }

        public AutopliusResultsPage PatikrintiRezultatuKieki(int expectedResultCount)
        {
            Assert.GreaterOrEqual(RezultatuKiekis, expectedResultCount, "Rezultatu kiekis mazesnis nei tikejomes");
            return this;
        }

        public AutopliusResultsPage NoDamageFilter()
        {
            NoDamageCheckBox.Click();
            return this;
        }

        public AutopliusResultsPage PaleistiPaieska()
        {
            SearchButton.Click();
            return this;
        }
    }
}
