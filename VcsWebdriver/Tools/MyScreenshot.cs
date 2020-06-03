using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace VcsWebdriver.Tools
{
    public static class MyScreenshot
    {
        public static void MakePhoto(IWebDriver webdriver)
        {
            // padarom screenshot'a
            Screenshot myScreenshot = webdriver.TakeScreenshot();

            // gauname vykdomos programos adresa
            string screenShotDirectory =
                Path.GetDirectoryName(
                    Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

            // "sulipdom" naujo folderio adresa, is to kuris yra + filderio pavadinimas
            string sceenShotFolder = Path.Combine(screenShotDirectory, "screenshots");

            // sukuria nauja aplankala
            Directory.CreateDirectory(sceenShotFolder);

            // sukuriam paveiksliuko pavadinima
            string screenShotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:HH-mm}.png";

            // kur saugosim screenshota, pilnas jo adresas
            string screenshotPath = Path.Combine(sceenShotFolder, screenShotName);

            myScreenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            Console.WriteLine($"Isssaugojom {screenshotPath}");
        }
    }
}
