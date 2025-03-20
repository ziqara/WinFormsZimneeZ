using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
    public class SalesHistory
    {
        List<ProductInfo> AllSales_ = new List<ProductInfo>();
        public void AddAllSales()
        {
            AllSales_.Add(new ProductInfo("Смартфон Galaxy S23", "Электроника", 10.00m, 65, 0, new DateTime(2025, 06, 20)));
            AllSales_.Add(new ProductInfo("Ноутбук Dell XPS 15", "Электроника", 20.50m, 10, 10, new DateTime(2025, 03, 20)));
            AllSales_.Add(new ProductInfo("Футболка мужская хлопок", "Одежда", 5.75m, 20, 0, new DateTime(2025, 03, 22)));
            AllSales_.Add(new ProductInfo("Футболка мужская хлопок", "Одежда", 5.75m, 20, 15, new DateTime(2025, 03, 20)));

            AllSales_.Add(new ProductInfo("Книга 'Мастер и Маргарита'", "Книги", 15.00m, 15, 5, new DateTime(2025, 03, 21)));
            AllSales_.Add(new ProductInfo("Наушники беспроводные Sony", "Электроника", 25.00m, 5, 20, new DateTime(2025, 03, 22)));
            AllSales_.Add(new ProductInfo("Кофе молотый Lavazza", "Продукты", 8.50m, 30, 8, new DateTime(2025, 03, 23)));
            AllSales_.Add(new ProductInfo("Шампунь для волос Pantene", "Косметика", 12.00m, 12, 12, new DateTime(2025, 03, 24)));
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 2, new DateTime(2025, 03, 25)));
            AllSales_.Add(new ProductInfo("Зубная паста Colgate", "Гигиена", 6.25m, 22, 18, new DateTime(2025, 03, 26)));
        }


        public List<ProductInfo> GetAllSales()
        {
            return AllSales_;
        }

        public void AddSales(ProductInfo newProduct)
        {
            AllSales_.Add(newProduct);
        }

        public BindingList<ProductInfo> ShowBestSellingProducts()
        {
            var topProducts = AllSales_
                .GroupBy(p => new { p.Name, p.Category })
                .Select(g =>
                {
                    var lastProduct = g.OrderByDescending(p => p.LastSell).First();
                    return new
                    {
                        g.Key.Name,
                        g.Key.Category,
                        TotalQuantitySold = g.Sum(p => p.QuantitySold),
                        g.First().Price,
                        lastProduct.Residue,
                        lastProduct.LastSell
                    };
                })
                .OrderByDescending(x => x.TotalQuantitySold).Take(10);

            
            BindingList<ProductInfo> bestSellingProducts = new BindingList<ProductInfo>();

            
            foreach (var item in topProducts)
            {
                
                ProductInfo aggregatedProduct = new ProductInfo(
                    item.Name,
                    item.Category,
                    item.Price,
                    item.TotalQuantitySold,
                    item.Residue,
                    item.LastSell
                );

                bestSellingProducts.Add(aggregatedProduct);
            }

            return bestSellingProducts;
        }


        public BindingList<ProductInfo> GetProductsWithZeroResidueAndLatestSale()
        {
            if (AllSales_ == null || AllSales_.Count == 0)
            {
                return new BindingList<ProductInfo>();
            }

            // Группируем продукты по имени и категории
            var groupedProducts = AllSales_
                .GroupBy(p => new { p.Name, p.Category })
                .Where(g => g.Any(p => p.Residue == 0)) // Фильтруем группы, где есть хотя бы один продукт с Residue == 0
                .Select(g => new ProductInfo
                {
                    Name = g.Key.Name,
                    Category = g.Key.Category,
                    Price = g.First().Price, // Берем цену из первого элемента группы
                    QuantitySold = g.Sum(p => p.QuantitySold), // Суммируем QuantitySold для всех элементов группы
                    Residue = 0, // Указываем Residue = 0, так как группа содержит хотя бы один продукт с Residue == 0
                    LastSell = g.Max(p => p.LastSell) // Находим максимальную дату продажи в группе
                })
                .ToList();

            return new BindingList<ProductInfo>(groupedProducts);
        }
    }
}
