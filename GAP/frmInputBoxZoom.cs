using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GAP
{
    public partial class frmInputBoxZoom : Form
    {
        public frmInputBoxZoom()
        {
            InitializeComponent();
        }

        public string strZoomVariable { get; set; }
        public string strZoomInput { get; set; }

        private void frmInputBoxZoom_Load(object sender, EventArgs e)
        {
            txtValue.Text = this.strZoomVariable.ToString();
            txtValue.Focus();
        }

        private void frmInputBoxZoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.strZoomInput = this.txtValue.Text;
            //strInput = txtValue.Text;
        }


    }
}
