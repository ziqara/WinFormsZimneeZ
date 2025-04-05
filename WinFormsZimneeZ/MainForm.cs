using MyLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsZimneeZ
{
    public partial class MainForm : Form
    {
        private SalesHistory History;
        private LoadCsvSaveHtml csvLoader;

        public MainForm()
        {
            InitializeComponent();
            History = new SalesHistory();
            csvLoader = new LoadCsvSaveHtml();

            History.AddAllSales();
            // Отображаем сгруппированные продажи
            ProductTable.DataSource = History.GetGroupedProducts();
            InitializeStyles();
        }


        private void InitializeStyles()
        {

            ProductTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            MenuFiltr.BackColor = ColorTranslator.FromHtml("#0d1b2a");
            DefStripButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            TopStripButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            FolderMenu.BackColor = ColorTranslator.FromHtml("#778da9");
            FolderMenu.ForeColor = ColorTranslator.FromHtml("#0d1b2a");

            TrendButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            TrendButton.FlatStyle = FlatStyle.Flat;
            TrendButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            TrendButton.FlatAppearance.BorderColor = Color.White;
            TrendButton.FlatAppearance.BorderSize = 1;

            SeasonButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            SeasonButton.FlatStyle = FlatStyle.Flat;
            SeasonButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            SeasonButton.FlatAppearance.BorderColor = Color.White;
            SeasonButton.FlatAppearance.BorderSize = 1;

            ProductTable.BackgroundColor = ColorTranslator.FromHtml("#0d1b2a");
            this.BackColor = ColorTranslator.FromHtml("#0d1b2a");

        }

        private void MainForn_Load(object sender, EventArgs e)
        {
            SetDataGridStyles();
        }

        private void SetDataGridStyles()
        {
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            ProductTable.AllowUserToAddRows = false;
            if (ProductTable.CurrentCell != null)
                ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }

        private void SetDataCellBackgroundColor(DataGridView grid, string hexColor)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                        cell.Style.ForeColor = Color.White;
                    }
                }
            }
        }

        private void ApplyDataCellStyle(DataGridView grid, string hexColor)
        {
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void SeasonButton_Click(object sender, EventArgs e)
        {
            SeasonForm seasonForm = new SeasonForm(History);
            seasonForm.Show();
            SetDataGridStyles();
            this.ActiveControl = null;
        }

        private void defStripButton_Click(object sender, EventArgs e)
        {
            BindingList<ProductInfo> zeroResidueProducts = History.GetProductsWithZeroResidueAndLatestSale();
            ProductTable.DataSource = zeroResidueProducts;
            SetDataGridStyles();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ProductTable.DataSource = History.ShowBestSellingProducts();
            SetDataGridStyles();
        }

        private void LoadToolStrip_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Select a CSV File"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    History = csvLoader.LoadCsvData(dlg.FileName, History);
                    ProductTable.DataSource = History.GetGroupedProducts();
                    InitializeStyles();
                    SetDataGridStyles();
                    MessageBox.Show("Данные успешно загружены", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*",
                Title = "Save DataGridView as HTML"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadCsvSaveHtml.SaveDataGridViewToHtml(ProductTable, dlg.FileName);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение завершено", MessageBoxButtons.OK);
            }
        }

        private void rdtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductTable.DataSource = History.GetGroupedProducts();
            SetDataGridStyles();
        }

        private void TurnList_Click(object sender, EventArgs e)
        {
            ProductTable.DataSource = History.GetAllSales();
            SetDataGridStyles();
        }

        private void TrendButton_Click(object sender, EventArgs e)
        {
            TrendForm trendForm = new TrendForm(History);
            trendForm.Show();
            SetDataGridStyles();
            this.ActiveControl = null;
        }
    }
}
