using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GAP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Future Development
        // http://www.c-sharpcorner.com/UploadFile/nipuntomar/contextmenuforgridview01162007124516PM/contextmenuforgridview.aspx


        public string VARtxtGAPConnection { get; set; }       // SQL Server Connection String to point to GAP Database
        public string VARtxtDBConnection { get; set; }        // SQL Server Connection String to point to Target Database

        public string VARstrStartupPath { get; set; }         // Startup Path for Sell-Through Files

        public int VARboolAdminMode { get; set; }         // Flag to determine whether 

        private void frmMain_Load(object sender, EventArgs e)
        {

            // Set the ico from the resources
            this.Icon = GAP.Properties.Resources.GAPLogo;

            VARtxtGAPConnection = @"Data Source=ZSL46;Initial Catalog=DW_ZSL;Integrated Security=True";
            VARtxtDBConnection = @"Data Source=ZSL46;Initial Catalog=DW_ZSL;Integrated Security=True";

            // Test that connections both work
            fnTestConnectionString(VARtxtGAPConnection);
            fnTestConnectionString(VARtxtDBConnection);

            // Assign default startup path
            // VARstrStartupPath = Application.StartupPath;
            VARstrStartupPath = @"C:\GAP";

            // Show initial Dataset - maybe Latest Build Times
            fnPopulatedgv1();

            mnuAdministratorReports.Checked = true;
            VARboolAdminMode = 1;

            this.Text = "Gift Aid Processor [" + VARtxtGAPConnection + "]";
        }

        public string fnSetConnectionString(string strConnection)
        {

            try
            {

                // Create and open Input Box to Enter SQL Server Connection String
                frmSelectConnection frmSelectConnection = new frmSelectConnection();

                frmSelectConnection.strDefault = strConnection;

                frmSelectConnection.ShowDialog();

                if (frmSelectConnection.DialogResult == DialogResult.OK)
                {

                    //MessageBox.Show("OK Pressed");
                    strConnection = frmSelectConnection.strDefault;

                    // Checks that the default SQL Server Connection works, if not a dialog box is openened for the user to enter the new connection string.
                    fnTestConnectionString(strConnection);
                }

                else
                {

                    // Exit the application if no connection can be made to the database
                    Application.Exit();
                }
            }

            catch (Exception Ex)
            {

                // Show default message
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return working database connection
            return strConnection;
        }


        public void fnTestConnectionString(string strConnection)
        {

            // Checks that the SQL Server Connection works, if not a dialog box is openened for the user to enter the new connection string.

            try
            {
                // Test a dummy connection to the Database to see if there is any connectivity
                SqlConnection conTestConnection;
                conTestConnection = new SqlConnection(strConnection);
                conTestConnection.Open();
                conTestConnection.Close();
                conTestConnection.Dispose();
            }

            catch (Exception Ex)
            {

                // Show default message
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Change the connection string as the default doesn't work
                fnSetConnectionString(strConnection);
            }
        }


        private void mnuReportsMenu_Click(object sender, EventArgs e)
        {

            // Call fnOpenReportsMenu()

            try
            {

                // Open Reports Menu
                fnOpenReportsMenu();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fnOpenReportsMenu()
        {

            // Show Reports Menu
            try
            {

                // Open Reports Menu - This is a multi table query ad cannot therefore be updated.
                fnViewData("Reports Menu", "sproc_GAP_SYSReportsMenu " + VARboolAdminMode, "ReportsMenu", 2, true, false, false, true, true);
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fnViewData(string strTitle, string strSQL, string strFileName,  int intExported, bool boolReadOnly, bool boolAddRows, bool boolDeleteRows, bool boolExecuteScript, bool boolFormModal)
        {

            // Opens frmViewData to show results of a Report or Query in a new form

            try
            {

                // Show Input Box for each variable
                frmViewData frmViewData = new frmViewData();
                frmViewData.strTitle = strTitle;
                frmViewData.strSQL = strSQL;
                frmViewData.boolReadOnly = boolReadOnly;
                frmViewData.boolAddRows = boolAddRows;
                frmViewData.boolExecuteScript = boolExecuteScript;
                frmViewData.strCSVFileName = strFileName;
                frmViewData.strDefaultPath = @VARstrStartupPath + @"\Export\";
                frmViewData.intExported = intExported;

                frmViewData.VARtxtDBConnection = VARtxtDBConnection;
                frmViewData.VARtxtGAPConnection = VARtxtGAPConnection;

                frmViewData.intDatabaseID = 1;  // This is the default connection for the GAP DB

                if (mnuAdministratorReports.Checked == true)
                {
                    frmViewData.intAdminstratorReports = 1;
                }
                else
                {
                    frmViewData.intAdminstratorReports = 0;
                }
                
                // Check to see if the Reports menu should be modal
                if (boolFormModal == true)
                {

                    // Shows form Modal - that form must be closed before any other window can be accessed.
                    // This is usually because the form allows updates which need to be actioned before another report can be run (otherwise the reults could be confusing).
                    frmViewData.ShowDialog();
                }

                else
                {

                    // Shows form - allows access to other forms
                    frmViewData.Show();
                }

            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fnPopulatedgv1()
        {
            //  Show default datagrid - Hap[pens to be a Donations file at the moment - Change CRH???

            SqlConnection conDGV1;
            SqlDataAdapter daDGV1;
            DataSet dsdgv1 = new DataSet();

            conDGV1 = new SqlConnection(VARtxtGAPConnection);
            dsdgv1.Clear();
            conDGV1.Open();

            daDGV1 = new SqlDataAdapter("select * from vw_RECENT_BUILDS", conDGV1);

            daDGV1.Fill(dsdgv1);
            conDGV1.Close();
            conDGV1.Dispose();
            dgv1.DataSource = dsdgv1.Tables[0];

            // Code to force seconds to be shown
            // http://social.msdn.microsoft.com/Forums/en-US/2055d187-1d71-4771-8113-d590f62731b6/datagridviewcolumn-display-datetime-with-seconds-milliseconds-?forum=winforms
            foreach (DataGridViewColumn dc in dgv1.Columns)
            {

                if (dc.ValueType == typeof(System.DateTime))
                {

                    dc.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                }
            }

            // Resize columns in datagrid
            dgv1.AutoResizeColumns();
        }

        private void mnuChangeGAPConnection_Click(object sender, EventArgs e)
        {

            // Change VARtxtGAPConnection Connection
            VARtxtGAPConnection = fnSetConnectionString(VARtxtGAPConnection);

            fnPopulatedgv1();

            this.Text = "Gift Aid Processor [" + VARtxtGAPConnection + "]";
        }

        private void mnuChangeTargetDBConnection_Click(object sender, EventArgs e)
        {

            // Change VARtxtDBConnection Connection
            VARtxtDBConnection = fnSetConnectionString(VARtxtDBConnection);
        }

        private void mnuAdministratorReports_Click(object sender, EventArgs e)
        {

            mnuAdministratorReports.Checked = !mnuAdministratorReports.Checked;

            if (mnuAdministratorReports.Checked)
            {
                VARboolAdminMode = 1;
            }
            else
            {
                VARboolAdminMode = 0;
            }
            
        }

        private void tsReports_Click(object sender, EventArgs e)
        {

            // Call fnOpenReportsMenu()

            try
            {

                // Open Reports Menu
                fnOpenReportsMenu();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
