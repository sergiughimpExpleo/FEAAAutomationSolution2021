
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SIA12AutomationSolution.Controls;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12AutomationSolution.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public LoggedInMenuItemControl loggedInMenuItemControl => new LoggedInMenuItemControl(driver);
    }
}
