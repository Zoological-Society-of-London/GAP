namespace GAP
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdministratorReports = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeGAPConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangeTargetDBConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsReports = new System.Windows.Forms.ToolStripButton();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportsMenu,
            this.mnuAdministratorReports});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // mnuReportsMenu
            // 
            this.mnuReportsMenu.Name = "mnuReportsMenu";
            this.mnuReportsMenu.Size = new System.Drawing.Size(190, 22);
            this.mnuReportsMenu.Text = "&Reports Menu";
            this.mnuReportsMenu.Click += new System.EventHandler(this.mnuReportsMenu_Click);
            // 
            // mnuAdministratorReports
            // 
            this.mnuAdministratorReports.Name = "mnuAdministratorReports";
            this.mnuAdministratorReports.Size = new System.Drawing.Size(190, 22);
            this.mnuAdministratorReports.Text = "Administrator Reports";
            this.mnuAdministratorReports.Click += new System.EventHandler(this.mnuAdministratorReports_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangeGAPConnection,
            this.mnuChangeTargetDBConnection});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "&Data";
            // 
            // mnuChangeGAPConnection
            // 
            this.mnuChangeGAPConnection.Name = "mnuChangeGAPConnection";
            this.mnuChangeGAPConnection.Size = new System.Drawing.Size(244, 22);
            this.mnuChangeGAPConnection.Text = "Change GAP Connection...";
            this.mnuChangeGAPConnection.Click += new System.EventHandler(this.mnuChangeGAPConnection_Click);
            // 
            // mnuChangeTargetDBConnection
            // 
            this.mnuChangeTargetDBConnection.Name = "mnuChangeTargetDBConnection";
            this.mnuChangeTargetDBConnection.Size = new System.Drawing.Size(244, 22);
            this.mnuChangeTargetDBConnection.Text = "Change Target DB Connection...";
            this.mnuChangeTargetDBConnection.Click += new System.EventHandler(this.mnuChangeTargetDBConnection_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dgv1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(605, 447);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(605, 508);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsReports});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(48, 39);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsReports
            // 
            this.tsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsReports.Image = global::GAP.Properties.Resources.STC_Reports1;
            this.tsReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReports.Name = "tsReports";
            this.tsReports.Size = new System.Drawing.Size(36, 36);
            this.tsReports.Text = "Reports Menu";
            this.tsReports.Click += new System.EventHandler(this.tsReports_Click);
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.Size = new System.Drawing.Size(605, 447);
            this.dgv1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 532);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Aid Processor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuReportsMenu;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeGAPConnection;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeTargetDBConnection;
        private System.Windows.Forms.ToolStripMenuItem mnuAdministratorReports;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsReports;
        private System.Windows.Forms.DataGridView dgv1;


    }
}

