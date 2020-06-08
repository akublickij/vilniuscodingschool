using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    public class AutopliusSearchTests : TestBase
    {
        [Test]
        public static void BasicScenario()
        {
            _autoPliusSearchPage
                .GoToPage()
                .AcceptCookies()
                .GaliojantiTa()
                .PasirinktiMarke("BMW")
                .PasirinktiModeli("5 serija")
                .PasirinktiSildomasSedynes()
                .PasirinktiMetus(2010,2015)
                .PasirinktiKura("Dyzelinas")
                .Search()
                .PatikrintiRezultatuAntraste("BMW")
                .PatikrintiRezultatuKieki(10)
                .NoDamageFilter()
                .PaleistiPaieska();
        }
    }
}
