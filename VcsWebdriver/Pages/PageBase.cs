using OpenQA.Selenium;

namespace VcsWebdriver.Pages
{
    public class PageBase
    {
        protected static IWebDriver Driver;

        public PageBase(IWebDriver webdriver)
        {
            Driver = webdriver;
        }


        public void CloseBrowser()
        {
            Driver.Quit();
        }
    }
}
