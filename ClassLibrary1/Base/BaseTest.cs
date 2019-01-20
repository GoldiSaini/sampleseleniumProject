using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp.Base
{
    public class BaseTest
    {
       public  IWebDriver driver = null;

        
        public void setup(string driverName)
        {
            switch(driverName)
            {
                case "chrome":
                    {
                        driver = new ChromeDriver();
                        break;
                    }
            }

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void teardown()
        {
            driver.Close();
        }

        public void navigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        public void waitHandler(int waitTime)
        {
            Thread.Sleep(waitTime);
        }
    }
}
