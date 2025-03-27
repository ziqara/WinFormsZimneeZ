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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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

            ProductTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            MenuFiltr.BackColor = ColorTranslator.FromHtml("#0d1b2a");
            DefStripButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            TopStripButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            FolderMenu.BackColor = ColorTranslator.FromHtml("#778da9");
            FolderMenu.ForeColor = ColorTranslator.FromHtml("#0d1b2a");



            label1.ForeColor = ColorTranslator.FromHtml("#778da9"); //textlabel
            label2.ForeColor = ColorTranslator.FromHtml("#778da9"); //textlabel

            SeasonBox.BackColor = ColorTranslator.FromHtml("#415a77"); //backtextbox
            SeasonBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a"); //TEXTINtextbox

            trendingWeeksTextBox.BackColor = ColorTranslator.FromHtml("#415a77"); //backtextbox
            trendingWeeksTextBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a"); //TEXTINtextbox


            TrendButton.BackColor = ColorTranslator.FromHtml("#1b263b"); //backbutton
            TrendButton.FlatStyle = FlatStyle.Flat;
            TrendButton.ForeColor = ColorTranslator.FromHtml("#778da9"); // TEXTINbutton
            TrendButton.FlatAppearance.BorderColor = Color.White; // outlinebutton
            TrendButton.FlatAppearance.BorderSize = 1;
            this.ActiveControl = null;

            SeasonButton.BackColor = ColorTranslator.FromHtml("#1b263b"); //backbutton
            SeasonButton.FlatStyle = FlatStyle.Flat;
            SeasonButton.ForeColor = ColorTranslator.FromHtml("#778da9"); // TEXTINbutton
            SeasonButton.FlatAppearance.BorderColor = Color.White; // outlinebutton
            SeasonButton.FlatAppearance.BorderSize = 1;
            this.ActiveControl = null;

            ProductTable.BackgroundColor = ColorTranslator.FromHtml("#0d1b2a");
            this.BackColor = ColorTranslator.FromHtml("#0d1b2a");// backform
            picDOWN.Image = Image.FromFile("vip.gif"); // gif
            picDOWN.SizeMode = PictureBoxSizeMode.StretchImage;

           
        }
        private void MainForn_Load(object sender, EventArgs e)
        {
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }

        private void ApplyDataCellStyle(DataGridView dataGridView, string hexColor)
        {
            ProductTable.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            dataGridView.Rows.Cast<DataGridViewRow>()
                .SelectMany(row => row.Cells.Cast<DataGridViewCell>())
                .Where(cell => cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                .ToList()
                .ForEach(cell =>
                {
                    cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                    cell.Style.ForeColor = Color.Black;
                });
        }

        private void SetDataCellBackgroundColor(DataGridView dataGridView, string hexColor)
        {
            dataGridView.Rows.Cast<DataGridViewRow>()
                .SelectMany(row => row.Cells.Cast<DataGridViewCell>())
                .Where(cell => cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                .ToList()
                .ForEach(cell =>
                {
                    cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                    cell.Style.ForeColor = Color.White;
                });
        }

        private void SeasonButton_Click(object sender, EventArgs e)
        {
            SeasonButton.BackColor = ColorTranslator.FromHtml("#1b263b"); //backbutton
            SeasonButton.FlatStyle = FlatStyle.Flat;
            SeasonButton.ForeColor = ColorTranslator.FromHtml("#778da9"); // TEXTINbutton
            SeasonButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#415a77"); // outlinebutton
            SeasonButton.FlatAppearance.BorderSize = 1;
            this.ActiveControl = null;

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
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
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
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }


        private void defStripButton_Click(object sender, EventArgs e)
        {
            
            BindingList<ProductInfo> Items = History.GetProductsWithZeroResidueAndLatestSale();
            ProductTable.DataSource = Items;
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> Items = History.ShowBestSellingProducts();
            ProductTable.DataSource = Items;
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }

        

        private void LoadToolStrip_Click(object sender, EventArgs e)
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

        private void SaveToolStrip_Click(object sender, EventArgs e)
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

        private void rdtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ProductTable.DataSource = History.GetAllSales();
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            this.ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }
    }
}

