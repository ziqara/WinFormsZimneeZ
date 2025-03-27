using MyLib;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsZimneeZ
{
    public partial class MainForm : Form
    {
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            const int HTCAPTION = 0x2;
            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam == (IntPtr)HTCAPTION)
            {
                return;
            }
            base.WndProc(ref m);
        }

        private SalesHistory History;
        private LoadCsvSaveHtml csvLoader;

        public MainForm()
        {
            InitializeComponent();

            // Инициализация истории продаж и загрузчика CSV
            History = new SalesHistory();
            csvLoader = new LoadCsvSaveHtml();

            // Заполняем тестовыми данными
            History.AddAllSales();

            // Отображаем продажи сгруппированные 
            ProductTable.DataSource = History.GetGroupedProducts();

            // Настраиваем внешний вид элементов формы
            InitializeStyles();
        }

        // Метод для установки стилей элементов управления
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
            

            picDOWN.Image = Image.FromFile("vip.gif");
            picDOWN.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Применение стилей к таблице при загрузке формы
        private void MainForn_Load(object sender, EventArgs e)
        {
            SetDataGridStyles();
        }

        // Вспомогательный метод для настройки DataGridView
        private void SetDataGridStyles()
        {
            SetDataCellBackgroundColor(ProductTable, "#415a77");
            ProductTable.AllowUserToAddRows = false;
            ProductTable.CurrentCell.Selected = false;
            ProductTable.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1b263b");
            ProductTable.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#778da9");
            ApplyDataCellStyle(ProductTable, "#778da9");
        }

        // Метод для установки фона ячеек
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

        // Метод для применения стиля шрифта и цвета текста ячеек
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

        // Обработчик кнопки для открытия формы сезонных продаж
        private void SeasonButton_Click(object sender, EventArgs e)
        {
            SeasonForm seasonForm = new SeasonForm(History);
            seasonForm.Show();
            SetDataGridStyles();
            this.ActiveControl = null;
        }

        // Обработчик кнопки для поиска трендовых товаров
        private void TrendButton_Click(object sender, EventArgs e)
        {
            
        }

        // Обработчик кнопки для поиска дефицитных товаров
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Select a CSV File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    csvLoader.LoadCsvData(openFileDialog.FileName, History);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*",
                Title = "Save DataGridView as HTML"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadCsvSaveHtml.SaveDataGridViewToHtml(ProductTable, saveFileDialog.FileName);
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
    }
}
