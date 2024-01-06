using HumanforceAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HumanforceAutomation.StepDefinitions
{

    [Binding]
    public class HomePageStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BasePage _basePage;
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public HomePageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext["WebDriver"] as IWebDriver;
            _homePage = new HomePage(_driver);
            _basePage = new BasePage(_driver);
        }

        [When(@"I visit '([^']*)'")]
        public void WhenIVisit(string url)
        {

            _basePage.NavigateToUrl(url);
            _homePage.AcceptCookies();
        }

        [Then(@"I should see the Humanforce public homepage")]
        public void ThenIShouldSeeTheHumanforcePublicHomepage()
        {
            Assert.IsTrue(_homePage.IsHomePageLoaded(), "Humanforce public homepage is not loaded correctly");
        }

        [Then(@"Verify Humanforce logo is visible")]
        public void ThenVerifyHumanforceLogoIsVisible()
        {
            Assert.IsTrue(_homePage.IsLogoVisible(), "Humanforce logo is not visible");
        }

        [When(@"I scroll to the bottom and select '([^']*)'")]
        public void WhenIScrollToTheBottomAndSelect(string linkText)
        {
            _homePage.ScrollToBottom();
            _homePage.ClickOnMenuItem(linkText);
        }

        [Then(@"I should see Helpful Resources, when I scroll to the bottom\.")]
        public void ThenIShouldSeeHelpfulResourcesWhenIScrollToTheBottom_()
        {
            Assert.IsTrue(_homePage.IsHelpfulResourcesVisible(), "Helpful Resources is not visible");
        }


        [Then(@"I visit and verify '([^']*)'")]
        public void ThenIVisitAndVerify(string webTitle)
        {
            _homePage.SelectWorkforceAnalyticsArticle(webTitle);
        }


    }
}
