using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SIA12AutomationSolution.PageObjects
{
    public class LoginPage
    {
        public IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(SignIn));
        }

        private By Email = By.Id("session_email");
        public IWebElement TxtEmail => driver.FindElement(Email);

        public IWebElement TxtPassword => driver.FindElement(By.Name("session[password]"));

        private By SignIn = By.CssSelector("input[type='submit']");
        public IWebElement BtnSignIn => driver.FindElement(SignIn);

        public IWebElement LblLoginFailed => driver.FindElement(By.CssSelector("div[data-test=notice]"));

        public HomePage LoginApplication(string email, string password)
        {
            TxtEmail.SendKeys(email);
            TxtPassword.SendKeys(password);
            BtnSignIn.Click();
            return new HomePage(driver);
        }

    }
}
