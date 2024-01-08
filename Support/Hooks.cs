using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using HumanforceWebAutomation.Factories;
using OpenQA.Selenium.Support.Extensions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using HumanforceAutomation;
using OpenQA.Selenium.Chrome;

namespace HumanforceWebAutomation.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private static DriverFactory _driverFactory;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        // @TODO: DriverFactory for multi browser parallel execution
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _driverFactory = new DriverFactory();
            Directory.CreateDirectory(Path.Combine("..", "..", "TestResults"));
        }


        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            _driver = _driverFactory.CreateDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            ScenarioContext.Current["WebDriver"] = _driver;
            _objectContainer.RegisterInstanceAs(_driver);
        }


        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            // Check if the scenario has failed
            if (scenarioContext.TestError != null)
            {
                // Save the screenshot with a unique name
                // _driver.TakeScreenshot().SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"), ScreenshotImageFormat.png);
            }
            _driver?.Dispose();
        }



    }
}