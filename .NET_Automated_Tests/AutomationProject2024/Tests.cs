/***************************************************************************
 *                                                                         *
 *  File:          Tests.cs                                                *
 *                                                                         *
 *  Description:   TestClass for ITGalaxy.ro tests                         *
 *                                                                         *
 *  Authors:        Ioan Cirja, Alexandra Florea                           *
 *                  Alexandra Butu, Vlad Bulgaru                           *
 *                                                                         *
 *  This code and information is provided "as is" without warranty of      *
 *  any kind, either expressed or implied, including but not limited       *
 *  to the implied warranties of merchantability or fitness for a          *
 *  particular purpose. You are free to use this source code in your       *
 *  applications as long as the original copyright notice is included.     *
 *                                                                         *
 **************************************************************************/


using AutomationProject2024.PageObjectModel;
using AutomationProject2024.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace AutomationProject2024
{
    [TestClass]
    public class Tests
    {
        #region Fields
        /// <summary>
        /// Driver-ul Chrome utilizat pentru teste.
        /// </summary>
        private ChromeDriver _driver;

        /// <summary>
        /// Driver-ul Edge utilizat pentru teste.
        /// </summary>
        private EdgeDriver _edgeDriver;

        /// <summary>
        /// Obiectul pentru pagina principală.
        /// </summary>
        private HomePage _homePage;

        /// <summary>
        /// Obiectul pentru datele de înregistrare ale utilizatorului.
        /// </summary>
        private RegisterUserData _userData;

        /// <summary>
        /// Obiectul pentru pagina de înregistrare.
        /// </summary>
        private RegisterPage _registerPage;

        /// <summary>
        /// Obiectul pentru pagina de adresă de livrare.
        /// </summary>
        private ShippingAddressPage _shippingAddressPage;

        /// <summary>
        /// Obiectul pentru datele adresei de livrare.
        /// </summary>
        private ShippingAddressData _shippingAddressData;

        /// <summary>
        /// Obiectul pentru pagina de laptopuri.
        /// </summary>
        private LaptopPage _laptopPage;

        /// <summary>
        /// Obiectul pentru elementele meniului înainte de autentificare.
        /// </summary>
        private MenuItemsBeforeSignIn _menuItemsBeforeSignIn;

        #endregion
        #region Initialization
        /// <summary>
        /// Inițializează testele, deschide browser-ul și navighează la URL-ul specificat.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            _driver= new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.itgalaxy.ro/");

            _homePage = new HomePage(_driver);
            _userData = new RegisterUserData(_driver);
            _registerPage = new RegisterPage(_driver, _userData);
            _shippingAddressData = new ShippingAddressData();
            _shippingAddressPage = new ShippingAddressPage(_driver, _shippingAddressData);
            _laptopPage = new LaptopPage(_driver);
            _menuItemsBeforeSignIn = new MenuItemsBeforeSignIn(_driver);


        }
        #endregion

        #region Tests
        /// <summary>
        /// Testează înregistrarea cu date valide.
        /// </summary>
        [TestMethod]
        public void ShouldRegisterIfCredentialsAreValid()
        {
            _homePage.GoRegister();
            _userData.GenerateData();
            _registerPage.RegisterWithGeneratedData();
            Thread.Sleep(3000);
            Assert.IsTrue(_driver.Url.Contains("https://www.itgalaxy.ro/cont"));

        }
        /// <summary>
        /// Testează înregistrarea cu date lipsă.
        /// </summary>
        [TestMethod]
        public void ShouldNotRegisterBecauseCredentialsAreMissing()
        {
            string firstName = "Ionescu";
            string lastName = "Ana";
            string phoneNumber = "0712345648";
            string email = "ioan.cirja.35@gmail.com";

            string password = "";
            _homePage.GoRegister();
            _registerPage.RegisterWithGivenData(firstName, lastName, phoneNumber, email, password);
            Thread.Sleep(2000);
            var errorMessageElement = _driver.FindElement(By.XPath("//*[@id='container_main']/div/div[1]/div[2]/div/ul/li[1]"));
            Assert.IsTrue(errorMessageElement.Displayed, "The expected error message is not visible.");

        }
        /// <summary>
        /// Testează înregistrarea cu un cont deja existent.
        /// </summary>
        [TestMethod]
        public void ShouldNotRegisterBecauseAccountAlreadyExists()
        {
            string firstName = "Ioan";
            string lastName = "Cîrjă";
            string phoneNumber = "0759150959";
            string email = "ioan.cirja.00@gmail.com";
            string password = "Twins020406!";

            _homePage.GoRegister();
            _registerPage.RegisterWithGivenData(firstName, lastName, phoneNumber, email, password);
            Thread.Sleep(2000);
            var errorMessageElement = _driver.FindElement(By.XPath("//*[@id='container_main']/div/div[1]/div[2]/div/ul/li[1]"));
            Assert.IsTrue(errorMessageElement.Displayed, "The expected error message is not visible.");

        }

        /// <summary>
        /// Testează autentificarea cu date valide.
        /// </summary>
        [TestMethod]
        public void ShouldLoginIfCredentialsAreValid()
        {
            _homePage.GoRegister();
            _registerPage.Login("ioan.cirja@student.tuiasi.ro", "Twins020406!");
            Thread.Sleep(3000);
            Assert.IsTrue(_driver.Url.Contains("https://www.itgalaxy.ro/cont"));

        }
        /// <summary>
        /// Testează autentificarea cu un email invalid.
        /// </summary>
        [TestMethod]
        public void ShouldNotLoginBecauseEmailIsInvalid()
        {
            _homePage.GoRegister();
            _registerPage.Login("ioan.cirja@student", "Twins020406!");
            Thread.Sleep(3000);
            var errorMessageElement = _driver.FindElement(By.XPath("//*[@id='container_main']/div/div[1]/div[2]/div/ul/li[1]"));
            Assert.IsTrue(errorMessageElement.Displayed, "The expected error message is not visible.");

        }
        /// <summary>
        /// Testează autentificarea cu un cont inexistent.
        /// </summary>
        [TestMethod]
        public void ShouldNotLoginBecauseAccountNotCreated()
        {
            _homePage.GoRegister();
            _registerPage.Login("ioan.cirja.75@gmail.com", "Twins020406!");
            Thread.Sleep(3000);
            var errorMessageElement = _driver.FindElement(By.XPath("//*[@id='container_main']/div/div[1]/div[2]/div/ul/li[1]"));
            Assert.IsTrue(errorMessageElement.Displayed, "The expected error message is not visible.");

        }
        /// <summary>
        /// Testează navigarea către laptopuri sortate crescator.
        /// </summary>
        [TestMethod]
        public void ShouldGoToLaptopsPage()
        {

            _menuItemsBeforeSignIn.GoToLaptopsPage();
            LaptopPage laptopPage = new LaptopPage(_driver);
            Assert.IsTrue(laptopPage.GetPageTitle().Equals(Resource.laptopPageTitle));

            laptopPage.GoToLaptopPageAscending();
        }
        /// <summary>
        /// Testează completarea formularului de livrare cu date valide.
        /// </summary>

        [TestMethod]
        public void ShouldAddInfoInShippingFormIfDataIsValid()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.itgalaxy.ro/suport-telefon/nex/compatibilitate-universala-32g-deschidere-brate-53mm-90mm-rotire-360-grade-negru-302009/");
                Thread.Sleep(600);
                _shippingAddressPage.PressAddToCartButton();
                Thread.Sleep(3000);
                _driver.Navigate().GoToUrl("https://www.itgalaxy.ro/trimite-comanda/#livrare-si-plata");

                _shippingAddressData.GenerateAddressData();

                Thread.Sleep(3000);
                _shippingAddressPage.AddingDataIntoShippingForm();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Testează adăugarea unui produs în coș folosind EdgeDriver.
        /// </summary>
        [TestMethod]
        public void AdaugaCosMetoda2()
        {
            /*
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            */
            _edgeDriver = new EdgeDriver();//options
            _edgeDriver.Manage().Window.Maximize();
            //_edgeDriver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");


            _edgeDriver.Navigate().GoToUrl("https://www.itgalaxy.ro/");
            _edgeDriver.Manage().Window.Maximize();


            //click consent
            _edgeDriver.FindElement(By.XPath("//button[@aria-label='Accepta']")).Click();

            _edgeDriver.FindElement(By.Id("uHNac_close")).Click();

            _edgeDriver.FindElement(By.XPath("//a[@title='Smartphones, Telefoane & Tablete']")).Click();


            _edgeDriver.FindElement(By.XPath("//button[@aria-label='Inchide']")).Click();

            Thread.Sleep(2000);

            IWebElement linkTelefoane = _edgeDriver.FindElement(By.XPath("//li/a[@title='Telefoane mobile']"));

            ((IJavaScriptExecutor)_edgeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", linkTelefoane);

            linkTelefoane.Click();


            IWebElement addToCart = _edgeDriver.FindElement(By.XPath("//div[@class='add']/button"));

            // asa poti muta bara de scroll pana la elementul dorit
            ((IJavaScriptExecutor)_edgeDriver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCart);

            Actions action = new Actions(_edgeDriver);

            // Asa faci mouse hover pe un element
            action.MoveToElement(addToCart).Perform();

            addToCart.Click();

            IWebElement cart = _edgeDriver.FindElement(By.Id("navbar-cart-l"));

            //hover pe cosul tau
            action.MoveToElement(cart).Perform();

            _edgeDriver.FindElement(By.XPath("//a[@href='https://www.itgalaxy.ro/trimite-comanda/']")).Click();

            // Închide browser-ul
            //_edgeDriver.Quit();

        }
        #endregion
        /// <summary>
        /// test cleanup
        /// </summary>
        #region Cleanup
        [TestCleanup]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
        #endregion
    }
}