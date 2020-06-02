using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Vezba31.PageObjects;
using QaHomePage = Vezba31.PageObjects.HomePage;
using QaListPage = Vezba31.PageObjects.ListPage;


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
            lista= naslovna.ClickOnList();

             Assert.GreaterOrEqual(lista.FemaleUsers, 30);
            //Assert.GreaterOrEqual(lista.MaleUsers, 30);

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
