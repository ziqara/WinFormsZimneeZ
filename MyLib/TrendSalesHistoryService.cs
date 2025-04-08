using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyLib.Services
{
    public class TrendSalesHistoryService
    {
        private SalesRepository _repository;

        public TrendSalesHistoryService(SalesRepository repository)
        {
            _repository = repository;
        }

        public BindingList<TrendingProduct> FindTrendingProducts(DateTime referenceDate, int trendingWeeks, double minIncrease)
        {
            BindingList<TrendingProduct> trendingProducts = new BindingList<TrendingProduct>();

            // Текущий период: от (referenceDate - trendingWeeks*7) до referenceDate
            DateTime currentPeriodStart = referenceDate.AddDays(-trendingWeeks * 7);
            // Предыдущий период: непосредственно перед текущим
            DateTime previousPeriodEnd = currentPeriodStart.AddDays(-1);
            DateTime previousPeriodStart = previousPeriodEnd.AddDays(-trendingWeeks * 7 + 1);
            
            // Группируем продажи по имени товара
            var groupedProducts = _repository.AllSales.GroupBy(p => p.Name);
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

        public void AddSales(ProductInfo newProduct)
        {
            _repository.AddSales(newProduct);
        }

        public void AddAllSales()
        {
            _repository.AddAllSales();
        }
    }
}
