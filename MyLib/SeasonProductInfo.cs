using System;
using System.ComponentModel;

namespace MyLib
{
    // Расширенный класс для сезонных товаров с данными по каждому месяцу и процентом увеличения
    public class SeasonProductInfo : ProductInfo
    {
        [DisplayName("Январь")]
        public int January { get; set; }
        [DisplayName("Февраль")]
        public int February { get; set; }
        [DisplayName("Март")]
        public int March { get; set; }
        [DisplayName("Апрель")]
        public int April { get; set; }
        [DisplayName("Май")]
        public int May { get; set; }
        [DisplayName("Июнь")]
        public int June { get; set; }
        [DisplayName("Июль")]
        public int July { get; set; }
        [DisplayName("Август")]
        public int August { get; set; }
        [DisplayName("Сентябрь")]
        public int September { get; set; }
        [DisplayName("Октябрь")]
        public int October { get; set; }
        [DisplayName("Ноябрь")]
        public int November { get; set; }
        [DisplayName("Декабрь")]
        public int December { get; set; }
        [DisplayName("Процент увеличения")]
        public decimal Percentage { get; set; }

        public SeasonProductInfo() { }

        // Конструктор, копирующий основные данные из ProductInfo
        public SeasonProductInfo(ProductInfo product)
        {
            Name = product.Name;
            Category = product.Category;
            Price = product.Price;
            QuantitySold = product.QuantitySold;
            Residue = product.Residue;
            LastSell = product.LastSell;
            // Инициализируем месяцы и процент нулём
            January = February = March = April = May = June =
            July = August = September = October = November = December = 0;
            Percentage = 0;
        }
    }
}
