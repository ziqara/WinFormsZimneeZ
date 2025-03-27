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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SeasonTable = new System.Windows.Forms.DataGridView();
            this.SeasonBox = new System.Windows.Forms.TextBox();
            this.FilterSeason = new System.Windows.Forms.Button();
            this.BackButt = new System.Windows.Forms.Button();
            this.SaveSeason = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.SeasonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SeasonTable.DefaultCellStyle = dataGridViewCellStyle32;
            this.SeasonTable.EnableHeadersVisualStyles = false;
            this.SeasonTable.GridColor = System.Drawing.Color.Black;
            this.SeasonTable.Location = new System.Drawing.Point(0, 121);
            this.SeasonTable.Name = "SeasonTable";
            this.SeasonTable.ReadOnly = true;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeasonTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.SeasonTable.RowHeadersVisible = false;
            this.SeasonTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SeasonTable.Size = new System.Drawing.Size(1035, 228);
            this.SeasonTable.TabIndex = 0;
            // 
            // SeasonBox
            // 
            this.SeasonBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeasonBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.SeasonBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeasonBox.Location = new System.Drawing.Point(482, 49);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(116, 18);
            this.SeasonBox.TabIndex = 2;
            this.SeasonBox.Text = "\r\n";
            this.SeasonBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SeasonBox.TextChanged += new System.EventHandler(this.SeasonBox_TextChanged);
            // 
            // FilterSeason
            // 
            this.FilterSeason.AutoSize = true;
            this.FilterSeason.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.FilterSeason.Location = new System.Drawing.Point(482, 71);
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
            this.BackButt.Location = new System.Drawing.Point(364, 71);
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
            this.SaveSeason.Location = new System.Drawing.Point(602, 71);
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
            this.label1.Location = new System.Drawing.Point(481, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите процент";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(364, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // SeasonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1035, 349);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveSeason);
            this.Controls.Add(this.BackButt);
            this.Controls.Add(this.FilterSeason);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.SeasonTable);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}