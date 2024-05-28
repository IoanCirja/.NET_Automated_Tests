/***************************************************************************
 *                                                                         *
 *  File:          LaptopPage.cs                                           *
 *                                                                         *
 *  Description:   LaptopPage Model for ITGalaxy.ro                        *
 *                                                                         *
 *  Author:        Alexandra Butu                                          *
 *                                                                         *
 *  This code and information is provided "as is" without warranty of      *
 *  any kind, either expressed or implied, including but not limited       *
 *  to the implied warranties of merchantability or fitness for a          *
 *  particular purpose. You are free to use this source code in your       *
 *  applications as long as the original copyright notice is included.     *
 *                                                                         *
 **************************************************************************/


using OpenQA.Selenium;

namespace AutomationProject2024.PageObjectModel
{
    public class LaptopPage
    {
        #region Fields
        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        #endregion

        #region Methods
        /// <summary>
        /// Constructorul pentru clasa LaptopPage.
        /// </summary>
        /// <param name="browser">Driver-ul de browser folosit pentru navigare.</param>
        public LaptopPage(IWebDriver browser)
        {
            _driver = browser;
        }
        /// <summary>
        /// Reprezintă Titlul Paginii.
        /// </summary>
        IWebElement PageTitle => _driver.FindElement(By.XPath("//h1[@class='cat-products-title text-left fw-bold' and text()='Laptopuri']"));
        /// <summary>
        /// Reprezintă filtrul crescator.
        /// </summary>
        IWebElement crescator => _driver.FindElement(By.CssSelector("select.form-control-sm > option[value='price/ascending']"));


        /// <summary>
        /// Metodă ce returneaza titlul paginii.
        /// </summary>
        public string GetPageTitle()
        {
            return PageTitle.Text;
        }
        /// <summary>
        /// Metodă ce redirectioneaza pe pagina filtrata
        /// </summary>
        public LaptopPageAscending GoToLaptopPageAscending()
        {
            crescator.Click();
            return new LaptopPageAscending(_driver);
        }

        #endregion

    }
}