﻿namespace Bakery.UITests
{
    using System.Configuration;

    using Bakery.UITests.Infraestructure;
    using Bakery.UITests.PageObjects;
    using Bakery.Web.Database;
    using Bakery.Web.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestClass]
    public class PurchasingCakes
    {
        private static IWebDriver driver;

        private static DataLoader dataLoader;
        [AssemblyInitialize]
        public static void SetupOnlyOnce(TestContext testContext)
        {
            driver = new ChromeDriver();
            dataLoader=new DataLoader();
        }

        [AssemblyCleanup]
        public static void TearDownOnlyOnce()
        {
            driver.Quit();
            dataLoader.Clean();
        }

        [TestMethod]
        public void SeeProductDetailsWhenPlacingOrder()
        {
            dataLoader.LoadData(new Product
                {
                    Name = "Apple Cake",
                    Description = "Default Descripcion",
                    Price = 8.99m,
                    ImageName = "carrot_cake.jpg"
                });

            var chooseProductPage = new ChooseProductPage(driver);
            chooseProductPage.Open();
            var placeOrderPage = chooseProductPage.GoToPlaceOrderForProduct("Apple Cake");

            Assert.IsTrue(placeOrderPage.ProductName.Contains("Apple Cake"));
            Assert.IsTrue(placeOrderPage.ProductPrice.Contains("8.99"));
        }

        [TestMethod]
        public void PurchaseOneCake()
        {

        }
    }
}