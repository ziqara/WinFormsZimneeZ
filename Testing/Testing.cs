using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TSalesHistory
    {
        private SalesHistory salesHistory;
        // Тестовые случаи: каждая коллекция продаж для одного теста
        private List<List<ProductInfo>> _allTestCases = new List<List<ProductInfo>>();

        [TestInitialize]
        public void TestInitialize()
        {
            salesHistory = new SalesHistory();

            _allTestCases.Clear();

            // 0: Пустой список
            _allTestCases.Add(new List<ProductInfo>());

            // 1: Один продукт, одна продажа в июне
            _allTestCases.Add(new List<ProductInfo>
            {
                new ProductInfo { Name = "Product1", QuantitySold = 50, LastSell = new DateTime(2023, 6, 15) }
            });

            // 2: Несколько продаж одного продукта
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

        [DataTestMethod]
        [DataRow(0, "Product1", "0,0,0,0,0,100,0,0,0,0,0,0", DisplayName = "Тест пустого списка продаж")]
        [DataRow(1, "Product1", "0,0,0,0,0,100,0,0,0,0,0,0", DisplayName = "Тест продажи одного продукта в июне")]
        [DataRow(2, "Product2", "20,80,0,0,0,0,0,0,0,0,0,0", DisplayName = "Тест нескольких продаж одного продукта")]
        [DataRow(3, "Product3", "0,0,33.33,66.67,0,0,0,0,0,0,0,0", DisplayName = "Тест округления процентов")]
        [DataRow(4, "Product4", "0,0,0,0,10,10,80,0,0,0,0,0", DisplayName = "Тест группировки по имени продукта")]
        public void TestGetSeasonSales(int testCaseIndex, string expectedName, string expectedGrowthCsv)
        {
            // Arrange: создаём новый экземпляр SalesHistory и добавляем данные из тестового случая
            salesHistory = new SalesHistory();
            foreach (var product in _allTestCases[testCaseIndex])
            {
                salesHistory.AddSales(product);
            }

            // Act: вызываем метод GetSeasonSales
            BindingList<SeasonProductInfo> result = salesHistory.GetSeasonSales();

            // Assert: если список пустой, проверяем, что он пустой
            if (testCaseIndex == 0)
            {
                Assert.AreEqual(0, result.Count, "Ожидается пустой список при отсутствии продаж.");
                return;
            }

            // Создаем ожидаемый объект SeasonProductInfo на основе входных данных
            double[] expectedGrowth = expectedGrowthCsv.Split(',')
                .Select(s => Math.Round(double.Parse(s.Trim(), CultureInfo.InvariantCulture), 2))
                .ToArray();

            SeasonProductInfo expected = new SeasonProductInfo
            {
                Name = expectedName,
                JanuaryGrowth = expectedGrowth[0],
                FebruaryGrowth = expectedGrowth[1],
                MarchGrowth = expectedGrowth[2],
                AprilGrowth = expectedGrowth[3],
                MayGrowth = expectedGrowth[4],
                JuneGrowth = expectedGrowth[5],
                JulyGrowth = expectedGrowth[6],
                AugustGrowth = expectedGrowth[7],
                SeptemberGrowth = expectedGrowth[8],
                OctoberGrowth = expectedGrowth[9],
                NovemberGrowth = expectedGrowth[10],
                DecemberGrowth = expectedGrowth[11]
            };

            // Получаем фактический объект (например, первый в списке)
            SeasonProductInfo actual = result.First();

            // Помещаем объекты в списки и сравниваем их через CollectionAssert
            var expectedList = new List<SeasonProductInfo> { expected };
            var actualList = new List<SeasonProductInfo> { actual };

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
