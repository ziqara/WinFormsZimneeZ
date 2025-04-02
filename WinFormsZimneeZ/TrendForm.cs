using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace WinFormsZimneeZ
{
    public partial class TrendForm : Form
    {
        public SalesHistory History { get; set; }
        public TrendForm(SalesHistory history)
        {
            History = history;
            InitializeComponent();
            // Загружаем все агрегированные данные, преобразованные в TrendingProduct с IncreaseFactor = 0
            TrendTable.DataSource = ConvertToTrendingProducts(History.GetGroupedProducts());

        }

        private void TrendButton_Click(object sender, EventArgs e)
        {
            int weeks;
            if (!int.TryParse(TrendBox.Text, out weeks) || weeks <= 0)
            {
                MessageBox.Show("Введите корректное положительное число недель.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime referenceDate = DateTimeWeek.Value.Date;
            LoadTrendingProducts(referenceDate, weeks);
        }

        private void LoadTrendingProducts(DateTime referenceDate, int trendingWeeks)
        {
            BindingList<TrendingProduct> trendingProducts = History.FindTrendingProducts(referenceDate, trendingWeeks);
            TrendTable.DataSource = trendingProducts;
            if (trendingProducts.Count == 0)
            {
                MessageBox.Show($"За период с {referenceDate.AddDays(-trendingWeeks * 7):d} по {referenceDate:d} трендовых товаров не обнаружено.",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TrendForm_Load(object sender, EventArgs e)
        {

        }

        private void ResetTableButton_Click(object sender, EventArgs e)
        {
            TrendTable.DataSource = ConvertToTrendingProducts(History.GetGroupedProducts()); ;
        }
        // Преобразует список ProductInfo в список TrendingProduct с IncreaseFactor = 0
        private BindingList<TrendingProduct> ConvertToTrendingProducts(BindingList<ProductInfo> products)
        {
            var list = products.Select(p => new TrendingProduct
            {
                Name = p.Name,
                Category = p.Category,
                Price = p.Price,
                IncreaseFactor = 0
            }).ToList();
            return new BindingList<TrendingProduct>(list);
        }
    }
}
