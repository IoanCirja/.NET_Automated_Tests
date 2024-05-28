/***************************************************************************
 *                                                                         *
 *  File:          MenuItemsBeforeSignIn.cs                                *
 *                                                                         *
 *  Description:   MenuItemsBeforeSignIn Model for ITGalaxy.ro             *
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

using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace AutomationProject2024.PageObjectModel
{
    public class MenuItemsBeforeSignIn : MenuItems
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        #endregion
        #region Methods
        public MenuItemsBeforeSignIn(IWebDriver browser) : base(browser)
        {
            _driver = browser;
        }
        /// <summary>
        /// Reprezintă câmpul pentru categorii.
        /// </summary>
        public IWebElement CategoriiOption => _driver.FindElement(By.XPath("//div[contains(@class, 'py-3 mb-0')]//i[contains(@class, 'fa-angle-down')]"));
        /// <summary>
        /// Reprezintă butonul pentru trimiterea la laptopuri.
        /// </summary>
        public IWebElement LaptopsAndAccessoriesLink => _driver.FindElement(By.CssSelector("a.openCategorySubmenu.dropdown-height[title='Laptopuri si Accesorii']"));
        /// <summary>
        /// Reprezintă linkul pentru laptopuri.
        /// </summary>
        public IWebElement LaptopsLink => _driver.FindElement(By.XPath("//a[normalize-space(text())='Laptopuri']"));
        /// <summary>
        /// Metoda care navigheaza pe pagina cu laptopuri.
        /// </summary>
        public LaptopPage GoToLaptopsPage()
        {
            Thread.Sleep(2000);
            new Actions(_driver).MoveToElement(LaptopsAndAccessoriesLink).Perform();
            LaptopsLink.Click();
            return new LaptopPage(_driver);
           
        }
        #endregion



    }
}