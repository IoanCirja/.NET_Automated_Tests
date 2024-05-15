using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationProject2024.TestData
{
    public class RegisterUserData
    {
        private IWebDriver driver;

        public RegisterUserData(IWebDriver browser)
        {
            driver = browser;
        }
        public string _firstName { get; set; }
        public string _lastName { get; set; }

        public string _email { get; set; }
        public string _phoneNumber { get; set;}
        public string _password { get; set; }
        private readonly string tempMailUrl = "https://temp-mail.org/en/";
        public string CurrentUrl { get; set; }


        public void GenerateData()
        {
            CurrentUrl = driver.Url;
            driver.Navigate().GoToUrl(tempMailUrl);
            Thread.Sleep(20000); 


            IWebElement emailElement = driver.FindElement(By.XPath("//*[@id=\"mail\"]"));

            // Get the value of the "data-value" attribute, which contains the email address
            string tempEmail = emailElement.GetAttribute("value");

            // Assign the email address to your _email variable
            _email = tempEmail;
            GenerateRandomName();
           GenerateRandomPhoneNumber();
           GenerateRandomPassword();

            driver.Navigate().GoToUrl(CurrentUrl);




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
            for (int i = 0; i < 18; i++)
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

    }
}
