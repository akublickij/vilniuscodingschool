using System;
using System.Linq;
using NUnit.Framework;
using VcsWebdriver.Drivers;
using VcsWebdriver.Pages;

namespace VcsWebdriver.Tests
{
    class SelectDemoTests
    {
        private static SelectDemoPage _demoPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = CustomDrivers.GetChromeDriver();
            _demoPage = new SelectDemoPage(driver);
        }

        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Friday)]
        public static void TestFirstCheckBoxExactWait(DayOfWeek testDay)
        {
            _demoPage.SelectDay(testDay).AssertSelectedDay(testDay);
        }


        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname")]
        public static void PasirinktiKeliasReiksmes(params string[] elementuValuesKuriuosPasirinksime)
        {
            _demoPage.PasirinkReiksmesIsDidelioLauko(elementuValuesKuriuosPasirinksime.ToList())
                .PaspauskGetAllSelected()
                .TikrinkPasirinktasReiksmes(elementuValuesKuriuosPasirinksime.ToList());

            
        }

        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _demoPage.CloseBrowser();
        }

    }
}
