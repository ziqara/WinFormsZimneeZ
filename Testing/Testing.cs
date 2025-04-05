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
        [TestMethod]
        public void TestFindTrendingProducts()
        public void TestGetSeasonSales(int productCount, double januaryGrowth, double februaryGrowth, double marchGrowth, double aprilGrowth)
        {
            // Arrange
            var salesHistory = new SalesHistory();
            var referenceDate = new DateTime(2023, 10, 15);
            var allSales = salesHistory.GetAllSales();

            // 1. Тест: нет продаж - должен вернуть пустой список
            var result1 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(0, result1.Count, "Должен вернуть пустой список при отсутствии продаж");

            // 2. Тест: продажи ниже порога (5/3 = 1.67 < 2)
            allSales.Add(new ProductInfo { Name = "Product1", QuantitySold = 5, LastSell = referenceDate.AddDays(-7) });
            allSales.Add(new ProductInfo { Name = "Product1", QuantitySold = 3, LastSell = referenceDate.AddDays(-21) });

            var result2 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(0, result2.Count, "Не должен находить тренд при росте продаж менее чем в 2 раза");

            // 3. Тест: продажи выше порога (10/4 = 2.5 >= 2)
            allSales.Add(new ProductInfo { Name = "Product2", QuantitySold = 10, LastSell = referenceDate.AddDays(-7) });
            allSales.Add(new ProductInfo { Name = "Product2", QuantitySold = 4, LastSell = referenceDate.AddDays(-21) });

            var result3 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(1, result3.Count, "Должен найти 1 трендовый продукт");
            Assert.AreEqual("Product2", result3[0].Name, "Должен вернуть правильное имя продукта");
            Assert.AreEqual(2.5, result3[0].IncreaseFactor, "Должен правильно рассчитать фактор роста");

            // 4. Тест: проверка использования данных последней продажи
            allSales.Add(new ProductInfo
            {
                Name = "Product3",
                Category = "OldCat",
                Price = 5.0m,
                QuantitySold = 4,
                LastSell = referenceDate.AddDays(-21)
            });
            allSales.Add(new ProductInfo
            {
                Name = "Product3",
                Category = "NewCat",
                Price = 10.0m,
                QuantitySold = 10,
                LastSell = referenceDate.AddDays(-7)
            });

            var result4 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual("NewCat", result4[1].Category, "Должен использовать категорию из последней продажи");
            Assert.AreEqual(10.0m, result4[1].Price, "Должен использовать цену из последней продажи");

            // 5. Тест: несколько продуктов, только один трендовый
            allSales.Add(new ProductInfo { Name = "Product4", QuantitySold = 5, LastSell = referenceDate.AddDays(-7) });
            allSales.Add(new ProductInfo { Name = "Product4", QuantitySold = 3, LastSell = referenceDate.AddDays(-21) });

            var result5 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(2, result5.Count, "Должен найти только трендовые продукты");
            Assert.IsTrue(result5.Any(p => p.Name == "Product2"), "Должен содержать Product2");
            Assert.IsTrue(result5.Any(p => p.Name == "Product3"), "Должен содержать Product3");
            Assert.IsFalse(result5.Any(p => p.Name == "Product1"), "Не должен содержать Product1");
            Assert.IsFalse(result5.Any(p => p.Name == "Product4"), "Не должен содержать Product4");

            // 6. Тест: нулевые продажи в предыдущем периоде
            allSales.Add(new ProductInfo { Name = "Product5", QuantitySold = 10, LastSell = referenceDate.AddDays(-7) });

            var result6 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(2, result6.Count, "Не должен учитывать продукты без продаж в предыдущем периоде");

            // 7. Тест: проверка расчета периодов
            allSales.Clear();
            allSales.Add(new ProductInfo { Name = "Product6", QuantitySold = 10, LastSell = referenceDate.AddDays(-7) });
            allSales.Add(new ProductInfo { Name = "Product6", QuantitySold = 4, LastSell = referenceDate.AddDays(-15) });

            var result7 = salesHistory.FindTrendingProducts(referenceDate, 2);
            Assert.AreEqual(1, result7.Count, "Должен правильно рассчитывать периоды");
            Assert.AreEqual(2.5, result7[0].IncreaseFactor, 0.01, "Должен правильно считать фактор для рассчитанных периодов");
        }

        [TestMethod]
        public void TestGetSeasonSales()
        {
            // Arrange
            var salesHistory = new SalesHistory();

            // 1. Тест пустого списка
            var emptyResult = salesHistory.GetSeasonSales();
            Assert.AreEqual(0, emptyResult.Count, "Должен вернуть пустой список при отсутствии продаж");

            // 2. Тест с одним продуктом и одним месяцем
            salesHistory.AddSales(new ProductInfo { Name = "Product1", QuantitySold = 50, LastSell = new DateTime(2023, 6, 15) });

            var singleProductResult = salesHistory.GetSeasonSales();
            Assert.AreEqual(1, singleProductResult.Count, "Должен вернуть один продукт");
            Assert.AreEqual(100.0, singleProductResult[0].JuneGrowth, 0.01, "Должен показать 100% для июня");
            Assert.AreEqual(0.0, singleProductResult[0].JanuaryGrowth, 0.01, "Должен показать 0% для января");

            // 3. Тест с несколькими продуктами и месяцами
            salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 20, LastSell = new DateTime(2023, 1, 10) });
            salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 30, LastSell = new DateTime(2023, 2, 15) });
            salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 50, LastSell = new DateTime(2023, 2, 20) });

            var multiProductResult = salesHistory.GetSeasonSales();
            var product2 = multiProductResult.First(p => p.Name == "Product2");

            Assert.AreEqual(20.0, product2.JanuaryGrowth, 0.01, "Неправильный процент для января (20/100=20%)");
            Assert.AreEqual(80.0, product2.FebruaryGrowth, 0.01, "Неправильный процент для февраля (80/100=80%)");
            Assert.AreEqual(0.0, product2.MarchGrowth, 0.01, "Должен быть 0% для месяцев без продаж");

            // 4. Тест округления процентов
            salesHistory.AddSales(new ProductInfo { Name = "Product3", QuantitySold = 1, LastSell = new DateTime(2023, 3, 5) });
            salesHistory.AddSales(new ProductInfo { Name = "Product3", QuantitySold = 2, LastSell = new DateTime(2023, 4, 5) });

            var roundingResult = salesHistory.GetSeasonSales();
            var product3 = roundingResult.First(p => p.Name == "Product3");

            Assert.AreEqual(33.33, product3.MarchGrowth, 0.01, "Должен округлить 1/3 до 33.33%");
            Assert.AreEqual(66.67, product3.AprilGrowth, 0.01, "Должен округлить 2/3 до 66.67%");

            // 5. Тест группировки по имени продукта
            salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 5, 1) });
            salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 6, 1) });
            salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 80, LastSell = new DateTime(2023, 7, 1) });

            var groupedResult = salesHistory.GetSeasonSales();
            var product4 = groupedResult.First(p => p.Name == "Product4");

            Assert.AreEqual(4, groupedResult.Count, "Должен сгруппировать по имени продукта");
            Assert.AreEqual(10.0, product4.MayGrowth, 0.01, "10% мая (10/100)");
            Assert.AreEqual(10.0, product4.JuneGrowth, 0.01, "10% июня (10/100)");
            Assert.AreEqual(80.0, product4.JulyGrowth, 0.01, "80% июля (80/100)");
        }
    }
}
    



