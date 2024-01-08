using OpenQA.Selenium;

namespace HumanforceAutomation.PageObjects
{
    internal class HomePage : BasePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        //Element locators
        private By workforceAnalyticsLink(string webTitle) => By.XPath($"//span[contains(.,'{webTitle}')]");
        private IWebElement logoElement => _driver.FindElement(By.XPath("//img[@alt='Humanforce logo.']"));
        private IWebElement acceptCookiesButton => _driver.FindElement(By.Id("cookiescript_accept"));
        private IWebElement helpfulResourcesElement => _driver.FindElement(By.XPath("//h2[contains(.,'Helpful resources')]"));
        public bool IsHomePageLoaded()
        {
            return _driver.Title.Contains("Humanforce");
        }

        public void AcceptCookies()
        {
            try
            {
                if (acceptCookiesButton.Displayed && acceptCookiesButton.Enabled)
                {
                    acceptCookiesButton.Click();
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cookie popup was not displayed. Proceeding...");
            }
        }

        public void ClickOnMenuItem(string linkText)
        {          
            By menuItem = By.LinkText(linkText);
            AssertElementIsVisible(menuItem);
            ClickElement(menuItem);
        }
        public bool IsLogoVisible()
        {
            try
            {
                return logoElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false; // Logo element not found
            }
        }

        public bool IsHelpfulResourcesVisible()
        {
            try
            {
                return helpfulResourcesElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false; // Helpful Resources element not found
            }
        }

        public void SelectWorkforceAnalyticsArticle(string webTitle)
        {
            
            ClickElement(workforceAnalyticsLink(webTitle));

            //verify article
            AssertElementIsVisible(workforceAnalyticsLink(webTitle));
        }
    }


}
