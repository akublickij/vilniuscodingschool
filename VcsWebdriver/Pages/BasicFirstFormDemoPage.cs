using NUnit.Framework;
using OpenQA.Selenium;

namespace VcsWebdriver.Pages
{
    class BasicFirstFormDemoPage : PageBase
    {
        private IWebElement _messageInput => Driver.FindElement(By.Id("user-message"));
        private IWebElement _showMessageButton => Driver.FindElement(By.XPath("//*[@id='get-input']/button"));
        private IWebElement _yourMessageLabel => Driver.FindElement(By.Id("display"));

        private IWebElement _laukasA => Driver.FindElement(By.Id("sum1"));
        private IWebElement _laukasB => Driver.FindElement(By.Id("sum2"));
        private IWebElement _getTotalMygtukas => Driver.FindElement(By.CssSelector(".btn:nth-child(3)"));
        private IWebElement _rezultatas => Driver.FindElement(By.Id("displayvalue"));


        public BasicFirstFormDemoPage(IWebDriver inputDriver) : base(inputDriver) { }

        public BasicFirstFormDemoPage EnterMessage(string myMessage)
        {
            _messageInput.Clear();
            _messageInput.SendKeys(myMessage);
            return this;
        }

        public BasicFirstFormDemoPage PushShowMessageButton()
        {
            _showMessageButton.Click();
            return this;
        }

        public void AssertShownMessage(string expectedMessage)
        {
            string message = _yourMessageLabel.Text;
            Assert.AreEqual(expectedMessage, message, "Pranesimas nesutampa");
        }

        public void EnterA(int a)
        {
            _laukasA.Clear();
            _laukasA.SendKeys(a.ToString());
        }

        public void EnterB(int b)
        {
            _laukasB.Clear();
            _laukasB.SendKeys(b.ToString());
        }

        public void EnterNumbers(int a, int b)
        {
            EnterA(a);
            EnterB(b);
        }

        public void ClickSumosMygtuka()
        {
            _getTotalMygtukas.Click();
        }

        public void PatikrintiRezultata(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _rezultatas.Text, "Suma nesutampa");
        }

        


    }
}
