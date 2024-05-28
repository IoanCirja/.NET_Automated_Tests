/***************************************************************************
 *                                                                         *
 *  File:          MenuItems.cs                                            *
 *                                                                         *
 *  Description:   MenuItems Model for ITGalaxy.ro                         *
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
    public class MenuItems
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        #endregion

        #region Methods
        /// <summary>
        /// Constructorul pentru clasa MenuItems.
        /// </summary>
        /// <param name="browser">Driver-ul de browser folosit pentru navigare.</param>
        public MenuItems(IWebDriver browser)
        {
            _driver = browser;
        }

        #endregion

    }
}
