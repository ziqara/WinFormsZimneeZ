namespace WinFormsZimneeZ
{
    partial class SeasonForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SeasonTable = new System.Windows.Forms.DataGridView();
            this.SeasonBox = new System.Windows.Forms.TextBox();
            this.FilterSeason = new System.Windows.Forms.Button();
            this.BackButt = new System.Windows.Forms.Button();
            this.SaveSeason = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resetbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SeasonTable
            // 
            this.SeasonTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SeasonTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.SeasonTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SeasonTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.SeasonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SeasonTable.DefaultCellStyle = dataGridViewCellStyle35;
            this.SeasonTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.SeasonTable.EnableHeadersVisualStyles = false;
            this.SeasonTable.GridColor = System.Drawing.Color.Black;
            this.SeasonTable.Location = new System.Drawing.Point(0, 0);
            this.SeasonTable.Name = "SeasonTable";
            this.SeasonTable.ReadOnly = true;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.SeasonTable.RowHeadersVisible = false;
            this.SeasonTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SeasonTable.Size = new System.Drawing.Size(617, 300);
            this.SeasonTable.TabIndex = 0;
            // 
            // SeasonBox
            // 
            this.SeasonBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.SeasonBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeasonBox.Location = new System.Drawing.Point(640, 77);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(86, 18);
            this.SeasonBox.TabIndex = 2;
            this.SeasonBox.Text = "\r\n";
            this.SeasonBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FilterSeason
            // 
            this.FilterSeason.AutoSize = true;
            this.FilterSeason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FilterSeason.Location = new System.Drawing.Point(640, 128);
            this.FilterSeason.Name = "FilterSeason";
            this.FilterSeason.Size = new System.Drawing.Size(234, 27);
            this.FilterSeason.TabIndex = 3;
            this.FilterSeason.Text = "Сформировать";
            this.FilterSeason.UseVisualStyleBackColor = true;
            this.FilterSeason.Click += new System.EventHandler(this.FilterSeason_Click);
            // 
            // BackButt
            // 
            this.BackButt.AutoSize = true;
            this.BackButt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackButt.Location = new System.Drawing.Point(640, 194);
            this.BackButt.Name = "BackButt";
            this.BackButt.Size = new System.Drawing.Size(234, 27);
            this.BackButt.TabIndex = 4;
            this.BackButt.Text = "На главную";
            this.BackButt.UseVisualStyleBackColor = true;
            this.BackButt.Click += new System.EventHandler(this.BackButt_Click);
            // 
            // SaveSeason
            // 
            this.SaveSeason.AutoSize = true;
            this.SaveSeason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveSeason.Location = new System.Drawing.Point(760, 161);
            this.SaveSeason.Name = "SaveSeason";
            this.SaveSeason.Size = new System.Drawing.Size(114, 27);
            this.SaveSeason.TabIndex = 5;
            this.SaveSeason.Text = "Сохранить";
            this.SaveSeason.UseVisualStyleBackColor = true;
            this.SaveSeason.Click += new System.EventHandler(this.SaveSeason_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(637, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите процент";
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.monthComboBox.Location = new System.Drawing.Point(640, 99);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(234, 25);
            this.monthComboBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(723, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = ">%";
            // 
            // resetbutton
            // 
            this.resetbutton.AutoSize = true;
            this.resetbutton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.resetbutton.Location = new System.Drawing.Point(640, 161);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(116, 27);
            this.resetbutton.TabIndex = 10;
            this.resetbutton.Text = "Сброс";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // SeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(896, 300);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveSeason);
            this.Controls.Add(this.BackButt);
            this.Controls.Add(this.FilterSeason);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.SeasonTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SeasonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сезонные товары";
            this.Load += new System.EventHandler(this.SeasonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeasonTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SeasonTable;
        private System.Windows.Forms.TextBox SeasonBox;
        private System.Windows.Forms.Button FilterSeason;
        private System.Windows.Forms.Button BackButt;
        private System.Windows.Forms.Button SaveSeason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetbutton;
    }
}