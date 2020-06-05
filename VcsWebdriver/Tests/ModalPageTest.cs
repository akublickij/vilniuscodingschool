using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    public class ModalPageTest : TestBase
    {
        
        [Test]
        public static void TestModal()
        {
            _modalPage.GotoPage().LaunchModal().SaveChanges();
        }

        [Test]
        public static void TestDoubleModal()
        {
            _modalPage.GotoPage().LaunchSecondModal().SaveChanges();
        }

    }
}
