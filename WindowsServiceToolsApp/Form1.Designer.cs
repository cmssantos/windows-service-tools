namespace WindowsServiceToolsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtExePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtExePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // txtExePath
            //
            this.txtExePath.Location = new System.Drawing.Point(12, 12);
            this.txtExePath.Name = "txtExePath";
            this.txtExePath.PlaceholderText = "Service Executable Path";
            this.txtExePath.Size = new System.Drawing.Size(400, 23);
            this.txtExePath.TabIndex = 0;
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(418, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            //
            // txtServiceName
            //
            this.txtServiceName.Location = new System.Drawing.Point(12, 41);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.PlaceholderText = "Service Name";
            this.txtServiceName.Size = new System.Drawing.Size(400, 23);
            this.txtServiceName.TabIndex = 2;
            //
            // btnInstall
            //
            this.btnInstall.Location = new System.Drawing.Point(12, 70);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(75, 23);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
            //
            // btnUninstall
            //
            this.btnUninstall.Location = new System.Drawing.Point(93, 70);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 4;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            //
            // btnClearLog
            //
            this.btnClearLog.Location = new System.Drawing.Point(174, 70);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            //
            // txtLog
            //
            this.txtLog.Location = new System.Drawing.Point(12, 99);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(481, 200);
            this.txtLog.TabIndex = 6;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 311);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.txtServiceName);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtExePath);
            this.Name = "Form1";
            this.Text = "Windows Service Tools";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
