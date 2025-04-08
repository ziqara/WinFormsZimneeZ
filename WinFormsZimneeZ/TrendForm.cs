using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyLib;
using MyLib.Services;

namespace WinFormsZimneeZ
{
    public partial class TrendForm : Form
    {
        private SalesRepository repository;
        private TrendSalesHistoryService trendService;

        public TrendForm(SalesRepository repository)
        {
            InitializeComponent();
            this.repository = repository;
            // Создаем сервис трендовых продаж, передавая SalesRepository
            trendService = new TrendSalesHistoryService(repository);
            // Отображаем данные по умолчанию:
            GeneralSalesHistoryService generalService = new GeneralSalesHistoryService(repository);
            TrendTable.DataSource = ConvertToTrendingProducts(generalService.GetGroupedProducts());
            TrendTable.DataBindingComplete += TrendTable_DataBindingComplete;
            InitializeStyles();
        }

        private void TrendTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetDataGridStyles();
        }

        private void InitializeStyles()
        {
            label1.ForeColor = ColorTranslator.FromHtml("#778da9");
            Trend.ForeColor = ColorTranslator.FromHtml("#778da9");
            TrendBox.BackColor = ColorTranslator.FromHtml("#778da9");
            TrendBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a");
            FiltrBox.BackColor = ColorTranslator.FromHtml("#778da9");
            FiltrBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a");

            TrendButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            TrendButton.FlatStyle = FlatStyle.Flat;
            TrendButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            TrendButton.FlatAppearance.BorderColor = Color.White;
            TrendButton.FlatAppearance.BorderSize = 1;

            FiltrButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            FiltrButton.FlatStyle = FlatStyle.Flat;
            FiltrButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            FiltrButton.FlatAppearance.BorderColor = Color.White;
            FiltrButton.FlatAppearance.BorderSize = 1;

            CancelButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            CancelButton.FlatStyle = FlatStyle.Flat;
            CancelButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            CancelButton.FlatAppearance.BorderColor = Color.White;
            CancelButton.FlatAppearance.BorderSize = 1;

            ResetTableButton.BackColor = ColorTranslator.FromHtml("#1b263b");
            ResetTableButton.FlatStyle = FlatStyle.Flat;
            ResetTableButton.ForeColor = ColorTranslator.FromHtml("#778da9");
            ResetTableButton.FlatAppearance.BorderColor = Color.White;
            ResetTableButton.FlatAppearance.BorderSize = 1;

            SaveHTMLBUTTON.BackColor = ColorTranslator.FromHtml("#1b263b");
            SaveHTMLBUTTON.FlatStyle = FlatStyle.Flat;
            SaveHTMLBUTTON.ForeColor = ColorTranslator.FromHtml("#778da9");
            SaveHTMLBUTTON.FlatAppearance.BorderColor = Color.White;
            SaveHTMLBUTTON.FlatAppearance.BorderSize = 1;

            TrendTable.BackgroundColor = ColorTranslator.FromHtml("#0d1b2a");
            this.BackColor = ColorTranslator.FromHtml("#0d1b2a");
        }

        private void SetDataGridStyles()
        {
            SetDataCellBackgroundColor(TrendTable, "#415a77");
            TrendTable.AllowUserToAddRows = false;
            if (TrendTable.CurrentCell != null)
                TrendTable.CurrentCell.Selected = false;
            SetHeaderStyles(TrendTable);
            ApplyDataCellStyle(TrendTable, "#778da9");
        }

        private void SetHeaderStyles(DataGridView grid)
        {
            Font headerFont = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.HeaderCell.Style.Font = headerFont;
                col.HeaderCell.Style.BackColor = ColorTranslator.FromHtml("#1b263b");
                col.HeaderCell.Style.ForeColor = ColorTranslator.FromHtml("#778da9");
            }
        }

        private void ApplyDataCellStyle(DataGridView grid, string hexColor)
        {
            Font font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            grid.DefaultCellStyle.Font = font;
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.Font = font;
                        cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                        cell.Style.ForeColor = Color.Black;
                    }
                }
            }
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

        private void TrendButton_Click(object sender, EventArgs e)
        {
            int weeks;
            if (!int.TryParse(TrendBox.Text, out weeks) || weeks <= 0)
            {
                MessageBox.Show("Введите корректное положительное число недель.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime referenceDate = DateTime.Today;
            double minIncrease = 2.0;
            LoadTrendingProducts(referenceDate, weeks, minIncrease);
        }

        private void LoadTrendingProducts(DateTime referenceDate, int trendingWeeks, double minIncrease)
        {
            BindingList<TrendingProduct> trendingProducts = trendService.FindTrendingProducts(referenceDate, trendingWeeks, minIncrease);
            TrendTable.DataSource = trendingProducts;
            if (trendingProducts.Count == 0)
            {
                MessageBox.Show($"За период с {referenceDate.AddDays(-trendingWeeks * 7):d} по {referenceDate:d} трендовых товаров не обнаружено.",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetTableButton_Click(object sender, EventArgs e)
        {
            TrendBox.Clear();
            FiltrBox.Clear();
            // Создаем новый экземпляр GeneralSalesHistoryService с общим репозиторием
            GeneralSalesHistoryService generalService = new GeneralSalesHistoryService(repository);
            TrendTable.DataSource = ConvertToTrendingProducts(generalService.GetGroupedProducts());
        }

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

        private void FiltrButton_Click(object sender, EventArgs e)
        {
            double threshold;
            if (!double.TryParse(FiltrBox.Text, out threshold) || threshold <= 0)
            {
                MessageBox.Show("Введите корректное положительное число для фильтра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BindingList<TrendingProduct> currentList = TrendTable.DataSource as BindingList<TrendingProduct>;
            if (currentList == null)
            {
                MessageBox.Show("Нет данных для фильтрации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var filtered = currentList.Where(tp => tp.IncreaseFactor >= threshold).ToList();
            BindingList<TrendingProduct> filteredList = new BindingList<TrendingProduct>(filtered);
            if (filteredList.Count == 0)
            {
                MessageBox.Show($"Нет товаров с ростом ≥ {threshold}.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TrendTable.DataSource = filteredList;
        }

        private void SaveHTMLBUTTON_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*",
                Title = "Save DataGridView as HTML"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadCsvSaveHtml.SaveDataGridViewToHtml(TrendTable, dlg.FileName);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение завершено", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void TrendForm_Load(object sender, EventArgs e)
        {
            SetDataGridStyles();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
