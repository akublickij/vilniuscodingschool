using NUnit.Framework;

namespace VcsWebdriver.Tests
{
    public class MultipleCheckBoxTests : TestBase
    {
        [Test]
        public static void SingleCheckBoxTest()
        {
            _multipleCheckBoxes
                .OpenCheckBoxPage()
                .CheckSingleCheckBox()
                .AssertSingleCheckBoxDemoSuccessMessage()
                .UnCheckSingleCheckBox();
        }

        [Test]
        public static void MultipleCheckBoxTest()
        {
            _multipleCheckBoxes
                .OpenCheckBoxPage()
                .CheckAllMultipleCheckBoxes()
                .AssertButtonName("Uncheck All");
        }

        [Test]
        public static void UncheckMultipleCheckBoxesTest()
        {
            _multipleCheckBoxes
                .OpenCheckBoxPage()
                .CheckAllMultipleCheckBoxes()
                .ClickGroupButton()
                .AssertMultipleCheckBoxesUnchecked();
        }
    }
}
