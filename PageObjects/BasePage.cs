using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace HumanforceAutomation.PageObjects
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            // Initialize WebDriverWait or other setup logic if needed
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        /*        public BasePage(ScenarioContext scenarioContext)
                {
                    // Assuming you have set up the WebDriver instance in your SpecFlow hooks
                    Driver = scenarioContext["WebDriver"] as IWebDriver;

                    // You can adjust the timeout and polling interval based on your needs
                    Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                }*/

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By locator)
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
            }
            catch (Exception ex)
            {
                //logging exception from previous click attempt
                Console.WriteLine(ex.ToString());

                //Retrying click with Javascript
                IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)Driver;
                javascriptExecutor.ExecuteScript("arguments[0].click();", Driver.FindElement(locator));
            }
            
        }

        public void AssertElementIsVisible(By locator)
        {
            Assert.IsTrue(Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed);
        }

        public void SelectDropdownOption(By locator, string optionText)
        {
            var dropdown = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByText(optionText);
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
    }
}


