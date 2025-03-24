using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TSellProduct
    {
        [TestMethod]
        [DynamicData(nameof(FindSeasonalProductsData), DynamicDataSourceType.Method)]
        public void TESTFindSeasonalProductsTEST(BindingList<ProductInfo> inputData, decimal percentageThreshold, BindingList<ProductInfo> expectedResult)
        {
            SalesHistory history = new SalesHistory();

            BindingList<ProductInfo> actualResult = history.FindSeasonalProducts(inputData, percentageThreshold);

            // Проверяем, что количество элементов в ожидаемом и фактическом результатах совпадает
            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            // Сравниваем каждый объект ProductInfo в ожидаемом и фактическом результатах
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Name, actualResult[i].Name);           // Проверяем имя
                Assert.AreEqual(expectedResult[i].Category, actualResult[i].Category);   // Проверяем категорию
                Assert.AreEqual(expectedResult[i].Price, actualResult[i].Price);         // Проверяем цену
                Assert.AreEqual(expectedResult[i].QuantitySold, actualResult[i].QuantitySold); // Проверяем количество проданного товара
                Assert.AreEqual(expectedResult[i].Residue, actualResult[i].Residue);       // Проверяем остаток
                Assert.AreEqual(expectedResult[i].LastSell, actualResult[i].LastSell);     // Проверяем дату последней продажи
            }
        }
        [TestMethod]
        [DynamicData(nameof(FindTrendingProductsData), DynamicDataSourceType.Method)]
        public void FindTrendingProducts_DynamicData(BindingList<ProductInfo> data, int trendingWeeks, BindingList<ProductInfo> expected)
        {
            
            SalesHistory history = new SalesHistory();
            
            BindingList<ProductInfo> actual = history.FindTrendingProducts(data, trendingWeeks);

            Assert.AreEqual(expected.Count, actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, actual[i].Name);
                Assert.AreEqual(expected[i].Category, actual[i].Category);
                Assert.AreEqual(expected[i].Price, actual[i].Price);
                Assert.AreEqual(expected[i].QuantitySold, actual[i].QuantitySold);
                Assert.AreEqual(expected[i].Residue, actual[i].Residue);
                Assert.AreEqual(expected[i].LastSell.Date, actual[i].LastSell.Date);
            }
        }








        public static IEnumerable<object[]> FindSeasonalProductsData()
        {

            // Один продукт, один месяц
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15))
                },
                20m,
                new BindingList<ProductInfo>() // Пустой список
            };

            // Один продукт, два месяца
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15)),
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 50, 50, new DateTime(2023, 2, 15))
                },
                50m,
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15))
                }
            };

            //Два одинаковых продукта
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15)),
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 2, 15))
                },
                50m,
                new BindingList<ProductInfo>() {}
            };

            // Два продукта, один сезонный, второй нет
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15)),
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 50, 50, new DateTime(2023, 2, 15)),
                    new ProductInfo("Товар B", "Категория 2", 10.00m, 100, 50, new DateTime(2023, 1, 15)),
                    new ProductInfo("Товар B", "Категория 2", 10.00m, 100, 50, new DateTime(2023, 2, 15))
                },
                50m,
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15))
                }
            };

            //Продажа продукта в разных месяцах
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 100, 50, new DateTime(2023, 1, 15)),
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 50, 50, new DateTime(2023, 1, 16)),
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 50, 50, new DateTime(2023, 2, 15)),
                },
                50m,
                new BindingList<ProductInfo>() {
                    new ProductInfo("Товар A", "Категория 1", 10.00m, 150, 50, new DateTime(2023, 1, 15))
                }
            };

            //Два продукта сезонные
            yield return new object[] {
                new BindingList<ProductInfo>() {
                    new ProductInfo("Test", "Test", 6.25m, 22, 18, new DateTime(2025, 03, 26)),
                    new ProductInfo("Test", "Test", 6.25m, 8, 18, new DateTime(2025, 04, 26)),
                    new ProductInfo("Test", "Test", 6.25m, 25, 18, new DateTime(2025, 05, 26)),
                    new ProductInfo("Test2", "Test", 6.25m, 22, 18, new DateTime(2025, 03, 26)),
                    new ProductInfo("Test2", "Test", 6.25m, 8, 18, new DateTime(2025, 04, 26)),
                    new ProductInfo("Test2", "Test", 6.25m, 25, 18, new DateTime(2025, 05, 26)),
                },
                20m,
                new BindingList<ProductInfo>() {
                    new ProductInfo("Test", "Test", 6.25m, 25, 18, new DateTime(2025, 5, 26)),
                    new ProductInfo("Test2", "Test", 6.25m, 25, 18, new DateTime(2025, 5, 26)),
                }
            };
        }

        public static IEnumerable<object[]> FindTrendingProductsData()
        {
            DateTime today = DateTime.Today;

            //Нет данных, должен вернуть пустой список
            yield return new object[]
            {
                new BindingList<ProductInfo>(), // данные
                2,                             // trendingWeeks (недели для тренда)
                new BindingList<ProductInfo>()  // ожидаемый результат
            };

            //Трендовый товар за 2 недели
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-16)),
                    new ProductInfo("Product A", "Category", 10, 30, 0, today.AddDays(-2)),
                },
                2,
                new BindingList<ProductInfo>()
                {
                new ProductInfo("Product A", "Category", 10, 30, 0, today.AddDays(-2))
                }
            };

            //Не трендовый, нет роста продаж
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-16)),
                    new ProductInfo("Product A", "Category", 10, 12, 0, today.AddDays(-2)),
                },
                2,
                new BindingList<ProductInfo>()
            };

            //Был трендовым, но перестал быть
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 30, 0, today.AddDays(-16)),
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-2)),
                },
                2,
                new BindingList<ProductInfo>()
            };

            //Два товара, один трендовый, другой нет
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-16)),
                    new ProductInfo("Product A", "Category", 10, 30, 0, today.AddDays(-2)),
                    new ProductInfo("Product B", "Category", 10, 10, 0, today.AddDays(-16)),
                    new ProductInfo("Product B", "Category", 10, 12, 0, today.AddDays(-2)),
                },
                2,
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 30, 0, today.AddDays(-2))
                }
            };

            //Ровно двукратный рост продаж
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-16)), 
                    new ProductInfo("Product A", "Category", 10, 20, 0, today.AddDays(-2)), 
                },
                2,
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 20, 0, today.AddDays(-2))
                }
            };

            //Проверка что выбирается последняя версия товара
            yield return new object[]
            {
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 10, 0, today.AddDays(-16)),
                    new ProductInfo("Product A", "Category", 10, 20, 0, today.AddDays(-2)),
                    new ProductInfo("Product A", "Category", 10, 5, 0, today.AddDays(-6)), 
                },
                2,
                new BindingList<ProductInfo>()
                {
                    new ProductInfo("Product A", "Category", 10, 20, 0, today.AddDays(-2))
                }
            };
        }

    }
 }



