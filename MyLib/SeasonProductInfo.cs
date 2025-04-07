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

        public override bool Equals(object obj)
        {
            if (obj is SeasonProductInfo other)
            {
                // Сравниваем имя и все месячные значения с допуском (0.01)
                return this.Name == other.Name &&
                       Math.Abs(this.JanuaryGrowth - other.JanuaryGrowth) < 0.01 &&
                       Math.Abs(this.FebruaryGrowth - other.FebruaryGrowth) < 0.01 &&
                       Math.Abs(this.MarchGrowth - other.MarchGrowth) < 0.01 &&
                       Math.Abs(this.AprilGrowth - other.AprilGrowth) < 0.01 &&
                       Math.Abs(this.MayGrowth - other.MayGrowth) < 0.01 &&
                       Math.Abs(this.JuneGrowth - other.JuneGrowth) < 0.01 &&
                       Math.Abs(this.JulyGrowth - other.JulyGrowth) < 0.01 &&
                       Math.Abs(this.AugustGrowth - other.AugustGrowth) < 0.01 &&
                       Math.Abs(this.SeptemberGrowth - other.SeptemberGrowth) < 0.01 &&
                       Math.Abs(this.OctoberGrowth - other.OctoberGrowth) < 0.01 &&
                       Math.Abs(this.NovemberGrowth - other.NovemberGrowth) < 0.01 &&
                       Math.Abs(this.DecemberGrowth - other.DecemberGrowth) < 0.01;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Можно комбинировать хэш-коды свойств; здесь для простоты возвращаем хэш имени
            return Name != null ? Name.GetHashCode() : 0;
        }
    }
}
