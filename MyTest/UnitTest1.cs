using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTest
{
    [TestClass]
    public class TSellProduct
    {
        [TestMethod]

        public void TestGetProductsWithLastSaleResidueZero()
        {
            // Arrange
            var products = new List<SellProduct>
        {
            new SellProduct("Product1", "Category1", 100, 1, new DateTime(2023, 10, 1)),
            new SellProduct("Product2", "Category2", 200, 0, new DateTime(2023, 10, 5)), // Последняя продажа с остатком 0
            new SellProduct("Product3", "Category1", 300, 0, new DateTime(2023, 10, 5)), // Последняя продажа с остатком 0
            new SellProduct("Product4", "Category3", 400, 2, new DateTime(2023, 8, 20))
        };

            // Act
            var result = SellProduct.GetProductsWithLastSaleResidueZero(products);

            // Assert
            Assert.AreEqual(2, result.Count); // Ожидаем два продукта
        }
    }
}
