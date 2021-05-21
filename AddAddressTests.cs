using System;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SIA12AutomationSolution.Controls;
using SIA12AutomationSolution.PageObjects;
using SIA12AutomationSolution.PageObjects.NewAddress;
using SIA12AutomationSolution.PageObjects.NewAddress.InputData;

namespace SIA12AutomationSolution
{
    [TestClass]
    public class AddAddressTests
    {
        private IWebDriver driver;
        private NewAddressPage newAddressPage;

        [TestInitialize]
        public void TestSetup()
        {
            //open browser
            driver = new ChromeDriver();
            //maximize window
            driver.Manage().Window.Maximize();
            //access URL of the system under test(SUT)
            driver.Navigate().GoToUrl("http://a.testaddressbook.com");
            //click sign in button from menu
            var menu = new LoggedOutMenuItemControl(driver);
            var loginPage = menu.NavigateToLoginPage();
            //init login page
            //var loginPage = new LoginPage(driver);
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            var addressesPage = homePage.loggedInMenuItemControl.NavigateToAddressesPage();
            newAddressPage = addressesPage.NavigateToNewAddressPage();
        }

        [TestMethod]
        public void Should_successfully_add_new_address()
        {
            var newAddressBo = new NewAddressBO()
            {
                FirstName = "Overriden First Name",
                LastName = "Overriden Last Name"
            };
            newAddressPage.SaveAddress(newAddressBo);
            var successfullyAddedAddressPage = new SuccessfullyAddedAddressPage(driver);
            Assert.AreEqual("Address was successfully created.", successfullyAddedAddressPage.LblSuccessfullyAdded.Text);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}