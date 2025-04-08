using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyLib.Services
{
    public class SeasonSalesHistoryService
    {
        private SalesRepository _repository;

        public SeasonSalesHistoryService(SalesRepository repository)
        {
            _repository = repository;
        }
        
        // Формирование сезонных данных.
        // Группировка происходит по имени товара.
        // Для каждого товара вычисляется процентное распределение продаж по месяцам.
        public BindingList<SeasonProductInfo> GetSeasonSales()
        {
            var seasonSales = _repository.AllSales
                 .GroupBy(sale => sale.Name)
                 .Select(g =>
                 {
                     int totalSales = g.Sum(sale => sale.QuantitySold);
                     SeasonProductInfo info = new SeasonProductInfo();
                     info.Name = g.Key;

                     for (int month = 1; month <= 12; month++)
                     {
                         int monthSales = g.Where(sale => sale.LastSell.Month == month).Sum(sale => sale.QuantitySold);
                         double growth = totalSales > 0 ? Math.Round(((double)monthSales / totalSales) * 100, 2) : 0;
                         switch (month)
                         {
                             case 1: info.JanuaryGrowth = growth; break;
                             case 2: info.FebruaryGrowth = growth; break;
                             case 3: info.MarchGrowth = growth; break;
                             case 4: info.AprilGrowth = growth; break;
                             case 5: info.MayGrowth = growth; break;
                             case 6: info.JuneGrowth = growth; break;
                             case 7: info.JulyGrowth = growth; break;
                             case 8: info.AugustGrowth = growth; break;
                             case 9: info.SeptemberGrowth = growth; break;
                             case 10: info.OctoberGrowth = growth; break;
                             case 11: info.NovemberGrowth = growth; break;
                             case 12: info.DecemberGrowth = growth; break;
                         }
                     }
                     return info;
                 })
                 .ToList();

            return new BindingList<SeasonProductInfo>(seasonSales);
        }

        // Группировка сезонных данных по имени товара (если нужно объединить несколько записей для одного товара)
        public BindingList<SeasonProductInfo> GroupProducts(BindingList<SeasonProductInfo> data)
        {
            var grouped = data.GroupBy(p => p.Name)
               .Select(g =>
               {
                   SeasonProductInfo aggregated = new SeasonProductInfo();
                   aggregated.Name = g.Key;
                   aggregated.JanuaryGrowth = Math.Round(g.Average(x => x.JanuaryGrowth), 2);
                   aggregated.FebruaryGrowth = Math.Round(g.Average(x => x.FebruaryGrowth), 2);
                   aggregated.MarchGrowth = Math.Round(g.Average(x => x.MarchGrowth), 2);
                   aggregated.AprilGrowth = Math.Round(g.Average(x => x.AprilGrowth), 2);
                   aggregated.MayGrowth = Math.Round(g.Average(x => x.MayGrowth), 2);
                   aggregated.JuneGrowth = Math.Round(g.Average(x => x.JuneGrowth), 2);
                   aggregated.JulyGrowth = Math.Round(g.Average(x => x.JulyGrowth), 2);
                   aggregated.AugustGrowth = Math.Round(g.Average(x => x.AugustGrowth), 2);
                   aggregated.SeptemberGrowth = Math.Round(g.Average(x => x.SeptemberGrowth), 2);
                   aggregated.OctoberGrowth = Math.Round(g.Average(x => x.OctoberGrowth), 2);
                   aggregated.NovemberGrowth = Math.Round(g.Average(x => x.NovemberGrowth), 2);
                   aggregated.DecemberGrowth = Math.Round(g.Average(x => x.DecemberGrowth), 2);
                   return aggregated;
               }).ToList();

            return new BindingList<SeasonProductInfo>(grouped);
        }
        
        // Фильтрация сезонных данных по глобальному порогу.
        // Возвращает те товары, у которых максимум из процентных значений за месяцы >= threshold.
        public BindingList<SeasonProductInfo> FilterSeasonProductsByThreshold(BindingList<SeasonProductInfo> data, double threshold)
        {
            var filtered = data.Where(product =>
            {
                double maxGrowth = new double[]
                {
                    product.JanuaryGrowth, product.FebruaryGrowth, product.MarchGrowth, product.AprilGrowth,
                    product.MayGrowth, product.JuneGrowth, product.JulyGrowth, product.AugustGrowth,
                    product.SeptemberGrowth, product.OctoberGrowth, product.NovemberGrowth, product.DecemberGrowth
                }.Max();
                return maxGrowth >= threshold;
            }).ToList();
            return new BindingList<SeasonProductInfo>(filtered);
        }

        public BindingList<SeasonProductInfo> FilterSeasonProductsByMonth(BindingList<SeasonProductInfo> data, int month, double threshold)
        {
            var filtered = data.Where(item =>
            {
                double value = 0;
                switch (month)
                {
                    case 1: value = item.JanuaryGrowth; break;
                    case 2: value = item.FebruaryGrowth; break;
                    case 3: value = item.MarchGrowth; break;
                    case 4: value = item.AprilGrowth; break;
                    case 5: value = item.MayGrowth; break;
                    case 6: value = item.JuneGrowth; break;
                    case 7: value = item.JulyGrowth; break;
                    case 8: value = item.AugustGrowth; break;
                    case 9: value = item.SeptemberGrowth; break;
                    case 10: value = item.OctoberGrowth; break;
                    case 11: value = item.NovemberGrowth; break;
                    case 12: value = item.DecemberGrowth; break;
                    default: value = 0; break;
                }
                return value >= threshold;
            }).ToList();

            return new BindingList<SeasonProductInfo>(filtered);
        }
    }
}
