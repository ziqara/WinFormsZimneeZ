using System;
using System.ComponentModel;

namespace MyLib
{
    public class SeasonProductInfo
    {
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Январь, %")]
        public double JanuaryGrowth { get; set; }
        [DisplayName("Февраль, %")]
        public double FebruaryGrowth { get; set; }
        [DisplayName("Март, %")]
        public double MarchGrowth { get; set; }
        [DisplayName("Апрель, %")]
        public double AprilGrowth { get; set; }
        [DisplayName("Май, %")]
        public double MayGrowth { get; set; }
        [DisplayName("Июнь, %")]
        public double JuneGrowth { get; set; }
        [DisplayName("Июль, %")]
        public double JulyGrowth { get; set; }
        [DisplayName("Август, %")]
        public double AugustGrowth { get; set; }
        [DisplayName("Сентябрь, %")]
        public double SeptemberGrowth { get; set; }
        [DisplayName("Октябрь, %")]
        public double OctoberGrowth { get; set; }
        [DisplayName("Ноябрь, %")]
        public double NovemberGrowth { get; set; }
        [DisplayName("Декабрь, %")]
        public double DecemberGrowth { get; set; }
    }
}
