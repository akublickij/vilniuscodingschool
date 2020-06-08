using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace VcsWebdriver.Pages
{
    public class AutopliusSearchPage : PageBase
    {
        private readonly string MainAdress = "https://autoplius.lt/paieska/naudoti-automobiliai";

        private SelectElement MarkeSelect => new SelectElement(Driver.FindElement(By.Id("make_id_list")));

        private IWebElement SildomosSedynesCheckBox => Driver.FindElement(By.XPath("//div[@id='top_features']/div/fieldset[5]/label"));


        
        private SelectElement ModeliaiMultipleSelect =>
            new SelectElement(Driver.FindElement(By.Id("make_id_sublist_portal")));

        private SelectElement MetaiNuo => new SelectElement(Driver.FindElement(By.Id("make_date_from")));
        private SelectElement MetaiIki => new SelectElement(Driver.FindElement(By.Id("make_date_to")));
        private SelectElement Kuras => new SelectElement(Driver.FindElement(By.Id("fuel_id")));

        private SelectElement PasirinktiModeliaiMultipleSelect =>
            new SelectElement(Driver.FindElement(By.Id("make_id_sublist")));


        private IWebElement IkeltiIpaieska => Driver.FindElement(By.Id("addbtn_make_id"));
        private IWebElement IeskotiMygtukas => Driver.FindElement(By.Id("search_form_submit_button"));
        private IWebElement TA => Driver.FindElement(By.XPath("//*[@id='search_form']/div[1]/div[5]/fieldset[7]/label"));


        public AutopliusSearchPage(IWebDriver webdriver) : base(webdriver)
        {
        }

        public AutopliusSearchPage GoToPage()
        {
            Driver.Url = MainAdress;
            return this;
        }

        public AutopliusSearchPage AcceptCookies()
        {
            Driver.Manage().Cookies
                .AddCookie(new Cookie("cookies_policy", "1", ".autoplius.lt", "/", DateTime.Now.AddDays(2)));
            Driver.Navigate().Refresh();
            return this;
        }

        public AutopliusSearchPage PasirinktiMarke(string marke)
        {
            MarkeSelect.SelectByText(marke);
            var wait = GetWait(5);

            wait.Until(e => ModeliaiMultipleSelect.Options.Any());

            return this;
        }

        public AutopliusSearchPage PasirinktiSildomasSedynes()
        {
            if (!SildomosSedynesCheckBox.Selected)
                SildomosSedynesCheckBox.Click();
            

            return this;
        }

        public AutopliusSearchPage GaliojantiTa()
        {
            if (!TA.Selected)
                TA.Click();


            return this;
        }


        public AutopliusSearchPage PasirinktiModeli(string modelis)
        {
            ModeliaiMultipleSelect.SelectByText(modelis);
            IkeltiIpaieska.Click();

            var wait = GetWait(5);
            wait.Until(e => PasirinktiModeliaiMultipleSelect.Options.Any(c => c.Text == modelis));

            return this;
        }

        public AutopliusSearchPage PasirinktiKura(string kuras)
        {
            Kuras.SelectByText(kuras);
            return this;
        }

        public AutopliusSearchPage PasirinktiMetus(int nuo, int iki)
        {
            MetaiNuo.SelectByValue(nuo.ToString());
            MetaiIki.SelectByValue(iki.ToString());
            return this;
        }

        public AutopliusResultsPage Search()
        {
            IeskotiMygtukas.Click();
            return new AutopliusResultsPage(Driver);
        }
    }
}
    