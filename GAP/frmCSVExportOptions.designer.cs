namespace GAP
{
    partial class frmCSVExportOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSVExportOptions));
            this.rbTab = new System.Windows.Forms.RadioButton();
            this.gbDelimiterReplacement = new System.Windows.Forms.GroupBox();
            this.rbDRDontReplace = new System.Windows.Forms.RadioButton();
            this.rbDRNothing = new System.Windows.Forms.RadioButton();
            this.txtDelimiterOther = new System.Windows.Forms.TextBox();
            this.rbDROther = new System.Windows.Forms.RadioButton();
            this.rbDRSpace = new System.Windows.Forms.RadioButton();
            this.rbDRUnderscore = new System.Windows.Forms.RadioButton();
            this.rbFieldOther = new System.Windows.Forms.RadioButton();
            this.rbSpace = new System.Windows.Forms.RadioButton();
            this.rbSemicolon = new System.Windows.Forms.RadioButton();
            this.rbComma = new System.Windows.Forms.RadioButton();
            this.chkLimitRows = new System.Windows.Forms.CheckBox();
            this.rbEncloseOther = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSingleQuotes = new System.Windows.Forms.RadioButton();
            this.txtLimitRows = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEncloseOther = new System.Windows.Forms.TextBox();
            this.rbDoubleQuotes = new System.Windows.Forms.RadioButton();
            this.rbNothing = new System.Windows.Forms.RadioButton();
            this.chkExportHeader = new System.Windows.Forms.CheckBox();
            this.gbRowDelimiter = new System.Windows.Forms.GroupBox();
            this.rbFormFeed = new System.Windows.Forms.RadioButton();
            this.txtRowOther = new System.Windows.Forms.TextBox();
            this.rbRowOther = new System.Windows.Forms.RadioButton();
            this.rbLineFeedOnly = new System.Windows.Forms.RadioButton();
            this.rbCRLF = new System.Windows.Forms.RadioButton();
            this.gbFieldDelimiter = new System.Windows.Forms.GroupBox();
            this.rbPipe = new System.Windows.Forms.RadioButton();
            this.txtFieldOther = new System.Windows.Forms.TextBox();
            this.bgFileNameSuffix = new System.Windows.Forms.GroupBox();
            this.txtSuffixOther = new System.Windows.Forms.TextBox();
            this.rbSuffixOther = new System.Windows.Forms.RadioButton();
            this.rbSuffixTXT = new System.Windows.Forms.RadioButton();
            this.rbSuffixCSV = new System.Windows.Forms.RadioButton();
            this.gbDelimiterReplacement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRowDelimiter.SuspendLayout();
            this.gbFieldDelimiter.SuspendLayout();
            this.bgFileNameSuffix.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbTab
            // 
            this.rbTab.AutoSize = true;
            this.rbTab.Location = new System.Drawing.Point(21, 89);
            this.rbTab.Name = "rbTab";
            this.rbTab.Size = new System.Drawing.Size(44, 17);
            this.rbTab.TabIndex = 3;
            this.rbTab.Text = "Tab";
            this.rbTab.UseVisualStyleBackColor = true;
            this.rbTab.CheckedChanged += new System.EventHandler(this.rbTab_CheckedChanged);
            // 
            // gbDelimiterReplacement
            // 
            this.gbDelimiterReplacement.Controls.Add(this.rbDRDontReplace);
            this.gbDelimiterReplacement.Controls.Add(this.rbDRNothing);
            this.gbDelimiterReplacement.Controls.Add(this.txtDelimiterOther);
            this.gbDelimiterReplacement.Controls.Add(this.rbDROther);
            this.gbDelimiterReplacement.Controls.Add(this.rbDRSpace);
            this.gbDelimiterReplacement.Controls.Add(this.rbDRUnderscore);
            this.gbDelimiterReplacement.Location = new System.Drawing.Point(178, 83);
            this.gbDelimiterReplacement.Name = "gbDelimiterReplacement";
            this.gbDelimiterReplacement.Size = new System.Drawing.Size(157, 142);
            this.gbDelimiterReplacement.TabIndex = 31;
            this.gbDelimiterReplacement.TabStop = false;
            this.gbDelimiterReplacement.Text = "Field delimiter replacement";
            this.gbDelimiterReplacement.Enter += new System.EventHandler(this.gbDelimiterReplacement_Enter);
            // 
            // rbDRDontReplace
            // 
            this.rbDRDontReplace.AutoSize = true;
            this.rbDRDontReplace.Location = new System.Drawing.Point(21, 88);
            this.rbDRDontReplace.Name = "rbDRDontReplace";
            this.rbDRDontReplace.Size = new System.Drawing.Size(88, 17);
            this.rbDRDontReplace.TabIndex = 7;
            this.rbDRDontReplace.Text = "Don\'t replace";
            this.rbDRDontReplace.UseVisualStyleBackColor = true;
            this.rbDRDontReplace.CheckedChanged += new System.EventHandler(this.rbDRDontReplace_CheckedChanged);
            // 
            // rbDRNothing
            // 
            this.rbDRNothing.AutoSize = true;
            this.rbDRNothing.Checked = true;
            this.rbDRNothing.Location = new System.Drawing.Point(21, 20);
            this.rbDRNothing.Name = "rbDRNothing";
            this.rbDRNothing.Size = new System.Drawing.Size(62, 17);
            this.rbDRNothing.TabIndex = 6;
            this.rbDRNothing.TabStop = true;
            this.rbDRNothing.Text = "Nothing";
            this.rbDRNothing.UseVisualStyleBackColor = true;
            this.rbDRNothing.CheckedChanged += new System.EventHandler(this.rbDRNothing_CheckedChanged);
            // 
            // txtDelimiterOther
            // 
            this.txtDelimiterOther.Location = new System.Drawing.Point(81, 111);
            this.txtDelimiterOther.Name = "txtDelimiterOther";
            this.txtDelimiterOther.Size = new System.Drawing.Size(35, 20);
            this.txtDelimiterOther.TabIndex = 5;
            this.txtDelimiterOther.TextChanged += new System.EventHandler(this.txtDelimiterOther_TextChanged);
            // 
            // rbDROther
            // 
            this.rbDROther.AutoSize = true;
            this.rbDROther.Location = new System.Drawing.Point(21, 111);
            this.rbDROther.Name = "rbDROther";
            this.rbDROther.Size = new System.Drawing.Size(54, 17);
            this.rbDROther.TabIndex = 4;
            this.rbDROther.Text = "Other:";
            this.rbDROther.UseVisualStyleBackColor = true;
            this.rbDROther.CheckedChanged += new System.EventHandler(this.rbDROther_CheckedChanged);
            // 
            // rbDRSpace
            // 
            this.rbDRSpace.AutoSize = true;
            this.rbDRSpace.Location = new System.Drawing.Point(21, 42);
            this.rbDRSpace.Name = "rbDRSpace";
            this.rbDRSpace.Size = new System.Drawing.Size(56, 17);
            this.rbDRSpace.TabIndex = 2;
            this.rbDRSpace.Text = "Space";
            this.rbDRSpace.UseVisualStyleBackColor = true;
            this.rbDRSpace.CheckedChanged += new System.EventHandler(this.rbDRSpace_CheckedChanged);
            // 
            // rbDRUnderscore
            // 
            this.rbDRUnderscore.AutoSize = true;
            this.rbDRUnderscore.Location = new System.Drawing.Point(21, 65);
            this.rbDRUnderscore.Name = "rbDRUnderscore";
            this.rbDRUnderscore.Size = new System.Drawing.Size(80, 17);
            this.rbDRUnderscore.TabIndex = 0;
            this.rbDRUnderscore.Text = "Underscore";
            this.rbDRUnderscore.UseVisualStyleBackColor = true;
            this.rbDRUnderscore.CheckedChanged += new System.EventHandler(this.rbDRUnderscore_CheckedChanged);
            // 
            // rbFieldOther
            // 
            this.rbFieldOther.AutoSize = true;
            this.rbFieldOther.Location = new System.Drawing.Point(21, 139);
            this.rbFieldOther.Name = "rbFieldOther";
            this.rbFieldOther.Size = new System.Drawing.Size(54, 17);
            this.rbFieldOther.TabIndex = 4;
            this.rbFieldOther.Text = "Other:";
            this.rbFieldOther.UseVisualStyleBackColor = true;
            this.rbFieldOther.CheckedChanged += new System.EventHandler(this.rbFieldOther_CheckedChanged);
            // 
            // rbSpace
            // 
            this.rbSpace.AutoSize = true;
            this.rbSpace.Location = new System.Drawing.Point(21, 66);
            this.rbSpace.Name = "rbSpace";
            this.rbSpace.Size = new System.Drawing.Size(56, 17);
            this.rbSpace.TabIndex = 2;
            this.rbSpace.Text = "Space";
            this.rbSpace.UseVisualStyleBackColor = true;
            this.rbSpace.CheckedChanged += new System.EventHandler(this.rbSpace_CheckedChanged);
            // 
            // rbSemicolon
            // 
            this.rbSemicolon.AutoSize = true;
            this.rbSemicolon.Location = new System.Drawing.Point(21, 42);
            this.rbSemicolon.Name = "rbSemicolon";
            this.rbSemicolon.Size = new System.Drawing.Size(74, 17);
            this.rbSemicolon.TabIndex = 1;
            this.rbSemicolon.Text = "Semicolon";
            this.rbSemicolon.UseVisualStyleBackColor = true;
            this.rbSemicolon.CheckedChanged += new System.EventHandler(this.rbSemicolon_CheckedChanged);
            // 
            // rbComma
            // 
            this.rbComma.AutoSize = true;
            this.rbComma.Checked = true;
            this.rbComma.Location = new System.Drawing.Point(21, 19);
            this.rbComma.Name = "rbComma";
            this.rbComma.Size = new System.Drawing.Size(60, 17);
            this.rbComma.TabIndex = 0;
            this.rbComma.TabStop = true;
            this.rbComma.Text = "Comma";
            this.rbComma.UseVisualStyleBackColor = true;
            this.rbComma.CheckedChanged += new System.EventHandler(this.rbComma_CheckedChanged);
            // 
            // chkLimitRows
            // 
            this.chkLimitRows.AutoSize = true;
            this.chkLimitRows.Location = new System.Drawing.Point(15, 59);
            this.chkLimitRows.Name = "chkLimitRows";
            this.chkLimitRows.Size = new System.Drawing.Size(165, 17);
            this.chkLimitRows.TabIndex = 29;
            this.chkLimitRows.Text = "Limit number of lines to export";
            this.chkLimitRows.UseVisualStyleBackColor = true;
            this.chkLimitRows.CheckedChanged += new System.EventHandler(this.chkLimitRows_CheckedChanged);
            // 
            // rbEncloseOther
            // 
            this.rbEncloseOther.AutoSize = true;
            this.rbEncloseOther.Location = new System.Drawing.Point(21, 89);
            this.rbEncloseOther.Name = "rbEncloseOther";
            this.rbEncloseOther.Size = new System.Drawing.Size(54, 17);
            this.rbEncloseOther.TabIndex = 0;
            this.rbEncloseOther.Text = "Other:";
            this.rbEncloseOther.UseVisualStyleBackColor = true;
            this.rbEncloseOther.CheckedChanged += new System.EventHandler(this.rbEncloseOther_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Please choose how to export your data.";
            // 
            // rbSingleQuotes
            // 
            this.rbSingleQuotes.AutoSize = true;
            this.rbSingleQuotes.Location = new System.Drawing.Point(21, 66);
            this.rbSingleQuotes.Name = "rbSingleQuotes";
            this.rbSingleQuotes.Size = new System.Drawing.Size(89, 17);
            this.rbSingleQuotes.TabIndex = 0;
            this.rbSingleQuotes.Text = "Single quotes";
            this.rbSingleQuotes.UseVisualStyleBackColor = true;
            this.rbSingleQuotes.CheckedChanged += new System.EventHandler(this.rbSingleQuotes_CheckedChanged);
            // 
            // txtLimitRows
            // 
            this.txtLimitRows.Enabled = false;
            this.txtLimitRows.Location = new System.Drawing.Point(193, 56);
            this.txtLimitRows.Name = "txtLimitRows";
            this.txtLimitRows.Size = new System.Drawing.Size(72, 20);
            this.txtLimitRows.TabIndex = 30;
            this.txtLimitRows.Text = "10";
            this.txtLimitRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimitRows.TextChanged += new System.EventHandler(this.txtLimitRows_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(504, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(585, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEncloseOther);
            this.groupBox1.Controls.Add(this.rbEncloseOther);
            this.groupBox1.Controls.Add(this.rbSingleQuotes);
            this.groupBox1.Controls.Add(this.rbDoubleQuotes);
            this.groupBox1.Controls.Add(this.rbNothing);
            this.groupBox1.Location = new System.Drawing.Point(341, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 119);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enclose field data with";
            // 
            // txtEncloseOther
            // 
            this.txtEncloseOther.Location = new System.Drawing.Point(81, 89);
            this.txtEncloseOther.Name = "txtEncloseOther";
            this.txtEncloseOther.Size = new System.Drawing.Size(35, 20);
            this.txtEncloseOther.TabIndex = 6;
            this.txtEncloseOther.TextChanged += new System.EventHandler(this.txtEncloseOther_TextChanged);
            // 
            // rbDoubleQuotes
            // 
            this.rbDoubleQuotes.AutoSize = true;
            this.rbDoubleQuotes.Checked = true;
            this.rbDoubleQuotes.Location = new System.Drawing.Point(21, 43);
            this.rbDoubleQuotes.Name = "rbDoubleQuotes";
            this.rbDoubleQuotes.Size = new System.Drawing.Size(94, 17);
            this.rbDoubleQuotes.TabIndex = 0;
            this.rbDoubleQuotes.TabStop = true;
            this.rbDoubleQuotes.Text = "Double quotes";
            this.rbDoubleQuotes.UseVisualStyleBackColor = true;
            this.rbDoubleQuotes.CheckedChanged += new System.EventHandler(this.rbDoubleQuotes_CheckedChanged);
            // 
            // rbNothing
            // 
            this.rbNothing.AutoSize = true;
            this.rbNothing.Location = new System.Drawing.Point(21, 20);
            this.rbNothing.Name = "rbNothing";
            this.rbNothing.Size = new System.Drawing.Size(62, 17);
            this.rbNothing.TabIndex = 0;
            this.rbNothing.Text = "Nothing";
            this.rbNothing.UseVisualStyleBackColor = true;
            this.rbNothing.CheckedChanged += new System.EventHandler(this.rbNothing_CheckedChanged);
            // 
            // chkExportHeader
            // 
            this.chkExportHeader.AutoSize = true;
            this.chkExportHeader.Checked = true;
            this.chkExportHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportHeader.Location = new System.Drawing.Point(15, 36);
            this.chkExportHeader.Name = "chkExportHeader";
            this.chkExportHeader.Size = new System.Drawing.Size(111, 17);
            this.chkExportHeader.TabIndex = 25;
            this.chkExportHeader.Text = "Export header line";
            this.chkExportHeader.UseVisualStyleBackColor = true;
            this.chkExportHeader.CheckedChanged += new System.EventHandler(this.chkExportHeader_CheckedChanged);
            // 
            // gbRowDelimiter
            // 
            this.gbRowDelimiter.Controls.Add(this.rbFormFeed);
            this.gbRowDelimiter.Controls.Add(this.txtRowOther);
            this.gbRowDelimiter.Controls.Add(this.rbRowOther);
            this.gbRowDelimiter.Controls.Add(this.rbLineFeedOnly);
            this.gbRowDelimiter.Controls.Add(this.rbCRLF);
            this.gbRowDelimiter.Location = new System.Drawing.Point(503, 83);
            this.gbRowDelimiter.Name = "gbRowDelimiter";
            this.gbRowDelimiter.Size = new System.Drawing.Size(157, 119);
            this.gbRowDelimiter.TabIndex = 27;
            this.gbRowDelimiter.TabStop = false;
            this.gbRowDelimiter.Text = "Row delimiter";
            // 
            // rbFormFeed
            // 
            this.rbFormFeed.AutoSize = true;
            this.rbFormFeed.Location = new System.Drawing.Point(21, 66);
            this.rbFormFeed.Name = "rbFormFeed";
            this.rbFormFeed.Size = new System.Drawing.Size(93, 17);
            this.rbFormFeed.TabIndex = 4;
            this.rbFormFeed.Text = "Form feed (FF)";
            this.rbFormFeed.UseVisualStyleBackColor = true;
            this.rbFormFeed.CheckedChanged += new System.EventHandler(this.rbFormFeed_CheckedChanged);
            // 
            // txtRowOther
            // 
            this.txtRowOther.Location = new System.Drawing.Point(81, 89);
            this.txtRowOther.Name = "txtRowOther";
            this.txtRowOther.Size = new System.Drawing.Size(35, 20);
            this.txtRowOther.TabIndex = 3;
            this.txtRowOther.TextChanged += new System.EventHandler(this.txtRowOther_TextChanged);
            // 
            // rbRowOther
            // 
            this.rbRowOther.AutoSize = true;
            this.rbRowOther.Location = new System.Drawing.Point(21, 89);
            this.rbRowOther.Name = "rbRowOther";
            this.rbRowOther.Size = new System.Drawing.Size(54, 17);
            this.rbRowOther.TabIndex = 2;
            this.rbRowOther.Text = "Other:";
            this.rbRowOther.UseVisualStyleBackColor = true;
            this.rbRowOther.CheckedChanged += new System.EventHandler(this.rbRowOther_CheckedChanged);
            // 
            // rbLineFeedOnly
            // 
            this.rbLineFeedOnly.AutoSize = true;
            this.rbLineFeedOnly.Location = new System.Drawing.Point(21, 42);
            this.rbLineFeedOnly.Name = "rbLineFeedOnly";
            this.rbLineFeedOnly.Size = new System.Drawing.Size(125, 17);
            this.rbLineFeedOnly.TabIndex = 1;
            this.rbLineFeedOnly.Text = "Line feed (LF) (UNIX)";
            this.rbLineFeedOnly.UseVisualStyleBackColor = true;
            this.rbLineFeedOnly.CheckedChanged += new System.EventHandler(this.rbLineFeedOnly_CheckedChanged);
            // 
            // rbCRLF
            // 
            this.rbCRLF.AutoSize = true;
            this.rbCRLF.Checked = true;
            this.rbCRLF.Location = new System.Drawing.Point(21, 19);
            this.rbCRLF.Name = "rbCRLF";
            this.rbCRLF.Size = new System.Drawing.Size(102, 17);
            this.rbCRLF.TabIndex = 0;
            this.rbCRLF.TabStop = true;
            this.rbCRLF.Text = "CRLF (Notepad)";
            this.rbCRLF.UseVisualStyleBackColor = true;
            this.rbCRLF.CheckedChanged += new System.EventHandler(this.rbCRLF_CheckedChanged);
            // 
            // gbFieldDelimiter
            // 
            this.gbFieldDelimiter.Controls.Add(this.rbPipe);
            this.gbFieldDelimiter.Controls.Add(this.txtFieldOther);
            this.gbFieldDelimiter.Controls.Add(this.rbFieldOther);
            this.gbFieldDelimiter.Controls.Add(this.rbTab);
            this.gbFieldDelimiter.Controls.Add(this.rbSpace);
            this.gbFieldDelimiter.Controls.Add(this.rbSemicolon);
            this.gbFieldDelimiter.Controls.Add(this.rbComma);
            this.gbFieldDelimiter.Location = new System.Drawing.Point(15, 83);
            this.gbFieldDelimiter.Name = "gbFieldDelimiter";
            this.gbFieldDelimiter.Size = new System.Drawing.Size(157, 169);
            this.gbFieldDelimiter.TabIndex = 23;
            this.gbFieldDelimiter.TabStop = false;
            this.gbFieldDelimiter.Text = "Field delimiter";
            // 
            // rbPipe
            // 
            this.rbPipe.AutoSize = true;
            this.rbPipe.Location = new System.Drawing.Point(21, 114);
            this.rbPipe.Name = "rbPipe";
            this.rbPipe.Size = new System.Drawing.Size(46, 17);
            this.rbPipe.TabIndex = 6;
            this.rbPipe.Text = "Pipe";
            this.rbPipe.UseVisualStyleBackColor = true;
            this.rbPipe.CheckedChanged += new System.EventHandler(this.rbPipe_CheckedChanged);
            // 
            // txtFieldOther
            // 
            this.txtFieldOther.Location = new System.Drawing.Point(89, 138);
            this.txtFieldOther.Name = "txtFieldOther";
            this.txtFieldOther.Size = new System.Drawing.Size(35, 20);
            this.txtFieldOther.TabIndex = 5;
            this.txtFieldOther.TextChanged += new System.EventHandler(this.txtFieldOther_TextChanged);
            // 
            // bgFileNameSuffix
            // 
            this.bgFileNameSuffix.Controls.Add(this.txtSuffixOther);
            this.bgFileNameSuffix.Controls.Add(this.rbSuffixOther);
            this.bgFileNameSuffix.Controls.Add(this.rbSuffixTXT);
            this.bgFileNameSuffix.Controls.Add(this.rbSuffixCSV);
            this.bgFileNameSuffix.Location = new System.Drawing.Point(437, 23);
            this.bgFileNameSuffix.Name = "bgFileNameSuffix";
            this.bgFileNameSuffix.Size = new System.Drawing.Size(223, 53);
            this.bgFileNameSuffix.TabIndex = 32;
            this.bgFileNameSuffix.TabStop = false;
            this.bgFileNameSuffix.Text = "FileName Suffix";
            // 
            // txtSuffixOther
            // 
            this.txtSuffixOther.Location = new System.Drawing.Point(171, 21);
            this.txtSuffixOther.Name = "txtSuffixOther";
            this.txtSuffixOther.Size = new System.Drawing.Size(35, 20);
            this.txtSuffixOther.TabIndex = 3;
            this.txtSuffixOther.TextChanged += new System.EventHandler(this.txtSuffixOther_TextChanged);
            // 
            // rbSuffixOther
            // 
            this.rbSuffixOther.AutoSize = true;
            this.rbSuffixOther.Location = new System.Drawing.Point(111, 22);
            this.rbSuffixOther.Name = "rbSuffixOther";
            this.rbSuffixOther.Size = new System.Drawing.Size(54, 17);
            this.rbSuffixOther.TabIndex = 2;
            this.rbSuffixOther.Text = "Other:";
            this.rbSuffixOther.UseVisualStyleBackColor = true;
            this.rbSuffixOther.CheckedChanged += new System.EventHandler(this.rbSuffixOther_CheckedChanged);
            // 
            // rbSuffixTXT
            // 
            this.rbSuffixTXT.AutoSize = true;
            this.rbSuffixTXT.Location = new System.Drawing.Point(69, 22);
            this.rbSuffixTXT.Name = "rbSuffixTXT";
            this.rbSuffixTXT.Size = new System.Drawing.Size(36, 17);
            this.rbSuffixTXT.TabIndex = 1;
            this.rbSuffixTXT.Text = "txt";
            this.rbSuffixTXT.UseVisualStyleBackColor = true;
            this.rbSuffixTXT.CheckedChanged += new System.EventHandler(this.rbSuffixTXT_CheckedChanged);
            // 
            // rbSuffixCSV
            // 
            this.rbSuffixCSV.AutoSize = true;
            this.rbSuffixCSV.Checked = true;
            this.rbSuffixCSV.Location = new System.Drawing.Point(21, 22);
            this.rbSuffixCSV.Name = "rbSuffixCSV";
            this.rbSuffixCSV.Size = new System.Drawing.Size(42, 17);
            this.rbSuffixCSV.TabIndex = 0;
            this.rbSuffixCSV.TabStop = true;
            this.rbSuffixCSV.Text = "csv";
            this.rbSuffixCSV.UseVisualStyleBackColor = true;
            this.rbSuffixCSV.CheckedChanged += new System.EventHandler(this.rbSuffixCSV_CheckedChanged);
            // 
            // frmCSVExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 263);
            this.Controls.Add(this.bgFileNameSuffix);
            this.Controls.Add(this.gbDelimiterReplacement);
            this.Controls.Add(this.chkLimitRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLimitRows);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkExportHeader);
            this.Controls.Add(this.gbRowDelimiter);
            this.Controls.Add(this.gbFieldDelimiter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCSVExportOptions";
            this.Text = "Export Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCSVExportOptions_FormClosing);
            this.Load += new System.EventHandler(this.frmCSVExportOptions_Load);
            this.gbDelimiterReplacement.ResumeLayout(false);
            this.gbDelimiterReplacement.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRowDelimiter.ResumeLayout(false);
            this.gbRowDelimiter.PerformLayout();
            this.gbFieldDelimiter.ResumeLayout(false);
            this.gbFieldDelimiter.PerformLayout();
            this.bgFileNameSuffix.ResumeLayout(false);
            this.bgFileNameSuffix.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbTab;
        private System.Windows.Forms.GroupBox gbDelimiterReplacement;
        private System.Windows.Forms.RadioButton rbDRNothing;
        private System.Windows.Forms.TextBox txtDelimiterOther;
        private System.Windows.Forms.RadioButton rbDROther;
        private System.Windows.Forms.RadioButton rbDRSpace;
        private System.Windows.Forms.RadioButton rbDRUnderscore;
        private System.Windows.Forms.RadioButton rbFieldOther;
        private System.Windows.Forms.RadioButton rbSpace;
        private System.Windows.Forms.RadioButton rbSemicolon;
        private System.Windows.Forms.RadioButton rbComma;
        private System.Windows.Forms.CheckBox chkLimitRows;
        private System.Windows.Forms.RadioButton rbEncloseOther;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbSingleQuotes;
        private System.Windows.Forms.TextBox txtLimitRows;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEncloseOther;
        private System.Windows.Forms.RadioButton rbDoubleQuotes;
        private System.Windows.Forms.RadioButton rbNothing;
        private System.Windows.Forms.CheckBox chkExportHeader;
        private System.Windows.Forms.GroupBox gbRowDelimiter;
        private System.Windows.Forms.RadioButton rbFormFeed;
        private System.Windows.Forms.TextBox txtRowOther;
        private System.Windows.Forms.RadioButton rbRowOther;
        private System.Windows.Forms.RadioButton rbLineFeedOnly;
        private System.Windows.Forms.RadioButton rbCRLF;
        private System.Windows.Forms.GroupBox gbFieldDelimiter;
        private System.Windows.Forms.RadioButton rbPipe;
        private System.Windows.Forms.TextBox txtFieldOther;
        private System.Windows.Forms.RadioButton rbDRDontReplace;
        private System.Windows.Forms.GroupBox bgFileNameSuffix;
        private System.Windows.Forms.TextBox txtSuffixOther;
        private System.Windows.Forms.RadioButton rbSuffixOther;
        private System.Windows.Forms.RadioButton rbSuffixTXT;
        private System.Windows.Forms.RadioButton rbSuffixCSV;
    }
}