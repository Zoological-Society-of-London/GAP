using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAP
{
    public partial class frmInputExtended : Form
    {
        public frmInputExtended()
        {
            InitializeComponent();
        }

        SqlConnection conViewData;
        SqlDataAdapter daViewData;
        SqlCommandBuilder cbViewData;
        DataSet dsViewData = new DataSet();

        private void frmInputExtended_Load(object sender, EventArgs e)
        {

        }
    }
}
