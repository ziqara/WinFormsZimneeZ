using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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

            // Устанавливаем стиль для заголовков столбцов
            SetHeaderStyles(TrendTable);

            // Применяем стиль к ячейкам (если нужно)
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
                        // Явно задаём шрифт для каждой ячейки
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
            // Используем текущую дату как точку отсчёта
            DateTime referenceDate = DateTime.Today;
            double minIncrease = 2.0; // Например, товар считается трендовым, если продажи увеличились в 2 и более раза.
            LoadTrendingProducts(referenceDate, weeks, minIncrease);
        }

        private void LoadTrendingProducts(DateTime referenceDate, int trendingWeeks, double minIncrease)
        {
            BindingList<TrendingProduct> trendingProducts = History.FindTrendingProducts(referenceDate, trendingWeeks, minIncrease);
            TrendTable.DataSource = trendingProducts;
            if (trendingProducts.Count == 0)
            {
                MessageBox.Show($"За период с {referenceDate.AddDays(-trendingWeeks * 7):d} по {referenceDate:d} трендовых товаров не обнаружено.",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetTableButton_Click(object sender, EventArgs e)
        {
            // Сброс TextBox
            TrendBox.Clear();
            FiltrBox.Clear();

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


        private void FiltrButton_Click(object sender, EventArgs e)
        {
            double threshold;
            if (!double.TryParse(FiltrBox.Text, out threshold) || threshold <= 0)
            {
                MessageBox.Show("Введите корректное положительное число для фильтра.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Предполагаем, что TrendTable.DataSource уже содержит список TrendingProduct
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
                MessageBox.Show($"Нет товаров с IncreaseFactor ≥ {threshold}.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
