namespace WinFormsZimneeZ
{
    partial class TrendForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TrendBox = new System.Windows.Forms.TextBox();
            this.TrendButton = new System.Windows.Forms.Button();
            this.TrendTable = new System.Windows.Forms.DataGridView();
            this.Trend = new System.Windows.Forms.Label();
            this.ResetTableButton = new System.Windows.Forms.Button();
            this.FiltrBox = new System.Windows.Forms.TextBox();
            this.FiltrButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SaveHTMLBUTTON = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrendTable)).BeginInit();
            this.SuspendLayout();
            // 
            // TrendBox
            // 
            this.TrendBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrendBox.Location = new System.Drawing.Point(9, 28);
            this.TrendBox.Name = "TrendBox";
            this.TrendBox.Size = new System.Drawing.Size(151, 25);
            this.TrendBox.TabIndex = 1;
            // 
            // TrendButton
            // 
            this.TrendButton.AutoSize = true;
            this.TrendButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrendButton.Location = new System.Drawing.Point(9, 59);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(151, 27);
            this.TrendButton.TabIndex = 2;
            this.TrendButton.Text = "Сформировать";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // TrendTable
            // 
            this.TrendTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.TrendTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TrendTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TrendTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrendTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TrendTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.TrendTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TrendTable.DefaultCellStyle = dataGridViewCellStyle16;
            this.TrendTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.TrendTable.EnableHeadersVisualStyles = false;
            this.TrendTable.GridColor = System.Drawing.Color.Black;
            this.TrendTable.Location = new System.Drawing.Point(171, 0);
            this.TrendTable.Name = "TrendTable";
            this.TrendTable.ReadOnly = true;
            this.TrendTable.RowHeadersVisible = false;
            this.TrendTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TrendTable.Size = new System.Drawing.Size(470, 450);
            this.TrendTable.TabIndex = 3;
            // 
            // Trend
            // 
            this.Trend.AutoSize = true;
            this.Trend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Trend.Location = new System.Drawing.Point(8, 8);
            this.Trend.Name = "Trend";
            this.Trend.Size = new System.Drawing.Size(151, 17);
            this.Trend.TabIndex = 4;
            this.Trend.Text = "Введите число недель";
            // 
            // ResetTableButton
            // 
            this.ResetTableButton.AutoSize = true;
            this.ResetTableButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ResetTableButton.Location = new System.Drawing.Point(9, 196);
            this.ResetTableButton.Name = "ResetTableButton";
            this.ResetTableButton.Size = new System.Drawing.Size(56, 27);
            this.ResetTableButton.TabIndex = 5;
            this.ResetTableButton.Text = "Сброс";
            this.ResetTableButton.UseVisualStyleBackColor = true;
            this.ResetTableButton.Click += new System.EventHandler(this.ResetTableButton_Click);
            // 
            // FiltrBox
            // 
            this.FiltrBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FiltrBox.Location = new System.Drawing.Point(9, 119);
            this.FiltrBox.Name = "FiltrBox";
            this.FiltrBox.Size = new System.Drawing.Size(151, 25);
            this.FiltrBox.TabIndex = 6;
            // 
            // FiltrButton
            // 
            this.FiltrButton.AutoSize = true;
            this.FiltrButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FiltrButton.Location = new System.Drawing.Point(9, 150);
            this.FiltrButton.Name = "FiltrButton";
            this.FiltrButton.Size = new System.Drawing.Size(152, 27);
            this.FiltrButton.TabIndex = 7;
            this.FiltrButton.Text = "Фильтровать";
            this.FiltrButton.UseVisualStyleBackColor = true;
            this.FiltrButton.Click += new System.EventHandler(this.FiltrButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите порог роста";
            // 
            // SaveHTMLBUTTON
            // 
            this.SaveHTMLBUTTON.AutoSize = true;
            this.SaveHTMLBUTTON.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveHTMLBUTTON.Location = new System.Drawing.Point(71, 196);
            this.SaveHTMLBUTTON.Name = "SaveHTMLBUTTON";
            this.SaveHTMLBUTTON.Size = new System.Drawing.Size(89, 27);
            this.SaveHTMLBUTTON.TabIndex = 9;
            this.SaveHTMLBUTTON.Text = "Сохранить";
            this.SaveHTMLBUTTON.UseVisualStyleBackColor = true;
            this.SaveHTMLBUTTON.Click += new System.EventHandler(this.SaveHTMLBUTTON_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AutoSize = true;
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.CancelButton.Location = new System.Drawing.Point(9, 229);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(151, 27);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "На главную";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TrendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 450);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveHTMLBUTTON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FiltrButton);
            this.Controls.Add(this.FiltrBox);
            this.Controls.Add(this.ResetTableButton);
            this.Controls.Add(this.Trend);
            this.Controls.Add(this.TrendTable);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.TrendBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TrendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Трендовые товары";
            this.Load += new System.EventHandler(this.TrendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrendTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TrendBox;
        private System.Windows.Forms.Button TrendButton;
        private System.Windows.Forms.DataGridView TrendTable;
        private System.Windows.Forms.Label Trend;
        private System.Windows.Forms.Button ResetTableButton;
        private System.Windows.Forms.TextBox FiltrBox;
        private System.Windows.Forms.Button FiltrButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveHTMLBUTTON;
        private System.Windows.Forms.Button CancelButton;
    }
}