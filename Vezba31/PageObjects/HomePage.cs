using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Vezba31.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }


        public void GoToPage()
        {
            this.driver.Navigate().GoToUrl("http://test.qa.rs/");
        }

        public IWebElement RegistrujKorisnika
        {
            get
            {
                IWebElement element;
                try
                {
                    wait.Until(EC.ElementIsVisible(By.XPath("//a[@href='/new']")));
                    element = this.driver.FindElement(By.XPath("//a[@href='/new']"));
                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }

        public RegistrationPage ClickOnRegistrujKorisnika()
        {
            this.RegistrujKorisnika?.Click();
            wait.Until(EC.ElementIsVisible(By.Name("ime")));
            return new RegistrationPage(driver);

        }



        public IWebElement ListaKorisnika
        {
            get
            {
                IWebElement element;
                try
                {
                    element = this.driver.FindElement(By.XPath("//a[@href='/list']"));
                }
                catch (Exception)
                {
                    element = null;
                }

                return element;
            }
        }

        public ListPage ClickOnList()
        {
            this.ListaKorisnika?.Click();
            wait.Until(EC.ElementIsVisible(By.TagName("table")));
            return new ListPage(driver);

        }


    }
}
