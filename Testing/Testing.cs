using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace Testing
{
    [TestClass]
    public class TSellProduct
    {
        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void TestGetProductsWithLastSaleResidueZero_DynamicData(
            List<ProductInfo> products,
            List<ProductInfo> expected)
        {
            // Act
            var actual = SalesHistory.GetProductsWithZeroResidueAndLatestSale(products);

            // Assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        public static IEnumerable<object[]> GetTestCases()
        {
            // Тестовый кейс 1: Один продукт с последней датой и нулевым остатком
            yield return new object[]
            {
                new List<ProductInfo>
                {
                    new ProductInfo("Product1", "Category1", 100, 1, new DateTime(2023, 10, 1)),
                    new ProductInfo("Product2", "Category2", 200, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product3", "Category1", 300, 2, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product4", "Category3", 400, 2, new DateTime(2023, 8, 20))
                },
                new List<ProductInfo>
                {
                    new ProductInfo("Product2", "Category2", 200, 0, new DateTime(2023, 10, 5))
                }
            };

            // Тестовый кейс 2: Несколько продуктов с последней датой и нулевым остатком
            yield return new object[]
            {
                new List<ProductInfo>
                {
                    new ProductInfo("Product1", "Category1", 200, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product2", "Category2", 200, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product3", "Category1", 300, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product4", "Category3", 400, 2, new DateTime(2023, 08, 20))
                },
                new List<ProductInfo>
                {
                    new ProductInfo("Product1", "Category1", 100, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product2", "Category2", 200, 0, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product3", "Category1", 300, 0, new DateTime(2023, 10, 5))
                }
            };

            // Тестовый кейс 3: Нет продуктов с последней датой и нулевым остатком (возвращается пустой список)
            yield return new object[]
            {
                new List<ProductInfo>
                {
                    new ProductInfo ("Product1", "Category1", 100, 1, new DateTime(2023, 10, 1)),
                    new ProductInfo("Product2", "Category2", 200, 1, new DateTime(2023, 09, 15)),
                    new ProductInfo("Product3", "Category1", 300, 2, new DateTime(2023, 10, 5)),
                    new ProductInfo("Product4", "Category3", 400, 0, new DateTime(2023, 08, 20))
                },
                new List<ProductInfo>() // Ожидается пустой список
            };
        }
    }
}
