using AutomationProject2024.PageObjectModel;
using AutomationProject2024.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
/*  to have these namespaces you need to add in solution 
from ManageNuGet Packages the following:
Selenium.Webdriver
Selenium.Webdriver.ChromeDriver
Selenium.Support*/

namespace AutomationProject2024
{
    [TestClass]
    public class MagentoTests
    {
        private ChromeDriver driver;
        private HomePage homePage;
        private RegisterUserData userData;
        private RegisterPage registerPage;


        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            driver= new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.itgalaxy.ro/");

            homePage = new HomePage(driver);
            userData = new RegisterUserData(driver);
            registerPage = new RegisterPage(driver, userData);

        }

        [TestMethod]

        public void ShouldRegisterIfCredentialsAreValid()
        {
            //homePage.ClickConsent();
            homePage.GoRegister();

            userData.GenerateData();
            registerPage.Register();

            Thread.Sleep(30000);

        }
            

        //[TestMethod]
        //public void LoginValidAccount()
        //{
        //    menuItemsBeforeSignIn.GoToLogin();

        //    loginPage.SignInAccount(Resources.email, Resources.password);

        //    homePage = new HomePage(driver);

        //    //Wait for page to load
        //    Thread.Sleep(2000);

        //}

        //This test should be refactorized
        //[TestMethod]
        //public void Should_RedirectToAnAlreadyCreatedAccountPage_When_TheAccountWasCreatedBefore()
        //{
        //    //Locate Create an Account link and click to go to the page 
        //    driver.FindElement(By.LinkText("Create an Account")).Click();

        //    //fill Create an Account form 
        //    driver.FindElement(By.Id("firstname")).SendKeys("Name");
        //    driver.FindElement(By.Id("lastname")).SendKeys("LastName");
        //    driver.FindElement(By.Id("email_address")).SendKeys(Resources.email);
        //    driver.FindElement(By.Id("password")).SendKeys(Resources.password);
        //    driver.FindElement(By.Id("password-confirmation")).SendKeys(Resources.password);

        //    //click on create account button
        //    driver.FindElement(By.XPath("//button[@title='Create an Account']")).Click();

        //    //identify if title page is the right one
        //    var newCustomerpageTitle = driver.FindElement(By.XPath("//span[contains(text(),'Create New Customer Account')]")).Text;
        //    //create the assertion to check if page is the correct one
        //    Assert.AreEqual("Create New Customer Account", newCustomerpageTitle);

        //    //locate the validation message for an already created account 
        //    var validationMessage = driver.FindElement(By.XPath("//div[@role='alert']/div")).Text;
        //    var expectedMessage = "There is already an account with this email address.";
        //    //we use this kind of assert when we want to check only some part of the entire text
        //    Assert.IsTrue(validationMessage.Contains(expectedMessage));
        //}


        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}