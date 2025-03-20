using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsZimneeZ
{
    public partial class MainForn : Form
    {
        private BindingList<ProductInfo> products;
        public MainForn()
        {
            InitializeComponent();
            ProductTable.DataSource = products;
        }

        private void LoadCsvButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}

