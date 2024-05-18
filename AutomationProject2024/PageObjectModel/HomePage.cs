using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationProject2024.PageObjectModel
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement GoToRegister => driver.FindElement(By.XPath("//*[@id=\"account-dropdown\"]"));

        // Imi da eroare ca nu gaseste elementul : 
        public IWebElement BtnConsent => driver.FindElement(By.XPath("//*[@id=\"uHNac_close\"]"));
      
        
      //Am gasit posibilitatea de a-l identifica asa:
     //  public IWebElement BtnConsent => driver.FindElement(By.CssSelector("a#uHNac_close.fw-bold.color-secondary.text-decoration-none"));


        public void ClickConsent()
        {
            Thread.Sleep(5000);
            BtnConsent.Click();
        }

        public void GoRegister()
        {
            GoToRegister.Click();
        }
    }
}
