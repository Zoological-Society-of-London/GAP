using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAP
{
    public partial class frmSelectConnection : Form
    {
        public frmSelectConnection()
        {
            InitializeComponent();
        }

        public string strDefault { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.strDefault = txtConnectionString.Text;
        }

        private void frmSelectConnection_Load(object sender, EventArgs e)
        {

            txtConnectionString.Text = this.strDefault;
        }

        private void btnLiveDW_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL46;Initial Catalog=DW_ZSL;Integrated Security=True";

        }

        private void btnLivePE_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL46;Initial Catalog=PE_ZSL;Integrated Security=True";
        }

        private void btnLocalDW_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL03456\SQLEXPRESS;Initial Catalog=DW_ZSL;Integrated Security=True";

        }

        private void btnLocalPE_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL03456\SQLEXPRESS;Initial Catalog=PE_ZSL;Integrated Security=True";

        }

        private void btnDevDW_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL26;Initial Catalog=DW_ZSL;Integrated Security=True";

        }

        private void btnDevPE_Click(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=ZSL26;Initial Catalog=PE_ZSL;Integrated Security=True";

        }
    }
}
