using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace automatic_tests
{
    static class DriverInstance
    {
        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
