using System;
using System.ComponentModel;

namespace MyLib
{
    // Класс для хранения основной информации о товаре
    public class ProductInfo
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Категория")]
        public string Category { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DisplayName("Количество проданного")]
        public int QuantitySold { get; set; }
        [DisplayName("Остаток")]
        public int Residue { get; set; }
        [DisplayName("Дата последней продажи")]
        public DateTime LastSell { get; set; }

        public ProductInfo() { }

        public ProductInfo(string name_, string category_, decimal price_, int quantitySold_, int residue_, DateTime lastSell_)
        {
            Name = name_;
            Category = category_;
            Price = price_;
            QuantitySold = quantitySold_;
            Residue = residue_;
            LastSell = lastSell_;
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductInfo other)
            {
                return Name == other.Name &&
                       Category == other.Category &&
                       Price == other.Price &&
                       Residue == other.Residue &&
                       LastSell == other.LastSell;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Name?.GetHashCode() ?? 0);
                hash = hash * 23 + (Category?.GetHashCode() ?? 0);
                hash = hash * 23 + Price.GetHashCode();
                hash = hash * 23 + Residue.GetHashCode();
                hash = hash * 23 + LastSell.GetHashCode();
                return hash;
            }
        }
    }
}
