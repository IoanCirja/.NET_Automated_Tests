using System;
using System.Text;

namespace AutomationProject2024.TestData
{
    public class ShippingAddressData
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }
        public string _phoneNumber { get; set; }
        public string _password { get; set; }
        public string _address { get; set; }
        public string _state { get; set; }
        public string _city { get; set; }
        public string _zipCode { get; set; }
        public string _email { get; set; }
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



        private void GenerateRandomAddress()
        {
            string[] addresses = { "Strada Florilor", "Strada Lalelelor", "Strada Principala", "Strada Dimitrie Mangeron", "Strada Sperantei" };
            Random rnd = new Random();
            _address = addresses[rnd.Next(addresses.Length)];
        }


        private void GenerateRandomCity()
        {
            string[] cities = { "Bacu", "Baltati", "Budai", "Cercu", "Dancu" };
            Random rnd = new Random();
            _city = cities[rnd.Next(cities.Length)];
        }

        private void GenerateRandomZipCode()
        {
            Random rnd = new Random();
            _zipCode = rnd.Next(10000, 99999).ToString();
        }
    }
}
