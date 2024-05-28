/***************************************************************************
 *                                                                         *
 *  File:          RegisterUserData.cs                                     *
 *                                                                         *
 *  Description:   RegisterUserData for creating accounts on ITGalaxy.ro   *
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
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AutomationProject2024.TestData
{
    public class RegisterUserData
    {
        #region Fields

        /// <summary>
        /// Driver-ul folosit pentru navigare.
        /// </summary>
        private IWebDriver _driver;

        /// <summary>
        /// Prenumele utilizatorului.
        /// </summary>
        public string _firstName { get; set; }

        /// <summary>
        /// Numele de familie al utilizatorului.
        /// </summary>
        public string _lastName { get; set; }

        /// <summary>
        /// Email-ul utilizatorului.
        /// </summary>
        public string _email { get; set; }

        /// <summary>
        /// Numarul de telefon al utilizatorului.
        /// </summary>
        public string _phoneNumber { get; set; }

        /// <summary>
        /// Parola utilizatorului.
        /// </summary>
        public string _password { get; set; }

        /// <summary>
        /// URL-ul site-ului de email temporar.
        /// </summary>
        private readonly string _tempMailUrl = "https://temp-mail.org/en/";

        /// <summary>
        /// URL-ul curent al paginii.
        /// </summary>
        public string CurrentUrl { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Constructorul pentru clasa RegisterUserData.
        /// </summary>
        /// <param name="browser">Driver-ul de browser folosit pentru navigare.</param>
        public RegisterUserData(IWebDriver browser)
        {
            _driver = browser;
        }

        /// <summary>
        /// Generează datele utilizatorului.
        /// </summary>
        public void GenerateData()
        {
            CurrentUrl = _driver.Url;
            _driver.Navigate().GoToUrl(_tempMailUrl);
            Thread.Sleep(20000);

            IWebElement emailElement = _driver.FindElement(By.XPath("//*[@id=\"mail\"]"));

            // Obține valoarea atributului "data-value", care conține adresa de email
            string tempEmail = emailElement.GetAttribute("value");

            // Atribuie adresa de email variabilei _email
            _email = tempEmail;
            GenerateRandomName();
            GenerateRandomPhoneNumber();
            GenerateRandomPassword();

            _driver.Navigate().GoToUrl(CurrentUrl);

            // Salvează datele într-un fișier
            SaveDataToFile();
        }

        /// <summary>
        /// Generează un nume aleatoriu.
        /// </summary>
        private void GenerateRandomName()
        {
            string[] firstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah" };
            string[] lastNames = { "Doe", "Smith", "Johnson", "Brown", "Taylor", "Wilson" };
            Random rnd = new Random();
            int firstNameIndex = rnd.Next(firstNames.Length);
            int lastNameIndex = rnd.Next(lastNames.Length);
            _firstName = firstNames[firstNameIndex];
            _lastName = lastNames[lastNameIndex];
        }

        /// <summary>
        /// Generează un număr de telefon aleatoriu.
        /// </summary>
        private void GenerateRandomPhoneNumber()
        {
            Random rnd = new Random();
            StringBuilder phoneNumber = new StringBuilder();
            for (int i = 0; i < 18; i++)
            {
                phoneNumber.Append(rnd.Next(0, 10));
            }
            _phoneNumber = phoneNumber.ToString();
        }

        /// <summary>
        /// Generează o parolă aleatorie.
        /// </summary>
        private void GenerateRandomPassword()
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < 15; i++)
            {
                password.Append(chars[rnd.Next(chars.Length)]);
            }
            password.Append("!");
            _password = password.ToString();
        }

        /// <summary>
        /// Salvează datele utilizatorului într-un fișier din folderul bin.
        /// </summary>
        private void SaveDataToFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "UserData.txt");

            StringBuilder userData = new StringBuilder();
            userData.AppendLine($"First Name: {_firstName}");
            userData.AppendLine($"Last Name: {_lastName}");
            userData.AppendLine($"Email: {_email}");
            userData.AppendLine($"Phone Number: {_phoneNumber}");
            userData.AppendLine($"Password: {_password}");
            userData.AppendLine();

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.AppendAllText(filePath, userData.ToString());
        }

        #endregion
    }
}
