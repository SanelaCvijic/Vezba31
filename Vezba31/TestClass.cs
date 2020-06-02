using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Vezba31.PageObjects;
using QaHomePage = Vezba31.PageObjects.HomePage;
using QaListPage = Vezba31.PageObjects.ListPage;
using RegistrationPage = Vezba31.PageObjects.RegistrationPage;


namespace Vezba31
{
    class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestHomePage()
        {
            HomePage naslovna = new HomePage(driver);
            ListPage lista = new ListPage(driver);
       
            naslovna.GoToPage();
            lista = naslovna.ClickOnList();

             Assert.GreaterOrEqual(lista.FemaleUsers, 30);
            //Assert.GreaterOrEqual(lista.MaleUsers, 30);



        }
        [Test]
        [Category ("Registration")]

        public void TestRegistration()
        {
            RegistrationPage reg;
            HomePage naslovna = new HomePage(driver);
            naslovna.GoToPage();

            reg = naslovna.ClickOnRegistrujKorisnika();
            reg.FirstName.SendKeys("Jovan");
            reg.LastName.SendKeys("Jovanovic");
            reg.UserName.SendKeys("jasonw");
            reg.Email.SendKeys("jovaJO@nestse.oorg");
            reg.Phone.SendKeys("003885255789");
            reg.Country.SelectByText("Serbia");
            reg.City.SelectByText("Novi Sad");
            reg.Address.SendKeys("Partizanska 180");
            reg.GenderM.Click();
            reg.Newsletter.Click();
            reg.Promotions.Click();
            reg.RegisterButton.Click();
        }


        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }

    }
}
