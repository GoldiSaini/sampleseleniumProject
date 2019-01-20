using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestApp.Base
{
   public class Reusables
    {

        public void selectFromDropdown(IWebElement element,string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(value);
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }

        }

           
        }
}
