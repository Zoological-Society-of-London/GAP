namespace GAP
{
    partial class frmViewData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewData));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDefaultExportFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAutoSizeColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsZoomText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowExecutedSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tssViewDataClose = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dgvViewData = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsExecuteScript = new System.Windows.Forms.ToolStripButton();
            this.tsSaveChanges = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOpenExportFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAutoSizeColumns = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExportData = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewData)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mnuDefaultExportFolder,
            this.toolStripMenuItem3,
            this.mnuAutoSizeColumns,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem4,
            this.tsZoomText,
            this.toolStripMenuItem5,
            this.mnuShowExecutedSQL,
            this.toolStripMenuItem6,
            this.tssViewDataClose});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Image = global::GAP.Properties.Resources.STC_Execute;
            this.executeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.executeToolStripMenuItem.Text = "&Execute Script";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::GAP.Properties.Resources.STC_Save;
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.saveToolStripMenuItem.Text = "&Save Changes";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuDefaultExportFolder
            // 
            this.mnuDefaultExportFolder.Image = global::GAP.Properties.Resources.STC_OpenDefaultFolder;
            this.mnuDefaultExportFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDefaultExportFolder.Name = "mnuDefaultExportFolder";
            this.mnuDefaultExportFolder.Size = new System.Drawing.Size(193, 38);
            this.mnuDefaultExportFolder.Text = "&Open Export Folder";
            this.mnuDefaultExportFolder.Click += new System.EventHandler(this.mnuDefaultExportFolder_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuAutoSizeColumns
            // 
            this.mnuAutoSizeColumns.Image = global::GAP.Properties.Resources.STC_AutoSizeColumns;
            this.mnuAutoSizeColumns.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuAutoSizeColumns.Name = "mnuAutoSizeColumns";
            this.mnuAutoSizeColumns.Size = new System.Drawing.Size(193, 38);
            this.mnuAutoSizeColumns.Text = "&Auto Size Columns";
            this.mnuAutoSizeColumns.Click += new System.EventHandler(this.mnuAutoSizeColumns_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::GAP.Properties.Resources.STC_Export;
            this.exportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.exportToolStripMenuItem.Text = "E&xport Data";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(190, 6);
            // 
            // tsZoomText
            // 
            this.tsZoomText.Name = "tsZoomText";
            this.tsZoomText.Size = new System.Drawing.Size(193, 38);
            this.tsZoomText.Text = "&Zoom Text";
            this.tsZoomText.Click += new System.EventHandler(this.tsZoomText_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuShowExecutedSQL
            // 
            this.mnuShowExecutedSQL.Name = "mnuShowExecutedSQL";
            this.mnuShowExecutedSQL.Size = new System.Drawing.Size(193, 38);
            this.mnuShowExecutedSQL.Text = "S&how Executed SQL";
            this.mnuShowExecutedSQL.Click += new System.EventHandler(this.mnuShowExecutedSQL_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(190, 6);
            // 
            // tssViewDataClose
            // 
            this.tssViewDataClose.Name = "tssViewDataClose";
            this.tssViewDataClose.Size = new System.Drawing.Size(193, 38);
            this.tssViewDataClose.Text = "&Close";
            this.tssViewDataClose.Click += new System.EventHandler(this.tssViewDataClose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssMessage
            // 
            this.tssMessage.Name = "tssMessage";
            this.tssMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgvViewData);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(696, 429);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(696, 468);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dgvViewData
            // 
            this.dgvViewData.AllowUserToAddRows = false;
            this.dgvViewData.AllowUserToDeleteRows = false;
            this.dgvViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViewData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvViewData.Location = new System.Drawing.Point(0, 0);
            this.dgvViewData.Name = "dgvViewData";
            this.dgvViewData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViewData.Size = new System.Drawing.Size(696, 429);
            this.dgvViewData.TabIndex = 4;
            this.dgvViewData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewData_CellContentClick);
            this.dgvViewData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewData_CellDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExecuteScript,
            this.tsSaveChanges,
            this.toolStripSeparator1,
            this.tsOpenExportFolder,
            this.toolStripSeparator2,
            this.tsAutoSizeColumns,
            this.toolStripSeparator3,
            this.tsExportData});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(210, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsExecuteScript
            // 
            this.tsExecuteScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExecuteScript.Image = global::GAP.Properties.Resources.STC_Execute;
            this.tsExecuteScript.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExecuteScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExecuteScript.Name = "tsExecuteScript";
            this.tsExecuteScript.Size = new System.Drawing.Size(36, 36);
            this.tsExecuteScript.Text = "Execute Script";
            this.tsExecuteScript.Click += new System.EventHandler(this.tsExecuteScript_Click);
            // 
            // tsSaveChanges
            // 
            this.tsSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSaveChanges.Image = global::GAP.Properties.Resources.STC_Save;
            this.tsSaveChanges.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveChanges.Name = "tsSaveChanges";
            this.tsSaveChanges.Size = new System.Drawing.Size(36, 36);
            this.tsSaveChanges.Text = "Save Changes";
            this.tsSaveChanges.Click += new System.EventHandler(this.tsSaveChanges_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsOpenExportFolder
            // 
            this.tsOpenExportFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpenExportFolder.Image = global::GAP.Properties.Resources.STC_OpenDefaultFolder;
            this.tsOpenExportFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOpenExportFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpenExportFolder.Name = "tsOpenExportFolder";
            this.tsOpenExportFolder.Size = new System.Drawing.Size(36, 36);
            this.tsOpenExportFolder.Text = "Open Export Folder";
            this.tsOpenExportFolder.Click += new System.EventHandler(this.tsOpenExportFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsAutoSizeColumns
            // 
            this.tsAutoSizeColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAutoSizeColumns.Image = global::GAP.Properties.Resources.STC_AutoSizeColumns;
            this.tsAutoSizeColumns.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAutoSizeColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAutoSizeColumns.Name = "tsAutoSizeColumns";
            this.tsAutoSizeColumns.Size = new System.Drawing.Size(36, 36);
            this.tsAutoSizeColumns.Text = "Auto Size Columns";
            this.tsAutoSizeColumns.Click += new System.EventHandler(this.tsAutoSizeColumns_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsExportData
            // 
            this.tsExportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExportData.Image = global::GAP.Properties.Resources.STC_Export;
            this.tsExportData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExportData.Name = "tsExportData";
            this.tsExportData.Size = new System.Drawing.Size(36, 36);
            this.tsExportData.Text = "Export Data";
            this.tsExportData.Click += new System.EventHandler(this.tsExportData_Click);
            // 
            // frmViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 514);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmViewData";
            this.Text = "frmViewData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewData_FormClosing);
            this.Load += new System.EventHandler(this.frmViewData_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewData)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssMessage;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDefaultExportFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView dgvViewData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsOpenExportFolder;
        private System.Windows.Forms.ToolStripButton tsExecuteScript;
        private System.Windows.Forms.ToolStripButton tsSaveChanges;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsExportData;
        private System.Windows.Forms.ToolStripButton tsAutoSizeColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoSizeColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tssViewDataClose;
        private System.Windows.Forms.ToolStripMenuItem tsZoomText;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuShowExecutedSQL;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    }
}