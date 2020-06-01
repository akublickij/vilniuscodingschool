using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    class SelectDemoPage : PageBase
    {
        // elementai
        private static SelectElement DaySelectList => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private static IWebElement SelectedDayLabel => Driver.FindElement(By.ClassName("selected-value"));

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
    }
}
