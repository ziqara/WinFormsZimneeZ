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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SeasonTable = new System.Windows.Forms.DataGridView();
            this.SeasonBox = new System.Windows.Forms.TextBox();
            this.FilterSeason = new System.Windows.Forms.Button();
            this.BackButt = new System.Windows.Forms.Button();
            this.SaveSeason = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SeasonTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SeasonTable
            // 
            this.SeasonTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.SeasonTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.SeasonTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SeasonTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SeasonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SeasonTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.SeasonTable.EnableHeadersVisualStyles = false;
            this.SeasonTable.GridColor = System.Drawing.Color.Black;
            this.SeasonTable.Location = new System.Drawing.Point(0, 141);
            this.SeasonTable.Name = "SeasonTable";
            this.SeasonTable.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SeasonTable.RowHeadersVisible = false;
            this.SeasonTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SeasonTable.Size = new System.Drawing.Size(1016, 206);
            this.SeasonTable.TabIndex = 0;
            // 
            // SeasonBox
            // 
            this.SeasonBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.SeasonBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeasonBox.Location = new System.Drawing.Point(461, 45);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(116, 18);
            this.SeasonBox.TabIndex = 2;
            this.SeasonBox.Text = "\r\n";
            this.SeasonBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FilterSeason
            // 
            this.FilterSeason.AutoSize = true;
            this.FilterSeason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FilterSeason.Location = new System.Drawing.Point(461, 92);
            this.FilterSeason.Name = "FilterSeason";
            this.FilterSeason.Size = new System.Drawing.Size(114, 27);
            this.FilterSeason.TabIndex = 3;
            this.FilterSeason.Text = "Сформировать";
            this.FilterSeason.UseVisualStyleBackColor = true;
            this.FilterSeason.Click += new System.EventHandler(this.FilterSeason_Click);
            // 
            // BackButt
            // 
            this.BackButt.AutoSize = true;
            this.BackButt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.BackButt.Location = new System.Drawing.Point(343, 92);
            this.BackButt.Name = "BackButt";
            this.BackButt.Size = new System.Drawing.Size(114, 27);
            this.BackButt.TabIndex = 4;
            this.BackButt.Text = "На главную";
            this.BackButt.UseVisualStyleBackColor = true;
            this.BackButt.Click += new System.EventHandler(this.BackButt_Click);
            // 
            // SaveSeason
            // 
            this.SaveSeason.AutoSize = true;
            this.SaveSeason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.SaveSeason.Location = new System.Drawing.Point(581, 92);
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
            this.label1.Location = new System.Drawing.Point(460, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите процент";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(334, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(376, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            this.monthComboBox.Location = new System.Drawing.Point(461, 65);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(116, 25);
            this.monthComboBox.TabIndex = 8;
            // 
            // SeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1018, 349);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveSeason);
            this.Controls.Add(this.BackButt);
            this.Controls.Add(this.FilterSeason);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.SeasonTable);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SeasonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeasonForm";
            this.Load += new System.EventHandler(this.SeasonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SeasonTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox monthComboBox;
    }
}