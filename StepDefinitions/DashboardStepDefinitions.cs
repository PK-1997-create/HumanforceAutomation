using HumanforceAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace HumanforceAutomation.StepDefinitions
{
    [Binding]
    public class DashboardStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly DashboardPage _dashboardPage;
        private readonly HomePage _homePage;
        private readonly BasePage _basepage;
        private readonly LoginPage _loginpage;

        public DashboardStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["WebDriver"] as IWebDriver;
            _dashboardPage = new DashboardPage(_driver);
            _homePage = new HomePage(_driver);
            _basepage = new BasePage(_driver);
            _loginpage = new LoginPage(_driver);
        }

        string currentWindowHandle;
        HashSet<string> windowHandlesBefore;

        [Then(@"Verify the greeting is visible for user ""([^""]*)""")]
        public void ThenVerifyTheGreetingIsVisibleForUser(string user)
        {
            _basepage.ClosePopup();
            _dashboardPage.GetGreetingMessage(user);
        }


        [Then(@"I click on HF Academy at the bottom left of the page")]
        public void ThenIClickOnHFAcademyAtTheBottomLeftOfThePage()
        {
            _dashboardPage.ClickOnHfAcademyButton();
        }


        [Then(@"Verify that there is a pop up window")]
        public void ThenVerifyThatThereIsAPopUpWindow()
        {
            Assert.IsTrue(_dashboardPage.IsHfAcademyPopupDisplayed());

        }


        [Then(@"I type '([^']*)' in to the search box")]
        public void ThenITypeInToTheSearchBox(string text)
        {
            _dashboardPage.TypeInSearchBox(text);
        }

        [Then(@"I click on '([^']*)' article")]
        public void ThenIClickOnArticle(string menuItem)
        {
            // Get the list of window handles before and after opening a new tab
            currentWindowHandle = _driver.CurrentWindowHandle;
            windowHandlesBefore = new HashSet<string>(_driver.WindowHandles);
            _dashboardPage.ClickOnArticle(By.XPath($"//div[contains(text(),'{menuItem}')]"));
        }

        [Then(@"Verify that the engine opens up a new browser tab")]
        public void ThenVerifyThatTheEngineOpensUpANewBrowserTab()
        {
            _basepage.SwitchToNewTab(windowHandlesBefore);
        }

        [Then(@"I close the current tab")]
        public void ThenICloseTheCurrentTab()
        {
            _basepage.CloseCurrentTab();
            _basepage.SwitchToMainTab();
        }

        [Then(@"I log out")]
        public void ThenILogOut()
        {
            _dashboardPage.Logout();
        }

        [When(@"I visit EmployeeManagement")]
        public void WhenIVisitEmployeeManagement()
        {
            _loginpage.NavigateToEmployeeManagementPage();
        }

        [Then(@"I should see '([^']*)'")]
        public void ThenIShouldSee(string warningMessage)
        {
            _dashboardPage.verifyWarningMessage(warningMessage);
        }

        [Then(@"Verify that the '([^']*)' button is visible")]
        public void ThenVerifyThatTheButtonIsVisible(string linkText)
        {
            _dashboardPage.verifyLinkButtonVisible(linkText);
        }

        [Then(@"Verify clicking '([^']*)' button will redirect user back to the home page")]
        public void ThenVerifyClickingButtonWillRedirectUserBackToTheHomePage(string linkText)
        {
            _dashboardPage.ClickLinkButton(linkText);
            _loginpage.VerifyHomePageDisplayed();
        }




        [Then(@"I double click on my own employee profile '([^']*)'")]
        public void ThenIDoubleClickOnMyOwnEmployeeProfile(string employeeid)
        {
            _dashboardPage.DoubleClickOnEmployeeProfile(employeeid);
        }

        [Then(@"I should see the popup warning message advising '([^']*)'")]
        public void ThenIShouldSeeThePopupWarningMessageAdvising(string warningtext)
        {
            _dashboardPage.IsPopupWarningVisible(warningtext);
            _dashboardPage.ClickButton("OK");
        }

        [Then(@"Verify that the 'Save' button is not visible")]
        public void ThenVerifyThatTheSaveButtonIsNotVisible()
        {
            Assert.IsFalse(_dashboardPage.IsSaveButtonVisible(), "'Save' button is visible");
        }

    }
}

