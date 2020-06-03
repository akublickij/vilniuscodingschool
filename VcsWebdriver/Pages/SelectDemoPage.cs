using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class SelectDemoPage : PageBase
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
            
        }

        public SelectDemoPage GoToSelectDemoPage()
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
            return this;
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
            // inicializuojame actions
            Actions actions = new Actions(Driver);

            // nuspausti Ctrl Mygtuka 
            actions.KeyDown(Keys.LeftControl);

            foreach (var option in MiestuPasirinkimoSarasas.Options)
                if (elementuValuesKuriuosPasirinksime.Contains(option.GetAttribute("value")))
                {
                    // nurodem kokius optionus clickint
                    actions.Click(option);
                }
                   
            // atleidziam mygtuka
            actions.KeyUp(Keys.LeftControl);

            // vykdome veiksmus
            actions.Build().Perform();

            return this;
        }


        public SelectDemoPage PaspauskGetAllSelected()
        {
            GetAllSelectedMygtukas.Click();
            return this;
        }

        public SelectDemoPage CheckListedCities(List<string> elementuValuesKuriuosPasirinksime)
        {
            // priskiriame zinute kintamajam
            string rezultatas = RezultatoZinute.Text;

            foreach (var pasirinktasMiestas in elementuValuesKuriuosPasirinksime)
            {
                Assert.True(rezultatas.Contains(pasirinktasMiestas),
                    $"{pasirinktasMiestas} nera tarp pasirinktu. Pasirinkti miestai: {rezultatas}");
            }

            return this;
        }

        public SelectDemoPage CheckListedCities()
        {
            var builded = new Actions(Driver);
            builded.SendKeys(Keys.PageDown);
            builded.Build().Perform();

            // priskiriame zinute kintamajam
            string rezultatas = RezultatoZinute.Text;

            IList<IWebElement> pasirinktiElementai = MiestuPasirinkimoSarasas.AllSelectedOptions;
            foreach (IWebElement pasirinktasMiestas in pasirinktiElementai)
            {
                Assert.True(rezultatas.Contains(pasirinktasMiestas.Text),
                    $"{pasirinktasMiestas} nera tarp pasirinktu");
            }

            return this;
        }

    }
}
