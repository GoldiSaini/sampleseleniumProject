using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Pages
{
    public class HomePage
    {
        IWebDriver driver = null;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Elements

        [FindsBy(How=How.CssSelector, Using= "#mat-input-0")]
        public IWebElement APIKeyInputbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table.mat-elevation-z8 >thead>tr>th")]
        public IList<IWebElement> ProductListTableHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='mat-stroked-button']/span[text()='Add Product']")]
        public IWebElement AddProductButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='mat-stroked-button']/span[text()='Refresh']")]
        public IWebElement RefreshButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@title='More']")]
        public IList<IWebElement> MoreButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='container']/h2")]
        public IWebElement MoredeatilsWindow { get; set; }
        




        #endregion


    }
}
