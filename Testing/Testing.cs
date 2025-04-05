using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TSalesHistory
    {

        [TestMethod]
        [DataRow(0, 0, 0, 0, 0, DisplayName = "Тест пустого списка продаж")]
        [DataRow(1, 50, 1, 100, 0, DisplayName = "Тест продажи одного продукта в июне")]
        [DataRow(3, 20, 20, 30, 50, DisplayName = "Тест нескольких продуктов")]
        [DataRow(1, 1, 2, 33.33, 66.67, DisplayName = "Тест округления процентов")]
        [DataRow(4, 10, 10, 80, 10, DisplayName = "Тест группировки по имени продукта")]
        public void TestGetSeasonSales(int productCount, double januaryGrowth, double februaryGrowth, double marchGrowth, double aprilGrowth)
        {
            // Arrange
            var salesHistory = new SalesHistory();
            
            // Добавление продаж
            if (productCount == 0)
            {
                // Пустой список
                var emptyResult = salesHistory.GetSeasonSales();
                Assert.AreEqual(0, emptyResult.Count, "Должен вернуть пустой список при отсутствии продаж");
            }
            else
            {
                if (productCount == 1)
                {
                    // Пример с одним продуктом и одной продажей
                    salesHistory.AddSales(new ProductInfo { Name = "Product1", QuantitySold = 50, LastSell = new DateTime(2023, 6, 15) });
                    var result = salesHistory.GetSeasonSales();
                    Assert.AreEqual(1, result.Count, "Должен вернуть один продукт");
                    Assert.AreEqual(100.0, result[0].JuneGrowth, 0.01, "Должен показать 100% для июня");
                    Assert.AreEqual(0.0, result[0].JanuaryGrowth, 0.01, "Должен показать 0% для января");
                }
                else if (productCount == 3)
                {
                    // Пример с несколькими продуктами и месяцами
                    salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 20, LastSell = new DateTime(2023, 1, 10) });
                    salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 30, LastSell = new DateTime(2023, 2, 15) });
                    salesHistory.AddSales(new ProductInfo { Name = "Product2", QuantitySold = 50, LastSell = new DateTime(2023, 2, 20) });

                    var multiProductResult = salesHistory.GetSeasonSales();
                    var product2 = multiProductResult.First(p => p.Name == "Product2");

                    Assert.AreEqual(20.0, product2.JanuaryGrowth, 0.01, "Неправильный процент для января (20/100=20%)");
                    Assert.AreEqual(80.0, product2.FebruaryGrowth, 0.01, "Неправильный процент для февраля (80/100=80%)");
                    Assert.AreEqual(0.0, product2.MarchGrowth, 0.01, "Должен быть 0% для месяцев без продаж");
                }
                else if (productCount == 1)
                {
                    // Пример округления процентов
                    salesHistory.AddSales(new ProductInfo { Name = "Product3", QuantitySold = 1, LastSell = new DateTime(2023, 3, 5) });
                    salesHistory.AddSales(new ProductInfo { Name = "Product3", QuantitySold = 2, LastSell = new DateTime(2023, 4, 5) });

                    var roundingResult = salesHistory.GetSeasonSales();
                    var product3 = roundingResult.First(p => p.Name == "Product3");

                    Assert.AreEqual(33.33, product3.MarchGrowth, 0.01, "Должен округлить 1/3 до 33.33%");
                    Assert.AreEqual(66.67, product3.AprilGrowth, 0.01, "Должен округлить 2/3 до 66.67%");
                }
                else if (productCount == 4)
                {
                    // Пример группировки по продукту
                    salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 5, 1) });
                    salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 10, LastSell = new DateTime(2023, 6, 1) });
                    salesHistory.AddSales(new ProductInfo { Name = "Product4", QuantitySold = 80, LastSell = new DateTime(2023, 7, 1) });

                    var groupedResult = salesHistory.GetSeasonSales();
                    var product4 = groupedResult.First(p => p.Name == "Product4");

                    Assert.AreEqual(10.0, product4.MayGrowth, 0.01, "10% мая (10/100)");
                    Assert.AreEqual(10.0, product4.JuneGrowth, 0.01, "10% июня (10/100)");
                    Assert.AreEqual(80.0, product4.JulyGrowth, 0.01, "80% июля (80/100)");
                }
            }
        }

        
    }
}
