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
        

        public static List<ProductInfo> AddListOfProducts()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            products.Add(new ProductInfo("Product1", "Category1", 100, 1, new DateTime(2023, 10, 1)));
            products.Add(new ProductInfo("Product2", "Category2", 200, 0, new DateTime(2023, 9, 15)));
            products.Add(new ProductInfo("Product3", "Category1", 300, 2, new DateTime(2023, 10, 5)));
            products.Add(new ProductInfo("Product4", "Category3", 400, 0, new DateTime(2023, 8, 20)));

            return products;
        }

        public static List<ProductInfo> GetProductsWithLastSaleResidueZero(List<ProductInfo> products)
        {

            List<ProductInfo> result = new List<ProductInfo>();

            if (products == null || products.Count == 0)
            {
                return result;
            }

            DateTime latestSaleDate = DateTime.MinValue;

            
            foreach (ProductInfo product in products)
            {
                if (product.GetLastSell() > latestSaleDate)
                {
                    latestSaleDate = product.GetLastSell();
                }
            }

           
            foreach (ProductInfo product in products)
            {
                if (product.GetLastSell() == latestSaleDate && product.GetResidue() == 0)
                {
                    result.Add(product);
                }
            }

            return result;
        }
    }
}
