using HumanforceAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HumanforceAutomation.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly BasePage _basePage;

        public LoginPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["WebDriver"] as IWebDriver;
            _loginPage = new LoginPage(_driver);
            _basePage = new BasePage(_driver);
        }

        [When(@"I visit <test instance>")]
        public void WhenIVisitTestInstance()
        {
            _loginPage.NavigateToLoginPage();
        }


        [Then(@"I should see the login page")]
        public void ThenIShouldSeeTheLoginPage()
        {
            _loginPage.VerifyLoginPage();
        }

        [Then(@"I navigate back to the Home Page")]
        public void ThenINavigateBackToTheHomePage()
        {
           _loginPage.NavigateToHomePage();
            _loginPage.VerifyHomePageDisplayed();
        }



        [Then(@"I Verify username and password fields are visible")]
        public void ThenIVerifyUsernameAndPasswordFieldsAreVisible()
        {
            _loginPage.VerifyLoginFields();
        }


        [When(@"I login with the ""([^""]*)"" credentials")]
        public void WhenILoginWithTheCredentials(string user)
        {
            _loginPage.Login(user);
            _basePage.ClosePopup();
        }

    }
}
