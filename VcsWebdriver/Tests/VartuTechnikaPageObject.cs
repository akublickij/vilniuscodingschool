using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    public class VartuTechnikaPageObject
    {
        private static VartuTechnikaPage _vartuTechnikaPuslapis;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _vartuTechnikaPuslapis = new VartuTechnikaPage(driver);
            _vartuTechnikaPuslapis.UzdarytiCookiesLangeli();
        }

        [TestCase(2000, 2000, true, false, "665")]
        [TestCase(4000, 2000, true, true, "1006.43")]
        [TestCase(4000, 2000, false, false, "692.35")]
        public static void EnterMessageTest(int plotis, int aukstis, bool automatika, bool montavimas, string expectedResult)
        {
            _vartuTechnikaPuslapis
                .IrasytiMatmenis(plotis, aukstis)
                .Automatika(automatika)
                .Montavimas(montavimas)
                .SkaiciuotiKaina()
                .TikrintiRezultata(expectedResult);
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _vartuTechnikaPuslapis.CloseBrowser();
        }

    }
}
