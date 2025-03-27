﻿namespace WinFormsZimneeZ
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ProductTable = new System.Windows.Forms.DataGridView();
            this.SeasonButton = new System.Windows.Forms.Button();
            this.TrendButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FolderMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.rdtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFiltr = new System.Windows.Forms.ToolStrip();
            this.DefStripButton = new System.Windows.Forms.ToolStripButton();
            this.TopStripButton = new System.Windows.Forms.ToolStripButton();
            this.reloaded = new System.Windows.Forms.ToolTip(this.components);
            this.picDOWN = new System.Windows.Forms.PictureBox();
            this.TurnList = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).BeginInit();
            this.FolderMenu.SuspendLayout();
            this.MenuFiltr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDOWN)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductTable
            // 
            this.ProductTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ProductTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ProductTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProductTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProductTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductTable.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.ProductTable.EnableHeadersVisualStyles = false;
            this.ProductTable.GridColor = System.Drawing.Color.Black;
            this.ProductTable.Location = new System.Drawing.Point(262, 0);
            this.ProductTable.Name = "ProductTable";
            this.ProductTable.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProductTable.RowHeadersVisible = false;
            this.ProductTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProductTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductTable.Size = new System.Drawing.Size(688, 321);
            this.ProductTable.TabIndex = 0;
            // 
            // SeasonButton
            // 
            this.SeasonButton.AutoSize = true;
            this.SeasonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SeasonButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeasonButton.Location = new System.Drawing.Point(48, 128);
            this.SeasonButton.Name = "SeasonButton";
            this.SeasonButton.Size = new System.Drawing.Size(168, 27);
            this.SeasonButton.TabIndex = 3;
            this.SeasonButton.Text = "Сезонные товары";
            this.SeasonButton.UseVisualStyleBackColor = true;
            this.SeasonButton.Click += new System.EventHandler(this.SeasonButton_Click);
            // 
            // TrendButton
            // 
            this.TrendButton.Cursor = System.Windows.Forms.Cursors.No;
            this.TrendButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrendButton.Location = new System.Drawing.Point(48, 165);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(168, 27);
            this.TrendButton.TabIndex = 4;
            this.TrendButton.Text = "Трендовые товары";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FolderMenu
            // 
            this.FolderMenu.BackColor = System.Drawing.SystemColors.Control;
            this.FolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.TurnList,
            this.rdtToolStripMenuItem});
            this.FolderMenu.Location = new System.Drawing.Point(0, 0);
            this.FolderMenu.Name = "FolderMenu";
            this.FolderMenu.Size = new System.Drawing.Size(262, 25);
            this.FolderMenu.TabIndex = 13;
            this.FolderMenu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStrip,
            this.SaveToolStrip});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.файлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("файлToolStripMenuItem.Image")));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(70, 21);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // LoadToolStrip
            // 
            this.LoadToolStrip.Name = "LoadToolStrip";
            this.LoadToolStrip.Size = new System.Drawing.Size(143, 22);
            this.LoadToolStrip.Text = "Загрузить";
            this.LoadToolStrip.ToolTipText = "CSV";
            this.LoadToolStrip.Click += new System.EventHandler(this.LoadToolStrip_Click);
            // 
            // SaveToolStrip
            // 
            this.SaveToolStrip.Name = "SaveToolStrip";
            this.SaveToolStrip.Size = new System.Drawing.Size(143, 22);
            this.SaveToolStrip.Text = "Сохранить";
            this.SaveToolStrip.ToolTipText = "HTML";
            this.SaveToolStrip.Click += new System.EventHandler(this.SaveToolStrip_Click);
            // 
            // rdtToolStripMenuItem
            // 
            this.rdtToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rdtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rdtToolStripMenuItem.Image")));
            this.rdtToolStripMenuItem.Name = "rdtToolStripMenuItem";
            this.rdtToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.rdtToolStripMenuItem.Text = "Сбросить";
            this.rdtToolStripMenuItem.ToolTipText = "Сбросить";
            this.rdtToolStripMenuItem.Click += new System.EventHandler(this.rdtToolStripMenuItem_Click);
            // 
            // MenuFiltr
            // 
            this.MenuFiltr.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuFiltr.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MenuFiltr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefStripButton,
            this.TopStripButton});
            this.MenuFiltr.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.MenuFiltr.Location = new System.Drawing.Point(48, 63);
            this.MenuFiltr.Name = "MenuFiltr";
            this.MenuFiltr.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MenuFiltr.Size = new System.Drawing.Size(131, 56);
            this.MenuFiltr.TabIndex = 14;
            this.MenuFiltr.TabStop = true;
            this.MenuFiltr.Text = "toolStrip1";
            // 
            // DefStripButton
            // 
            this.DefStripButton.AutoSize = false;
            this.DefStripButton.DoubleClickEnabled = true;
            this.DefStripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
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
            this.TopStripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
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
            // picDOWN
            // 
            this.picDOWN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picDOWN.BackgroundImage")));
            this.picDOWN.Location = new System.Drawing.Point(48, 228);
            this.picDOWN.Name = "picDOWN";
            this.picDOWN.Size = new System.Drawing.Size(168, 93);
            this.picDOWN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDOWN.TabIndex = 17;
            this.picDOWN.TabStop = false;
            this.picDOWN.Visible = false;
            // 
            // TurnList
            // 
            this.TurnList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TurnList.Image = ((System.Drawing.Image)(resources.GetObject("TurnList.Image")));
            this.TurnList.Name = "TurnList";
            this.TurnList.Size = new System.Drawing.Size(108, 21);
            this.TurnList.Text = "Развернуть";
            this.TurnList.Click += new System.EventHandler(this.TurnList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(967, 259);
            this.Controls.Add(this.MenuFiltr);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.SeasonButton);
            this.Controls.Add(this.FolderMenu);
            this.Controls.Add(this.picDOWN);
            this.Controls.Add(this.ProductTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.FolderMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Sales Analyzer";
            this.Load += new System.EventHandler(this.MainForn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).EndInit();
            this.FolderMenu.ResumeLayout(false);
            this.FolderMenu.PerformLayout();
            this.MenuFiltr.ResumeLayout(false);
            this.MenuFiltr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDOWN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductTable;
        private System.Windows.Forms.Button SeasonButton;
        private System.Windows.Forms.Button TrendButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip FolderMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStrip;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStrip;
        private System.Windows.Forms.ToolStrip MenuFiltr;
        private System.Windows.Forms.ToolStripButton DefStripButton;
        private System.Windows.Forms.ToolStripButton TopStripButton;
        private System.Windows.Forms.ToolTip reloaded;
        private System.Windows.Forms.PictureBox picDOWN;
        private System.Windows.Forms.ToolStripMenuItem rdtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TurnList;
    }
}

