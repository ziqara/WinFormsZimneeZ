using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsZimneeZ
{
    public partial class MainForn : Form
    {
        private SalesHistory History;
        private LoadCsvSaveHtml csvLoader;

        public MainForn()
        {
            InitializeComponent();
            History = new SalesHistory();
            csvLoader = new LoadCsvSaveHtml();
            History.AddAllSales();
            ProductTable.DataSource = History.GetAllSales();

            reloaded.SetToolTip(Reload, "Сбросить");
        }

        private void LoadCsvButton_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a CSV File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    csvLoader.LoadCsvData(filePath, History);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DefButton_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = History.GetProductsWithZeroResidueAndLatestSale();
            ProductTable.DataSource = Items;
        }

        private void TopButton_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = History.ShowBestSellingProducts();
            ProductTable.DataSource = Items;
        }

        private void SeasonButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(SeasonBox.Text, out decimal percentageThreshold))
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для процента.");
                return;
            }
            if (Convert.ToDecimal(SeasonBox.Text) < 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для процента.");
                return;
            }
            // Получаем список сезонных товаров
            BindingList<ProductInfo> Items = History.FindSeasonalProducts(History.GetAllSales(), percentageThreshold);

            ProductTable.DataSource = Items;
        }

        private void TrendButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(trendingWeeksTextBox.Text, out int trendingWeeks))
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для количества недель.");
                return;
            }
            if (Convert.ToDecimal(trendingWeeksTextBox.Text) < 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение для количества недель..");
                return;
            }
            // Находим трендовые товары
            BindingList<ProductInfo> Items = History.FindTrendingProducts(History.GetAllSales(), trendingWeeks);

            ProductTable.DataSource = Items;
        }
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            ProductTable.DataSource = History.GetAllSales();
        }

        private void SaveHtmlButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Save DataGridView as HTML";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                LoadCsvSaveHtml.SaveDataGridViewToHtml(ProductTable, filePath);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение завершено", MessageBoxButtons.OK);
            }
        }

        private void defStripButton_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = History.GetProductsWithZeroResidueAndLatestSale();
            ProductTable.DataSource = Items;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = History.ShowBestSellingProducts();
            ProductTable.DataSource = Items;
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ProductTable.DataSource = History.GetAllSales();
        }
    }
}

