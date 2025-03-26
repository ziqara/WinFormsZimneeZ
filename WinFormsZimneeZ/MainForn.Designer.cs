namespace WinFormsZimneeZ
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForn));
            this.ProductTable = new System.Windows.Forms.DataGridView();
            this.SeasonButton = new System.Windows.Forms.Button();
            this.TrendButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SeasonBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trendingWeeksTextBox = new System.Windows.Forms.TextBox();
            this.FolderMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFiltr = new System.Windows.Forms.ToolStrip();
            this.DefStripButton = new System.Windows.Forms.ToolStripButton();
            this.TopStripButton = new System.Windows.Forms.ToolStripButton();
            this.Reload = new System.Windows.Forms.Button();
            this.reloaded = new System.Windows.Forms.ToolTip(this.components);
            this.picUP = new System.Windows.Forms.PictureBox();
            this.picDOWN = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).BeginInit();
            this.FolderMenu.SuspendLayout();
            this.MenuFiltr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDOWN)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductTable
            // 
            this.ProductTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ProductTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.ProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductTable.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductTable.DefaultCellStyle = dataGridViewCellStyle47;
            this.ProductTable.Location = new System.Drawing.Point(131, 26);
            this.ProductTable.Name = "ProductTable";
            this.ProductTable.ReadOnly = true;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle48;
            this.ProductTable.RowHeadersVisible = false;
            this.ProductTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductTable.Size = new System.Drawing.Size(581, 375);
            this.ProductTable.TabIndex = 0;
            // 
            // SeasonButton
            // 
            this.SeasonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SeasonButton.Location = new System.Drawing.Point(718, 159);
            this.SeasonButton.Name = "SeasonButton";
            this.SeasonButton.Size = new System.Drawing.Size(245, 23);
            this.SeasonButton.TabIndex = 3;
            this.SeasonButton.Text = "Сезонные товары";
            this.SeasonButton.UseVisualStyleBackColor = true;
            this.SeasonButton.Click += new System.EventHandler(this.SeasonButton_Click);
            // 
            // TrendButton
            // 
            this.TrendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TrendButton.Location = new System.Drawing.Point(718, 325);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(245, 23);
            this.TrendButton.TabIndex = 4;
            this.TrendButton.Text = "Трендовые товары";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SeasonBox
            // 
            this.SeasonBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SeasonBox.Location = new System.Drawing.Point(718, 133);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(245, 20);
            this.SeasonBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите процент продаж";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введите количество недель";
            // 
            // trendingWeeksTextBox
            // 
            this.trendingWeeksTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trendingWeeksTextBox.Location = new System.Drawing.Point(718, 299);
            this.trendingWeeksTextBox.Name = "trendingWeeksTextBox";
            this.trendingWeeksTextBox.Size = new System.Drawing.Size(245, 20);
            this.trendingWeeksTextBox.TabIndex = 11;
            // 
            // FolderMenu
            // 
            this.FolderMenu.BackColor = System.Drawing.SystemColors.Control;
            this.FolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.FolderMenu.Location = new System.Drawing.Point(0, 0);
            this.FolderMenu.Name = "FolderMenu";
            this.FolderMenu.Size = new System.Drawing.Size(967, 24);
            this.FolderMenu.TabIndex = 13;
            this.FolderMenu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStrip,
            this.SaveToolStrip});
            this.файлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("файлToolStripMenuItem.Image")));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // LoadToolStrip
            // 
            this.LoadToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("LoadToolStrip.Image")));
            this.LoadToolStrip.Name = "LoadToolStrip";
            this.LoadToolStrip.Size = new System.Drawing.Size(180, 22);
            this.LoadToolStrip.Text = "Загрузить";
            this.LoadToolStrip.ToolTipText = "CSV";
            this.LoadToolStrip.Click += new System.EventHandler(this.LoadToolStrip_Click);
            // 
            // SaveToolStrip
            // 
            this.SaveToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStrip.Image")));
            this.SaveToolStrip.Name = "SaveToolStrip";
            this.SaveToolStrip.Size = new System.Drawing.Size(180, 22);
            this.SaveToolStrip.Text = "Сохранить";
            this.SaveToolStrip.ToolTipText = "HTML";
            this.SaveToolStrip.Click += new System.EventHandler(this.SaveToolStrip_Click);
            // 
            // MenuFiltr
            // 
            this.MenuFiltr.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuFiltr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefStripButton,
            this.TopStripButton});
            this.MenuFiltr.Location = new System.Drawing.Point(0, 24);
            this.MenuFiltr.Name = "MenuFiltr";
            this.MenuFiltr.Size = new System.Drawing.Size(131, 397);
            this.MenuFiltr.TabIndex = 14;
            this.MenuFiltr.Text = "toolStrip1";
            // 
            // DefStripButton
            // 
            this.DefStripButton.AutoSize = false;
            this.DefStripButton.DoubleClickEnabled = true;
            this.DefStripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DefStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DefStripButton.Image")));
            this.DefStripButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DefStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DefStripButton.Name = "DefStripButton";
            this.DefStripButton.Size = new System.Drawing.Size(130, 24);
            this.DefStripButton.Text = "Дефицитные";
            this.DefStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DefStripButton.ToolTipText = "Показать дефицитные товары";
            this.DefStripButton.Click += new System.EventHandler(this.defStripButton_Click);
            // 
            // TopStripButton
            // 
            this.TopStripButton.AutoSize = false;
            this.TopStripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopStripButton.Image = ((System.Drawing.Image)(resources.GetObject("TopStripButton.Image")));
            this.TopStripButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TopStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TopStripButton.Name = "TopStripButton";
            this.TopStripButton.Size = new System.Drawing.Size(130, 24);
            this.TopStripButton.Text = "Продаваемые";
            this.TopStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TopStripButton.ToolTipText = "Показать 10 самых продаваемых товаров";
            this.TopStripButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Reload
            // 
            this.Reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reload.Image = ((System.Drawing.Image)(resources.GetObject("Reload.Image")));
            this.Reload.Location = new System.Drawing.Point(718, 377);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(24, 24);
            this.Reload.TabIndex = 15;
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // picUP
            // 
            this.picUP.Location = new System.Drawing.Point(893, 240);
            this.picUP.Name = "picUP";
            this.picUP.Size = new System.Drawing.Size(70, 70);
            this.picUP.TabIndex = 16;
            this.picUP.TabStop = false;
            // 
            // picDOWN
            // 
            this.picDOWN.Location = new System.Drawing.Point(893, 74);
            this.picDOWN.Name = "picDOWN";
            this.picDOWN.Size = new System.Drawing.Size(70, 70);
            this.picDOWN.TabIndex = 17;
            this.picDOWN.TabStop = false;
            // 
            // MainForn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.MenuFiltr);
            this.Controls.Add(this.trendingWeeksTextBox);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.SeasonButton);
            this.Controls.Add(this.ProductTable);
            this.Controls.Add(this.FolderMenu);
            this.Controls.Add(this.picDOWN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picUP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.FolderMenu;
            this.Name = "MainForn";
            this.Text = "CSV Sales Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).EndInit();
            this.FolderMenu.ResumeLayout(false);
            this.FolderMenu.PerformLayout();
            this.MenuFiltr.ResumeLayout(false);
            this.MenuFiltr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDOWN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductTable;
        private System.Windows.Forms.Button SeasonButton;
        private System.Windows.Forms.Button TrendButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox SeasonBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox trendingWeeksTextBox;
        private System.Windows.Forms.MenuStrip FolderMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStrip;
        private System.Windows.Forms.ToolStrip MenuFiltr;
        private System.Windows.Forms.ToolStripButton DefStripButton;
        private System.Windows.Forms.ToolStripButton TopStripButton;
        private System.Windows.Forms.Button Reload;
        private System.Windows.Forms.ToolTip reloaded;
        private System.Windows.Forms.PictureBox picUP;
        private System.Windows.Forms.PictureBox picDOWN;
    }
}

