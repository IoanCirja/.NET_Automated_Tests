using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationProject2024.PageObjectModel
{
    public class LaptopPage
    {
        IWebDriver driver;

        public LaptopPage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement PageTitle => driver.FindElement(By.XPath("//h1[@class='cat-products-title text-left fw-bold' and text()='Laptopuri']"));


        IWebElement selectElement => driver.FindElement(By.CssSelector("select.form-control-sm"));

        IWebElement crescator => driver.FindElement(By.CssSelector("select.form-control-sm > option[value='price/ascending']"));



        public string GetPageTitle()
        {
            return PageTitle.Text;
        }

        public LaptopPageAscending GoToLaptopPageAscending()
        {
            crescator.Click();
            return new LaptopPageAscending(driver);
        }
        
      
    }
}