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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsZimneeZ
{
    public partial class SeasonForm : Form
    {
        public SalesHistory History { get; set; }
        private BindingList<SeasonProductInfo> _allSeasonData;

        public SeasonForm(SalesHistory history)
        {
            InitializeComponent();
            InitializeStyles();
            History = history;
            _allSeasonData = History.GetSeasonSales();
            GroupData(); // Группируем данные при инициализации
            UpdateSeasonTable(0); // Отображаем все данные при запуске
        }
        private void InitializeStyles()
        {
            pictureBox1.Image = Image.FromFile("MB.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            SeasonTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            
            label1.ForeColor = ColorTranslator.FromHtml("#778da9");
            SeasonBox.BackColor = ColorTranslator.FromHtml("#778da9");
            SeasonBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a");

            SaveSeason.BackColor = ColorTranslator.FromHtml("#1b263b");
            SaveSeason.FlatStyle = FlatStyle.Flat;
            SaveSeason.ForeColor = ColorTranslator.FromHtml("#778da9");
            SaveSeason.FlatAppearance.BorderColor = Color.White;
            SaveSeason.FlatAppearance.BorderSize = 1;

            BackButt.BackColor = ColorTranslator.FromHtml("#1b263b");
            BackButt.FlatStyle = FlatStyle.Flat;
            BackButt.ForeColor = ColorTranslator.FromHtml("#778da9");
            BackButt.FlatAppearance.BorderColor = Color.White;
            BackButt.FlatAppearance.BorderSize = 1;

            FilterSeason.BackColor = ColorTranslator.FromHtml("#1b263b");
            FilterSeason.FlatStyle = FlatStyle.Flat;
            FilterSeason.ForeColor = ColorTranslator.FromHtml("#778da9");
            FilterSeason.FlatAppearance.BorderColor = Color.White;
            FilterSeason.FlatAppearance.BorderSize = 1;

            SeasonTable.BackgroundColor = ColorTranslator.FromHtml("#0d1b2a");
            this.BackColor = ColorTranslator.FromHtml("#0d1b2a");

        }
        private void SetDataGridStyles()
        {
            if (SeasonTable == null)
            {
                return;
            }

            // Если в таблице есть строки – применяем стили
            if (SeasonTable.Rows != null && SeasonTable.Rows.Count > 0)
            {
                SetDataCellBackgroundColor(SeasonTable, "#415a77");
                SeasonTable.AllowUserToAddRows = false;
                SeasonTable.CurrentCell.Selected = false;
                SeasonTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
                SeasonTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
                ApplyDataCellStyle(SeasonTable, "#778da9");
            }
        }
        private void SetDataCellBackgroundColor(DataGridView dataGridView, string hexColor)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
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
        private void ApplyDataCellStyle(DataGridView dataGridView, string hexColor)
        {
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView.Rows)
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


        private void UpdateSeasonTable(decimal threshold)
        {
            BindingList<SeasonProductInfo> filteredData = History.FilterSeasonalProducts(_allSeasonData, threshold);

            // Если подходящих товаров нет, выводим сообщение об ошибке.
            if (filteredData == null || filteredData.Count == 0)
            {
                MessageBox.Show("Нет товаров, соответствующих заданному проценту.","Ошибка",MessageBoxButtons.OK);
            }

            // Устанавливаем источник данных для таблицы.
            SeasonTable.DataSource = filteredData;
        }

        private void GroupData()
        {
            _allSeasonData = History.GroupProducts(_allSeasonData);
        }

        private void SeasonBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void FilterSeason_Click(object sender, EventArgs e)
        {
            decimal threshold;
            if (decimal.TryParse(SeasonBox.Text, out threshold))
            {
                UpdateSeasonTable(threshold);
                SetDataGridStyles();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное число для процента.", "Ошибка",MessageBoxButtons.OK);
                UpdateSeasonTable(0);
                SetDataGridStyles();
            }
        }

        private void BackButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSeason_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*",
                Title = "Save DataGridView as HTML"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCsvSaveHtml.SaveDataGridViewToHtml(SeasonTable, saveFileDialog.FileName);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение завершено", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void SeasonForm_Load(object sender, EventArgs e)
        {
            SetDataGridStyles();
        }
    }
}
