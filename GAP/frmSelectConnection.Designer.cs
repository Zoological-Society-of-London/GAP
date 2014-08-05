namespace GAP
{
    partial class frmSelectConnection
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
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLiveDW = new System.Windows.Forms.Button();
            this.btnLocalDW = new System.Windows.Forms.Button();
            this.btnDevDW = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnLivePE = new System.Windows.Forms.Button();
            this.btnLocalPE = new System.Windows.Forms.Button();
            this.btnDevPE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(12, 31);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(530, 20);
            this.txtConnectionString.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter connection string:";
            // 
            // btnLiveDW
            // 
            this.btnLiveDW.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLiveDW.Location = new System.Drawing.Point(15, 58);
            this.btnLiveDW.Name = "btnLiveDW";
            this.btnLiveDW.Size = new System.Drawing.Size(116, 23);
            this.btnLiveDW.TabIndex = 2;
            this.btnLiveDW.Text = "Live (ZSL_46) DW";
            this.btnLiveDW.UseVisualStyleBackColor = false;
            this.btnLiveDW.Click += new System.EventHandler(this.btnLiveDW_Click);
            // 
            // btnLocalDW
            // 
            this.btnLocalDW.BackColor = System.Drawing.Color.PaleGreen;
            this.btnLocalDW.Location = new System.Drawing.Point(137, 58);
            this.btnLocalDW.Name = "btnLocalDW";
            this.btnLocalDW.Size = new System.Drawing.Size(116, 23);
            this.btnLocalDW.TabIndex = 3;
            this.btnLocalDW.Text = "Local DW";
            this.btnLocalDW.UseVisualStyleBackColor = false;
            this.btnLocalDW.Click += new System.EventHandler(this.btnLocalDW_Click);
            // 
            // btnDevDW
            // 
            this.btnDevDW.BackColor = System.Drawing.Color.Salmon;
            this.btnDevDW.Location = new System.Drawing.Point(259, 58);
            this.btnDevDW.Name = "btnDevDW";
            this.btnDevDW.Size = new System.Drawing.Size(116, 23);
            this.btnDevDW.TabIndex = 4;
            this.btnDevDW.Text = "Dev (ZSL_26) DW";
            this.btnDevDW.UseVisualStyleBackColor = false;
            this.btnDevDW.Click += new System.EventHandler(this.btnDevDW_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(467, 85);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(386, 85);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnLivePE
            // 
            this.btnLivePE.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLivePE.Location = new System.Drawing.Point(15, 87);
            this.btnLivePE.Name = "btnLivePE";
            this.btnLivePE.Size = new System.Drawing.Size(116, 23);
            this.btnLivePE.TabIndex = 7;
            this.btnLivePE.Text = "Live (ZSL_46) PE";
            this.btnLivePE.UseVisualStyleBackColor = false;
            this.btnLivePE.Click += new System.EventHandler(this.btnLivePE_Click);
            // 
            // btnLocalPE
            // 
            this.btnLocalPE.BackColor = System.Drawing.Color.PaleGreen;
            this.btnLocalPE.Location = new System.Drawing.Point(137, 87);
            this.btnLocalPE.Name = "btnLocalPE";
            this.btnLocalPE.Size = new System.Drawing.Size(116, 23);
            this.btnLocalPE.TabIndex = 8;
            this.btnLocalPE.Text = "Local PE";
            this.btnLocalPE.UseVisualStyleBackColor = false;
            this.btnLocalPE.Click += new System.EventHandler(this.btnLocalPE_Click);
            // 
            // btnDevPE
            // 
            this.btnDevPE.BackColor = System.Drawing.Color.Salmon;
            this.btnDevPE.Location = new System.Drawing.Point(259, 87);
            this.btnDevPE.Name = "btnDevPE";
            this.btnDevPE.Size = new System.Drawing.Size(116, 23);
            this.btnDevPE.TabIndex = 9;
            this.btnDevPE.Text = "Dev (ZSL_26) PE";
            this.btnDevPE.UseVisualStyleBackColor = false;
            this.btnDevPE.Click += new System.EventHandler(this.btnDevPE_Click);
            // 
            // frmSelectConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 120);
            this.Controls.Add(this.btnDevPE);
            this.Controls.Add(this.btnLocalPE);
            this.Controls.Add(this.btnLivePE);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDevDW);
            this.Controls.Add(this.btnLocalDW);
            this.Controls.Add(this.btnLiveDW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnectionString);
            this.Name = "frmSelectConnection";
            this.Text = "Select Connection";
            this.Load += new System.EventHandler(this.frmSelectConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLiveDW;
        private System.Windows.Forms.Button btnLocalDW;
        private System.Windows.Forms.Button btnDevDW;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnLivePE;
        private System.Windows.Forms.Button btnLocalPE;
        private System.Windows.Forms.Button btnDevPE;
    }
}