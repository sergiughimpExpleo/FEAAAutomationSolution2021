using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12AutomationSolution.PageObjects;

namespace SIA12AutomationSolution
{
    [TestClass]
    public class LoginTests
    {
        //declare Iwebdriver instance 
        //declare it outside of any method so that we can use it in various methods
        private IWebDriver driver;
        //declare LoginPage class
        private LoginPage loginPage;

        [TestInitialize]
        public void SetUp()
        {
            //open browser
            driver = new ChromeDriver();
            //init login page
            loginPage = new LoginPage(driver);
            //maximize window
            driver.Manage().Window.Maximize();
            //access URL of the system under test(SUT)
            driver.Navigate().GoToUrl("http://a.testaddressbook.com");
            //click sign in button from menu
            driver.FindElement(By.Id("sign-in")).Click();
            Thread.Sleep(2000); //BAD BAD PRACTICE
        }

        [TestCleanup]
        public void CleanUp()
        {
            //quit the driver instance
            driver.Quit();
        }

        [TestMethod]
        public void Should_login_successfully_with_valid_credentials()
        {
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            //assert that the email is correct
            Assert.AreEqual(homePage.loggedInMenuItemControl.LblEmail.Text, "test@test.test");
        }

        [TestMethod]
        public void Should_fail_login_with_invalid_credentials()
        {
            loginPage.LoginApplication("dasdas@asda.asdas", "asdasdasd");
            //assert that login failed
            Assert.AreEqual(loginPage.LblLoginFailed.Text, "Bad email or password.");
        }

        [TestMethod]
        public void Should_fail_login_with_invalid_email()
        {
            loginPage.LoginApplication("asdasd@fasda.fas", "test");
            Assert.AreEqual(loginPage.LblLoginFailed.Text, "Bad email or password.");
        }

        [TestMethod]
        public void Should_fail_login_with_valid_invalid_password()
        {
            loginPage.LoginApplication("test@test.test", "gasdasdas");
            Assert.AreEqual(loginPage.LblLoginFailed.Text, "Bad email or password.");
        }

    }
}
