﻿namespace WinFormsZimneeZ
{
    partial class MainForn
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForn));
            this.ProductTable = new System.Windows.Forms.DataGridView();
            this.DefButton = new System.Windows.Forms.Button();
            this.TopButton = new System.Windows.Forms.Button();
            this.SeasonButton = new System.Windows.Forms.Button();
            this.TrendButton = new System.Windows.Forms.Button();
            this.LoadCsvButton = new System.Windows.Forms.Button();
            this.SaveHtmlButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SeasonBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trendingWeeksTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductTable
            // 
            this.ProductTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProductTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ProductTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductTable.Location = new System.Drawing.Point(131, 26);
            this.ProductTable.Name = "ProductTable";
            this.ProductTable.ReadOnly = true;
            this.ProductTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductTable.Size = new System.Drawing.Size(574, 375);
            this.ProductTable.TabIndex = 0;
            // 
            // DefButton
            // 
            this.DefButton.Location = new System.Drawing.Point(3, 4);
            this.DefButton.Name = "DefButton";
            this.DefButton.Size = new System.Drawing.Size(245, 23);
            this.DefButton.TabIndex = 1;
            this.DefButton.Text = "Дефицитные товары";
            this.DefButton.UseVisualStyleBackColor = true;
            this.DefButton.Click += new System.EventHandler(this.DefButton_Click);
            // 
            // TopButton
            // 
            this.TopButton.Location = new System.Drawing.Point(254, 3);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(245, 23);
            this.TopButton.TabIndex = 2;
            this.TopButton.Text = "Самые продаваемые";
            this.TopButton.UseVisualStyleBackColor = true;
            this.TopButton.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // SeasonButton
            // 
            this.SeasonButton.Location = new System.Drawing.Point(823, 193);
            this.SeasonButton.Name = "SeasonButton";
            this.SeasonButton.Size = new System.Drawing.Size(245, 23);
            this.SeasonButton.TabIndex = 3;
            this.SeasonButton.Text = "Сезонные товары";
            this.SeasonButton.UseVisualStyleBackColor = true;
            this.SeasonButton.Click += new System.EventHandler(this.SeasonButton_Click);
            // 
            // TrendButton
            // 
            this.TrendButton.Location = new System.Drawing.Point(823, 277);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(245, 23);
            this.TrendButton.TabIndex = 4;
            this.TrendButton.Text = "Трендовые товары";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // LoadCsvButton
            // 
            this.LoadCsvButton.Location = new System.Drawing.Point(823, 48);
            this.LoadCsvButton.Name = "LoadCsvButton";
            this.LoadCsvButton.Size = new System.Drawing.Size(245, 23);
            this.LoadCsvButton.TabIndex = 5;
            this.LoadCsvButton.Text = "Загрузить файл";
            this.LoadCsvButton.UseVisualStyleBackColor = true;
            this.LoadCsvButton.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // SaveHtmlButton
            // 
            this.SaveHtmlButton.Location = new System.Drawing.Point(823, 86);
            this.SaveHtmlButton.Name = "SaveHtmlButton";
            this.SaveHtmlButton.Size = new System.Drawing.Size(245, 23);
            this.SaveHtmlButton.TabIndex = 6;
            this.SaveHtmlButton.Text = "Сохранить";
            this.SaveHtmlButton.UseVisualStyleBackColor = true;
            this.SaveHtmlButton.Click += new System.EventHandler(this.SaveHtmlButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SeasonBox
            // 
            this.SeasonBox.Location = new System.Drawing.Point(823, 167);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(245, 20);
            this.SeasonBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(820, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите процент продаж";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(915, 328);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(75, 23);
            this.ReturnButton.TabIndex = 9;
            this.ReturnButton.Text = "Сброс";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(820, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введите количество недель";
            // 
            // trendingWeeksTextBox
            // 
            this.trendingWeeksTextBox.Location = new System.Drawing.Point(823, 251);
            this.trendingWeeksTextBox.Name = "trendingWeeksTextBox";
            this.trendingWeeksTextBox.Size = new System.Drawing.Size(245, 20);
            this.trendingWeeksTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TopButton);
            this.panel1.Controls.Add(this.DefButton);
            this.panel1.Location = new System.Drawing.Point(823, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 30);
            this.panel1.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1149, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("загрузитьToolStripMenuItem.Image")));
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьToolStripMenuItem.Image")));
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // Menu
            // 
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.Menu.Location = new System.Drawing.Point(0, 24);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(131, 397);
            this.Menu.TabIndex = 14;
            this.Menu.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DoubleClickEnabled = true;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(130, 24);
            this.toolStripButton1.Text = "Дефицитные";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ToolTipText = "Показать дефицитные товары";
            this.toolStripButton1.Click += new System.EventHandler(this.defStripButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(130, 24);
            this.toolStripButton2.Text = "Продаваемые";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ToolTipText = "Показать 10 самых продаваемых товаров";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // MainForn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 421);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trendingWeeksTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.SaveHtmlButton);
            this.Controls.Add(this.LoadCsvButton);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.SeasonButton);
            this.Controls.Add(this.ProductTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForn";
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductTable;
        private System.Windows.Forms.Button DefButton;
        private System.Windows.Forms.Button TopButton;
        private System.Windows.Forms.Button SeasonButton;
        private System.Windows.Forms.Button TrendButton;
        private System.Windows.Forms.Button LoadCsvButton;
        private System.Windows.Forms.Button SaveHtmlButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SeasonBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox trendingWeeksTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStrip Menu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}

