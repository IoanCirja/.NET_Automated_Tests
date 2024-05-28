/***************************************************************************
 *                                                                         *
 *  File:          ShippingAddressPage.cs                                  *
 *                                                                         *
 *  Description:   ShippingAddressPage Model for ITGalaxy.ro               *
 *                                                                         *
 *  Author:        Alexandra Florea                                        *
 *                                                                         *
 *  This code and information is provided "as is" without warranty of      *
 *  any kind, either expressed or implied, including but not limited       *
 *  to the implied warranties of merchantability or fitness for a          *
 *  particular purpose. You are free to use this source code in your       *
 *  applications as long as the original copyright notice is included.     *
 *                                                                         *
 **************************************************************************/

using AutomationProject2024.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationProject2024.PageObjectModel
{
    public class ShippingAddressPage
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        /// <summary>
        /// Datele pentru comanda.
        /// </summary>
        private ShippingAddressData _addressData;


        #endregion

        #region Methods
        public ShippingAddressPage(IWebDriver browser, ShippingAddressData addressData)
        {
            _driver = browser;
            _addressData = addressData;
        }
        /// <summary>
        /// Reprezintă câmpul de formular pentru prenume.
        /// </summary>
        public IWebElement FirstNameForm => _driver.FindElement(By.XPath("//*[@id=\"new_firstname\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru nume.
        /// </summary>
        public IWebElement LastNameForm => _driver.FindElement(By.XPath("//*[@id=\"new_lastname\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru telefon.
        /// </summary>
        public IWebElement TelephoneForm => _driver.FindElement(By.XPath("//*[@id=\"new_telephone\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru email.
        /// </summary>
        public IWebElement EmailForm => _driver.FindElement(By.XPath("//*[@id=\"new_email\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru parolă.
        /// </summary>
        public IWebElement PasswordForm => _driver.FindElement(By.XPath("//*[@id=\"new_password\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru reintroducerea parolei.
        /// </summary>
        public IWebElement PasswordRetypeForm => _driver.FindElement(By.XPath("//*[@id=\"new_passwordretype\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru adresa.
        /// </summary>
        public IWebElement BuyerAddressForm => _driver.FindElement(By.XPath("//*[@id=\"buyer_address\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru tara.
        /// </summary>

        public IWebElement StateNewBuyerForm => _driver.FindElement(By.XPath("//*[@id=\"state_new_buyer\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru oras.
        /// </summary>

        public IWebElement CityNewBuyerForm => _driver.FindElement(By.XPath("//*[@id=\"city_new_buyer\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru termenii și condițiile.
        /// </summary>
        public IWebElement TermsAndConditionsButton => _driver.FindElement(By.XPath("//*[@id=\"option_agree\"]"));

        /// <summary>
        /// Metodă care apasa add to cart.
        /// </summary>
        public void PressAddToCartButton()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 1000);");
            IWebElement AddToCartButton = _driver.FindElement(By.XPath("//*[@id=\"addtocart_button\"]"));
            Thread.Sleep(500);
            AddToCartButton.Click();
        }
        /// <summary>
        /// Metodă care efectueaza o comanda.
        /// </summary>
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
            Thread.Sleep(300);
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


        }
        #endregion
    }
}
