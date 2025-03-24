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
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductTable
            // 
            this.ProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductTable.Location = new System.Drawing.Point(316, 38);
            this.ProductTable.Name = "ProductTable";
            this.ProductTable.ReadOnly = true;
            this.ProductTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductTable.Size = new System.Drawing.Size(782, 358);
            this.ProductTable.TabIndex = 0;
            // 
            // DefButton
            // 
            this.DefButton.Location = new System.Drawing.Point(40, 38);
            this.DefButton.Name = "DefButton";
            this.DefButton.Size = new System.Drawing.Size(245, 23);
            this.DefButton.TabIndex = 1;
            this.DefButton.Text = "Дефицитные товары";
            this.DefButton.UseVisualStyleBackColor = true;
            this.DefButton.Click += new System.EventHandler(this.DefButton_Click);
            // 
            // TopButton
            // 
            this.TopButton.Location = new System.Drawing.Point(40, 67);
            this.TopButton.Name = "TopButton";
            this.TopButton.Size = new System.Drawing.Size(245, 23);
            this.TopButton.TabIndex = 2;
            this.TopButton.Text = "Самые продаваемые";
            this.TopButton.UseVisualStyleBackColor = true;
            this.TopButton.Click += new System.EventHandler(this.TopButton_Click);
            // 
            // SeasonButton
            // 
            this.SeasonButton.Location = new System.Drawing.Point(40, 239);
            this.SeasonButton.Name = "SeasonButton";
            this.SeasonButton.Size = new System.Drawing.Size(245, 23);
            this.SeasonButton.TabIndex = 3;
            this.SeasonButton.Text = "Сезонные товары";
            this.SeasonButton.UseVisualStyleBackColor = true;
            this.SeasonButton.Click += new System.EventHandler(this.SeasonButton_Click);
            // 
            // TrendButton
            // 
            this.TrendButton.Location = new System.Drawing.Point(40, 373);
            this.TrendButton.Name = "TrendButton";
            this.TrendButton.Size = new System.Drawing.Size(245, 23);
            this.TrendButton.TabIndex = 4;
            this.TrendButton.Text = "Трендовые товары";
            this.TrendButton.UseVisualStyleBackColor = true;
            this.TrendButton.Click += new System.EventHandler(this.TrendButton_Click);
            // 
            // LoadCsvButton
            // 
            this.LoadCsvButton.Location = new System.Drawing.Point(316, 402);
            this.LoadCsvButton.Name = "LoadCsvButton";
            this.LoadCsvButton.Size = new System.Drawing.Size(245, 23);
            this.LoadCsvButton.TabIndex = 5;
            this.LoadCsvButton.Text = "Загрузить файл";
            this.LoadCsvButton.UseVisualStyleBackColor = true;
            this.LoadCsvButton.Click += new System.EventHandler(this.LoadCsvButton_Click);
            // 
            // SaveHtmlButton
            // 
            this.SaveHtmlButton.Location = new System.Drawing.Point(853, 402);
            this.SaveHtmlButton.Name = "SaveHtmlButton";
            this.SaveHtmlButton.Size = new System.Drawing.Size(245, 23);
            this.SaveHtmlButton.TabIndex = 6;
            this.SaveHtmlButton.Text = "Сохранить";
            this.SaveHtmlButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SeasonBox
            // 
            this.SeasonBox.Location = new System.Drawing.Point(40, 213);
            this.SeasonBox.Name = "SeasonBox";
            this.SeasonBox.Size = new System.Drawing.Size(245, 20);
            this.SeasonBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите процент продаж";
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(668, 402);
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
            this.label2.Location = new System.Drawing.Point(37, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введите количество недель";
            // 
            // trendingWeeksTextBox
            // 
            this.trendingWeeksTextBox.Location = new System.Drawing.Point(40, 347);
            this.trendingWeeksTextBox.Name = "trendingWeeksTextBox";
            this.trendingWeeksTextBox.Size = new System.Drawing.Size(245, 20);
            this.trendingWeeksTextBox.TabIndex = 11;
            // 
            // MainForn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 450);
            this.Controls.Add(this.trendingWeeksTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SeasonBox);
            this.Controls.Add(this.SaveHtmlButton);
            this.Controls.Add(this.LoadCsvButton);
            this.Controls.Add(this.TrendButton);
            this.Controls.Add(this.SeasonButton);
            this.Controls.Add(this.TopButton);
            this.Controls.Add(this.DefButton);
            this.Controls.Add(this.ProductTable);
            this.Name = "MainForn";
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.ProductTable)).EndInit();
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
    }
}

