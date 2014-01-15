////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Daniel Du 2014 - ADN/Developer Technical Services
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VaultPluginWizard
{
  

  public partial class SdkLocationForm : Form
  {

    const string CONFIG_SDK_PATH = ".//Autodesk/Wizards/VaultPlugin/SDKPath";
    const string CONFIG_WSE3_PATH = ".//Autodesk/Wizards/VaultPlugin/Wse3Path";
    const string  CONFIG_EXPLORER_PATH = ".//Autodesk/Wizards/VaultPlugin/ExplorerPath";

    const string DEFAULT_SDK_PATH = @"C:\Program Files (x86)\Autodesk\Autodesk Vault 2014 SDK";
    const string DEFAULT_WSE3_PATH = @"C:\Program Files (x86)\Microsoft WSE\v3.0";
    const string DEFAULT_EXPLORER_PATH = @"C:\Program Files\Autodesk\Vault Professional 2014\Explorer\Connectivity.VaultPro.exe";

    
    //private string vaultInterfaceName;
    private string sdkPath;

    private XmlConfigurator.XmlConfig mConfig = null;

    public string SdkPath
    {
      get { return sdkPath; }
      set { sdkPath = value; }
    }
    private string wsePath;

    public string WsePath
    {
      get { return wsePath; }
      set { wsePath = value; }
    }

    private string explorerExecutivePath;

    public string ExplorerExecutivePath
    {
      get { return explorerExecutivePath; }
      set { explorerExecutivePath = value; }
    }


    public SdkLocationForm()
    {
      InitializeComponent();

      //- Read path from last time
      mConfig = new XmlConfigurator.XmlConfig(VaultPluginWizard.AddInCompany, VaultPluginWizard.AddInProductName, VaultPluginWizard.AddInBaseConfigName);

      if (mConfig.ValueAt(CONFIG_SDK_PATH) == null || mConfig.ValueAt(CONFIG_SDK_PATH).ToString() == "XmlConfigurator.XmlConfigElt")
      {
          this.sdkPath = DEFAULT_SDK_PATH;
          mConfig.SetValueAt(CONFIG_SDK_PATH, DEFAULT_SDK_PATH);
          mConfig.Save();
      }
      else
      {
          this.sdkPath = mConfig.ValueAt(CONFIG_SDK_PATH);
      }

      if (mConfig.ValueAt(CONFIG_WSE3_PATH) == null || mConfig.ValueAt(CONFIG_WSE3_PATH).ToString() == "XmlConfigurator.XmlConfigElt")
      {
          this.wsePath = DEFAULT_WSE3_PATH;
          mConfig.SetValueAt(CONFIG_WSE3_PATH, DEFAULT_WSE3_PATH);
          mConfig.Save();
      }
      else
      {
          this.wsePath = mConfig.ValueAt(CONFIG_WSE3_PATH);
      }

      if (mConfig.ValueAt(CONFIG_EXPLORER_PATH) == null || mConfig.ValueAt(CONFIG_EXPLORER_PATH).ToString() == "XmlConfigurator.XmlConfigElt")
      {
          this.explorerExecutivePath = DEFAULT_EXPLORER_PATH;
          mConfig.SetValueAt(CONFIG_EXPLORER_PATH, DEFAULT_EXPLORER_PATH);
          mConfig.Save();
      }
      else
      {
          this.explorerExecutivePath = mConfig.ValueAt(CONFIG_EXPLORER_PATH);
      }
   

      this.txtSDKPath.Text = this.sdkPath;
      this.txtWSE3Path.Text = this.wsePath;
      this.txtExplorerPath.Text = this.explorerExecutivePath;

        //default is explorer plugin
      this.vaultInterfaceName = "IExplorerExtension";
      this.extensionAssemblyFullName = "Autodesk.Connectivity.Explorer.Extensibility.IExplorerExtension, Autodesk.Connectivity.Explorer.Extensibility, Version=18.0.0.0, Culture=neutral, PublicKeyToken=aa20f34aedd220e1";

    }

    private string vaultInterfaceName;

    public string VaultInterfaceName
    {
        get { return vaultInterfaceName; }
        set { vaultInterfaceName = value; }
    }

    private string extensionAssemblyFullName;

    public string ExtensionAssemblyFullName
    {
        get { return extensionAssemblyFullName; }
        set { extensionAssemblyFullName = value; }
    }



    private void rbExplorerPlugin_CheckedChanged(object sender, EventArgs e)
    {
        if (rbExplorerPlugin.Checked)
        {
            this.vaultInterfaceName = "IExplorerExtension";
            this.extensionAssemblyFullName = "Autodesk.Connectivity.Explorer.Extensibility.IExplorerExtension, Autodesk.Connectivity.Explorer.Extensibility, Version=18.0.0.0, Culture=neutral, PublicKeyToken=aa20f34aedd220e1";
        }
        
    }

    private void txtSDKPath_TextChanged(object sender, EventArgs e)
    {
      string path = txtSDKPath.Text.Trim();

      if (SdkPathIsValid(path))
      {
        this.sdkPath = path;
      }

      mConfig.SetValueAt(CONFIG_SDK_PATH, path);
      mConfig.Save();

    }

    private bool SdkPathIsValid(string sdkPath)
    {
      //TODO: Do more validat, i.e. check if containes vault dlls 
      if (sdkPath.Trim() != string.Empty && Directory.Exists(sdkPath))
      {
        return true;
      }
      return false;
    }

    private void txtWSE3Path_TextChanged(object sender, EventArgs e)
    {
      string path = txtSDKPath.Text.Trim();

      if (WsePathIsValid(path))
      {
        this.wsePath = path;
      }

      mConfig.SetValueAt(CONFIG_WSE3_PATH, path);
      mConfig.Save();
    }

    private bool WsePathIsValid(string path)
    {
      //TODO: Do more validat, i.e. check if containes Microsoft.Web.Services3.dll
      if (path.Trim() != string.Empty
          && Directory.Exists(path) 
          && File.Exists(path + @"\Microsoft.Web.Services3.dll"))
      {
        
        return true;
      }
      return false;
    }

    private void txtExplorerPath_TextChanged(object sender, EventArgs e)
    {
    string explorerExecutive = txtExplorerPath.Text.Trim();
      if( txtExplorerPath.Text.Trim() != string.Empty
        &&  File.Exists(explorerExecutive))
      {
          this.explorerExecutivePath = explorerExecutive;
      }

      mConfig.SetValueAt(CONFIG_EXPLORER_PATH, explorerExecutive);
      mConfig.Save();
    }

    private void btnFindSdk_Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        string path = this.folderBrowserDialog.SelectedPath;
        this.txtSDKPath.Text = path;
        //- Save path for next time
        mConfig.SetValueAt(CONFIG_SDK_PATH, path);
        mConfig.Save();

      }
    }

    private void btnFindWse3_Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        string path = this.folderBrowserDialog.SelectedPath;
        this.txtWSE3Path.Text = path;

        if (!WsePathIsValid(path))
        {
          MessageBox.Show("Please select a folder which contains Microsoft.Web.Services3.dll.");
          return;
        }
        //- Save path for next time
        mConfig.SetValueAt(CONFIG_WSE3_PATH, path);
        mConfig.Save();

      }
    }

    private void btnFindExplorer_Click(object sender, EventArgs e)
    {
      if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        string path = this.openFileDialog1.FileName;
        this.txtExplorerPath.Text = path;

        //- Save path for next time
        mConfig.SetValueAt(CONFIG_EXPLORER_PATH, path);
        mConfig.Save();

      }
    }

    private void rbCustomJob_CheckedChanged(object sender, EventArgs e)
    {
        if (rbCustomJob.Checked)
        {
            this.vaultInterfaceName = "IJobHandler";
            this.extensionAssemblyFullName = "Autodesk.Connectivity.JobProcessor.Extensibility.IJobHandler, Autodesk.Connectivity.JobProcessor.Extensibility, Version=18.0.0.0, Culture=neutral, PublicKeyToken=aa20f34aedd220e1";
        }
    }

    private void rbEventhandler_CheckedChanged(object sender, EventArgs e)
    {
        if (this.rbEventhandler.Checked)
        {
            this.vaultInterfaceName = "IWebServiceExtension";
            this.extensionAssemblyFullName = "Autodesk.Connectivity.WebServices.IWebServiceExtension, Autodesk.Connectivity.WebServices, Version=18.0.0.0, Culture=neutral, PublicKeyToken=aa20f34aedd220e1";
        }
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
   
        AboutForm aboutFrom = new AboutForm();

        aboutFrom.ShowDialog();
        aboutFrom.Dispose();
    }

    private void SdkLocationForm_Load(object sender, EventArgs e)
    {

    }
  }
}
