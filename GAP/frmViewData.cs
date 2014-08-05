using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GAP
{
    public partial class frmViewData : Form
    {
        public frmViewData()
        {
            InitializeComponent();
        }

        public string strTitle { get; set; }     // Variable Name        
        public string strSQL { get; set; }     // Variable Name        
        public Boolean boolReadOnly { get; set; }     // Variable Name
        public Boolean boolAddRows { get; set; }     // Variable Name
        public Boolean boolDeleteRows { get; set; }     // Variable Name
        public Boolean boolExecuteScript { get; set; }     // Variable Name
        public string strCSVFileName { get; set; }     // Name of file to be exported
        public string strDefaultPath { get; set; }     // Name of file to be exported
        public int intExported { get; set; }
        public string VARtxtDBConnection { get; set; }   // Connection String for DB
        public string VARtxtGAPConnection { get; set; }   // Connection String for DB
        public string VARtxtCurrentConnection { get; set; }  // Current string selection
        public int intDatabaseID { get; set; }

        public int intAdminstratorReports { get; set; }


        SqlConnection conViewData;
        SqlDataAdapter daViewData;
        SqlCommandBuilder cbViewData;
        DataSet dsViewData = new DataSet();
        DataSet changes;

        public string[,] sxVARSQLVariables { get; set; }           // Stores Name/Value Pairs of Variables in an array
        public string sxVARSQLVarList { get; set; }                // Stores Name/Value Pairs of Variables in a string

        public string strExecutedSQL;  // String to hold last executed SQL

        private void frmViewData_Load(object sender, EventArgs e)
        {

            try
            {

                // Set form title
                this.Text = strTitle;

                // Database = 1 is the GAP Database connection
                if (this.intDatabaseID == 1)
                {

                    VARtxtCurrentConnection = VARtxtGAPConnection;
                }

                else
                {

                    VARtxtCurrentConnection = VARtxtDBConnection;
                }



                // Load data into Form
                fnLoadData();

                // Maximise Form
                this.WindowState = FormWindowState.Maximized;


                // Allow the addition of Rows to the Data grid depending upon the value of boolAddRows
                dgvViewData.AllowUserToAddRows = boolAddRows;
                dgvViewData.AllowUserToDeleteRows = boolDeleteRows;

                tsZoomText.Enabled = !boolReadOnly;

                if (strTitle == "Reports Menu")
                {

                    mnuShowExecutedSQL.Enabled = false;
                    executeToolStripMenuItem.Enabled = false;
                    tsExecuteScript.Enabled = false;
                    saveToolStripMenuItem.Enabled = false;
                    tsSaveChanges.Enabled = false;
                }
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fnLoadData()
        {

            // Load data into Form

            try
            {

                // Cursor Wait
                Cursor.Current = Cursors.WaitCursor;

                // Create a new connection with the Current Connection and fill dgvViewData
                conViewData = new SqlConnection(VARtxtCurrentConnection);
                dsViewData.Reset(); // CRH - Clears the whole dataset
                conViewData.Open();
                daViewData = new SqlDataAdapter(strSQL, conViewData);
                daViewData.SelectCommand.CommandTimeout = 0;
                daViewData.Fill(dsViewData);
                conViewData.Close();
                dgvViewData.DataSource = dsViewData.Tables[0];

                // Code to force seconds to be shown
                // http://social.msdn.microsoft.com/Forums/en-US/2055d187-1d71-4771-8113-d590f62731b6/datagridviewcolumn-display-datetime-with-seconds-milliseconds-?forum=winforms
                foreach (DataGridViewColumn dc in dgvViewData.Columns)
                {

                    if (dc.ValueType == typeof(System.DateTime))
                    {

                        dc.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss.fff";

                    }

                }

                MessageBox.Show(strSQL.ToString());

                int numRowCount = dgvViewData.RowCount;

                // Only resize columns if the reports has 250 or less records.  
                // Massive datasets take AGES to resize columns
                if (numRowCount <= 250)
                {

                    // Resize Columns
                    dgvViewData.AutoResizeColumns();
                }

                else
                {

                    // Stop the full row selection as edits may take place
                    dgvViewData.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                }



                // Can users edit the data?
                dgvViewData.ReadOnly = boolReadOnly;

                // Set menu options                
                executeToolStripMenuItem.Enabled = boolExecuteScript;
                tsExecuteScript.Enabled = boolExecuteScript;
                saveToolStripMenuItem.Enabled = !boolReadOnly;
                tsSaveChanges.Enabled = !boolReadOnly;

                // Check if "ReportCode" column exists, word wrap the text
                if (dgvViewData.Columns["ReportCode"] != null)
                {

                    // http://stackoverflow.com/questions/1706454/c-multiline-text-in-datagridview-control
                    // dgvViewData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    // Autosize - makes free text fields massive!
                    // dgvViewData.Columns["ReportCode"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    
                    dgvViewData.Columns["ReportCode"].Width = 300;

                }

                // Update Status Message on the form
                fnUpdateMessages("Records loaded: " + dgvViewData.Rows.Count.ToString());
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            finally
            {

                Cursor.Current = Cursors.Default;
            }
        }


        private void fnUpdateMessages(string strMessage)
        {

            // Update Status Message on the form

            try
            {

                tssMessage.Text = strMessage;
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fnSaveData()
        {

            // Save dataset changes back to the DB

            try
            {
                this.Validate();

                cbViewData = new SqlCommandBuilder(daViewData);
                changes = dsViewData.GetChanges();

                if (changes != null)
                {

                    daViewData.Update(changes);
                    changes.Dispose();

                }

                fnUpdateMessages("Records Saved");

                // Load data into Form
                fnLoadData();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmViewData_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {

            // Validates data in cells.  This means that the dataset can be saved back to the DB without the user having to move off that row to validate the data (which allows saving).
            this.Validate();

                if (boolReadOnly == false)
                {

                    cbViewData = new SqlCommandBuilder(daViewData);
                    changes = dsViewData.GetChanges();

                    // If there are no changes to update
                    if (changes != null)
                    {

                        DialogResult dlg = MessageBox.Show("Save changes before closing?", "Save Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dlg == DialogResult.Yes)
                        {

                            // Prompt to save
                            fnSaveData();
                        }

                        if (dlg == DialogResult.Cancel)
                        {

                            // This makes exiting the application complete
                            e.Cancel = true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Call fnLoadData()

            try
            {

                fnLoadData();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Call fnSaveData()

            try
            {

                fnSaveData();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Call fnExportToCSV2()

            try
            {

                fnExportToCSV();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string fnGetCurrentDateString()
        {

            try
            {
                // Build Date in format YYYY_MM_DD HH_MI_SS and assign to strFileTime
                string strFileTime = "";
                strFileTime = DateTime.Now.Year.ToString();
                strFileTime += "_" + ("0" + DateTime.Now.Month.ToString()).Substring(("0" + DateTime.Now.Month.ToString()).Length - 2);
                strFileTime += "_" + ("0" + DateTime.Now.Day.ToString()).Substring(("0" + DateTime.Now.Day.ToString()).Length - 2);
                strFileTime += " " + ("0" + DateTime.Now.Hour.ToString()).Substring(("0" + DateTime.Now.Hour.ToString()).Length - 2);
                strFileTime += "_" + ("0" + DateTime.Now.Minute.ToString()).Substring(("0" + DateTime.Now.Minute.ToString()).Length - 2);
                strFileTime += "_" + ("0" + DateTime.Now.Second.ToString()).Substring(("0" + DateTime.Now.Second.ToString()).Length - 2);

                // Return the formatted date
                return strFileTime;
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }


        private void fnExportToCSV()
        {

            //http://stackoverflow.com/questions/4959722/c-sharp-datatable-to-csv
            // Genius!

            try
            {

                // CRH Need to handle carriage returns in the output (Reports Menu multiline SQL for example).  It doesn't work on CSVs

                // Initialise default parameters
                string strFieldDelimiter = "";
                string strFieldEncloser = "";
                string strRowDelimiter = "";
                string strDelimiterReplacement = "";
                string strFileNameSuffix = "";
                bool boolOutputHeader = true;
                int intLimitRows = 0;

                // Open CSVExportOptions Form 
                frmCSVExportOptions frmCSVExport = new frmCSVExportOptions();

                // Set default values
                //frmCSVExport.strFieldDelimiter = "\t";
                //frmCSVExport.strFileNameSuffix = ".txt";
                //frmCSVExport.strFieldEncloser = "";

                frmCSVExport.strFieldDelimiter = ",";
                frmCSVExport.strFileNameSuffix = ".csv";
                frmCSVExport.strFieldEncloser = "";

                // Open Form
                DialogResult drFlag = frmCSVExport.ShowDialog();

                if (frmCSVExport.intLimitRows > dgvViewData.Rows.Count)
                {
                    intLimitRows = dgvViewData.Rows.Count;
                }

                else
                {
                    intLimitRows = frmCSVExport.intLimitRows;
                }

                if (drFlag == DialogResult.OK)
                {

                    // Set cursor to wait
                    Cursor.Current = Cursors.WaitCursor;

                    strFieldDelimiter = frmCSVExport.strFieldDelimiter;
                    strFieldEncloser = frmCSVExport.strFieldEncloser;
                    strRowDelimiter = frmCSVExport.strRowDelimiter;
                    strDelimiterReplacement = frmCSVExport.strDelimiterReplacement;
                    strFileNameSuffix = frmCSVExport.strFileNameSuffix;
                    boolOutputHeader = frmCSVExport.boolOutputHeader;

                    //http://stackoverflow.com/questions/4959722/c-sharp-datatable-to-csv

                    StringBuilder sbData = new StringBuilder();

                    IEnumerable<string> columnNames = dsViewData.Tables[0].Columns.Cast<DataColumn>().Select(column => strFieldEncloser + column.ColumnName.ToString().Replace(strFieldDelimiter, strDelimiterReplacement) + strFieldEncloser);
                    sbData.AppendLine(string.Join(strFieldDelimiter, columnNames)); // Join Field with strFieldDelimiter

                    foreach (DataRow row in dsViewData.Tables[0].Rows)
                    {

                        if (intLimitRows == 0)
                        {
                            break;
                        }                            
                        
                        IEnumerable<string> fields = row.ItemArray.Select(field => strFieldEncloser + field.ToString().Replace(strFieldDelimiter, strDelimiterReplacement) + strFieldEncloser);
                            sbData.AppendLine(string.Join(strFieldDelimiter, fields)); // Join Field with strFieldDelimiter
                            intLimitRows = intLimitRows - 1;
                    }

                    // http://stackoverflow.com/questions/6637969/c-sharp-datarow-all-itemarrays-to-single-string-appending-to-each-array

                    // Build Export file path

                    string txtExportFileName = strDefaultPath + strCSVFileName  + this.fnGetCurrentDateString() + strFileNameSuffix;

                    // Write data to export file
                    File.WriteAllText(@txtExportFileName, sbData.ToString());

                    // Create and assign variable to see if the user wants to open the file
                    DialogResult Result = MessageBox.Show("Data exported." + Environment.NewLine + Environment.NewLine + "Would you like to work with this file right now?", this.strTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Test to see if the user wants to open the file right now
                    if (Result == DialogResult.Yes)
                    {

                        // Open the file with the default program (Usually Excel or Notepad) for .csv files
                        System.Diagnostics.Process.Start(txtExportFileName);
                    }
                }
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                // Set cursor to default
                Cursor.Current = Cursors.Default;
            }
        }


        private void fnOpenDefaultExportFolder()
        {

            // Open  Default Export Folder in Windows Explorer

            try
            {

                System.Diagnostics.Process.Start(@strDefaultPath);
            }
        
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mnuDefaultExportFolder_Click(object sender, EventArgs e)
        {

            // Call fnOpenDefaultExportFolder()

            try
            {

                fnOpenDefaultExportFolder();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void tsOpenExportFolder_Click(object sender, EventArgs e)
        {

            // Call fnOpenDefaultExportFolder()

            try
            {

                fnOpenDefaultExportFolder();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsExecuteScript_Click(object sender, EventArgs e)
        {

            // Call fnLoadData()

            try
            {

                fnLoadData();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsSaveChanges_Click(object sender, EventArgs e)
        {

            // Call fnSaveData()

            try
            {

                fnSaveData();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsExportData_Click(object sender, EventArgs e)
        {

            // Call fnExportToCSV()

            try
            {

                fnExportToCSV();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fnAutoSizeColumns()
        {

            // Autosize columns

            try
            {

                dgvViewData.AutoResizeColumns();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mnuAutoSizeColumns_Click(object sender, EventArgs e)
        {

            // Call fnAutoSizeColumns();

            try
            {

                fnAutoSizeColumns();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsAutoSizeColumns_Click(object sender, EventArgs e)
        {

            // Call fnAutoSizeColumns();

            try
            {

                fnAutoSizeColumns();
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tssViewDataClose_Click(object sender, EventArgs e)
        {

            // Closes form and then calls FormClosing
            this.Close();
        }

        private void dgvViewData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // http://stackoverflow.com/questions/3207420/datagridview-editmode-editonenter-how-to-select-the-row-to-delete-it

            // If the whole Row is highlighted, end editing
            if (e.ColumnIndex == -1)
            {

                // Highlight the whole row
                dgvViewData.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgvViewData.EndEdit();
            }

            else
            {

                // If a cell is clicked
                if (dgvViewData.EditMode != DataGridViewEditMode.EditOnEnter)
                {

                    // Edit the cell
                    dgvViewData.EditMode = DataGridViewEditMode.EditOnEnter;
                    dgvViewData.BeginEdit(false);
                }
            }

        }

        private void tsZoomText_Click(object sender, EventArgs e)
        {

            frmInputBoxZoom frmInputZoom = new frmInputBoxZoom();

            // Transfer Variable Name to the Input Box
            frmInputZoom.strZoomVariable = dgvViewData.SelectedCells[0].Value.ToString();

            // Show Input Dialog Box
            frmInputZoom.ShowDialog();

            // Assign the return value from the Input Box to the Textbox
            dgvViewData.SelectedCells[0].Value = frmInputZoom.strZoomInput;
        }


        private void dgvViewData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            // Open Report if you are viewing the 'Reports Menu'

            try
            {

                // If this is the Reports menu, then Double-Clicking a line will run the Code
                if (this.strTitle == "Reports Menu")
                {

                    Cursor.Current = Cursors.WaitCursor;

                    if (dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ReportName"].Value.ToString() != "")
                    {

                        strSQL = fnSplitSQL(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ReportCode"].Value.ToString());

                        if(strSQL != "")
                        {

                            // Show Input Box for each variable
                            frmViewData frmViewDataReport = new frmViewData();
                            frmViewDataReport.strTitle = dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ReportName"].Value.ToString();
                            frmViewDataReport.strSQL = strSQL;
                            frmViewDataReport.boolReadOnly = Convert.ToBoolean(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ReadOnly"].Value);
                            frmViewDataReport.boolAddRows = Convert.ToBoolean(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["AddRows"].Value);
                            frmViewDataReport.boolDeleteRows = Convert.ToBoolean(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["DeleteRows"].Value);
                            frmViewDataReport.boolExecuteScript = Convert.ToBoolean(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ExecuteScript"].Value);
                            frmViewDataReport.intDatabaseID = Convert.ToInt32(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["DatabaseID"].Value);

                            if (dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ExportFilenamePrefix"].Value.ToString() == "")
                            {
                                frmViewDataReport.strCSVFileName = dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ReportName"].Value.ToString().Replace(" ", "") + "-" + this.sxVARSQLVarList;
                            }

                            else
                            {
                                frmViewDataReport.strCSVFileName = dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["ExportFilenamePrefix"].Value.ToString() + "-" + this.sxVARSQLVarList;
                            }

                            frmViewDataReport.strDefaultPath = this.strDefaultPath; // + @"\Export\";
                            frmViewDataReport.intExported = intExported;
                            frmViewDataReport.VARtxtDBConnection = VARtxtDBConnection;
                            frmViewDataReport.VARtxtGAPConnection = VARtxtGAPConnection;

                            // Decide whether the form should be opened modally or not
                            if (Convert.ToBoolean(dgvViewData.Rows[dgvViewData.SelectedCells[0].RowIndex].Cells["FormModal"].Value) == true)
                            {

                                frmViewDataReport.ShowDialog();
                            }

                            else
                            {

                                frmViewDataReport.Show();
                            }
                        }

                    }

                    Cursor.Current = Cursors.Default;
                }
            }

            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string fnSplitSQL(string strSQLPassed)
        {

            try
            {

                strExecutedSQL = "";

                //string strExecutableSQL = strSQLPassed;
                //return strExecutableSQL;


                strExecutedSQL = strSQLPassed + " ";  // Add extra space as Input Parameters that end the SQL Statement won't work

                // http://www.csharpfriends.com/articles/getarticle.aspx?articleid=28



                // Stores how many Variables there are in the SQL
                int intVarCount = 0;

                // Holds the original Split SQL
                string[] arInfo = new string[50];

                // Updates the original Split SQL
                string[] arInfo2 = new string[50];

                // Reset sxVARSQLVariables (Max of 50 - arbitrary number) 
                // Stores Name/Value Pairs of Variables in an array
                this.sxVARSQLVariables = new string[50, 2];

                // Reset sxVARSQLVarList 
                // Stores Name/Value Pairs of Variables in a string
                this.sxVARSQLVarList = "";

                // Define which character is seperating fields
                char[] splitter = { '@' };

                // Holds the original Split SQL
                arInfo = strExecutedSQL.Split(splitter);

                // Updates the original Split SQL
                arInfo2 = strExecutedSQL.Split(splitter);

                // Create and Initialise bool variable for opening Input box
                bool boolGetVariable = true;

                // String to Assign the Variable Name to
                string strVariableName = "";

                // Variable to check to see if the Variable is a 'Simple Variable'
                int intContainsSemiColon = 0;

                // Loop through the split SQL sections one at a time
                for (int x = 0; x < arInfo.Length; x++)
                {

                    // If the first character is a "(" (it is a Variable), then continue
                    if (arInfo[x].Substring(0, 1) == "(")
                    {

                        // Reset boolGetVariable - by default the Input Box should be called unless set otherwise (when the variable has been set before)
                        boolGetVariable = true;

                        // Check through all of the existing Variables to see if it has already been set.
                        // The '/2' is because it's a two dimensional array.  This works out how many variable names are stored
                        for (int y = 0; y < (this.sxVARSQLVariables.Length / 2); y++)
                        {

                            // Assign the Section of Text to a variable to carry out checks to see which InputBox Override it uses (how many ';'s it has)
                            strVariableName = arInfo[x];

                            // Variable 
                            intContainsSemiColon = 0;

                            // Find out if the Variable has a ';'
                            intContainsSemiColon = strVariableName.IndexOf(";", 1);

                            // Test intContainsSemiColon for ';'s
                            if (intContainsSemiColon > 0)
                            {

                                // Variable HAS a ';' - Assign the variable name as the text up to the first ';'
                                strVariableName = arInfo[x].Substring(1, intContainsSemiColon - 1);

                            }
                            else
                            {

                                // Variable has NOT got a ';' - Assign the variable name the whole word - Simple Variable
                                strVariableName = arInfo[x].Substring(1, arInfo[x].Length - 2);

                            }

                            // Is the current Variable the same as the current Name in the array?
                            if (strVariableName == this.sxVARSQLVariables[y, 0])
                            {

                                // When the two match, use the existing value to update the split array
                                arInfo2[x] = this.sxVARSQLVariables[y, 1];

                                // Make sure that the variable picker is not opened
                                boolGetVariable = false;
                            }
                        }

                        // Check to see if there was a match already, if not, then show the variable picker
                        if (boolGetVariable == true)
                        {

                            // Show Input Box for each variable
                            frmInputBox frmInputBox = new frmInputBox();
                            frmInputBox.strDatePickerFormat = "dd-MMM-yyyy";
                            frmInputBox.strAutoRun = "false";

                            // Create and assign variables to split the variable properties.  Max Variables is 50 CRH
                            string[] arVariable = new string[50];
                            char[] charVariableSplitter = ";".ToCharArray();
                            arVariable = arInfo[x].Substring(1, arInfo[x].Length - 2).Split(charVariableSplitter);

                            // Check to see which kind of Variable picker is being summonsed
                            if (arVariable.Length == 1)
                            {
                                // Transfer Variable Name to the Input Box without the brackets and set defaults
                                frmInputBox.strVariable = arVariable[0];
                                frmInputBox.strMessage = "Enter value for " + arVariable[0];
                                frmInputBox.strDataType = "String";
                                frmInputBox.strDefaultValue = "";

                                frmInputBox.boolLOV = false;
                                frmInputBox.boolMulti = false;
                                frmInputBox.strOperator = "";
                                frmInputBox.strDSN = "";
                                frmInputBox.strSQLLU = "";
                            }

                            if (arVariable.Length == 2)
                            {
                                // Transfer Variable Name to the Input Box without the brackets and set defaults
                                frmInputBox.strVariable = arVariable[0];
                                frmInputBox.strMessage = "Enter value for " + arVariable[0];
                                frmInputBox.strDataType = "String";
                                frmInputBox.strDefaultValue = arVariable[1];

                                frmInputBox.boolLOV = false;
                                frmInputBox.boolMulti = false;
                                frmInputBox.strOperator = "";
                                frmInputBox.strDSN = "";
                                frmInputBox.strSQLLU = "";
                            }

                            // @(LastSold;Please enter Date in the format DD/MM/YYYY;Date;-5)@

                            if (arVariable.Length == 4)
                            {

                                // Transfer Variable Name to the Input Box without the brackets
                                frmInputBox.strVariable = arVariable[0];
                                frmInputBox.strMessage = arVariable[1];
                                frmInputBox.strDataType = arVariable[2];
                                frmInputBox.strDefaultValue = arVariable[3];

                                frmInputBox.boolLOV = false;
                                frmInputBox.boolMulti = false;
                                frmInputBox.strOperator = "=";
                                frmInputBox.strDSN = "";
                                frmInputBox.strSQLLU = "";
                            }

                            //if (arVariable.Length == 10)
                            //{

                            //    // Transfer Variable Name to the Input Box without the brackets
                            //    frmInputBox.strVariable = arVariable[0];
                            //    frmInputBox.strMessage = arVariable[1];
                            //    frmInputBox.strDataType = arVariable[2];
                            //    frmInputBox.strDefaultValue = arVariable[3];

                            //    frmInputBox.boolLOV = Convert.ToBoolean(arVariable[4]);
                            //    frmInputBox.boolMulti = Convert.ToBoolean(arVariable[5]);
                            //    frmInputBox.boolEdit = Convert.ToBoolean(arVariable[6]);
                            //    frmInputBox.strOperator = "=";
                            //    frmInputBox.strDSN = arVariable[7];
                            //    frmInputBox.strSQLLU = arVariable[8];

                            //    // CRH???
                            //    frmInputBox.strCurrentConnectionName = VARtxtCurrentConnection; // this.sxVARODBCConnectionStrings[this.fnGetConnectionString(arVariable[7], false), 2];
                            //}


                            // Show Input Dialog Box
                            if (frmInputBox.ShowDialog() == DialogResult.OK)
                            {



                                // Assign the return value from the Input Box to the array
                                arInfo2[x] = frmInputBox.strInput;

                                // Assign NAME / VALUE pairs for current Variables
                                this.sxVARSQLVariables[intVarCount, 0] = arVariable[0]; // arInfo[x].Substring(1, arInfo[x].Length - 2);
                                this.sxVARSQLVariables[intVarCount, 1] = arInfo2[x].ToString();

                                this.sxVARSQLVarList += this.sxVARSQLVariables[intVarCount, 0].ToString() + "{" + this.sxVARSQLVariables[intVarCount, 1].ToString() + "}";

                                // Increment the number of variables held
                                intVarCount++;
                            }
                            else
                            {
                                //break;

                                // Return blank string if Input Box is cancelled
                                return "";

                                //MessageBox.Show("Query cancelled","Cancel")
                            }
                        }
                    }
                }

                // Reset strJoin
                string strJoin = "";

                // Join Parsed Text
                strJoin = String.Join("", arInfo2);

                //MessageBox.Show(strJoin);

                strExecutedSQL = strJoin;

                // Return joined string 
                return strJoin;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Application.ProductName.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void mnuShowExecutedSQL_Click(object sender, EventArgs e)
        {

            frmInputBoxZoom frmInputZoom = new frmInputBoxZoom();

            // Transfer Variable Name to the Input Box
            frmInputZoom.strZoomVariable = strExecutedSQL;

            // Show Input Dialog Box
            frmInputZoom.ShowDialog();

            
        }

        private void dgvViewData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




    }
}

