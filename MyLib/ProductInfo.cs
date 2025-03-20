using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
     public class ProductInfo
    {
        private string Name { get; set; }
        private string Category { get; set; }
        private decimal Price { get; set; }
        private int Residue { get; set; }
        private DateTime LastSell { get; set; }

        public ProductInfo(string name_, string category_, decimal price_, int residue_, DateTime lastsell_)
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals(obj as ProductInfo);
        }

        public bool Equals(ProductInfo other)
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
            unchecked
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
