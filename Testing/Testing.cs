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
        public void FindSeasonalProducts_DynamicData(BindingList<ProductInfo> inputData, decimal percentageThreshold, BindingList<ProductInfo> expectedResult)
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
    } 
}



