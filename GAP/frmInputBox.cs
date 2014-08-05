using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;  // Needed for SQL Server Connection


namespace GAP
{
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
        }

        public string strVariable { get; set; }     // Variable Name
        public string strMessage { get; set; }      // Message to explain variable
        public string strDataType { get; set; }     // Data Type of Variable
        public string strDefaultValue { get; set; } // Default Value
        public string strDatePickerFormat { get; set; } // Default Date Format
        public string strAutoRun { get; set; }      // AutoRun - no interaction with user - just use defaults

        public bool boolLOV { get; set; } // Default Value
        public bool boolMulti { get; set; } // Default Value
        public bool boolEdit { get; set; } // Default Value
        public string strOperator { get; set; } // Default Value
        public string strDSN { get; set; } // Default Value
        public string strSQLLU { get; set; } // Default Value

        public string strCurrentConnectionName { get; set; } // Default Value


        public string strInput { get; set; }        // Return Value

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            // Check if Message was Black, Create simple default one using the Variable Name
            this.Text = "Variable: " + this.strVariable; // strVariable;

            // If the Message is blank, create a default message
            if (this.strMessage == "")
            {

                // Create message "Enter value for VariableName"
                this.strMessage = "Enter value for " + this.strVariable;
            }

            // Set the prompt
            this.lblPrompt.Text = strMessage; //"Enter value for " + strVariable + ":";

            // Set the default value
            this.txtValue.Text = this.strDefaultValue;


            if (this.strDataType == "Date")
            {
                //MessageBox.Show("Date Picker");
                this.dtpDatePicker.Visible = true;
                this.checkedListBox1.Visible = false;
                this.comboBox1.Visible = false;
                SelectDate();
            }

            if (this.boolLOV == true & this.boolMulti == true)
            {
                MessageBox.Show("Checked List Box");
                this.dtpDatePicker.Visible = false;
                this.checkedListBox1.Visible = true;
                this.comboBox1.Visible = false;
                SelectCheckedListBox();
            }

            if (this.boolLOV == true & this.boolMulti == false)
            {
                MessageBox.Show("Combo Box");
                this.dtpDatePicker.Visible = false;
                this.checkedListBox1.Visible = false;
                this.comboBox1.Visible = true;
                SelectComboBox();
            }

            // Set the focus to the text box
            this.txtValue.Focus();

            if (this.strAutoRun == "true")
            {

                ClickOK();
            }
        }


        private void SelectDate()
        {

            // If the data type is Date then set up the Date Picker
            if (this.strDataType == "Date")
            {

                // Set up format of the returned value depending upon the <DatePickerFormat> in SQLExecutor.xml
                this.dtpDatePicker.CustomFormat = this.strDatePickerFormat.ToString();

                // Set up the format of the date pricker depending upon regional settings
                this.dtpDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;

                // If the default value is blank, use today's date
                if (this.strDefaultValue == "" || this.strDefaultValue == "0")
                {

                    // Assign Today's date
                    this.dtpDatePicker.Value = System.DateTime.Now;
                    this.txtValue.Text = dtpDatePicker.Text;
                }
                else

                // If default is not blank then calculate what it should be
                {

                    // Check to see if there is a slash '/' in the default value.  If there is the default is a static date.
                    if ((this.strDefaultValue.IndexOf("/") > 0))
                    {

                        // Assign static date
                        this.dtpDatePicker.Value = Convert.ToDateTime(this.strDefaultValue);
                        this.txtValue.Text = dtpDatePicker.Text;
                    }
                    else
                    {

                        //  Set the default as a relative number of days from today, plus or minus
                        this.dtpDatePicker.Value = System.DateTime.Now.AddDays(Convert.ToDouble(this.strDefaultValue));
                        this.txtValue.Text = dtpDatePicker.Text;
                    }
                }

                // Set the focus to the Date Picker
                this.dtpDatePicker.Focus();
            }
        }

        private void SelectCheckedListBox()
        {



            //string strConn = "Data Source=PPS-SRV-01;Initial Catalog=InsightDW;Integrated Security=True";
            string strConn = this.strCurrentConnectionName;

            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            //string strCmd = "select SP_Code, SP_Name from dimSalesPersons where DW_CompanyID = 4	ORDER BY 1";
            string strCmd = strSQLLU;

            SqlCommand Cmd = new SqlCommand(strCmd, Con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, Con);
            DataSet ds = new DataSet();
            Con.Close();
            da.Fill(ds);
            checkedListBox1.DataSource = ds.Tables[0];
            checkedListBox1.ValueMember = ds.Tables[0].Columns[0].ColumnName;
            checkedListBox1.DisplayMember = ds.Tables[0].Columns[1].ColumnName;
        }

        private void SelectComboBox()
        {

            //string strConn = "Data Source=PPS-SRV-01;Initial Catalog=InsightDW;Integrated Security=True";
            string strConn = this.strCurrentConnectionName;

            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            //string strCmd = "select SP_Code, SP_Name from dimSalesPersons where DW_CompanyID = 4	ORDER BY 1";
            string strCmd = strSQLLU;

            SqlCommand Cmd = new SqlCommand(strCmd, Con);
            SqlDataAdapter da = new SqlDataAdapter(strCmd, Con);
            DataSet ds = new DataSet();
            Con.Close();
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.ValueMember = ds.Tables[0].Columns[0].ColumnName;
            comboBox1.DisplayMember = ds.Tables[0].Columns[1].ColumnName;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void ClickOK()
        {
            // Set the return value to that of the text box
            this.strInput = txtValue.Text;


            // When Dialog OK is pressed then pass back this result
            this.DialogResult = DialogResult.OK;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            frmInputBoxZoom frmInputZoom = new frmInputBoxZoom();

            // Transfer Variable Name to the Input Box
            frmInputZoom.strZoomVariable = this.txtValue.Text;

            // Show Input Dialog Box
            frmInputZoom.ShowDialog();

            // Assign the return value from the Input Box to the Textbox
            this.txtValue.Text = frmInputZoom.strZoomInput;

            //this.txtValue.SelectAll();

        }

        private void dtpDatePicker_ValueChanged(object sender, EventArgs e)
        {

            // Assign the Input Text Box
            this.txtValue.Text = dtpDatePicker.Text;
        }

        public void fnSetTextCheckedListBox()
        {
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.checkedlistbox.checkeditems.aspx
            //http://stackoverflow.com/questions/6518518/how-to-get-value-member-of-checked-items-in-checkedlistbox-windows-control

            String strSelected = "";
            //txtValue.Text = strSelected;

            foreach (DataRowView view in checkedListBox1.CheckedItems)
            {

                //MessageBox.Show(view[checkedListBox1.ValueMember].ToString() + " | " + view[checkedListBox1.DisplayMember].ToString());
                strSelected += (view[checkedListBox1.ValueMember].ToString()) + ",";
            }

            if (strSelected.Length == 0)

                strSelected = "";
            else
                strSelected = strSelected.Substring(0, strSelected.Length - 1);

            txtValue.Text = strSelected;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnSetTextCheckedListBox();
        }

        public void fnSetTextComboBox()
        {
            //http://msdn.microsoft.com/en-us/library/system.windows.forms.checkedlistbox.checkeditems.aspx
            //http://stackoverflow.com/questions/6518518/how-to-get-value-member-of-checked-items-in-checkedlistbox-windows-control

            //String strSelected = "";

            txtValue.Text = comboBox1.SelectedValue.ToString();

            //txtValue.Text = strSelected;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fnSetTextComboBox();
        }





    }
}
