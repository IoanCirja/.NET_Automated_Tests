using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AC2024
{
    [TestClass]
    public class AdaugareCos
    {
        private IWebDriver driver;
        [TestMethod]
        public void AdaugaCosMetoda2()
        {
            /*
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            */
            driver = new EdgeDriver();//options
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");


            driver.Navigate().GoToUrl("https://www.itgalaxy.ro/");
            driver.Manage().Window.Maximize();


            //click consent
            driver.FindElement(By.XPath("//button[@aria-label='Accepta']")).Click();

            driver.FindElement(By.Id("uHNac_close")).Click();

            driver.FindElement(By.XPath("//a[@title='Smartphones, Telefoane & Tablete']")).Click();


            driver.FindElement(By.XPath("//button[@aria-label='Inchide']")).Click();

            Thread.Sleep(2000);

            IWebElement linkTelefoane = driver.FindElement(By.XPath("//li/a[@title='Telefoane mobile']"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", linkTelefoane);

            linkTelefoane.Click();


            IWebElement addToCart = driver.FindElement(By.XPath("//div[@class='add']/button"));

            // asa poti muta bara de scroll pana la elementul dorit
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCart);

            Actions action = new Actions(driver);

            // Asa faci mouse hover pe un element
            action.MoveToElement(addToCart).Perform();

            addToCart.Click();

            IWebElement cart = driver.FindElement(By.Id("navbar-cart-l"));

            //hover pe cosul tau
            action.MoveToElement(cart).Perform();

            driver.FindElement(By.XPath("//a[@href='https://www.itgalaxy.ro/trimite-comanda/']")).Click();

            // Închide browser-ul
            //driver.Quit();

        }

    }
}
