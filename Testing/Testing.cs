using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using MyLib.Services;

namespace Testing
{
    [TestClass]
    public class TSeasonSalesHistoryService
    {
        private SalesRepository _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new SalesRepository();

            // Товар 1 (январские продажи)
            _repository.AddSales(new ProductInfo
            {
                Name = "Product1",
                QuantitySold = 30,
                LastSell = new DateTime(2023, 1, 10)
            });
            _repository.AddSales(new ProductInfo
            {
                Name = "Product1",
                QuantitySold = 20,
                LastSell = new DateTime(2023, 1, 15)
            });

            // Товар 2 (февральские продажи)
            _repository.AddSales(new ProductInfo
            {
                Name = "Product2",
                QuantitySold = 40,
                LastSell = new DateTime(2023, 2, 5)
            });
            _repository.AddSales(new ProductInfo
            {
                Name = "Product2",
                QuantitySold = 60,
                LastSell = new DateTime(2023, 2, 20)
            });
        }

        [DataTestMethod]
        [DataRow("Product1", new double[] { 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [DataRow("Product2", new double[] { 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })]
        public void TestProductSalesDistribution(string productName, double[] expectedDistribution)
        {
            // Act
            var result = new SeasonSalesHistoryService(_repository).GetSeasonSales();
            var productsDict = result.ToDictionary(p => p.Name);
            var product = productsDict[productName];

            // Assert
            var actualDistribution = new[]
            {
            product.JanuaryGrowth,
            product.FebruaryGrowth,
            product.MarchGrowth,
            product.AprilGrowth,
            product.MayGrowth,
            product.JuneGrowth,
            product.JulyGrowth,
            product.AugustGrowth,
            product.SeptemberGrowth,
            product.OctoberGrowth,
            product.NovemberGrowth,
            product.DecemberGrowth
            };

            CollectionAssert.AreEqual(expectedDistribution, actualDistribution);
        }
    }
}