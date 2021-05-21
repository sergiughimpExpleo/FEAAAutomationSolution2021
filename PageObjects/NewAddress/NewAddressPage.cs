using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SIA12AutomationSolution.PageObjects.NewAddress.InputData;
using SIA12AutomationSolution.Utils;

namespace SIA12AutomationSolution.PageObjects.NewAddress
{
    public class NewAddressPage
    {
        private IWebDriver driver;

        public NewAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By FirstName = By.Id("address_first_name");
        public IWebElement TxtFirstName => driver.FindElement(FirstName);

        private By LastName = By.Id("address_last_name");
        public IWebElement TxtLastName => driver.FindElement(LastName);

        private By Address1 = By.Id("address_street_address");
        public IWebElement TxtAddress1 => driver.FindElement(Address1);

        private By City = By.Id("address_city");
        public IWebElement TxtCity => driver.FindElement(City);

        private By State = By.Id("address_state");
        public IWebElement DdlState => driver.FindElement(State);

        private By StateList = By.CssSelector("[name ='address[state]'] option");
        public IList<IWebElement> LstStates => driver.FindElements(StateList);

        private By ZipCode = By.Id("address_zip_code");
        public IWebElement TxtZipCode => driver.FindElement(ZipCode);

        private By Countries = By.CssSelector("input[type=radio]");
        public IList<IWebElement> LstCountry => driver.FindElements(Countries);

        private By Color = By.Id("address_color");
        public IWebElement ClColor => driver.FindElement(Color);

        private By CreateAddress = By.CssSelector("input[type=submit]");
        public IWebElement BtnCreateAddress => driver.FindElement(CreateAddress);

        public void SaveAddress(NewAddressBO newAddressBo)
        {
            WaitHelpers.WaitElementToBeVisible(driver, CreateAddress);
            TxtFirstName.SendKeys(newAddressBo.FirstName);
            TxtLastName.SendKeys(newAddressBo.LastName);
            TxtAddress1.SendKeys(newAddressBo.Address1);
            TxtCity.SendKeys(newAddressBo.City);
            TxtZipCode.SendKeys(newAddressBo.City);
            LstCountry[newAddressBo.Country].Click();
            SelectState(newAddressBo);

            var js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", ClColor, newAddressBo.Color);
            //js.ExecuteScript("document.getElementById('address_first_name').style.backgroundColor = 'lightBlue'");

            BtnCreateAddress.Click();
        }

        public void SelectState(NewAddressBO newAddressBo)
        {
            var selectState = new SelectElement(DdlState);
            selectState.SelectByText(newAddressBo.State);
        }

        public void SelectStateFromList()
        {
            foreach (var state in LstStates)
            {
                if (state.Text.Equals("Kentucky"))
                {
                    state.Click();
                    break;
                }
            }
        }

    }
}