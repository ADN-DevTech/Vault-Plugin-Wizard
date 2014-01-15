namespace VaultPluginWizard
{
  partial class SdkLocationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDKPath = new System.Windows.Forms.TextBox();
            this.txtWSE3Path = new System.Windows.Forms.TextBox();
            this.btnFindSdk = new System.Windows.Forms.Button();
            this.btnFindWse3 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbExplorerPlugin = new System.Windows.Forms.RadioButton();
            this.rbCustomJob = new System.Windows.Forms.RadioButton();
            this.rbEventhandler = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExplorerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindExplorer = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAbout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vault SDK Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "WSE 3 Path:";
            // 
            // txtSDKPath
            // 
            this.txtSDKPath.Location = new System.Drawing.Point(163, 11);
            this.txtSDKPath.Name = "txtSDKPath";
            this.txtSDKPath.Size = new System.Drawing.Size(399, 25);
            this.txtSDKPath.TabIndex = 2;
            this.txtSDKPath.Text = "C:\\Program Files (x86)\\Autodesk\\Autodesk Vault 2014 SDK";
            this.txtSDKPath.TextChanged += new System.EventHandler(this.txtSDKPath_TextChanged);
            // 
            // txtWSE3Path
            // 
            this.txtWSE3Path.Location = new System.Drawing.Point(163, 50);
            this.txtWSE3Path.Name = "txtWSE3Path";
            this.txtWSE3Path.Size = new System.Drawing.Size(399, 25);
            this.txtWSE3Path.TabIndex = 3;
            this.txtWSE3Path.Text = "C:\\Program Files (x86)\\Microsoft WSE\\v3.0";
            this.txtWSE3Path.TextChanged += new System.EventHandler(this.txtWSE3Path_TextChanged);
            // 
            // btnFindSdk
            // 
            this.btnFindSdk.Location = new System.Drawing.Point(569, 12);
            this.btnFindSdk.Name = "btnFindSdk";
            this.btnFindSdk.Size = new System.Drawing.Size(75, 23);
            this.btnFindSdk.TabIndex = 4;
            this.btnFindSdk.Text = "...";
            this.btnFindSdk.UseVisualStyleBackColor = true;
            this.btnFindSdk.Click += new System.EventHandler(this.btnFindSdk_Click);
            // 
            // btnFindWse3
            // 
            this.btnFindWse3.Location = new System.Drawing.Point(569, 49);
            this.btnFindWse3.Name = "btnFindWse3";
            this.btnFindWse3.Size = new System.Drawing.Size(75, 23);
            this.btnFindWse3.TabIndex = 5;
            this.btnFindWse3.Text = "...";
            this.btnFindWse3.UseVisualStyleBackColor = true;
            this.btnFindWse3.Click += new System.EventHandler(this.btnFindWse3_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(184, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbExplorerPlugin
            // 
            this.rbExplorerPlugin.AutoSize = true;
            this.rbExplorerPlugin.Checked = true;
            this.rbExplorerPlugin.Location = new System.Drawing.Point(6, 56);
            this.rbExplorerPlugin.Name = "rbExplorerPlugin";
            this.rbExplorerPlugin.Size = new System.Drawing.Size(148, 19);
            this.rbExplorerPlugin.TabIndex = 15;
            this.rbExplorerPlugin.TabStop = true;
            this.rbExplorerPlugin.Text = "Explorer Plugin";
            this.rbExplorerPlugin.UseVisualStyleBackColor = true;
            this.rbExplorerPlugin.CheckedChanged += new System.EventHandler(this.rbExplorerPlugin_CheckedChanged);
            // 
            // rbCustomJob
            // 
            this.rbCustomJob.AutoSize = true;
            this.rbCustomJob.Location = new System.Drawing.Point(222, 56);
            this.rbCustomJob.Name = "rbCustomJob";
            this.rbCustomJob.Size = new System.Drawing.Size(108, 19);
            this.rbCustomJob.TabIndex = 16;
            this.rbCustomJob.Text = "Custom Job";
            this.rbCustomJob.UseVisualStyleBackColor = true;
            this.rbCustomJob.CheckedChanged += new System.EventHandler(this.rbCustomJob_CheckedChanged);
            // 
            // rbEventhandler
            // 
            this.rbEventhandler.AutoSize = true;
            this.rbEventhandler.Location = new System.Drawing.Point(398, 56);
            this.rbEventhandler.Name = "rbEventhandler";
            this.rbEventhandler.Size = new System.Drawing.Size(132, 19);
            this.rbEventhandler.TabIndex = 17;
            this.rbEventhandler.Text = "Event Handler";
            this.rbEventhandler.UseVisualStyleBackColor = true;
            this.rbEventhandler.CheckedChanged += new System.EventHandler(this.rbEventhandler_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbExplorerPlugin);
            this.groupBox1.Controls.Add(this.rbEventhandler);
            this.groupBox1.Controls.Add(this.rbCustomJob);
            this.groupBox1.Location = new System.Drawing.Point(16, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 116);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plug-in Type";
            // 
            // txtExplorerPath
            // 
            this.txtExplorerPath.Location = new System.Drawing.Point(163, 86);
            this.txtExplorerPath.Name = "txtExplorerPath";
            this.txtExplorerPath.Size = new System.Drawing.Size(399, 25);
            this.txtExplorerPath.TabIndex = 19;
            this.txtExplorerPath.Text = "C:\\Program Files\\Autodesk\\Vault Professional 2014\\Explorer\\Connectivity.VaultPro." +
    "exe";
            this.txtExplorerPath.TextChanged += new System.EventHandler(this.txtExplorerPath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Vault Explorer Path:";
            // 
            // btnFindExplorer
            // 
            this.btnFindExplorer.Location = new System.Drawing.Point(569, 88);
            this.btnFindExplorer.Name = "btnFindExplorer";
            this.btnFindExplorer.Size = new System.Drawing.Size(75, 23);
            this.btnFindExplorer.TabIndex = 21;
            this.btnFindExplorer.Text = "...";
            this.btnFindExplorer.UseVisualStyleBackColor = true;
            this.btnFindExplorer.Click += new System.EventHandler(this.btnFindExplorer_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(404, 270);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 22;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // SdkLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 321);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnFindExplorer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExplorerPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnFindWse3);
            this.Controls.Add(this.btnFindSdk);
            this.Controls.Add(this.txtWSE3Path);
            this.Controls.Add(this.txtSDKPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SdkLocationForm";
            this.Text = "SdkLocationForm";
            this.Load += new System.EventHandler(this.SdkLocationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtSDKPath;
    private System.Windows.Forms.TextBox txtWSE3Path;
    private System.Windows.Forms.Button btnFindSdk;
    private System.Windows.Forms.Button btnFindWse3;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.RadioButton rbExplorerPlugin;
    private System.Windows.Forms.RadioButton rbCustomJob;
    private System.Windows.Forms.RadioButton rbEventhandler;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtExplorerPath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnFindExplorer;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button btnAbout;
  }
}