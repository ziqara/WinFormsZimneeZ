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


        [TestClass]
        public class TGeneralSalesHistoryService
        {
            private SalesRepository _repository;
            private GeneralSalesHistoryService _service;

            [TestInitialize]
            public void TestInitialize()
            {
                _repository = new SalesRepository();
                _service = new GeneralSalesHistoryService(_repository);

                // Товар 1
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductA",
                    Category = "Category1",
                    QuantitySold = 50,
                    Price = 10,
                    Residue = 15,
                    LastSell = new DateTime(2023, 3, 10)
                });
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductA",
                    Category = "Category1",
                    QuantitySold = 70,
                    Price = 10,
                    Residue = 8,
                    LastSell = new DateTime(2023, 3, 15)
                });

                // Товар 2
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductB",
                    Category = "Category2",
                    QuantitySold = 90,
                    Price = 20,
                    Residue = 5,
                    LastSell = new DateTime(2023, 4, 1)
                });

                // Товар 3
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductC",
                    Category = "Category3",
                    QuantitySold = 30,
                    Price = 15,
                    Residue = 20,
                    LastSell = new DateTime(2023, 2, 28)
                });

                // Товар 4 — нулевой остаток
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductD",
                    Category = "Category4",
                    QuantitySold = 40,
                    Price = 12,
                    Residue = 10,
                    LastSell = new DateTime(2023, 3, 5)
                });
                _service.AddSales(new ProductInfo
                {
                    Name = "ProductD",
                    Category = "Category4",
                    QuantitySold = 20,
                    Price = 12,
                    Residue = 0,
                    LastSell = new DateTime(2023, 3, 20)
                });
            }

            [DataTestMethod]
            [DataRow(new string[] { "ProductA", "ProductB", "ProductD", "ProductC" })]
            public void TestShowBestSellingProducts(string[] expectedProducts)
            {
                // Act
                BindingList<ProductInfo> result = _service.ShowBestSellingProducts();

                // Assert
                var actualProducts = result.Select(p => p.Name).ToList();

                CollectionAssert.AreEqual(expectedProducts, actualProducts);
            }

            [DataTestMethod]
            [DataRow(new string[] { "ProductD" })]
            public void TestGetProductsWithZeroResidueAndLatestSale(string[] expectedProducts)
            {
                // Act
                BindingList<ProductInfo> result = _service.GetProductsWithZeroResidueAndLatestSale();

                // Assert
                var actualProducts = result.Select(p => p.Name).ToList();

                CollectionAssert.AreEqual(expectedProducts, actualProducts);
            }
        }
    }
}