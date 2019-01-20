using TestApp.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Pages;
using OpenQA.Selenium.Interactions;

namespace TestApp.TestCases
{
   public class Tests : BaseTest
    {


        [Test]
        public void VerifyProductListTable()
        {
            #region Open browser and enter url
            setup(AppData.Browser);
            navigateToURL(AppData.URL);
            #endregion

            #region Variable Declration
            HomePage home = new HomePage(driver);
            #endregion


            #region verify header of Product table
            waitHandler(AppData.WaitForPageLoad);
            home.APIKeyInputbox.SendKeys(AppData.APIKey);
            waitHandler(AppData.WaitForPageLoad);
            home.RefreshButton.Click();
            waitHandler(AppData.WaitForPageLoad);
            string[] Expected = AppData.ProductTableHeader.Split(',');
            for(int column=0;column< Expected.Length;column++)
            {
                Assert.IsTrue(Expected[column].Equals(home.ProductListTableHeader[column].Text),"Column header matched: "+ Expected[column]);
            }
            #endregion
        }

        [Test]
        public void AddNewProduct()
        {
            #region Open browser and enter url
            setup(AppData.Browser);
            navigateToURL(AppData.URL);
            #endregion

            #region Variable Declration
            HomePage home = new HomePage(driver);
            AddProduct Addprdt = new AddProduct(driver);
            Reusables reuse = new Reusables();
            #endregion
            try
            {

                #region verify header of Product table
                waitHandler(AppData.WaitForPageLoad);
                home.APIKeyInputbox.SendKeys(AppData.APIKey);
                waitHandler(AppData.WaitForPageLoad);
                home.RefreshButton.Click();
                waitHandler(AppData.WaitForPageLoad);
                home.AddProductButton.Click();
                waitHandler(AppData.WaitForPageLoad);
                Assert.IsTrue(reuse.IsElementDisplayed(Addprdt.AddproductLabel), "Add product page not opened successfully");

                //verify all fields are displyed
                Assert.IsTrue(reuse.IsElementDisplayed(Addprdt.NameInputbox), "Name textbox is not present on Add product page");
                Assert.IsTrue(reuse.IsElementDisplayed(Addprdt.DescInputbox), "Decs textbox is not present on Add product page");
                Assert.IsTrue(reuse.IsElementDisplayed(Addprdt.URLInputbox), "URL textbox is not present on Add product page");
                Assert.IsTrue(reuse.IsElementDisplayed(Addprdt.CategoryDropdown), "Category dropdown is not present on Add product page");


                //verify Name is mandatory fields
                Addprdt.SaveButton.Click();
                Assert.IsTrue(Addprdt.RequiredError.Text.Equals("Required"), "Name field is not a required field");


                //verify BVA on Name
                string value = AppData.NameValue + "ad";
                Addprdt.NameInputbox.SendKeys(value);
                Assert.IsFalse(Addprdt.NameInputbox.Text.Length == value.Length, "Name field not accepting value >50");

                //verify URL,Desc and category are not required fields
                Addprdt.SaveButton.Click();
                Assert.IsFalse(reuse.IsElementDisplayed(Addprdt.RequiredError), "field other than Name is also required field");

                //verfiy BVA on Desc
                value = AppData.DescriptionValue + "ad";
                Addprdt.DescInputbox.SendKeys(value);
                Assert.IsFalse(Addprdt.DescInputbox.Text.Length == value.Length, "Desc field not accepting value >200");

                //verify BVA on URL
                value = AppData.NameValue + "ad";
                Addprdt.URLInputbox.SendKeys(value);
                Assert.IsFalse(Addprdt.URLInputbox.Text.Length == value.Length, "URL field not accepting value >50");



                //select category
                Addprdt.CategoryDropdown.Click();

                Addprdt.CategoryDropdownContent[0].Click();
                Addprdt.CategoryDropdownContent[1].Click();
                Addprdt.CategoryDropdownContent[2].Click();
                Addprdt.CategoryDropdownContent[3].Click();

                //click on save button.
                Actions action = new Actions(driver);
                action.MoveToElement(Addprdt.AddproductLabel).Click().Build().Perform();
               // Addprdt.CategoryDropdown.Click();
                Addprdt.SaveButton.Click();

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }



            #endregion
        }


        [Test]
        public void VerifyMoreDetailsSections()
        {
            #region Open browser and enter url
            setup(AppData.Browser);
            navigateToURL(AppData.URL);
            #endregion

            #region Variable Declration
            HomePage home = new HomePage(driver);
            Reusables reuse = new Reusables();
            #endregion


            #region verify header of Product table
            waitHandler(AppData.WaitForPageLoad);
            home.APIKeyInputbox.SendKeys(AppData.APIKey);
            waitHandler(AppData.WaitForPageLoad);
            home.RefreshButton.Click();
            waitHandler(AppData.WaitForPageLoad);

            if (reuse.IsElementDisplayed(home.MoreButtons[0]))
            {
                home.MoreButtons[0].Click();
                waitHandler(AppData.WaitForPageLoad);
                Assert.IsTrue(reuse.IsElementDisplayed(home.MoredeatilsWindow));
            }
            else
            {
                Assert.Fail("No product is available");
            }
            

            #endregion
        }
    }
}
