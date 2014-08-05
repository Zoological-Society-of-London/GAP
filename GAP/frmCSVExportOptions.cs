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
    public partial class frmCSVExportOptions : Form
    {
        // http://kb.iu.edu/data/acux.html
        public string strFieldDelimiter { get; set; }
        public string strFieldEncloser { get; set; }
        public string strRowDelimiter { get; set; }
        public string strDelimiterReplacement { get; set; }
        public string strFileNameSuffix { get; set; }
        public bool boolOutputHeader { get; set; }
        public int intLimitRows { get; set; }


        public frmCSVExportOptions()
        {
            InitializeComponent();
        }

        private void frmCSVExportOptions_Load(object sender, EventArgs e)
        {

            strRowDelimiter = "\r\n";
            strDelimiterReplacement = "";

            boolOutputHeader = true;
            intLimitRows = 10000000;
            
            // If this is a sales Export as designated by having a strYYYYWW
            if (strFieldDelimiter == "\t")
            {

                rbTab.Checked = true;
            }
            else
            {

                strFieldDelimiter = ",";
                rbComma.Checked = true;
            }

            if (strFileNameSuffix == ".txt")
            {

                rbSuffixTXT.Checked = true;
            }
            else
            {

                strFileNameSuffix = ".csv";
                rbSuffixCSV.Checked = true;
            }

            if (strFieldEncloser == "")
            {
                rbNothing.Checked = true;
            }
            else
            {

                strFieldEncloser = "\"";
                rbDoubleQuotes.Checked = true;
            }
        }

        private void rbComma_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = ",";
        }

        private void rbSemicolon_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = ";";
        }

        private void rbSpace_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = " ";
        }

        private void rbTab_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = "\t";
        }

        private void rbPipe_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = "|";
        }


        private void rbFieldOther_CheckedChanged(object sender, EventArgs e)
        {
            strFieldDelimiter = txtFieldOther.Text.ToString();
        }

        private void txtFieldOther_TextChanged(object sender, EventArgs e)
        {
            rbFieldOther.Checked = true;
            strFieldDelimiter = txtFieldOther.Text.ToString();
        }


        private void rbNothing_CheckedChanged(object sender, EventArgs e)
        {
            strFieldEncloser = "";
        }

        private void rbDoubleQuotes_CheckedChanged(object sender, EventArgs e)
        {
            strFieldEncloser = "\"";
        }

        private void rbSingleQuotes_CheckedChanged(object sender, EventArgs e)
        {
            strFieldEncloser = "'";
        }

        private void rbEncloseOther_CheckedChanged(object sender, EventArgs e)
        {
            strFieldEncloser = txtEncloseOther.Text.ToString();
        }

        private void txtEncloseOther_TextChanged(object sender, EventArgs e)
        {
            rbEncloseOther.Checked = true;
            strFieldEncloser = txtEncloseOther.Text.ToString();

        }



        private void rbCRLF_CheckedChanged(object sender, EventArgs e)
        {
            strRowDelimiter = "\r\n";
        }

        private void rbLineFeedOnly_CheckedChanged(object sender, EventArgs e)
        {
            strRowDelimiter = "\n";
        }

        private void rbFormFeed_CheckedChanged(object sender, EventArgs e)
        {
            strRowDelimiter = "\f";
        }

        private void rbRowOther_CheckedChanged(object sender, EventArgs e)
        {
            strRowDelimiter = txtRowOther.Text.ToString();
        }

        private void txtRowOther_TextChanged(object sender, EventArgs e)
        {
            rbRowOther.Checked = true;
            strRowDelimiter = txtRowOther.Text.ToString();
        }

        private void chkExportHeader_CheckedChanged(object sender, EventArgs e)
        {
            boolOutputHeader = chkExportHeader.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkLimitRows.Checked)
            {
                intLimitRows = int.Parse(txtLimitRows.Text.ToString());
            }
            else
            {
                intLimitRows = 10000000;
            }
        }

        private void chkLimitRows_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLimitRows.Checked)
            {
                this.txtLimitRows.Enabled = true;
                intLimitRows = Convert.ToInt32(txtLimitRows.Text);
            }
            else
            {
                this.txtLimitRows.Enabled = false;
                intLimitRows = 10000000;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = txtDelimiterOther.Text.ToString();
        }

        private void rbCRSpace_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = " ";
        }

        private void rbCRComma_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = ",";
        }

        private void rbCRNothing_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = "";
        }


        private void rbDRNothing_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = "";
        }

        private void rbDRSpace_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = " ";
        }

        private void rbDRUnderscore_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = "_";
        }

        private void rbDROther_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = txtDelimiterOther.Text.ToString();
        }

        private void txtDelimiterOther_TextChanged(object sender, EventArgs e)
        {
            rbDROther.Checked = true;
            strDelimiterReplacement = txtDelimiterOther.Text.ToString();
        }

        private void gbDelimiterReplacement_Enter(object sender, EventArgs e)
        {

        }

        private void rbDRDontReplace_CheckedChanged(object sender, EventArgs e)
        {
            strDelimiterReplacement = strFieldDelimiter;
        }

        private void frmCSVExportOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rbDRDontReplace.Checked == true)
            {
                strDelimiterReplacement = strFieldDelimiter;
            }
        }

        private void rbSuffixCSV_CheckedChanged(object sender, EventArgs e)
        {
            strFileNameSuffix = ".csv";
        }

        private void rbSuffixTXT_CheckedChanged(object sender, EventArgs e)
        {
            strFileNameSuffix = ".txt";
        }

        private void rbSuffixOther_CheckedChanged(object sender, EventArgs e)
        {

            strFileNameSuffix = ".csv";
            strFileNameSuffix = "." + txtSuffixOther.Text.ToString().Replace(".","");
        }

        private void txtSuffixOther_TextChanged(object sender, EventArgs e)
        {

            rbSuffixOther.Checked = true;
            strFileNameSuffix = "." + txtSuffixOther.Text.ToString().Replace(".", "");
        }

        private void txtLimitRows_TextChanged(object sender, EventArgs e)
        {




            try
            {
                chkLimitRows.Checked = true;
                intLimitRows = Convert.ToInt32(txtLimitRows.Text);
            }
            catch 
            {

                intLimitRows = 0;
                txtLimitRows.Text = "0";

            }

        }


    }
}
