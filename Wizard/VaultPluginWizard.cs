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


using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using VSLangProj;

namespace VaultPluginWizard
{
    public class VaultPluginWizard : IWizard
    {

        public static string AddInCompany = "<see Assembly>";
        public static string AddInProductName = "<see Assembly>";
        public static string AddInVersion = "<see Assembly>";
        public const string AddInBaseConfigName = "Settings";

        private SdkLocationForm inputForm;
        private string interfaceName = string.Empty;
        private string referencePath = string.Empty;
        private string explorerExecutivePath = string.Empty;
        private string extensionAssemblyFullname = string.Empty;


        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {

        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
            string startArgs = string.Empty;

            project.Properties.Item("ReferencePath").Value = referencePath;
            //- Does not work on Express Editions, See AddReferencesOnExpress
            VSProject vsproject = project.Object as VSProject;
            //this.AddReferencesOnVS(vsproject);

            //If it is vault explorer, enable debugger
            //TODO: decouple the interface name here, at least using CONST
            if (interfaceName == "IExplorerExtension"
                && explorerExecutivePath != null
              && explorerExecutivePath.Trim() != string.Empty)
            {
                //- Debugger

                if (SetupDebuggerOnVS(vsproject, explorerExecutivePath, startArgs) == false)
                {
                    SetupDebuggerOnExpress(project, explorerExecutivePath, referencePath, startArgs);
                }
            }


        }

        private void SetupDebuggerOnExpress(EnvDTE.Project project, string explorerExecutive, string referencePath, string startArgs)
        {
            string name = project.FullName + ".user";
            string text =
                "<Project xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\n"
              + "<PropertyGroup>\n"
              + "<ReferencePath>" + referencePath + "</ReferencePath>\n"
              + "</PropertyGroup>\n"
              + "<PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\n"
              + "<StartProgram>" + explorerExecutive + "</StartProgram>\n"
              + "<StartAction>Program</StartAction>\n"
              + "<StartArguments>" + startArgs + "</StartArguments>\n"
              + "</PropertyGroup>\n"
              + "</Project>";
            System.IO.StreamWriter SW = new System.IO.StreamWriter(name);
            SW.Write(text);
            SW.Flush();
            SW.Close();
        }

        private bool SetupDebuggerOnVS(VSProject vsproject, string explorerExecutive, string startArgs)
        {
            bool ret = false;
            try
            {
                //Configuration config =vsproject.Project.ConfigurationManager.Item("Debug", "Any CPU");
                //ProjectConfigurationProperties pp =config.Properties as ProjectConfigurationProperties ;
                //pp.StartProgram = "acad.exe";
                //pp.StartWorkingDirectory = "";
                vsproject.Project.ConfigurationManager.ActiveConfiguration.Properties.Item("StartProgram").Value = explorerExecutive;
                vsproject.Project.ConfigurationManager.ActiveConfiguration.Properties.Item("StartAction").Value = 1; // "Program";
                vsproject.Project.ConfigurationManager.ActiveConfiguration.Properties.Item("StartArguments").Value = startArgs;
                ret = true;
            }
            catch
            {
                //MessageBox.Show("debug vs error");
            }
            return (ret);
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {

        }

        public void RunFinished()
        {

        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {

            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly(); // GetEntryAssembly()
            AddInCompany = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(ass, typeof(AssemblyCompanyAttribute), false)).Company;
            AssemblyTitleAttribute titleAttr = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute;
            AddInProductName = titleAttr.Title;
            AddInVersion = ass.GetName().Version.ToString();


            // Display a form to the user. The form collects 
            // input for the custom message.
            inputForm = new SdkLocationForm();
            inputForm.ShowDialog();

            if (inputForm.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                throw new WizardBackoutException();
            }

            interfaceName = inputForm.VaultInterfaceName;
            extensionAssemblyFullname = inputForm.ExtensionAssemblyFullName;

            // Add custom parameters.
            replacementsDictionary.Add("$interface$", interfaceName);
            replacementsDictionary.Add("$extensionAssemblyFullname$", extensionAssemblyFullname);
            replacementsDictionary.Add("$entensionid$", Guid.NewGuid().ToString());

            referencePath = inputForm.SdkPath + @"\bin";
            referencePath += ";" + inputForm.WsePath;

            explorerExecutivePath = inputForm.ExplorerExecutivePath;


        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
