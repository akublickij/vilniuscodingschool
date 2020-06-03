using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;


namespace VcsWebdriver.Drivers
{
    public class ScreenCapture
    {
        public static void Shot(IWebDriver webDriver)
        {
            Screenshot screenshot = webDriver.TakeScreenshot();

            string directoryName = 
                Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location));

            string screenshotFolder = Path.Combine(directoryName, "screenshots");
            Directory.CreateDirectory(screenshotFolder);


            string screenshotFile = Path.Combine(screenshotFolder, $"{TestContext.CurrentContext.Test.Name}.png");
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            Console.WriteLine($"Isssaugojom {screenshotFile}");
        }
    }
}
