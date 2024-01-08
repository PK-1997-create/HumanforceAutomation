using OpenQA.Selenium;
using NUnit.Framework;


namespace HumanforceAutomation.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        private By usernameInput = By.Id("UserName");
        private By passwordInput = By.Id("Password");
        private By loginButton => By.Id("btnSubmit");

        //TODO: urls can be saved into separate json file
        private string baseUrl =  "https://qatestchallenge.humanforce.io/";
        private string loginPage = "Account/LogOn?ReturnUrl=%2f";
        private string homePage = "Home/";
        private string employeemanagement = "EmployeeManagement/";

        //TODO: Credentials can be saved into separate json file
        private string password = "Q@T3chCh4lleng31";  //password can be encrypted using base64 or any other encryption for security purposes
        private string username;

        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl(baseUrl);
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(baseUrl + homePage);
        }

        public void NavigateToEmployeeManagementPage()
        {
            _driver.Navigate().GoToUrl(baseUrl + employeemanagement);
        }

        public void VerifyLoginPage()
        {
            Assert.AreEqual(baseUrl + loginPage, _driver.Url, "Login page is not displayed");
        }

        public void VerifyHomePageDisplayed()
        {
            string actualUrl = _driver.Url;
            if (!actualUrl.EndsWith("/"))
            {
               actualUrl += "/";
            }
            Assert.AreEqual(baseUrl + homePage, actualUrl, "Home page is not displayed");
        }

        public void Login(string userType)
        {
            switch (userType.ToLower())
            {
                case "admin":
                    username = "ADM01";
                    break;
                case "manager":
                    username = "MNG01";
                    break;
                case "employee":
                    username = "EMP01";
                    break;
                default:
                    throw new Exception("User type is not defined");
            }
            _driver.FindElement(usernameInput).SendKeys(username);
            _driver.FindElement(passwordInput).SendKeys(password);
            _driver.FindElement(loginButton).Click();            
        }

            public void VerifyLoginFields()
        {
            AssertElementIsVisible(usernameInput);
            AssertElementIsVisible(passwordInput);
            AssertElementIsVisible(loginButton);
        }
    }
}
  