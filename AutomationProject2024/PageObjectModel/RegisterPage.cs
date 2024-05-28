/***************************************************************************
 *                                                                         *
 *  File:          RegisterPage.cs                                         *
 *                                                                         *
 *  Description:   RegisterPage Model for ITGalaxy.ro                      *
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


using AutomationProject2024.TestData;
using OpenQA.Selenium;
using System.Threading;


namespace AutomationProject2024.PageObjectModel
{
    public class RegisterPage
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;
        /// <summary>
        /// Datele utilizatorului.
        /// </summary>
        private RegisterUserData _userData;


        #endregion

        #region Methods


        public RegisterPage(IWebDriver browser, RegisterUserData userData)
        {
            _driver = browser;
            _userData = userData;
        }

        /// <summary>
        /// Constructorul clasei RegisterPage.
        /// </summary>
        /// <param name="browser">Driver-ul de browser folosit pentru navigare.</param>
        public RegisterPage(IWebDriver browser)
        {
            _driver = browser;
        }

        /// <summary>
        /// Reprezintă câmpul de formular pentru prenume.
        /// </summary>
        public IWebElement FirstNameForm => _driver.FindElement(By.XPath("//*[@id=\"newfirstname\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru nume.
        /// </summary>
        public IWebElement LastNameForm => _driver.FindElement(By.XPath("//*[@id=\"newlastname\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru telefon.
        /// </summary>
        public IWebElement PhoneForm => _driver.FindElement(By.XPath("//*[@id=\"telephone\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru email.
        /// </summary>
        public IWebElement EmailForm => _driver.FindElement(By.XPath("//*[@id=\"newemail\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru parolă.
        /// </summary>
        public IWebElement PasswordForm => _driver.FindElement(By.XPath("//*[@id=\"newpassword\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru reintroducerea parolei.
        /// </summary>
        public IWebElement RepeatPasswordForm => _driver.FindElement(By.XPath("//*[@id=\"newpasswordretype\"]"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru termenii și condițiile.
        /// </summary>
        public IWebElement TermsAndConditionsForm => _driver.FindElement(By.XPath("//*[@id=\"terms_conditions\"]"));
        //*[@id="terms_conditions"]

        /// <summary>
        /// Reprezintă câmpul de formular pentru abonarea la newsletter.
        /// </summary>
        public IWebElement NewsletterForm => _driver.FindElement(By.XPath("//*[@id=\"newsletter\"]"));
        /// <summary>
        /// Reprezintă butonul pentru crearea unui cont.
        /// </summary>
        public IWebElement CreateAccountBtn => _driver.FindElement(By.XPath("//*[@id=\"register\"]/fieldset/div/div[9]/button"));

        /// <summary>
        /// Reprezintă câmpul de formular pentru email.
        /// </summary>
        public IWebElement EmailLoginForm => _driver.FindElement(By.XPath("//*[@id=\"email\"]"));
        /// <summary>
        /// Reprezintă câmpul de formular pentru parolă.
        /// </summary>
        public IWebElement PasswordLoginForm => _driver.FindElement(By.XPath("//*[@id=\"password\"]"));
        /// <summary>
        /// Reprezintă butonul pentru logare.
        /// </summary>
        public IWebElement LoginButton => _driver.FindElement(By.XPath("//*[@id=\"login\"]/fieldset/div[1]/div/button"));
        /// <summary>
        /// Reprezintă butonul pentru cookies.
        /// </summary>
        public IWebElement CookieButton => _driver.FindElement(By.XPath("//*[@id=\"alert-cookies-warning\"]/div[1]/button[2]"));


        /// <summary>
        /// Metodă care înregistrează un nou utilizator cu detaliile furnizate.
        /// </summary>
        /// <param name="firstName">Prenumele utilizatorului.</param>
        /// <param name="lastName">Numele de familie al utilizatorului.</param>
        /// <param name="phoneNumber">Numărul de telefon al utilizatorului.</param>
        /// <param name="email">Adresa de email a utilizatorului.</param>
        /// <param name="password">Parola pentru contul utilizatorului.</param>
        public void RegisterWithGeneratedData()
        {
            try
            {
                //asteptam sa se incarce pagina
                Thread.Sleep(3000);

                // apasam pe cookie daca exista
                if (CookieButton != null)
                {
                    CookieButton.Click();
                    Thread.Sleep(3000);
                }

                // marim window-ul
                _driver.Manage().Window.Maximize();

                // completam datele
                FirstNameForm.SendKeys(_userData._firstName);
                LastNameForm.SendKeys(_userData._lastName);
                PhoneForm.SendKeys(_userData._phoneNumber);
                EmailForm.SendKeys(_userData._email);
                PasswordForm.SendKeys(_userData._password);
                RepeatPasswordForm.SendKeys(_userData._password);


                // Scroll 600 pixels
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 600);");


                Thread.Sleep(1000);

                // Terms and Conditions and Newsletter 
                TermsAndConditionsForm.Click();
                NewsletterForm.Click();
                Thread.Sleep(1500);

                // Create Account button
                CreateAccountBtn.Click();
            }
            finally
            {
                Thread.Sleep(5000);

                // inchidem WebDriver (pentru testing)
                //_driver.Quit();
            }
        }
        /// <summary>
        /// Metodă care înregistrează un nou utilizator cu detaliile furnizate.
        /// </summary>
        /// <param name="firstName">Prenumele utilizatorului.</param>
        /// <param name="lastName">Numele de familie al utilizatorului.</param>
        /// <param name="phoneNumber">Numărul de telefon al utilizatorului.</param>
        /// <param name="email">Adresa de email a utilizatorului.</param>
        /// <param name="password">Parola pentru contul utilizatorului.</param>
        public void RegisterWithGivenData(string firstName, string lastName, string phoneNumber, string email, string password)
        {
            try
            {
                //asteptam sa se incarce pagina
                Thread.Sleep(3000);

                // apasam pe cookie daca exista
                if (CookieButton != null)
                {
                    CookieButton.Click();
                    Thread.Sleep(3000);
                }

                // marim window-ul
                _driver.Manage().Window.Maximize();

                // completam datele
                FirstNameForm.SendKeys(firstName);
                LastNameForm.SendKeys(lastName);
                PhoneForm.SendKeys(phoneNumber);
                EmailForm.SendKeys(email);
                PasswordForm.SendKeys(password);
                RepeatPasswordForm.SendKeys(password);


                // Scroll 600 pixels
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 600);");


                Thread.Sleep(1000);

                // Terms and Conditions and Newsletter 
                TermsAndConditionsForm.Click();
                NewsletterForm.Click();
                Thread.Sleep(1500);

                // Create Account button
                CreateAccountBtn.Click();
            }
            finally
            {
                Thread.Sleep(5000);

                // inchidem WebDriver (pentru testing)
                //_driver.Quit();
            }
        }


        /// <summary>
        /// Metodă care autentifică un utilizator cu email-ul și parola furnizate.
        /// </summary>
        /// <param name="email">Adresa de email a utilizatorului.</param>
        /// <param name="password">Parola utilizatorului.</param>
        public void Login(string email, string password)
        {

            _driver.Manage().Window.Maximize();


            Thread.Sleep(3000);
            if (CookieButton != null)
            {
                CookieButton.Click();

                Thread.Sleep(1000);

            }
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0, 800);");

            Thread.Sleep(3000);

            EmailLoginForm.SendKeys(email);
            PasswordLoginForm.SendKeys(password);
            Thread.Sleep(2000);

            LoginButton.Click();

        }

        #endregion
    }
}
