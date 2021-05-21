using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SIA12AutomationSolution.PageObjects.NewAddress;
using SIA12AutomationSolution.Utils;

namespace SIA12AutomationSolution.PageObjects.Addresses
{
    public class AddressesPage
    {
        private IWebDriver driver;

        public AddressesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By NewAddress = By.CssSelector("a[data-test=create]");
        public IWebElement BtnNewAddress => driver.FindElement(NewAddress);

        private By Addresses = By.CssSelector("tbody tr");
        private IList<IWebElement> LstAddresses => driver.FindElements(Addresses);

        private By Destroy = By.CssSelector("[data-method=delete]");
        public IWebElement BtnDestroy(string addressName) =>
            LstAddresses.FirstOrDefault(e => e.Text.Contains(addressName))?.FindElement(Destroy);

        private By SuccessfullyDestroyed = By.CssSelector("[data-test=notice]");
        public IWebElement LblSuccessfullyDestroyed => driver.FindElement(SuccessfullyDestroyed);

        public void DeleteAddress(string addressName)
        {
            WaitHelpers.WaitElementToBeVisible(driver, NewAddress);
            BtnDestroy(addressName).Click();
            driver.SwitchTo().Alert().Accept();
        }


        public NewAddressPage NavigateToNewAddressPage()
        {
            WaitHelpers.WaitElementToBeVisible(driver, NewAddress);
            BtnNewAddress.Click();
            return new NewAddressPage(driver);
        }
    }
}
