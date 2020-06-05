using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    public class SenukaiLoginTest : TestBase
    {
        [Test]
        public static void AcceptCookies()
        {
            _senukaiLoginPage
                .GoToLoginPage()
                .AddAdvertisingConsentCookies();
        }

        [Test]
        public static void TestBasicLogin()
        {
            _senukaiLoginPage
                .GoToLoginPage()
                .AddAdvertisingConsentCookies()
                //.AcceptSelectedCookies()
                .PerformLogin("vcs_autotest@yahoo.com", "password")
                .AssertLoggedIn()
                .ClearAllCookies()
                .AssertLoggedOut();
        }
    }
}
