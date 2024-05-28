using AutomationProject2024.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationProject2024.PageObjectModel
{
    public class ShippingAddressPage
    {
        private IWebDriver _driver;
        private ShippingAddressData _addressData;

        public ShippingAddressPage(IWebDriver browser, ShippingAddressData addressData)
        {
            _driver = browser;
            _addressData = addressData;
        }

        public IWebElement FirstNameForm => _driver.FindElement(By.XPath("//*[@id=\"new_firstname\"]"));
        public IWebElement LastNameForm => _driver.FindElement(By.XPath("//*[@id=\"new_lastname\"]"));
        public IWebElement TelephoneForm => _driver.FindElement(By.XPath("//*[@id=\"new_telephone\"]"));
        public IWebElement EmailForm => _driver.FindElement(By.XPath("//*[@id=\"new_email\"]"));
        public IWebElement PasswordForm => _driver.FindElement(By.XPath("//*[@id=\"new_password\"]"));
        public IWebElement PasswordRetypeForm => _driver.FindElement(By.XPath("//*[@id=\"new_passwordretype\"]"));
        public IWebElement BuyerAddressForm => _driver.FindElement(By.XPath("//*[@id=\"buyer_address\"]"));
        public IWebElement StateNewBuyerForm => _driver.FindElement(By.XPath("//*[@id=\"state_new_buyer\"]"));
        public IWebElement CityNewBuyerForm => _driver.FindElement(By.XPath("//*[@id=\"city_new_buyer\"]"));
        public IWebElement TermsAndConditionsButton => _driver.FindElement(By.XPath("//*[@id=\"option_agree\"]"));

        public void PressAddToCartButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 1000);");
            IWebElement AddToCartButton = _driver.FindElement(By.XPath("//*[@id=\"addtocart_button\"]"));
            Thread.Sleep(500);
            AddToCartButton.Click();
        }

        public void AddingDataIntoShippingForm()
        {
            FirstNameForm.SendKeys(_addressData._firstName);
            LastNameForm.SendKeys(_addressData._lastName);
            TelephoneForm.SendKeys(_addressData._phoneNumber);
            EmailForm.SendKeys(_addressData._email);
            PasswordForm.SendKeys(_addressData._password);
            PasswordRetypeForm.SendKeys(_addressData._password);
            BuyerAddressForm.SendKeys(_addressData._address);
            StateNewBuyerForm.SendKeys(_addressData._state);

            SelectElement citySelect = new SelectElement(CityNewBuyerForm);
            Thread.Sleep(1000);
            citySelect.SelectByText(_addressData._city);
            Thread.Sleep(1500);

            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 20000);");

            IWebElement FindCheckoutContinueButton = _driver.FindElement(By.XPath("//*[@id=\"checkout_continue\"]"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(300));

            wait.Until(driver => FindCheckoutContinueButton.Displayed && FindCheckoutContinueButton.Enabled);

            IWebElement CheckoutContinueButton = _driver.FindElement(By.XPath("//*[@id=\"checkout_continue\"]"));

            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", CheckoutContinueButton);

            wait.Until(driver => driver.Url.Contains("trimite-comanda"));
            Thread.Sleep(1000);

            
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 1000);");

            IWebElement ConfirmButton = _driver.FindElement(By.XPath("//*[@id=\"cart_bottom_summary_a\"]"));
            Thread.Sleep(1000);

            IWebElement termsButton = _driver.FindElement(By.XPath("//*[@id=\"option_agree\"]"));
            wait.Until(driver => termsButton.Displayed && termsButton.Enabled);
            termsButton = _driver.FindElement(By.Id("option_agree"));
            Thread.Sleep(1000);
            termsButton.Click();

            Thread.Sleep(1000);
            ConfirmButton = _driver.FindElement(By.XPath("//*[@id=\"cart_bottom_summary_a\"]"));
            Thread.Sleep(2000);
            ConfirmButton.Click();
            
            
        }
    }
}
