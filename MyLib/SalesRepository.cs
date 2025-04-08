using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyLib
{
    public class SalesRepository
    {
        public BindingList<ProductInfo> AllSales { get; private set; }

        public SalesRepository()
        {
            AllSales = new BindingList<ProductInfo>();
        }

        public void AddSales(ProductInfo product)
        {
            AllSales.Add(product);
        }

        public BindingList<ProductInfo> GetAllSales()
        {
            return AllSales;
        }

        public void AddAllSales()
        {
            AllSales.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 0, 2, new DateTime(2025, 01, 15)));
            AllSales.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 10, 0, new DateTime(2025, 02, 20)));
            AllSales.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 20, 0, new DateTime(2025, 03, 01)));
            AllSales.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 50, 0, new DateTime(2025, 03, 15)));
            AllSales.Add(new ProductInfo("Xiaomi Himo", "Транспорт", 1299.99m, 200, 0, new DateTime(2025, 04, 01)));

            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 9, 2, new DateTime(2025, 01, 25))); // Январь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 7, 5, new DateTime(2025, 02, 14))); // Февраль
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 3, new DateTime(2025, 03, 08))); // Март
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 03, 22))); // Март
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 6, 2, new DateTime(2025, 04, 15))); // Апрель (две одинаковые даты)
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 0, new DateTime(2025, 04, 15))); // Апрель
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 4, new DateTime(2025, 05, 10))); // Май
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 2, new DateTime(2025, 06, 10))); // Июнь (три одинаковые даты)
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 06, 10))); // Июнь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 2, 0, new DateTime(2025, 06, 10))); // Июнь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 7, 3, new DateTime(2025, 07, 18))); // Июль
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 1, new DateTime(2025, 08, 05))); // Август
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 0, new DateTime(2025, 08, 19))); // Август
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 6, 2, new DateTime(2025, 09, 05))); // Сентябрь (две одинаковые даты)
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 4, 1, new DateTime(2025, 09, 05))); // Сентябрь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 3, new DateTime(2025, 10, 12))); // Октябрь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 3, 1, new DateTime(2025, 11, 08))); // Ноябрь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 2, 0, new DateTime(2025, 11, 22))); // Ноябрь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 8, 4, new DateTime(2025, 12, 15))); // Декабрь (три одинаковые даты)
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 5, 2, new DateTime(2025, 12, 15))); // Декабрь
            AllSales.Add(new ProductInfo("Чайник электрический Bosch", "Бытовая техника", 18.75m, 200, 1, new DateTime(2025, 12, 15))); // Декабрь

            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 10, 5, new DateTime(2025, 01, 10)));
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 3, 2, new DateTime(2025, 02, 15)));
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 2, 0, new DateTime(2025, 02, 28))); // Остаток стал 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 03, 05))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 04, 10))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 05, 15))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 06, 20))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 07, 25))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 08, 30))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 09, 05))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 10, 10))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 11, 15))); // Нет продаж, остаток 0  
            AllSales.Add(new ProductInfo("Кофемашина DeLonghi Magnifica", "Бытовая техника", 499.99m, 0, 0, new DateTime(2025, 12, 20))); // Нет продаж, остаток 0  

            AllSales.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 8, 5, new DateTime(2025, 01, 10)));
            AllSales.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 5, 2, new DateTime(2025, 02, 15)));
            AllSales.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 2, 0, new DateTime(2025, 03, 05)));
            AllSales.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 0, 0, new DateTime(2025, 04, 12)));
            AllSales.Add(new ProductInfo("Samsung Galaxy S24", "Электроника", 1099.99m, 0, 0, new DateTime(2025, 05, 18)));

            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 6, 4, new DateTime(2025, 01, 05)));
            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 4, 1, new DateTime(2025, 02, 10)));
            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 1, 0, new DateTime(2025, 03, 15)));
            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 04, 20)));
            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 05, 25)));
            AllSales.Add(new ProductInfo("Roborock S8", "Бытовая техника", 699.99m, 0, 0, new DateTime(2025, 06, 30)));

            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 12, 8, new DateTime(2025, 01, 08)));
            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 8, 3, new DateTime(2025, 02, 12)));
            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 3, 0, new DateTime(2025, 03, 18)));
            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 04, 22)));
            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 05, 28)));
            AllSales.Add(new ProductInfo("Razer Viper", "Компьютерные аксессуары", 89.99m, 0, 0, new DateTime(2025, 06, 30)));

            AllSales.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 7, 5, new DateTime(2025, 01, 12)));
            AllSales.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 5, 2, new DateTime(2025, 02, 18)));
            AllSales.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 2, 0, new DateTime(2025, 03, 22)));
            AllSales.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 0, 0, new DateTime(2025, 04, 28)));
            AllSales.Add(new ProductInfo("Nest Thermostat", "Умный дом", 249.99m, 0, 0, new DateTime(2025, 05, 30)));

            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 4, 3, new DateTime(2025, 01, 20)));
            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 3, 1, new DateTime(2025, 02, 25)));
            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 1, 0, new DateTime(2025, 03, 05)));
            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 04, 10)));
            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 05, 15)));
            AllSales.Add(new ProductInfo("Epson Home Cinema", "Техника для дома", 899.99m, 0, 0, new DateTime(2025, 06, 20)));

            AllSales.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 10, 7, new DateTime(2025, 01, 07)));
            AllSales.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 7, 3, new DateTime(2025, 02, 14)));
            AllSales.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 3, 0, new DateTime(2025, 03, 21)));
            AllSales.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 0, 0, new DateTime(2025, 04, 28)));
            AllSales.Add(new ProductInfo("PocketBook", "Гаджеты", 149.99m, 0, 0, new DateTime(2025, 05, 05)));

            AllSales.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 5, 4, new DateTime(2025, 01, 11)));
            AllSales.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 4, 1, new DateTime(2025, 02, 19)));
            AllSales.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 1, 0, new DateTime(2025, 03, 27)));
            AllSales.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 0, 0, new DateTime(2025, 04, 03)));
            AllSales.Add(new ProductInfo("Krups Espresso", "Бытовая техника", 399.99m, 0, 0, new DateTime(2025, 05, 11)));

            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 15, 10, new DateTime(2025, 01, 06)));
            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 10, 4, new DateTime(2025, 02, 13)));
            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 4, 0, new DateTime(2025, 03, 20)));
            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 04, 27)));
            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 05, 04)));
            AllSales.Add(new ProductInfo("Huawei Band 8", "Гаджеты", 59.99m, 0, 0, new DateTime(2025, 06, 11)));

            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 15, 12, new DateTime(2025, 01, 05)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 12, 9, new DateTime(2025, 01, 15)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 9, 7, new DateTime(2025, 01, 25)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 7, 5, new DateTime(2025, 02, 05)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 5, 3, new DateTime(2025, 02, 15)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 3, 2, new DateTime(2025, 02, 25)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 2, 1, new DateTime(2025, 03, 05)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 1, 1, new DateTime(2025, 03, 15)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 1, 0, new DateTime(2025, 03, 25)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 05)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 15)));
            AllSales.Add(new ProductInfo("OnePlus 12", "Электроника", 899.99m, 0, 0, new DateTime(2025, 04, 25)));

            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 10, 8, new DateTime(2025, 01, 10)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 8, 6, new DateTime(2025, 01, 20)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 6, 5, new DateTime(2025, 02, 01)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 5, 4, new DateTime(2025, 02, 10)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 4, 3, new DateTime(2025, 02, 20)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 3, 2, new DateTime(2025, 03, 01)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 2, 1, new DateTime(2025, 03, 10)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 1, 1, new DateTime(2025, 03, 20)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 1, 0, new DateTime(2025, 04, 01)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 0, new DateTime(2025, 04, 10)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 0, new DateTime(2025, 04, 20)));
            AllSales.Add(new ProductInfo("iRobot j7+", "Бытовая техника", 799.99m, 0, 3, new DateTime(2025, 05, 01)));

            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 8, 7, new DateTime(2025, 01, 07)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 7, 6, new DateTime(2025, 01, 17)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 6, 5, new DateTime(2025, 01, 27)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 5, 4, new DateTime(2025, 02, 07)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 4, 3, new DateTime(2025, 02, 17)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 3, 2, new DateTime(2025, 02, 27)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 2, 1, new DateTime(2025, 03, 07)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 1, 1, new DateTime(2025, 03, 17)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 1, 0, new DateTime(2025, 03, 27)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 0, new DateTime(2025, 04, 07)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 0, new DateTime(2025, 04, 17)));
            AllSales.Add(new ProductInfo("Segway Ninebot", "Транспорт", 1499.99m, 0, 10, new DateTime(2025, 04, 27)));
        }
    }
}
