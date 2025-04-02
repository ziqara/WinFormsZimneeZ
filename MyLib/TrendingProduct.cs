using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class TrendingProduct
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }
        [DisplayName("Категория")]
        public string Category { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        // Показывает, во сколько раз выросли продажи (например, 2.5 означает увеличение в 2.5 раза)
        [DisplayName("Во сколько раз выросли продажи")]
        public double IncreaseFactor { get; set; }
    }
}
