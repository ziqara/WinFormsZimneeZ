using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TSalesHistory
    {
        private SalesHistory salesHistory;
        private List<ProductInfo> testProducts;
        private readonly List<List<ProductInfo>> _allTestCases = new List<List<ProductInfo>>();

        [TestInitialize]
        public void TestInitialize()
        {
            salesHistory = new SalesHistory();
            testProducts = new List<ProductInfo>();

            // Инициализация всех тестовых случаев
            _allTestCases.Clear();

            // 0: Пустой список
            _allTestCases.Add(new List<ProductInfo>());

            // 1: Один продукт, одна продажа в июне
            _allTestCases.Add(new List<ProductInfo>
            {
                new ProductInfo { Name = "Product1", QuantitySold = 50, LastSell = new DateTime(2023, 6, 15) }
            });

            // 2: Несколько продуктов
            _allTestCases.Add(new List<ProductInfo>
            {
                new ProductInfo { Name = "Product2", QuantitySold = 20, LastSell = new DateTime(2023, 1, 10) },
                new ProductInfo { Name = "Product2", QuantitySold = 30, LastSell = new DateTime(2023, 2, 15) },
                new ProductInfo { Name = "Product2", QuantitySold = 50, LastSell = new DateTime(2023, 2, 20) }
            });

            // 3: Тест округления процентов
            _allTestCases.Add(new List<ProductInfo>
            {
                new ProductInfo { Name = "Product3", QuantitySold = 1, LastSell = new DateTime(2023, 3, 5) },
                new ProductInfo { Name = "Product3", QuantitySold = 2, LastSell = new DateTime(2023, 4, 5) }
            });

            // 4: Группировка по имени продукта
            _allTestCases.Add(new List<ProductInfo>
            {
                new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 5, 1) },
                new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 6, 1) },
                new ProductInfo { Name = "Product4", QuantitySold = 80, LastSell = new DateTime(2023, 7, 1) }
            });
        }

        private void SetupTestProducts(int testCaseIndex)
        {
            testProducts.Clear();
            salesHistory = new SalesHistory();

            if (testCaseIndex >= 0 && testCaseIndex < _allTestCases.Count)
            {
                testProducts.AddRange(_allTestCases[testCaseIndex]);
            }

            foreach (var product in testProducts)
            {
                salesHistory.AddSales(product);
            }
        }

        [TestMethod]
        [DataRow(0, new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, DisplayName = "Тест пустого списка продаж")]
        [DataRow(1, new double[] { 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0 }, DisplayName = "Тест продажи одного продукта в июне")]
        [DataRow(2, new double[] { 20, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, DisplayName = "Тест нескольких продуктов")]
        [DataRow(3, new double[] { 0, 0, 33.33, 66.67, 0, 0, 0, 0, 0, 0, 0, 0 }, DisplayName = "Тест округления процентов")]
        [DataRow(4, new double[] { 0, 0, 0, 0, 10, 10, 80, 0, 0, 0, 0, 0 }, DisplayName = "Тест группировки по имени продукта")]
        public void TestGetSeasonSales(int testCaseIndex, double[] expectedMonthlyGrowth)
        {
            // Arrange
            SetupTestProducts(testCaseIndex);

            // Act
            var result = salesHistory.GetSeasonSales();

            // Assert
            if (testCaseIndex == 0)
            {
                Assert.AreEqual(0, result.Count, "Должен вернуть пустой список при отсутствии продаж");
                return;
            }

            var product = result.First();
            var actualMonthlyGrowth = new double[]
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

            CollectionAssert.AreEqual(expectedMonthlyGrowth, actualMonthlyGrowth,
                $"Ожидаемые проценты по месяцам: {string.Join(", ", expectedMonthlyGrowth)}. " +
                $"Фактические: {string.Join(", ", actualMonthlyGrowth)}");
        }
    }
}