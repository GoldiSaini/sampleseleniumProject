using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Pages
{
   public class AddProduct
    {
        IWebDriver driver = null;

        public AddProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Elements

        [FindsBy(How = How.Id, Using = "mat-input-1")]
        public IWebElement NameInputbox { get; set; }

        [FindsBy(How = How.Id, Using = "mat-input-2")]
        public IWebElement DescInputbox { get; set; }

        [FindsBy(How = How.Id, Using = "mat-input-3")]
        public IWebElement URLInputbox { get; set; }

        [FindsBy(How = How.Id, Using = "mat-select-1")]
        public IWebElement CategoryDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "mat-error-0")]
        public IWebElement RequiredError { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#cdk-overlay-0 > div > div > mat-option")]
        public IList<IWebElement> CategoryDropdownContent { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='mat-stroked-button']/span[text()='Save']")]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='mat-stroked-button']/span[text()='Cancle']")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//h1[text()='Add Product']")]
        public IWebElement AddproductLabel { get; set; }

        #endregion



    }
}
