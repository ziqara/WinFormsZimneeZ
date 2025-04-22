using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyLib.Services
{
    public class GeneralSalesHistoryService
    {
        private SalesRepository _repository;

        public GeneralSalesHistoryService(SalesRepository repository)
        {
            _repository = repository;
        }

        public BindingList<ProductInfo> GetAllSales()
        {
            return _repository.GetAllSales();
        }

        public void AddSales(ProductInfo newProduct)
        {
            _repository.AddSales(newProduct);
        }

        // Группировка товаров по наименованию, категории и цене.
        // Для каждой группы суммируется количество проданного, 
        // дата последней продажи определяется как максимальная,
        // а остаток берётся из записи с самой поздней датой.
        public BindingList<ProductInfo> GetGroupedProducts()
        {
            var grouped = _repository.AllSales
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
                }).ToList();

            return new BindingList<ProductInfo>(grouped);
        }

        // Метод показывает 10 самых продаваемых товаров.
        public BindingList<ProductInfo> ShowBestSellingProducts()
        {
            var topProducts = _repository.AllSales
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
                .Take(2);

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
                if (_repository.AllSales == null || _repository.AllSales.Count == 0)
                    return new BindingList<ProductInfo>();

                var groupedProducts = _repository.AllSales
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

        public void AddAllSales()
        {
            _repository.AddAllSales();
        }
    }
}
