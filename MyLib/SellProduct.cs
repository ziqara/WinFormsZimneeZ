using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLib
{
    public class SellProduct
    {
        private string Name;
        private string Category;
        private decimal Price;
        private int Residue;
        private DateTime LastSell;

        public SellProduct(string name_, string category_, decimal price_, int residue_, DateTime lastsell_)
        {
            Name = name_;
            Category = category_;
            Price = price_;
            Residue = residue_;
            LastSell = lastsell_;
        }

        public string GetName() { return Name; }
        public string GetCategory() { return Category; }
        public decimal GetPrice() { return Price; }
        public int GetResidue() { return Residue; }
        public DateTime GetLastSell() { return LastSell; }

        public static List<SellProduct> AddListOfProducts()
        {
            List<SellProduct> products = new List<SellProduct>();
            products.Add(new SellProduct("Product1", "Category1", 100, 1, new DateTime(2023, 10, 1)));
            products.Add(new SellProduct("Product2", "Category2", 200, 0, new DateTime(2023, 9, 15)));
            products.Add(new SellProduct("Product3", "Category1", 300, 2, new DateTime(2023, 10, 5)));
            products.Add(new SellProduct("Product4", "Category3", 400, 0, new DateTime(2023, 8, 20)));

            return products;
        }

        public static List<SellProduct> GetProductsWithLastSaleResidueZero(List<SellProduct> products)
        {

            List<SellProduct> result = new List<SellProduct>();

            if (products == null || products.Count == 0)
            {
                return result; // Возвращаем пустой список
            }

            DateTime latestSaleDate = DateTime.MinValue; // Инициализируем минимальной датой

            // Находим самую позднюю дату
            foreach (SellProduct product in products)
            {
                if (product.GetLastSell() > latestSaleDate)
                {
                    latestSaleDate = product.GetLastSell();
                }
            }

            // Фильтруем продукты по дате и остатку
            foreach (SellProduct product in products)
            {
                if (product.GetLastSell() == latestSaleDate && product.GetResidue() == 0)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as SellProduct);
        }

        public bool Equals(SellProduct other)
        {
            if (other == null)
            {
                return false;
            }

            return Name == other.Name &&
                   Category == other.Category &&
                   Price == other.Price &&
                   Residue == other.Residue &&
                   LastSell == other.LastSell;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + (Category != null ? Category.GetHashCode() : 0);
                hash = hash * 23 + Price.GetHashCode();
                hash = hash * 23 + Residue.GetHashCode();
                hash = hash * 23 + LastSell.GetHashCode();
                return hash;
            }
        }
    }
}
