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
            
            AllSales_.Add(new ProductInfo("TestProduct1", "TestCategoryA", 10.00m, 0, DateTime.Now));
            AllSales_.Add(new ProductInfo("TestProduct2", "TestCategoryB", 20.50m, 10, DateTime.Now.AddDays(-1)));
            AllSales_.Add(new ProductInfo("TestProduct3", "TestCategoryA", 5.75m, 20, DateTime.Now.AddDays(-2)));
        }

        public List<ProductInfo> GetAllSales()
        {
             return AllSales_.ToList();
        } 

        public void AddSales(ProductInfo newProduct)
        {
            AllSales_.Add(newProduct);
        }


        public BindingList<ProductInfo> GetProductsWithZeroResidueAndLatestSale()
        {
            if (AllSales_ == null || AllSales_.Count == 0)
            {
                return new BindingList<ProductInfo>();
            }
            DateTime maxDate = AllSales_.Max(p => p.LastSell);
            return new BindingList<ProductInfo>(AllSales_.Where(p => p.LastSell == maxDate && p.Residue == 0).ToList());
        }
    }
}
