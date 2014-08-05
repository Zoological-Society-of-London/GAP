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
    public partial class frmInput : Form
    {

        public string strTitle { get; set; }     // Variable Name        
        public string strPrompt { get; set; }     // Variable Name       
        public string strDefault { get; set; }

        public frmInput()
        {
            InitializeComponent();
        }


        private void frmInput_Load(object sender, EventArgs e)
        {

            // Set the ico from the resources
            this.Icon = GAP.Properties.Resources.GAPLogo;

            // Set up From with paramters passed from calling function

            try
            {
                this.Text = this.strTitle;
                lblPrompt.Text = this.strPrompt;
                txtInput.Text = this.strDefault;

                if (this.strTitle == "")
                {

                    this.Text = "Enter value:";
                }
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fnOK()
        {

            // OK Clicked.  Send data back to the calling function

            try
            {

                // Set the return value to that of the text box
                this.strDefault = txtInput.Text;

                // When Dialog OK is pressed then pass back this result
                this.DialogResult = DialogResult.OK;
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            // Call fnOK()
            try
            {

                fnOK();
            }
             
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
