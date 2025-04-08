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
        private SalesRepository salesRepository;
        // Тестовые случаи: каждая коллекция продаж для одного теста
        private List<List<ProductInfo>> _allTestCases = new List<List<ProductInfo>>();

        [TestInitialize]
        public void TestInitialize()
        {
            salesRepository = new SalesRepository();

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
        [DataRow(0, "", "0,0,0,0,0,0,0,0,0,0,0,0", DisplayName = "Пустой список продаж")]
        [DataRow(1, "Product1", "0,0,0,0,0,100,0,0,0,0,0,0", DisplayName = "Одна продажа в июне")]
        [DataRow(2, "Product2", "20,80,0,0,0,0,0,0,0,0,0,0", DisplayName = "Несколько продаж одного продукта")]
        [DataRow(3, "Product3", "0,0,33.33,66.67,0,0,0,0,0,0,0,0", DisplayName = "Тест округления процентов")]
        [DataRow(4, "Product4", "0,0,0,0,10,10,80,0,0,0,0,0", DisplayName = "Группировка по продукту")]
        public void TestGetSeasonSales(int testCaseIndex, string expectedName, string expectedGrowthCsv)
        {
            // Arrange: создаем новый экземпляр репозитория и добавляем данные тестового случая
            salesRepository = new SalesRepository();
            foreach (var product in _allTestCases[testCaseIndex])
            {
                salesRepository.AddSales(product);
            }

            // Act: создаем сервис для сезонного анализа и вызываем метод GetSeasonSales
            SeasonSalesHistoryService service = new SeasonSalesHistoryService(salesRepository);
            BindingList<SeasonProductInfo> result = service.GetSeasonSales();

            // Если тестовый случай пустой, проверяем, что список пуст
            if (testCaseIndex == 0)
            {
                Assert.AreEqual(0, result.Count, "Ожидается пустой список при отсутствии продаж.");
                return;
            }

            // Парсинг ожидаемых процентных значений из CSV-строки
            double[] expectedGrowth = expectedGrowthCsv.Split(',')
                .Select(s => Math.Round(double.Parse(s.Trim(), CultureInfo.InvariantCulture), 2))
                .ToArray();

            // Формируем ожидаемый объект
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

            // Получаем фактический объект (первый в списке)
            SeasonProductInfo actual = result.First();

            // Если класс SeasonProductInfo реализует корректное сравнение (Equals/GetHashCode),
            // можно сравнить списки напрямую:
            var expectedList = new List<SeasonProductInfo> { expected };
            var actualList = new List<SeasonProductInfo> { actual };

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
