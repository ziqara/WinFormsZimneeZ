﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MyLib;
using MyLib.Services;

namespace WinFormsZimneeZ
{
    public partial class SeasonForm : Form
    {
        private SeasonSalesHistoryService seasonService;
        private BindingList<SeasonProductInfo> _allSeasonData;

        public SeasonForm(SalesRepository repository)
        {
            InitializeComponent();
            InitializeStyles();
            seasonService = new SeasonSalesHistoryService(repository);
            // Получаем сезонные данные и сразу группируем их.
            _allSeasonData = seasonService.GroupProducts(seasonService.GetSeasonSales());
            SeasonTable.DataSource = _allSeasonData;
        }

        private void InitializeStyles()
        {
            monthComboBox.BackColor = ColorTranslator.FromHtml("#778da9");
            monthComboBox.ForeColor = ColorTranslator.FromHtml("#0d1b2a");
            monthComboBox.FlatStyle = FlatStyle.Flat;
            monthComboBox.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);

            SeasonTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);

            label1.ForeColor = ColorTranslator.FromHtml("#778da9");
            label2.ForeColor = ColorTranslator.FromHtml("#778da9");
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

            resetbutton.BackColor = ColorTranslator.FromHtml("#1b263b");
            resetbutton.FlatStyle = FlatStyle.Flat;
            resetbutton.ForeColor = ColorTranslator.FromHtml("#778da9");
            resetbutton.FlatAppearance.BorderColor = Color.White;
            resetbutton.FlatAppearance.BorderSize = 1;

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
                return;

            if (SeasonTable.Rows != null && SeasonTable.Rows.Count > 0)
            {
                SetDataCellBackgroundColor(SeasonTable, "#415a77");
                SeasonTable.AllowUserToAddRows = false;
                if (SeasonTable.CurrentCell != null)
                    SeasonTable.CurrentCell.Selected = false;
                SeasonTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
                SeasonTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
                ApplyDataCellStyle(SeasonTable, "#778da9");
            }
        }

        private void SetDataCellBackgroundColor(DataGridView grid, string hexColor)
        {
            foreach (DataGridViewRow row in grid.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                        cell.Style.ForeColor = Color.White;
                    }
        }

        private void ApplyDataCellStyle(DataGridView grid, string hexColor)
        {
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            foreach (DataGridViewRow row in grid.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        cell.Style.BackColor = ColorTranslator.FromHtml(hexColor);
                        cell.Style.ForeColor = Color.Black;
                    }
        }

        private void FilterSeason_Click(object sender, EventArgs e)
        {
            double threshold;
            bool thresholdProvided = double.TryParse(SeasonBox.Text, out threshold);
            int selectedMonth = 0;
            if (monthComboBox.SelectedItem != null)
            {
                string selected = monthComboBox.SelectedItem.ToString();
                if (selected != "Все")
                {
                    switch (selected)
                    {
                        case "Январь": selectedMonth = 1; break;
                        case "Февраль": selectedMonth = 2; break;
                        case "Март": selectedMonth = 3; break;
                        case "Апрель": selectedMonth = 4; break;
                        case "Май": selectedMonth = 5; break;
                        case "Июнь": selectedMonth = 6; break;
                        case "Июль": selectedMonth = 7; break;
                        case "Август": selectedMonth = 8; break;
                        case "Сентябрь": selectedMonth = 9; break;
                        case "Октябрь": selectedMonth = 10; break;
                        case "Ноябрь": selectedMonth = 11; break;
                        case "Декабрь": selectedMonth = 12; break;
                    }
                }
            }

            BindingList<SeasonProductInfo> filteredData = null;
            if (selectedMonth > 0 && thresholdProvided)
            {
                filteredData = seasonService.FilterSeasonProductsByMonth(_allSeasonData, selectedMonth, threshold);
            }
            else if (selectedMonth > 0)
            {
                filteredData = new BindingList<SeasonProductInfo>(
                    _allSeasonData.Where(item =>
                    {
                        double value = 0;
                        switch (selectedMonth)
                        {
                            case 1: value = item.JanuaryGrowth; break;
                            case 2: value = item.FebruaryGrowth; break;
                            case 3: value = item.MarchGrowth; break;
                            case 4: value = item.AprilGrowth; break;
                            case 5: value = item.MayGrowth; break;
                            case 6: value = item.JuneGrowth; break;
                            case 7: value = item.JulyGrowth; break;
                            case 8: value = item.AugustGrowth; break;
                            case 9: value = item.SeptemberGrowth; break;
                            case 10: value = item.OctoberGrowth; break;
                            case 11: value = item.NovemberGrowth; break;
                            case 12: value = item.DecemberGrowth; break;
                        }
                        return value > 0;
                    }).ToList()
                );
            }
            else if (thresholdProvided)
            {
                filteredData = seasonService.FilterSeasonProductsByThreshold(_allSeasonData, threshold);
            }
            else
            {
                filteredData = _allSeasonData;
            }

            if (filteredData == null || filteredData.Count == 0)
            {
                MessageBox.Show("Нет товаров, удовлетворяющих заданным критериям.", "Информация", MessageBoxButtons.OK);
            }
            SeasonTable.DataSource = filteredData;
            SetDataGridStyles();
        }

        private void BackButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveSeason_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*",
                Title = "Save DataGridView as HTML"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadCsvSaveHtml.SaveDataGridViewToHtml(SeasonTable, dlg.FileName);
                MessageBox.Show("Данные успешно сохранены!", "Сохранение завершено", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            _allSeasonData = seasonService.GroupProducts(seasonService.GetSeasonSales());
            SeasonTable.DataSource = _allSeasonData;
            monthComboBox.SelectedIndex = -1;
            monthComboBox.Text = string.Empty;
            SeasonBox.Clear();
            SetDataGridStyles();
        }

        private void SeasonForm_Load(object sender, EventArgs e)
        {
            SetDataGridStyles();
        }
    }
}
