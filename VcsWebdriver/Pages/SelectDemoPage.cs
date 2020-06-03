using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class SelectDemoPage : PageBase
    {
        // elementai
        private static SelectElement DaySelectList => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private static IWebElement SelectedDayLabel => Driver.FindElement(By.ClassName("selected-value"));

        private static SelectElement MiestuPasirinkimoSarasas => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private static IWebElement GetAllSelectedMygtukas => Driver.FindElement(By.Id("printAll"));
        private static IWebElement RezultatoZinute => Driver.FindElement(By.ClassName("getall-selected"));

        // konstruktorius
        public SelectDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        }

        // metodai- veiksmai

        public SelectDemoPage SelectDay(DayOfWeek selectOption)
        {
            DaySelectList.SelectByValue(selectOption.ToString());
            return this;
        }


        public SelectDemoPage AssertSelectedDay(DayOfWeek expectedDay)
        {
            Assert.AreEqual($"Day selected :- {expectedDay}", SelectedDayLabel.Text);

            return this;
        }

        public SelectDemoPage PasirinkReiksmesIsDidelioLauko(List<string> elementuValuesKuriuosPasirinksime)
        {
            var actions = new Actions(Driver).KeyDown(Keys.LeftControl);

            foreach (var option in MiestuPasirinkimoSarasas.Options)
                if (elementuValuesKuriuosPasirinksime.Contains(option.GetAttribute("value")))
                    actions.Click(option);

            actions.KeyUp(Keys.LeftControl).Build().Perform();
            return this;
        }

        public SelectDemoPage PaspauskGetAllSelected()
        {
            GetAllSelectedMygtukas.Click();
            return this;
        }

        public SelectDemoPage TikrinkPasirinktasReiksmes(List<string> elementuValuesKuriuosPasirinksime)
        {
            string message = RezultatoZinute.Text;
            Assert.IsTrue(message.StartsWith("Options selected are : "), "Expected message to start with 'Options selected are : '");
            foreach (var reiksme in elementuValuesKuriuosPasirinksime)
                Assert.IsTrue(message.Contains(reiksme), $"Expected '{message}' to contain '{reiksme}'");

            return this;
        }

        public SelectDemoPage TikrinkPasirinktaReiksme(string reiksme)
        {
            string message = RezultatoZinute.Text;
            Assert.AreEqual($"Options selected are : {reiksme}", message, "Uzrasas nesutampa");
            return this;
        }
    }
}
