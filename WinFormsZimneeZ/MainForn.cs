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

            // Получаем BindingList из History
            BindingList<ProductInfo> allProducts = History.GetAllSales();

            // Получаем список сезонных товаров
            BindingList<ProductInfo> seasonalProducts = History.FindSeasonalProducts(allProducts, percentageThreshold); // Вызываем метод через объект History

            // Обновляем DataGridView
            ProductTable.DataSource = seasonalProducts;
        }
    }
}

