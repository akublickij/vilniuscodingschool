using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class MultipleCheckBoxPage : PageBase
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

        // web elementai
        private IWebElement _singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));

        private IReadOnlyCollection<IWebElement> _multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _checkAllButton => Driver.FindElement(By.Id("check1"));
        
        // message
        private const string SingleCheckBoxMessageText = "Success - Check box is checked";


        // konstruktorius
        public MultipleCheckBoxPage(IWebDriver webdriver) : base(webdriver)
        { }

        public MultipleCheckBoxPage OpenCheckBoxPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;

            return this;
        }

        // veiksmai - metodai
        public MultipleCheckBoxPage CheckSingleCheckBox()
        {
            if (!_singleCheckBox.Selected)
            {
                _singleCheckBox.Click();
            }

            return this;
        }

        public MultipleCheckBoxPage UnCheckSingleCheckBox()
        {
            if (_singleCheckBox.Selected)
            {
                _singleCheckBox.Click();
            }

            return this;
        }

        public MultipleCheckBoxPage AssertSingleCheckBoxDemoSuccessMessage()
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElement(_singleCheckBoxMessage, SingleCheckBoxMessageText));

            Assert.AreEqual(SingleCheckBoxMessageText, _singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }


        public MultipleCheckBoxPage CheckAllMultipleCheckBoxes()
        {
            foreach (var singleCheckbox in _multipleCheckBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }

            return this;
        }

        public MultipleCheckBoxPage AssertButtonName(string expectedName)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(_checkAllButton, expectedName));

            Assert.AreEqual(expectedName, _checkAllButton.GetAttribute("value"), "Wrong button label");

            return this;
        }


        public MultipleCheckBoxPage ClickGroupButton()
        {
            _checkAllButton.Click();
            return this;
        }

        public MultipleCheckBoxPage AssertMultipleCheckBoxesUnchecked()
        {
            foreach (var singleCheckbox in _multipleCheckBoxes)
            {
                Assert.False(singleCheckbox.Selected, "One of checkboxes is still checked!");
            }

            return this;
        }

    }
}
