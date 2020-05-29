using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace VcsWebdriver.Pages
{
    class VartuTechnikaPage : PageBase
    {
        private IWebElement _plocioLaukas => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _aukscioLaukas => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _automatika => Driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimas => Driver.FindElement(By.Id("darbai"));
        private IWebElement _skaiciuotiKaina => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _rezultatas => Driver.FindElement(By.Id("calc_result"));
        private IWebElement _uzdarytiAcceptCookies => Driver.FindElement(By.Id("cookiescript_reject"));


        public VartuTechnikaPage(IWebDriver inputDriver) : base(inputDriver)
        {
            Driver.Url = "http://vartutechnika.lt/";
        }

        public VartuTechnikaPage IrasytiMatmenis(int plotis, int aukstis)
        {
            _plocioLaukas.Clear();
            _aukscioLaukas.Clear();
            _plocioLaukas.SendKeys(plotis.ToString());
            _aukscioLaukas.SendKeys(aukstis.ToString());
            return this;
        }

        public VartuTechnikaPage Automatika(bool uzsakyta)
        {
            if (_automatika.Selected != uzsakyta)
                _automatika.Click();

            return this;
        }

        public VartuTechnikaPage Montavimas(bool uzsakytas)
        {
            if (_montavimas.Selected != uzsakytas)
                _montavimas.Click();

            return this;
        }

        public VartuTechnikaPage SkaiciuotiKaina()
        {
            _skaiciuotiKaina.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return this;
        }

        public void TikrintiRezultata(string expectedPrice)
        {
            Assert.True(_rezultatas.Text.Contains(expectedPrice));
        }

        public void UzdarytiCookiesLangeli()
        {
            _uzdarytiAcceptCookies.Click();
        }

    }
}
