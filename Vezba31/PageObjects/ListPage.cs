using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Text.RegularExpressions;

namespace Vezba31.PageObjects
{
    class ListPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ListPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }


        public UInt64 FemaleUsers
        {
            get
            {
                ReadOnlyCollection<IWebElement> rows = null;
                try
                {
                    rows = this.driver.FindElements(By.XPath("//td[contains(@class, 'gender') and text() = 'Z']"));
                }
                catch (Exception)
                {
                    rows = null;
                }

                return Convert.ToUInt64(rows.Count);
            }
        }

        public UInt64 MaleUsers
        {
            get
            {
                ReadOnlyCollection<IWebElement> rows = null;
                try
                {
                    rows = this.driver.FindElements(By.XPath("//td[contains(@class, 'gender') and text() = 'M']"));
                }
                catch (Exception)
                {
                    rows = null;
                }

                return Convert.ToUInt64(rows.Count);
            }
        }


    }
}
