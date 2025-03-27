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

        public BindingList<ProductInfo> GetAllSales()
        {
            return AllSales_;
        }

        // Метод группировки товаров по наименованию, категории и цене.
        // В сгруппированном наборе суммируется количество проданного и остаток,
        // а дата последней продажи определяется как максимальная (самая свежая)
        // Метод группировки товаров по наименованию, категории и цене.
        // Количество проданного суммируется,
        // дата последней продажи определяется как максимальная,
        // а остаток берётся из записи с самой поздней датой.
        public BindingList<ProductInfo> GetGroupedProducts()
        {
            var grouped = AllSales_
                .GroupBy(p => new { p.Name, p.Category, p.Price })
                .Select(g =>
                {
                    // Находим запись с самой поздней датой продажи
                    var latestSale = g.OrderByDescending(p => p.LastSell).First();

                    return new ProductInfo(
                        g.Key.Name,                     // Наименование
                        g.Key.Category,                 // Категория
                        g.Key.Price,                    // Цена
                        g.Sum(p => p.QuantitySold),     // Суммарное количество проданного
                        latestSale.Residue,             // Остаток из самой поздней продажи
                        latestSale.LastSell             // Дата последней продажи (максимальная)
                    );
                })
                .ToList();

            return new BindingList<ProductInfo>(grouped);
        }

        public void AddSales(ProductInfo newProduct)
        {
            AllSales_.Add(newProduct);
        }

        public BindingList<SeasonProductInfo> GetSeasonSales()
        {
            BindingList<SeasonProductInfo> seasonSales = new BindingList<SeasonProductInfo>();

            foreach (var sale in AllSales_)
            {
                SeasonProductInfo seasonProduct = new SeasonProductInfo(sale);
                // Заполняем соответствующий месяц по дате продажи
                switch (sale.LastSell.Month)
                {
                    case 1: seasonProduct.January += sale.QuantitySold; break;
                    case 2: seasonProduct.February += sale.QuantitySold; break;
                    case 3: seasonProduct.March += sale.QuantitySold; break;
                    case 4: seasonProduct.April += sale.QuantitySold; break;
                    case 5: seasonProduct.May += sale.QuantitySold; break;
                    case 6: seasonProduct.June += sale.QuantitySold; break;
                    case 7: seasonProduct.July += sale.QuantitySold; break;
                    case 8: seasonProduct.August += sale.QuantitySold; break;
                    case 9: seasonProduct.September += sale.QuantitySold; break;
                    case 10: seasonProduct.October += sale.QuantitySold; break;
                    case 11: seasonProduct.November += sale.QuantitySold; break;
                    case 12: seasonProduct.December += sale.QuantitySold; break;
                }
                seasonSales.Add(seasonProduct);
            }
            return seasonSales;
        }

        // Пересчитываем процент увеличения для каждого товара
        public void CalculatePercentages(BindingList<SeasonProductInfo> data)
        {
            foreach (var product in data)
            {
                // Собираем продажи по месяцам в массив для удобства
                int[] monthlySales = {
                    product.January, product.February, product.March, product.April,
                    product.May, product.June, product.July, product.August,
                    product.September, product.October, product.November, product.December
                };

                int totalSales = monthlySales.Sum();
                if (totalSales > 0)
                {
                    int maxSales = monthlySales.Max();
                    decimal percentage = ((decimal)maxSales / totalSales) * 100;
                    product.Percentage = Math.Round(percentage, 2);
                }
                else
                {
                    product.Percentage = 0;
                }
            }
        }

        // Фильтрация сезонных товаров по введённому порогу процента
        public BindingList<SeasonProductInfo> FilterSeasonalProducts(BindingList<SeasonProductInfo> data, decimal threshold)
        {
            BindingList<SeasonProductInfo> filteredData = new BindingList<SeasonProductInfo>();
            foreach (var product in data)
            {
                if (IsSeasonal(product, threshold))
                {
                    filteredData.Add(product);
                }
            }
            return filteredData;
        }

        // Метод определяет, сезонный ли товар, исходя из порога процента
        private bool IsSeasonal(SeasonProductInfo product, decimal threshold)
        {
            int[] monthlySales = {
                product.January, product.February, product.March, product.April,
                product.May, product.June, product.July, product.August,
                product.September, product.October, product.November, product.December
            };

            int totalSales = monthlySales.Sum();
            if (totalSales == 0)
            {
                product.Percentage = 0;
                return false;
            }

            int maxSales = monthlySales.Max();
            // Вычисляем процент максимальных продаж от общего числа продаж
            product.Percentage = Math.Round(((decimal)maxSales / totalSales) * 100, 2);

            // Возвращаем true, если процент больше или равен пороговому значению
            return product.Percentage >= threshold;
        }


        // Группировка товаров по наименованию, категории и цене с суммированием месячных данных
        public BindingList<SeasonProductInfo> GroupProducts(BindingList<SeasonProductInfo> data)
        {
            var groupedProducts = data.GroupBy(p => new { p.Name, p.Category, p.Price })
                .Select(g =>
                {
                    var firstProduct = g.First();
                    SeasonProductInfo groupedProduct = new SeasonProductInfo(
                        new ProductInfo(firstProduct.Name, firstProduct.Category, firstProduct.Price, 0, 0, DateTime.MinValue)
                    );
                    groupedProduct.January = g.Sum(p => p.January);
                    groupedProduct.February = g.Sum(p => p.February);
                    groupedProduct.March = g.Sum(p => p.March);
                    groupedProduct.April = g.Sum(p => p.April);
                    groupedProduct.May = g.Sum(p => p.May);
                    groupedProduct.June = g.Sum(p => p.June);
                    groupedProduct.July = g.Sum(p => p.July);
                    groupedProduct.August = g.Sum(p => p.August);
                    groupedProduct.September = g.Sum(p => p.September);
                    groupedProduct.October = g.Sum(p => p.October);
                    groupedProduct.November = g.Sum(p => p.November);
                    groupedProduct.December = g.Sum(p => p.December);
                    groupedProduct.Residue = g.Sum(p => p.Residue);
                    groupedProduct.QuantitySold = g.Sum(p => p.QuantitySold);
                    groupedProduct.LastSell = g.Max(p => p.LastSell);
                    return groupedProduct;
                })
                .ToBindingList();
            return groupedProducts;
        }


        // Метод показывает 10 самых продаваемых товаров
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

        // Метод, который показывает товары с нулевым остатком, сортируя по последней дате продажи
        public BindingList<ProductInfo> GetProductsWithZeroResidueAndLatestSale()
        {
            try
            {
                // Если данных нет, сразу возвращаем пустой список
                if (AllSales_ == null || AllSales_.Count == 0)
                {
                    return new BindingList<ProductInfo>();
                }

                // Группируем товары по наименованию и категории
                var groupedProducts = AllSales_
                    .GroupBy(p => new { p.Name, p.Category })
                    .Select(g => new
                    {
                        // Выбираем запись с самой поздней датой продажи
                        LatestSale = g.OrderByDescending(p => p.LastSell).First(),
                        // Суммируем общее количество проданного по группе
                        TotalQuantitySold = g.Sum(p => p.QuantitySold)
                    })
                    // Фильтруем группы: включаем только если остаток в последней продаже равен 0
                    .Where(x => x.LatestSale.Residue == 0)
                    .Select(x => new ProductInfo
                    {
                        Name = x.LatestSale.Name,
                        Category = x.LatestSale.Category,
                        Price = x.LatestSale.Price,
                        QuantitySold = x.TotalQuantitySold,
                        // Остаток берем из записи с самой поздней датой продажи (ожидается, что он равен 0)
                        Residue = x.LatestSale.Residue,
                        LastSell = x.LatestSale.LastSell
                    })
                    .ToList();

                return new BindingList<ProductInfo>(groupedProducts);
            }
            catch (Exception ex)
            {
                // Возвращаем пустой список
                return new BindingList<ProductInfo>();
            }
        }

        public void AddAllSales()
        {
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
            AllSales_.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 12, 15))); // Декабрь

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

            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 3, 2, new DateTime(2025, 01, 15)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 2, 0, new DateTime(2025, 02, 20)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 0, 0, new DateTime(2025, 03, 10)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 0, 0, new DateTime(2025, 04, 15)));
            AllSales_.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 0, 0, new DateTime(2025, 05, 20)));

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
    

