using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SIA12AutomationSolution.PageObjects;
using SIA12AutomationSolution.PageObjects.Addresses;
using SIA12AutomationSolution.Utils;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12AutomationSolution.Controls
{
    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.CssSelector("");
        public IWebElement BtnHome => driver.FindElement(home);
    }

    public class LoggedOutMenuItemControl : MenuItemControl
    {
        public LoggedOutMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        private By SignIn = By.Id("sign-in");
        public IWebElement BtnSignIn => driver.FindElement(SignIn);

        public LoginPage NavigateToLoginPage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, SignIn);
            BtnSignIn.Click();
            return new LoginPage(driver);
        }
    }

    public class LoggedInMenuItemControl : MenuItemControl
    {
        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        private By Email = By.XPath("//span[@data-test='current-user']");
        public IWebElement LblEmail => driver.FindElement(Email);

        private By Address = By.CssSelector("a[data-test=addresses]");
        public IWebElement BtnAddresses => driver.FindElement(Address);

        public AddressesPage NavigateToAddressesPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(Email));
            BtnAddresses.Click();
            return new AddressesPage(driver);
        }
    }
}