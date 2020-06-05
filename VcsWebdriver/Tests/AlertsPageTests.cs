using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    public class AlertsPageTests : TestBase
    {
        
        [Test]
        public static void TestAccept()
        {
            _alertPage.GotoPage().ClickAlert().DismissAlert();
        }

        [Test]
        public static void TestAccept2()
        {
            _alertPage.GotoPage().ClickConfirmationButton().AcceptAlert();
        }

        [TestCase("skip this alert")]
        public static void TestAccept3(string inputText)
        {
            _alertPage
                .GotoPage()
                .ClickPromptButton()
                .AcceptAlertWithText(inputText)
                .CheckEnteredText(inputText);
        }
    }
}
