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
        private BindingList<ProductInfo> products;
        private LoadCsvSaveHtml csvLoader;
        public MainForn()
        {
            InitializeComponent();
            products = new BindingList<ProductInfo>();
            csvLoader = new LoadCsvSaveHtml();
            FillWithTestData();
            ProductTable.DataSource = products;
        }

        private void FillWithTestData()
        {
            products.Add(new ProductInfo("TestProduct1", "TestCategoryA", 10.00m, 5, DateTime.Now));
            products.Add(new ProductInfo("TestProduct2", "TestCategoryB", 20.50m, 10, DateTime.Now.AddDays(-1)));
            products.Add(new ProductInfo("TestProduct3", "TestCategoryA", 5.75m, 20, DateTime.Now.AddDays(-2)));
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
                    csvLoader.LoadCsvData(filePath, products);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DefButton_Click(object sender, EventArgs e)
        {

        }
    }
}

