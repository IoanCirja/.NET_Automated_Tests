using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject2024.PageObjectModel
{
    public class MenuItemsBeforeSignIn : MenuItems
    {
        private IWebDriver driver;

        public MenuItemsBeforeSignIn(IWebDriver browser) : base(browser)
        {
            driver = browser;
        }

        public IWebElement CategoriiOption => driver.FindElement(By.XPath("//div[contains(@class, 'py-3 mb-0')]//i[contains(@class, 'fa-angle-down')]"));

        public IWebElement LaptopsAndAccessoriesLink => driver.FindElement(By.CssSelector("a.openCategorySubmenu.dropdown-height[title='Laptopuri si Accesorii']"));

        public IWebElement LaptopsLink => driver.FindElement(By.XPath("//a[normalize-space(text())='Laptopuri']"));

        public LaptopPage GoToLaptopsPage()
        {
            Thread.Sleep(2000);
            new Actions(driver).MoveToElement(LaptopsAndAccessoriesLink).Perform();
            LaptopsLink.Click();
            return new LaptopPage(driver);
           
        }
    


    }
}