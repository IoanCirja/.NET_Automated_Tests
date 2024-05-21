using AutomationProject2024.TestData;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationProject2024.PageObjectModel
{
    public class RegisterPage
    {
        private IWebDriver _driver;
        private RegisterUserData _userData;


        public RegisterPage(IWebDriver browser, RegisterUserData userData)
        {
            _driver = browser;
            _userData = userData;
        }


        public IWebElement FirstNameForm => _driver.FindElement(By.XPath("//*[@id=\"newfirstname\"]"));
        public IWebElement LastNameForm => _driver.FindElement(By.XPath("//*[@id=\"newlastname\"]"));
        public IWebElement PhoneForm => _driver.FindElement(By.XPath("//*[@id=\"telephone\"]"));
        public IWebElement EmailForm => _driver.FindElement(By.XPath("//*[@id=\"newemail\"]"));
        public IWebElement PasswordForm => _driver.FindElement(By.XPath("//*[@id=\"newpassword\"]"));
        public IWebElement RepeatPasswordForm => _driver.FindElement(By.XPath("//*[@id=\"newpasswordretype\"]"));
        public IWebElement TermsAndConditionsForm => _driver.FindElement(By.XPath("//*[@id=\"terms_conditions\"]"));
        public IWebElement NewsletterForm => _driver.FindElement(By.XPath("//*[@id=\"newsletter\"]"));

        public IWebElement CreateAccountBtn => _driver.FindElement(By.XPath("//*[@id=\"register\"]/fieldset/div/div[9]/button"));
        public void Register()
        {
            FirstNameForm.SendKeys(_userData._firstName);
            LastNameForm.SendKeys(_userData._lastName);
            PhoneForm.SendKeys(_userData._phoneNumber);
            EmailForm.SendKeys(_userData._email);
            PasswordForm.SendKeys(_userData._password);
            RepeatPasswordForm.SendKeys(_userData._password);
            TermsAndConditionsForm.Click(); 
            NewsletterForm.Click(); 
            CreateAccountBtn.Click();
        }

    }
}