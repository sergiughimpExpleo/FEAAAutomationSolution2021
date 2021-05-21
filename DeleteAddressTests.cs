using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SIA12AutomationSolution.Controls;
using SIA12AutomationSolution.PageObjects;
using SIA12AutomationSolution.PageObjects.NewAddress;
using SIA12AutomationSolution.PageObjects.NewAddress.InputData;

namespace SIA12AutomationSolution
{
    [TestClass]
    public class DeleteAddressTests
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
            var homePage = loginPage.LoginApplication("test@test.test", "test");
            var addressesPage = homePage.loggedInMenuItemControl.NavigateToAddressesPage();
            newAddressPage = addressesPage.NavigateToNewAddressPage();
            newAddressPage.SaveAddress(new NewAddressBO());
        }

        [TestMethod]
        public void DeleteAddress()
        {
            var successfullyAddedPage = new SuccessfullyAddedAddressPage(driver);
            var addressesPage = successfullyAddedPage.NavigateToAddressesPage();

            addressesPage.DeleteAddress(new NewAddressBO().FirstName);

            Assert.AreEqual("Address was successfully destroyed.", addressesPage.LblSuccessfullyDestroyed.Text);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }
    }
}