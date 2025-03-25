using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
    public class SalesHistory
    {
        BindingList<ProductInfo> AllSales_ = new BindingList<ProductInfo>();
        public void AddAllSales()
        {
            AllSales_.Add(new ProductInfo("321 '321'", "Продукты", 3.50m, 10, 18, new DateTime(2025, 03, 10)));
            AllSales_.Add(new ProductInfo("321 '321'", "Продукты", 3.50m, 30, 18, new DateTime(2025, 03, 24)));

            AllSales_.Add(new ProductInfo("123 '123'", "Продукты", 3.50m, 10, 18, new DateTime(2025, 03, 3)));
            AllSales_.Add(new ProductInfo("123 '123'", "Продукты", 3.50m, 30, 18, new DateTime(2025, 03, 24)));

            AllSales_.Add(new ProductInfo("Смартфон Galaxy S23", "Электроника", 10.00m, 65, 0, new DateTime(2025, 06, 20))); // Июнь
            AllSales_.Add(new ProductInfo("Смартфон Galaxy S23", "Электроника", 10.00m, 35, 0, new DateTime(2025, 07, 20))); // Июль

            AllSales_.Add(new ProductInfo("Ноутбук Dell XPS 15", "Электроника", 20.50m, 10, 10, new DateTime(2025, 03, 20))); // Март
            AllSales_.Add(new ProductInfo("Ноутбук Dell XPS 15", "Электроника", 20.50m, 12, 10, new DateTime(2025, 04, 20))); // Апрель

            AllSales_.Add(new ProductInfo("Футболка мужская хлопок", "Одежда", 5.75m, 20, 0, new DateTime(2025, 03, 22))); // Март
            AllSales_.Add(new ProductInfo("Футболка мужская хлопок", "Одежда", 5.75m, 20, 15, new DateTime(2025, 03, 20))); // Март
            AllSales_.Add(new ProductInfo("Футболка мужская хлопок", "Одежда", 5.75m, 22, 0, new DateTime(2025, 04, 22))); // Апрель

            AllSales_.Add(new ProductInfo("Книга 'Мастер и Маргарита'", "Книги", 15.00m, 15, 5, new DateTime(2025, 03, 21))); // Март
            AllSales_.Add(new ProductInfo("Книга 'Мастер и Маргарита'", "Книги", 15.00m, 5, 5, new DateTime(2025, 04, 21))); // Апрель
            AllSales_.Add(new ProductInfo("Книга 'Мастер и Маргарита'", "Книги", 15.00m, 25, 5, new DateTime(2025, 12, 21))); // Декабрь

            AllSales_.Add(new ProductInfo("Наушники беспроводные Sony", "Электроника", 25.00m, 5, 20, new DateTime(2025, 03, 22))); // Март
            AllSales_.Add(new ProductInfo("Наушники беспроводные Sony", "Электроника", 25.00m, 7, 20, new DateTime(2025, 05, 22))); // Май

            AllSales_.Add(new ProductInfo("Кофе молотый Lavazza", "Продукты", 8.50m, 30, 8, new DateTime(2025, 03, 23))); // Март
            AllSales_.Add(new ProductInfo("Кофе молотый Lavazza", "Продукты", 8.50m, 10, 8, new DateTime(2025, 04, 23))); // Апрель
            AllSales_.Add(new ProductInfo("Кофе молотый Lavazza", "Продукты", 8.50m, 15, 8, new DateTime(2025, 12, 23))); // Декабрь

            AllSales_.Add(new ProductInfo("Шампунь для волос Pantene", "Косметика", 12.00m, 12, 12, new DateTime(2025, 03, 24))); // Март
            AllSales_.Add(new ProductInfo("Шампунь для волос Pantene", "Косметика", 12.00m, 15, 12, new DateTime(2025, 02, 24))); // Февраль

            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 2, new DateTime(2025, 03, 25))); // Март
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 9, 2, new DateTime(2025, 01, 25))); // Январь

            AllSales_.Add(new ProductInfo("Зубная паста Colgate", "Гигиена", 6.25m, 22, 18, new DateTime(2025, 03, 26))); // Март
            AllSales_.Add(new ProductInfo("Зубная паста Colgate", "Гигиена", 6.25m, 8, 18, new DateTime(2025, 04, 26))); // Апрель
            AllSales_.Add(new ProductInfo("Зубная паста Colgate", "Гигиена", 6.25m, 25, 18, new DateTime(2025, 05, 26))); // Май

            AllSales_.Add(new ProductInfo("Телевизор Samsung QLED", "Электроника", 30.00m, 90, 0, new DateTime(2025, 12, 01))); // Декабрь
            AllSales_.Add(new ProductInfo("Телевизор Samsung QLED", "Электроника", 30.00m, 10, 0, new DateTime(2025, 01, 01))); // Январь
            AllSales_.Add(new ProductInfo("Телевизор Samsung QLED", "Электроника", 30.00m, 15, 0, new DateTime(2025, 11, 01))); // Ноябрь

            AllSales_.Add(new ProductInfo("Хлеб 'Бородинский'", "Продукты", 2.50m, 40, 20, new DateTime(2025, 02, 10))); // Февраль
            AllSales_.Add(new ProductInfo("Хлеб 'Бородинский'", "Продукты", 2.50m, 38, 20, new DateTime(2025, 03, 10))); // Март

            AllSales_.Add(new ProductInfo("Вода минеральная 'Аква'", "Продукты", 1.00m, 50, 50, new DateTime(2025, 07, 05))); // Июль

            AllSales_.Add(new ProductInfo("Молоко 'Простоквашино'", "Продукты", 3.20m, 25, 15, new DateTime(2025, 06, 15))); // Июнь
            AllSales_.Add(new ProductInfo("Молоко 'Простоквашино'", "Продукты", 3.20m, 28, 15, new DateTime(2025, 08, 15))); // Август

            AllSales_.Add(new ProductInfo("Кефир 'Домик в деревне'", "Продукты", 3.50m, 32, 18, new DateTime(2025, 05, 20))); // Май
            AllSales_.Add(new ProductInfo("Кефир 'Домик в деревне'", "Продукты", 3.50m, 30, 18, new DateTime(2025, 07, 20))); // Июль
        }


        public BindingList<ProductInfo> GetAllSales()
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

           
            var groupedProducts = AllSales_
                .GroupBy(p => new { p.Name, p.Category })
                .Where(g => g.Any(p => p.Residue == 0))
                .Select(g => new ProductInfo
                {
                    Name = g.Key.Name,
                    Category = g.Key.Category,
                    Price = g.First().Price,
                    QuantitySold = g.Sum(p => p.QuantitySold),
                    Residue = 0,
                    LastSell = g.Max(p => p.LastSell)
                })
                .ToList();

            return new BindingList<ProductInfo>(groupedProducts);
        }

        public BindingList<ProductInfo> FindSeasonalProducts(BindingList<ProductInfo> data, decimal percentageThreshold)
        {
            //Создаем новый BindingList для хранения результатов
            BindingList<ProductInfo> resultList = new BindingList<ProductInfo>();

            //Группируем данные по товару И месяцу и суммируем количество проданного товара
            var groupedSales = data.GroupBy(p => new { p.Name, p.LastSell.Month })
                                 .Select(g => new ProductInfo
                                 {
                                     Name = g.Key.Name,
                                     Category = g.First().Category, //  Сохраняем Category
                                     Price = g.First().Price,       //  Сохраняем Price
                                     QuantitySold = g.Sum(p => p.QuantitySold),
                                     Residue = g.First().Residue,   // Сохраняем Residue
                                     LastSell = new DateTime(g.First().LastSell.Year, g.Key.Month, g.First().LastSell.Day)// Используем месяц для сравнения
                                 })
                                 .ToList();

            //Определяем сезонность на основе просуммированных данных
            foreach (var product in groupedSales)
            {
                var monthlySales = groupedSales.Where(p => p.Name == product.Name).ToList();  // Фильтруем только текущий товар
                if (monthlySales.Count <= 1) continue; // Если только один месяц, пропускаем

                decimal averageSalesExcludingCurrentMonth;
                var otherMonthsSales = monthlySales.Where(ms => ms.LastSell.Month != product.LastSell.Month);

                if (otherMonthsSales.Any())
                {
                    averageSalesExcludingCurrentMonth = (decimal)otherMonthsSales.Average(ms => ms.QuantitySold);
                }
                else
                {
                    averageSalesExcludingCurrentMonth = 0;
                }

                decimal percentageIncrease = ((decimal)product.QuantitySold - averageSalesExcludingCurrentMonth) / averageSalesExcludingCurrentMonth * 100m;

                if (percentageIncrease > percentageThreshold)
                {
                    resultList.Add(product);
                }
            }

            //Убираем дубликаты.
            var distinctProducts = resultList.GroupBy(p => p.Name)
                                             .Select(g => g.OrderByDescending(p => p.QuantitySold).First())
                                             .ToList();

            resultList = new BindingList<ProductInfo>(distinctProducts);
            return resultList;
        }

        public BindingList<ProductInfo> FindTrendingProducts(BindingList<ProductInfo> data, int trendingWeeks)
        {
            BindingList<ProductInfo> trendingProducts = new BindingList<ProductInfo>();
            DateTime today = DateTime.Today;

            // Определяем дату начала периода анализа
            DateTime startDate = today.AddDays(-(trendingWeeks * 7));
            int daysToSubtract = trendingWeeks * 7; // Сделаем число положительным
            startDate = today.AddDays(-daysToSubtract);

            // Определяем дату начала предыдущего периода
            DateTime previousEndDate = startDate.AddDays(-1);
            previousEndDate = previousEndDate.Date;

            DateTime previousStartDate = previousEndDate.AddDays(-(trendingWeeks * 7) + 1);
            previousStartDate = previousStartDate.Date;

            // Группируем продажи по названию продукта
            var groupedProducts = data.GroupBy(p => p.Name);

            foreach (var productGroup in groupedProducts)
            {
                string productName = productGroup.Key;

                // Вычисляем общую сумму продаж за последние trendingWeeks недель
                int currentPeriodSales = productGroup
                    .Where(p => p.LastSell.Date > startDate.AddDays(-1))
                    .Sum(p => p.QuantitySold);

                // Вычисляем общую сумму продаж за предыдущие trendingWeeks недель
                int previousPeriodSales = productGroup
                    .Where(p => p.LastSell.Date >= previousStartDate && p.LastSell.Date <= previousEndDate)
                    .Sum(p => p.QuantitySold);

                // Проверяем, были ли продажи за предыдущий период
                if (previousPeriodSales > 0)
                {
                    //Проверяем, во сколько раз выросли продажи (должно быть 2 или больше)
                    decimal salesIncreaseFactor = (decimal)currentPeriodSales / previousPeriodSales;

                    //Если продажи выросли в 2 и более раз, добавляем продукт
                    if (salesIncreaseFactor >= 2)
                    {
                        // Берем самую последнюю продажу товара
                        ProductInfo latestProduct = productGroup.OrderByDescending(p => p.LastSell).FirstOrDefault();
                        if (latestProduct != null)
                        {
                            trendingProducts.Add(latestProduct);
                        }
                    }
                }
            }

            return trendingProducts;
        }

    }
    
}
    

