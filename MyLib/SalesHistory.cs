using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace MyLib
{
    public static class BindingListExtensions
    {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> source)
        {
            return new BindingList<T>(source.ToList());
        }
    }

    public class SalesHistory
    {
        private BindingList<ProductInfo> AllSales_ = new BindingList<ProductInfo>();

        public BindingList<TrendingProduct> FindTrendingProducts(DateTime referenceDate, int trendingWeeks, double minIncrease)
        {
            BindingList<TrendingProduct> trendingProducts = new BindingList<TrendingProduct>();

            // Текущий период: от (referenceDate - trendingWeeks*7) до referenceDate
            DateTime currentPeriodStart = referenceDate.AddDays(-trendingWeeks * 7);
            // Предыдущий период: непосредственно перед текущим
            DateTime previousPeriodEnd = currentPeriodStart.AddDays(-1);
            DateTime previousPeriodStart = previousPeriodEnd.AddDays(-trendingWeeks * 7 + 1);

            // Группируем продажи по имени товара
            var groupedProducts = AllSales_.GroupBy(p => p.Name);
            foreach (var group in groupedProducts)
            {
                int currentSales = group
                    .Where(p => p.LastSell.Date >= currentPeriodStart && p.LastSell.Date <= referenceDate)
                    .Sum(p => p.QuantitySold);
                int previousSales = group
                    .Where(p => p.LastSell.Date >= previousPeriodStart && p.LastSell.Date <= previousPeriodEnd)
                    .Sum(p => p.QuantitySold);

                if (previousSales > 0)
                {
                    double factor = Math.Round((double)currentSales / previousSales, 2);
                    if (factor >= minIncrease)
                    {
                        ProductInfo latestProduct = group.OrderByDescending(p => p.LastSell).FirstOrDefault();
                        if (latestProduct != null)
                        {
                            TrendingProduct tp = new TrendingProduct
                            {
                                Name = latestProduct.Name,
                                Category = latestProduct.Category,
                                Price = latestProduct.Price,
                                IncreaseFactor = factor
                            };
                            trendingProducts.Add(tp);
                        }
                    }
                }
            }
            return trendingProducts;
        }



        public BindingList<ProductInfo> GetAllSales()
        {
            return AllSales_;
        }

        public void ClearSales()
        {
            AllSales_.Clear();
        }

        // Группировка товаров по наименованию, категории и цене.
        // Для каждой группы суммируется количество проданного, 
        // дата последней продажи определяется как максимальная,
        // а остаток берётся из записи с самой поздней датой.
        public BindingList<ProductInfo> GetGroupedProducts()
        {
            var grouped = AllSales_
                .GroupBy(p => new { p.Name, p.Category, p.Price })
                .Select(g =>
                {
                    var latestSale = g.OrderByDescending(p => p.LastSell).First();
                    return new ProductInfo(
                        g.Key.Name,
                        g.Key.Category,
                        g.Key.Price,
                        g.Sum(p => p.QuantitySold),
                        latestSale.Residue,
                        latestSale.LastSell
                    );
                })
                .ToList();

            return new BindingList<ProductInfo>(grouped);
        }

        public void AddSales(ProductInfo newProduct)
        {
            AllSales_.Add(newProduct);
        }

        // Формирование сезонных данных.
        // Группировка происходит по имени товара.
        // Для каждого товара вычисляется процентное распределение продаж по месяцам.
        public BindingList<SeasonProductInfo> GetSeasonSales()//
        {
            var seasonSales = AllSales_
                 .GroupBy(sale => sale.Name)
                 .Select(g =>
                 {
                     int totalSales = g.Sum(sale => sale.QuantitySold);
                     SeasonProductInfo info = new SeasonProductInfo();
                     info.Name = g.Key;

                     // Для каждого месяца вычисляем процент продаж
                     for (int month = 1; month <= 12; month++)
                     {
                         int monthSales = g.Where(sale => sale.LastSell.Month == month).Sum(sale => sale.QuantitySold);
                         double growth = totalSales > 0 ? Math.Round(((double)monthSales / totalSales) * 100, 2) : 0;
                         switch (month)
                         {
                             case 1: info.JanuaryGrowth = growth; break;
                             case 2: info.FebruaryGrowth = growth; break;
                             case 3: info.MarchGrowth = growth; break;
                             case 4: info.AprilGrowth = growth; break;
                             case 5: info.MayGrowth = growth; break;
                             case 6: info.JuneGrowth = growth; break;
                             case 7: info.JulyGrowth = growth; break;
                             case 8: info.AugustGrowth = growth; break;
                             case 9: info.SeptemberGrowth = growth; break;
                             case 10: info.OctoberGrowth = growth; break;
                             case 11: info.NovemberGrowth = growth; break;
                             case 12: info.DecemberGrowth = growth; break;
                         }
                     }
                     return info;
                 })
                 .ToList();

            return new BindingList<SeasonProductInfo>(seasonSales);
        }

        // Группировка сезонных данных по имени товара (если нужно объединить несколько записей для одного товара)
        public BindingList<SeasonProductInfo> GroupProducts(BindingList<SeasonProductInfo> data)
        {
            var grouped = data.GroupBy(p => p.Name)
               .Select(g =>
               {
                   SeasonProductInfo aggregated = new SeasonProductInfo();
                   aggregated.Name = g.Key;
                   aggregated.JanuaryGrowth = Math.Round(g.Average(x => x.JanuaryGrowth), 2);
                   aggregated.FebruaryGrowth = Math.Round(g.Average(x => x.FebruaryGrowth), 2);
                   aggregated.MarchGrowth = Math.Round(g.Average(x => x.MarchGrowth), 2);
                   aggregated.AprilGrowth = Math.Round(g.Average(x => x.AprilGrowth), 2);
                   aggregated.MayGrowth = Math.Round(g.Average(x => x.MayGrowth), 2);
                   aggregated.JuneGrowth = Math.Round(g.Average(x => x.JuneGrowth), 2);
                   aggregated.JulyGrowth = Math.Round(g.Average(x => x.JulyGrowth), 2);
                   aggregated.AugustGrowth = Math.Round(g.Average(x => x.AugustGrowth), 2);
                   aggregated.SeptemberGrowth = Math.Round(g.Average(x => x.SeptemberGrowth), 2);
                   aggregated.OctoberGrowth = Math.Round(g.Average(x => x.OctoberGrowth), 2);
                   aggregated.NovemberGrowth = Math.Round(g.Average(x => x.NovemberGrowth), 2);
                   aggregated.DecemberGrowth = Math.Round(g.Average(x => x.DecemberGrowth), 2);
                   return aggregated;
               }).ToList();

            return new BindingList<SeasonProductInfo>(grouped);
        }

        // Метод показывает 10 самых продаваемых товаров.
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
                .OrderByDescending(x => x.TotalQuantitySold)
                .Take(10);

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

        // Метод, который показывает товары с нулевым остатком, сортируя по последней дате продажи.
        public BindingList<ProductInfo> GetProductsWithZeroResidueAndLatestSale()
        {
            try
            {
                if (AllSales_ == null || AllSales_.Count == 0)
                {
                    return new BindingList<ProductInfo>();
                }

                var groupedProducts = AllSales_
                    .GroupBy(p => new { p.Name, p.Category })
                    .Select(g => new
                    {
                        LatestSale = g.OrderByDescending(p => p.LastSell).First(),
                        TotalQuantitySold = g.Sum(p => p.QuantitySold)
                    })
                    .Where(x => x.LatestSale.Residue == 0)
                    .Select(x => new ProductInfo
                    {
                        Name = x.LatestSale.Name,
                        Category = x.LatestSale.Category,
                        Price = x.LatestSale.Price,
                        QuantitySold = x.TotalQuantitySold,
                        Residue = x.LatestSale.Residue,
                        LastSell = x.LatestSale.LastSell
                    })
                    .ToList();

                return new BindingList<ProductInfo>(groupedProducts);
            }
            catch (Exception)
            {
                return new BindingList<ProductInfo>();
            }

        }
        // Фильтрация сезонных данных по глобальному порогу.
        // Возвращает те товары, у которых максимум из процентных значений за месяцы >= threshold.
        public BindingList<SeasonProductInfo> FilterSeasonProductsByThreshold(BindingList<SeasonProductInfo> data, double threshold)
        {
            var filtered = data.Where(product =>
            {
                double maxGrowth = new double[]
                {
            product.JanuaryGrowth, product.FebruaryGrowth, product.MarchGrowth, product.AprilGrowth,
            product.MayGrowth, product.JuneGrowth, product.JulyGrowth, product.AugustGrowth,
            product.SeptemberGrowth, product.OctoberGrowth, product.NovemberGrowth, product.DecemberGrowth
                }.Max();
                return maxGrowth >= threshold;
            }).ToList();
            return new BindingList<SeasonProductInfo>(filtered);
        }

        public BindingList<SeasonProductInfo> FilterSeasonProductsByMonth(BindingList<SeasonProductInfo> data, int month, double threshold)
        {
            var filtered = data.Where(item =>
            {
                double value = 0;
                switch (month)
                {
                    case 1: value = item.JanuaryGrowth; break;
                    case 2: value = item.FebruaryGrowth; break;
                    case 3: value = item.MarchGrowth; break;
                    case 4: value = item.AprilGrowth; break;
                    case 5: value = item.MayGrowth; break;
                    case 6: value = item.JuneGrowth; break;
                    case 7: value = item.JulyGrowth; break;
                    case 8: value = item.AugustGrowth; break;
                    case 9: value = item.SeptemberGrowth; break;
                    case 10: value = item.OctoberGrowth; break;
                    case 11: value = item.NovemberGrowth; break;
                    case 12: value = item.DecemberGrowth; break;
                    default: value = 0; break;
                }
                return value >= threshold;
            }).ToList();

            return new BindingList<SeasonProductInfo>(filtered);
        }

        public void AddAllSales()
        {
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 0, 2, new DateTime(2025, 01, 15)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 10, 0, new DateTime(2025, 02, 20)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 20, 0, new DateTime(2025, 03, 01)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 50, 0, new DateTime(2025, 03, 15)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 200, 0, new DateTime(2025, 04, 01)));

            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 9, 2, new DateTime(2025, 01, 25))); // Январь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 7, 5, new DateTime(2025, 02, 14))); // Февраль
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 3, new DateTime(2025, 03, 08))); // Март
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 03, 22))); // Март
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 6, 2, new DateTime(2025, 04, 15))); // Апрель (две одинаковые даты)
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 0, new DateTime(2025, 04, 15))); // Апрель
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 4, new DateTime(2025, 05, 10))); // Май
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 2, new DateTime(2025, 06, 10))); // Июнь (три одинаковые даты)
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 06, 10))); // Июнь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 2, 0, new DateTime(2025, 06, 10))); // Июнь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 7, 3, new DateTime(2025, 07, 18))); // Июль
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 1, new DateTime(2025, 08, 05))); // Август
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 0, new DateTime(2025, 08, 19))); // Август
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 6, 2, new DateTime(2025, 09, 05))); // Сентябрь (две одинаковые даты)
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 1, new DateTime(2025, 09, 05))); // Сентябрь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 3, new DateTime(2025, 10, 12))); // Октябрь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 11, 08))); // Ноябрь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 2, 0, new DateTime(2025, 11, 22))); // Ноябрь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 4, new DateTime(2025, 12, 15))); // Декабрь (три одинаковые даты)
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 2, new DateTime(2025, 12, 15))); // Декабрь
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 200, 1, new DateTime(2025, 12, 15))); // Декабрь

            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 10, 5, new DateTime(2025, 01, 10)));
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 3, 2, new DateTime(2025, 02, 15)));
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 2, 0, new DateTime(2025, 02, 28))); // Остаток стал 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 03, 05))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 04, 10))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 05, 15))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 06, 20))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 07, 25))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 08, 30))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 09, 05))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 10, 10))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 11, 15))); // Нет продаж, остаток 0  
            AllSales_.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 12, 20))); // Нет продаж, остаток 0  

            AllSales_.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 8, 5, new DateTime(2025, 01, 10)));
            AllSales_.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 5, 2, new DateTime(2025, 02, 15)));
            AllSales_.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 2, 0, new DateTime(2025, 03, 05)));
            AllSales_.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 0, 0, new DateTime(2025, 04, 12)));
            AllSales_.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 0, 0, new DateTime(2025, 05, 18)));

            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 6, 4, new DateTime(2025, 01, 05)));
            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 4, 1, new DateTime(2025, 02, 10)));
            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 1, 0, new DateTime(2025, 03, 15)));
            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 04, 20)));
            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 05, 25)));
            AllSales_.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 06, 30)));

            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 12, 8, new DateTime(2025, 01, 08)));
            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 8, 3, new DateTime(2025, 02, 12)));
            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 3, 0, new DateTime(2025, 03, 18)));
            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 04, 22)));
            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 05, 28)));
            AllSales_.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 06, 30)));

            AllSales_.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 7, 5, new DateTime(2025, 01, 12)));
            AllSales_.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 5, 2, new DateTime(2025, 02, 18)));
            AllSales_.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 2, 0, new DateTime(2025, 03, 22)));
            AllSales_.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 0, 0, new DateTime(2025, 04, 28)));
            AllSales_.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 0, 0, new DateTime(2025, 05, 30)));

            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 4, 3, new DateTime(2025, 01, 20)));
            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 3, 1, new DateTime(2025, 02, 25)));
            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 1, 0, new DateTime(2025, 03, 05)));
            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 04, 10)));
            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 05, 15)));
            AllSales_.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 06, 20)));

            AllSales_.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 10, 7, new DateTime(2025, 01, 07)));
            AllSales_.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 7, 3, new DateTime(2025, 02, 14)));
            AllSales_.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 3, 0, new DateTime(2025, 03, 21)));
            AllSales_.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 0, 0, new DateTime(2025, 04, 28)));
            AllSales_.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 0, 0, new DateTime(2025, 05, 05)));

            AllSales_.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 5, 4, new DateTime(2025, 01, 11)));
            AllSales_.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 4, 1, new DateTime(2025, 02, 19)));
            AllSales_.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 1, 0, new DateTime(2025, 03, 27)));
            AllSales_.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 0, 0, new DateTime(2025, 04, 03)));
            AllSales_.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 0, 0, new DateTime(2025, 05, 11)));

            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 15, 10, new DateTime(2025, 01, 06)));
            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 10, 4, new DateTime(2025, 02, 13)));
            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 4, 0, new DateTime(2025, 03, 20)));
            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 04, 27)));
            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 05, 04)));
            AllSales_.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 06, 11)));

            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 15, 12, new DateTime(2025, 01, 05)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 12, 9, new DateTime(2025, 01, 15)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 9, 7, new DateTime(2025, 01, 25)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 7, 5, new DateTime(2025, 02, 05)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 5, 3, new DateTime(2025, 02, 15)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 3, 2, new DateTime(2025, 02, 25)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 2, 1, new DateTime(2025, 03, 05)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 1, 1, new DateTime(2025, 03, 15)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 1, 0, new DateTime(2025, 03, 25)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 05)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 15)));
            AllSales_.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 25)));

            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 10, 8, new DateTime(2025, 01, 10)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 8, 6, new DateTime(2025, 01, 20)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 6, 5, new DateTime(2025, 02, 01)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 5, 4, new DateTime(2025, 02, 10)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 4, 3, new DateTime(2025, 02, 20)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 3, 2, new DateTime(2025, 03, 01)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 2, 1, new DateTime(2025, 03, 10)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 1, 1, new DateTime(2025, 03, 20)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 1, 0, new DateTime(2025, 04, 01)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 0, new DateTime(2025, 04, 10)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 0, new DateTime(2025, 04, 20)));
            AllSales_.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 3, new DateTime(2025, 05, 01)));

            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 8, 7, new DateTime(2025, 01, 07)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 7, 6, new DateTime(2025, 01, 17)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 6, 5, new DateTime(2025, 01, 27)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 5, 4, new DateTime(2025, 02, 07)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 4, 3, new DateTime(2025, 02, 17)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 3, 2, new DateTime(2025, 02, 27)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 2, 1, new DateTime(2025, 03, 07)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 1, 1, new DateTime(2025, 03, 17)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 1, 0, new DateTime(2025, 03, 27)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 0, new DateTime(2025, 04, 07)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 0, new DateTime(2025, 04, 17)));
            AllSales_.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 10, new DateTime(2025, 04, 27)));


        }

    }
}
    

