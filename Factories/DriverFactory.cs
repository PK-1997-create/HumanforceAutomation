using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using HumanforceAutomation;

namespace HumanforceWebAutomation.Factories
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            TestSettings testSettings;
            testSettings = ConfigurationHelper.GetTestSettings();
            string browser = Environment.GetEnvironmentVariable("BROWSER") ?? testSettings.BrowserOption;

            

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    // Set up Chrome options                   
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (testSettings.RunInHeadlessMode)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
                    return chromeDriver;
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented: {browser}");
            }
        }
    }
}