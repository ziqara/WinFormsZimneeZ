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
        private SalesHistory Histroy;
        private LoadCsvSaveHtml csvLoader;

        public MainForn()
        {
            InitializeComponent();
            Histroy = new SalesHistory();
            csvLoader = new LoadCsvSaveHtml();
            Histroy.AddAllSales();
            ProductTable.DataSource = Histroy.GetAllSales();       
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
                    csvLoader.LoadCsvData(filePath, Histroy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DefButton_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = Histroy.GetProductsWithZeroResidueAndLatestSale();

            ProductTable.DataSource = Items;
        }

        private void TopButton_Click(object sender, EventArgs e)
        {

            BindingList<ProductInfo> Items = Histroy.ShowBestSellingProducts();
            ProductTable.DataSource = Items;
        }
    }
}

