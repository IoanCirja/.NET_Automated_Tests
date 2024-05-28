/***************************************************************************
 *                                                                         *
 *  File:          HomePage.cs                                             *
 *                                                                         *
 *  Description:   HomePage Model for ITGalaxy.ro                          *
 *                                                                         *
 *  Author:        Ioan Cirja                                              *
 *                                                                         *
 *  This code and information is provided "as is" without warranty of      *
 *  any kind, either expressed or implied, including but not limited       *
 *  to the implied warranties of merchantability or fitness for a          *
 *  particular purpose. You are free to use this source code in your       *
 *  applications as long as the original copyright notice is included.     *
 *                                                                         *
 **************************************************************************/


using OpenQA.Selenium;
using System.Threading;

namespace AutomationProject2024.PageObjectModel
{
    public class HomePage
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        #endregion

        #region Methods

        /// <summary>
        /// Constructorul pentru clasa HomePage.
        /// </summary>
        /// <param name="browser">Driver-ul de browser folosit pentru navigare.</param>
        public HomePage(IWebDriver browser)
        {
            _driver = browser;
        }
        /// <summary>
        /// Reprezintă butonul de redirecționare pentru pagina de înregistrare. 
        /// </summary>
        public IWebElement GoToRegister => _driver.FindElement(By.XPath("//*[@id=\"account-dropdown\"]"));
        /// <summary>
        /// Reprezintă checkbox-ul de consent.
        /// </summary>
        public IWebElement BtnConsent => _driver.FindElement(By.XPath("//*[@id=\"uHNac_close\"]"));
        /// <summary>
        /// Metodă pentru interacțiunea cu butonul de consent.
        /// </summary>
        public void ClickConsent()
        {
            Thread.Sleep(5000);
            BtnConsent.Click();
        }
        /// <summary>
        /// Metodă pentru interacțiunea cu butonul de înregistrare.
        /// </summary>
        public void GoRegister()
        {
            GoToRegister.Click();
        }

        #endregion
    }
}
