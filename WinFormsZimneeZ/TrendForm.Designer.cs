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
            this.DateTimeWeek = new System.Windows.Forms.DateTimePicker();
            this.TrendBox = new System.Windows.Forms.TextBox();
            this.TrendButton = new System.Windows.Forms.Button();
            this.TrendTable = new System.Windows.Forms.DataGridView();
            this.Trend = new System.Windows.Forms.Label();
            this.ResetTableButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TrendTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DateTimeWeek
            // 
            this.DateTimeWeek.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.DateTimeWeek.Location = new System.Drawing.Point(13, 236);
            this.DateTimeWeek.Name = "DateTimeWeek";
            this.DateTimeWeek.Size = new System.Drawing.Size(147, 25);
            this.DateTimeWeek.TabIndex = 0;
            // 
            // TrendBox
            // 
            this.TrendBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrendBox.Location = new System.Drawing.Point(12, 172);
            this.TrendBox.Name = "TrendBox";
            this.TrendBox.Size = new System.Drawing.Size(148, 25);
            this.TrendBox.TabIndex = 1;
            // 
            // TrendButton
            // 
            this.TrendButton.AutoSize = true;
            this.TrendButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.TrendButton.Location = new System.Drawing.Point(12, 203);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(148, 27);
            this.TrendButton.TabIndex = 2;
            this.TrendButton.Text = "Сформировать";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // TrendTable
            // 
            this.TrendTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrendTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.TrendTable.Location = new System.Drawing.Point(173, 0);
            this.TrendTable.Name = "TrendTable";
            this.TrendTable.Size = new System.Drawing.Size(627, 450);
            this.TrendTable.TabIndex = 3;
            // 
            // Trend
            // 
            this.Trend.AutoSize = true;
            this.Trend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.Trend.Location = new System.Drawing.Point(10, 152);
            this.Trend.Name = "Trend";
            this.Trend.Size = new System.Drawing.Size(151, 17);
            this.Trend.TabIndex = 4;
            this.Trend.Text = "Введите число недель";
            // 
            // ResetTableButton
            // 
            this.ResetTableButton.AutoSize = true;
            this.ResetTableButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.ResetTableButton.Location = new System.Drawing.Point(12, 267);
            this.ResetTableButton.Name = "ResetTableButton";
            this.ResetTableButton.Size = new System.Drawing.Size(148, 27);
            this.ResetTableButton.TabIndex = 5;
            this.ResetTableButton.Text = "Сброс";
            this.ResetTableButton.UseVisualStyleBackColor = true;
            this.ResetTableButton.Click += new System.EventHandler(this.ResetTableButton_Click);
            // 
            // TrendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResetTableButton);
            this.Controls.Add(this.Trend);
            this.Controls.Add(this.TrendTable);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.TrendBox);
            this.Controls.Add(this.DateTimeWeek);
            this.Name = "TrendForm";
            this.Text = "TrendForm";
            this.Load += new System.EventHandler(this.TrendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrendTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateTimeWeek;
        private System.Windows.Forms.TextBox TrendBox;
        private System.Windows.Forms.Button TrendButton;
        private System.Windows.Forms.DataGridView TrendTable;
        private System.Windows.Forms.Label Trend;
        private System.Windows.Forms.Button ResetTableButton;
    }
}