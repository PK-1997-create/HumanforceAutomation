using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HumanforceAutomation.PageObjects
{

    public class DashboardPage : BasePage
    {
        private IWebDriver driver;

        // Constructor
        public DashboardPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By HfAcademyButton = By.XPath("//menu-footer[@class='hf-menu__footer']/footer/div/div/div");
        private By searchBoxLocator = By.XPath("(//input[@type='search'])[1]");
        By employeeProfileLocator(String employeeid) => By.XPath($"//td[contains(.,'{employeeid}')]");
        By popupWarningLocator(String warningtext) => By.XPath($"//div[text()='{warningtext}']");
        By buttonLocator(string buttonName) => By.XPath($"//button[contains(text(),'{buttonName}')]");
        By saveButtonLocator = By.XPath("//span[contains(.,'Save')]");
        By linkButtonLocator(string linkText) => By.LinkText($"{linkText}");

        public bool IsDashboardDisplayed()
        {
            return driver.FindElement(By.Id("dashboard")).Displayed;
        }

        public string GetGreetingMessage(string user)
        {
            //AssertElementIsVisible(By.XPath($"//span[contains(.,'Hello {user}')]"));
            return driver.FindElement(By.XPath($"//span[contains(.,'Hello {user}')]")).Text;
        }

        public void ClickOnHfAcademyButton()
        {
            ClickElement(HfAcademyButton);
        }

        public bool IsHfAcademyPopupDisplayed()
        {
            try
            {
                AssertElementIsVisible(By.XPath("//div[@id='walkme-menu']"));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void TypeInSearchBox(string text)
        {
            driver.FindElement(searchBoxLocator).SendKeys(text);
        }

        public void ClickOnArticle(By articleLocator)
        {
            ClickElement(articleLocator);
        }

        public void CloseCurrentTab()
        {
            // Close the current tab
            driver.Close();
        }

        public void Logout()
        {
            ClickElement(By.Id("MenuFooter_Logout"));
        }

        public void DoubleClickOnEmployeeProfile(string employeeid)
        {
            DoubleClickOnElement(employeeProfileLocator(employeeid));
        }
        public void IsPopupWarningVisible(string warningtext)
        {
            AssertElementIsVisible(popupWarningLocator(warningtext));
        }
        public bool IsSaveButtonVisible()
        {
            try
            {
                return driver.FindElement(saveButtonLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public void ClickButton(string buttonName)
        {
            ClickElement(buttonLocator(buttonName));
        }

        public void verifyLinkButtonVisible(string linkText)
        {
            AssertElementIsVisible(linkButtonLocator(linkText));
        }

        public void ClickLinkButton(string linkText)
        {
            ClickElement(linkButtonLocator(linkText));
        }
        public void verifyWarningMessage(string errorMessage)
        {
            AssertElementIsVisible(By.XPath($"//h2[contains(text(),'{errorMessage}')]"));
        }
    }

}


