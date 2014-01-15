
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.Extensibility.Framework;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using VDF = Autodesk.DataManagement.Client.Framework;
using Autodesk.Connectivity.JobProcessor.Extensibility;


//There are  5 assembly attributes you need to have in your code:
//Items 1-3 are provided by Visual Studio in the AssemblyInfo file.  
//You just need to check that they have accurate data.  
//Items 4 and 5 need to be created by you.

//[assembly: AssemblyCompany("Your Company")]
//[assembly: AssemblyProduct("$safeprojectname$")]
//[assembly: AssemblyDescription("Your assembly description")]
//For Autodesk Vault 2014, ApiVersion is "6.0"
[assembly: ApiVersion("6.0")]
[assembly: ExtensionId("$entensionid$")]

namespace $safeprojectname$
{
    //if you rename this class name, please make sure change accordingly in vaultplugin.vcet.config
  public class Class1 : $interface$
    {

      //TODO: Delete the unnecessory implementations

#region IExplorerExtenion implemenation
      public IEnumerable<CommandSite> CommandSites()
      {
            // Create the Hello World command object.
            CommandItem helloWorldCmdItem = new CommandItem("HelloWorldCommand", "Hello World...") 
            { 
                // this command is active when a File is selected
                NavigationTypes = new SelectionTypeId[] { SelectionTypeId.File, SelectionTypeId.FileVersion }, 

                // this command is not active if there are multiple entities selected
                MultiSelectEnabled = false 
            };

            // The HelloWorldCommandHandler function is called when the custom command is executed.
            helloWorldCmdItem.Execute += HelloWorldCommandHandler;

            // Create a command site to hook the command to the Advanced toolbar
            CommandSite toolbarCmdSite = new CommandSite("HelloWorldCommand.Toolbar", "Hello World Menu") 
            { 
                Location = CommandSiteLocation.AdvancedToolbar, 
                DeployAsPulldownMenu = false 
            };
            toolbarCmdSite.AddCommand(helloWorldCmdItem);

            // Create another command site to hook the command to the right-click menu for Files.
            CommandSite fileContextCmdSite = new CommandSite("HelloWorldCommand.FileContextMenu", "Hello World Menu") 
            { 
                Location = CommandSiteLocation.FileContextMenu, 
                DeployAsPulldownMenu = false 
            };
            fileContextCmdSite.AddCommand(helloWorldCmdItem);

            // Now the custom command is available in 2 places.

            // Gather the sites in a List.
            List<CommandSite> sites = new List<CommandSite>();
            sites.Add(toolbarCmdSite);
            sites.Add(fileContextCmdSite);

            // Return the list of CommandSites.
            return sites;
      }

        /// <summary>
        /// This is the function that is called whenever the custom command is executed.
        /// </summary>
        /// <param name="s">The sender object.  Usually not used.</param>
        /// <param name="e">The event args.  Provides additional information about the environment.</param>
        void HelloWorldCommandHandler(object s, CommandItemEventArgs e)
        {
            try
            {
                VDF.Vault.Currency.Connections.Connection connection = e.Context.Application.Connection;

                // The Context part of the event args tells us information about what is selected.
                // Run some checks to make sure that the selection is valid.
                if (e.Context.CurrentSelectionSet.Count() == 0)
                    MessageBox.Show("Nothing is selected");
                else if (e.Context.CurrentSelectionSet.Count() > 1)
                    MessageBox.Show("This function does not support multiple selections");
                else
                {
                    // we only have one item selected, which is the expected behavior

                    ISelection selection = e.Context.CurrentSelectionSet.First();

                    // Look of the File object.  How we do this depends on what is selected.
                    File selectedFile = null;
                    if (selection.TypeId == SelectionTypeId.File)
                    {
                        // our ISelection.Id is really a File.MasterId
                        selectedFile = connection.WebServiceManager.DocumentService.GetLatestFileByMasterId(selection.Id);
                    }
                    else if (selection.TypeId == SelectionTypeId.FileVersion)
                    {
                        // our ISelection.Id is really a File.Id
                        selectedFile = connection.WebServiceManager.DocumentService.GetFileById(selection.Id);
                    }

                    if (selectedFile == null)
                    {
                        MessageBox.Show("Selection is not a file.");
                    }
                    else
                    {
                        // this is the message we hope to see
                        MessageBox.Show(String.Format("Hello World! The file size is: {0} bytes",
                                             selectedFile.FileSize));
                    }
                }
            }
            catch (Exception ex)
            {
                // If something goes wrong, we don't want the exception to bubble up to Vault Explorer.
                MessageBox.Show("Error: " + ex.Message);
            }
        }

      public IEnumerable<CustomEntityHandler> CustomEntityHandlers()
      {
        return null;
      }

      public IEnumerable<DetailPaneTab> DetailTabs()
      {
        return null;
      }

      public IEnumerable<string> HiddenCommands()
      {
        return null;
      }

      public void OnLogOff(IApplication application)
      {

      }

      public void OnLogOn(IApplication application)
      {

      }

      public void OnShutdown(IApplication application)
      {

      }

      public void OnStartup(IApplication application)
      {

      }
#endregion 

#region IJob interface implementation
              public bool CanProcess(string jobType)
        {
            throw new NotImplementedException();
        }

        public JobOutcome Execute(IJobProcessorServices context, IJob job)
        {
            throw new NotImplementedException();
        }

        public void OnJobProcessorShutdown(IJobProcessorServices context)
        {
            throw new NotImplementedException();
        }

        public void OnJobProcessorSleep(IJobProcessorServices context)
        {
            throw new NotImplementedException();
        }

        public void OnJobProcessorStartup(IJobProcessorServices context)
        {
            throw new NotImplementedException();
        }

        public void OnJobProcessorWake(IJobProcessorServices context)
        {
            throw new NotImplementedException();
        }
#endregion 

#region IWebServiceExtension implementation
        public void OnLoad()
        {
            throw new NotImplementedException();
        }
#endregion 
    }
}
