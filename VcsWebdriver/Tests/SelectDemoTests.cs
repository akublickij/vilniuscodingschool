using System;
using System.Linq;
using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    class SelectDemoTests : TestBase
    {
        [TestCase(DayOfWeek.Monday)]
        [TestCase(DayOfWeek.Tuesday)]
        [TestCase(DayOfWeek.Friday)]
        public static void TestFirstCheckBoxExactWait(DayOfWeek testDay)
        {
            _demoPage
                .GoToSelectDemoPage()
                .SelectDay(testDay)
                .AssertSelectedDay(testDay);
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname")]
        public static void PasirinktiKeliasReiksmes(params string[] elementuValuesKuriuosPasirinksime)
        {
            _demoPage
                .GoToSelectDemoPage()
                .PasirinkReiksmesIsDidelioLauko(elementuValuesKuriuosPasirinksime.ToList())
                .PaspauskGetAllSelected()
                .CheckListedCities();
        }
    }
}
