using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

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

        public void ClosePopup()
        {
            try
            {
                By cancelButtonLocator = By.XPath("//div[contains(text(),'×')]");
                ClickElement(cancelButtonLocator);
            }
            catch
            {
                Console.WriteLine("Greeting popup was not displayed. Proceeding...");
            }
        }

        public bool IsPopupInsideIframeDisplayed(By iframeLocator, By popupLocator)
        {
            // Switch to the iframe
            IWebElement iframeElement = Driver.FindElement(iframeLocator);
            Driver.SwitchTo().Frame(iframeElement);
            Thread.Sleep(5000);

            // Check if the popup is displayed
            bool isPopupDisplayed = Driver.FindElement(popupLocator).Displayed;

            return isPopupDisplayed;
        }
        public void SwitchToNewTab(HashSet<string> windowHandlesBefore)
        {
            // Wait for the new tab to open by checking for an increase in window handles
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.WindowHandles.Count > windowHandlesBefore.Count);

            // Switch to the new tab
            foreach (string windowHandle in Driver.WindowHandles)
            {
                if (!windowHandlesBefore.Contains(windowHandle))
                {
                    Driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }

        public void CloseCurrentTab()
        {
            // Close the current tab
            Driver.Close();

            // Switch back to the main window if there are multiple tabs
            if (Driver.WindowHandles.Count > 1)
            {
                string mainWindowHandle = Driver.WindowHandles.First();
                Driver.SwitchTo().Window(mainWindowHandle);
            }
        }

        public void SwitchToMainTab()
        {
            // Switch back to the main tab or window
            string mainTabHandle = Driver.WindowHandles.First();
            Driver.SwitchTo().Window(mainTabHandle);
        }

        public void DoubleClickOnElement(By locator)
        {
            Actions action = new Actions(Driver);
            IWebElement element = Driver.FindElement(locator);
            action.DoubleClick(element).Build().Perform();
        }

       
    }
}


