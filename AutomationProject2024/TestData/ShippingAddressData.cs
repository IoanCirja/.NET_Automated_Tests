/***************************************************************************
 *                                                                         *
 *  File:          ShippingAddressData.cs                                  *
 *                                                                         *
 *  Description:   ShippingAddressData for generating random address data  *
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
using System;
using System.Text;

namespace AutomationProject2024.TestData
{
    public class ShippingAddressData
    {
        #region Fields

        /// <summary>
        /// Prenumele utilizatorului.
        /// </summary>
        public string _firstName { get; set; }

        /// <summary>
        /// Numele de familie al utilizatorului.
        /// </summary>
        public string _lastName { get; set; }

        /// <summary>
        /// Numărul de telefon al utilizatorului.
        /// </summary>
        public string _phoneNumber { get; set; }

        /// <summary>
        /// Parola utilizatorului.
        /// </summary>
        public string _password { get; set; }

        /// <summary>
        /// Adresa utilizatorului.
        /// </summary>
        public string _address { get; set; }

        /// <summary>
        /// Județul utilizatorului.
        /// </summary>
        public string _state { get; set; }

        /// <summary>
        /// Orașul utilizatorului.
        /// </summary>
        public string _city { get; set; }

        /// <summary>
        /// Codul poștal al utilizatorului.
        /// </summary>
        public string _zipCode { get; set; }

        /// <summary>
        /// Email-ul utilizatorului.
        /// </summary>
        public string _email { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Generează datele de adresă ale utilizatorului.
        /// </summary>
        public void GenerateAddressData()
        {
            GenerateRandomAddress();
            _state = "Iasi";
            GenerateRandomCity();
            GenerateRandomZipCode();
            _email = "ale@gmail.com";
            GenerateRandomName();
            GenerateRandomPhoneNumber();
            GenerateRandomPassword();
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
            phoneNumber.Append(0);
            phoneNumber.Append(7);
            for (int i = 0; i < 8; i++)
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
        /// Generează o adresă aleatorie.
        /// </summary>
        private void GenerateRandomAddress()
        {
            string[] addresses = { "Strada Florilor", "Strada Lalelelor", "Strada Principala", "Strada Dimitrie Mangeron", "Strada Sperantei" };
            Random rnd = new Random();
            _address = addresses[rnd.Next(addresses.Length)];
        }

        /// <summary>
        /// Generează un oraș aleatoriu.
        /// </summary>
        private void GenerateRandomCity()
        {
            string[] cities = { "Bacu", "Baltati", "Budai", "Cercu", "Dancu" };
            Random rnd = new Random();
            _city = cities[rnd.Next(cities.Length)];
        }

        /// <summary>
        /// Generează un cod poștal aleatoriu.
        /// </summary>
        private void GenerateRandomZipCode()
        {
            Random rnd = new Random();
            _zipCode = rnd.Next(10000, 99999).ToString();
        }

        #endregion
    }
}
