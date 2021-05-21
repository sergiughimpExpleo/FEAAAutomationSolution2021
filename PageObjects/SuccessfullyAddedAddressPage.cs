

using OpenQA.Selenium;
using SIA12AutomationSolution.PageObjects.Addresses;

namespace SIA12AutomationSolution.PageObjects
{
    public class SuccessfullyAddedAddressPage
    {
        private IWebDriver driver;

        public SuccessfullyAddedAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By SuccessfullyAdded = By.CssSelector("div[data-test=notice]");
        public IWebElement LblSuccessfullyAdded => driver.FindElement(SuccessfullyAdded);

        private By List = By.CssSelector("[data-test=list]");
        public IWebElement BtnList => driver.FindElement(List);


        public AddressesPage NavigateToAddressesPage()
        {
            BtnList.Click();
            return new AddressesPage(driver);
        }
    }
}
