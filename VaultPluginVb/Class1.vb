
Imports Autodesk.Connectivity.Explorer.Extensibility
Imports Autodesk.Connectivity.Extensibility.Framework
Imports Autodesk.Connectivity.JobProcessor.Extensibility
Imports Autodesk.Connectivity.WebServices
Imports Autodesk.Connectivity.WebServicesTools
Imports VDF = Autodesk.DataManagement.Client.Framework

'There are  5 assembly attributes you need to have in your code:
'Items 1-3 are provided by Visual Studio in the AssemblyInfo file.  
'You just need to check that they have accurate data.  
'Items 4 and 5 need to be created by you.

'<Assembly: AssemblyCompany("Your Company")>
'<Assembly: AssemblyProduct("$safeprojectname$")>
'<Assembly: AssemblyDescription("Your assembly description")> 
'For Autodesk Vault 2014, ApiVersion is "6.0"
<Assembly: ApiVersion("6.0")> 
<Assembly: ExtensionId("$entensionid$")> 

Namespace $safeprojectname$

    'if you rename this class name, please make sure change accordingly in vaultplugin.vcet.config
    Public Class Class1 : Implements $interface$


        'TODO: Delete the unnecessory implementations

#Region "IExplorerExtension implementation"
        Public Function CommandSites() As IEnumerable(Of CommandSite) Implements IExplorerExtension.CommandSites

        End Function

        Public Function CustomEntityHandlers() As IEnumerable(Of CustomEntityHandler) Implements IExplorerExtension.CustomEntityHandlers

        End Function

        Public Function DetailTabs() As IEnumerable(Of DetailPaneTab) Implements IExplorerExtension.DetailTabs

        End Function

        Public Function HiddenCommands() As IEnumerable(Of String) Implements IExplorerExtension.HiddenCommands

        End Function

        Public Sub OnLogOff(application As IApplication) Implements IExplorerExtension.OnLogOff

        End Sub

        Public Sub OnLogOn(application As IApplication) Implements IExplorerExtension.OnLogOn

        End Sub

        Public Sub OnShutdown(application As IApplication) Implements IExplorerExtension.OnShutdown

        End Sub

        Public Sub OnStartup(application As IApplication) Implements IExplorerExtension.OnStartup

        End Sub

#End Region

#Region "IJobHandler implementation"

        Public Function CanProcess(jobType As String) As Boolean Implements IJobHandler.CanProcess

        End Function

        Public Function Execute(context As IJobProcessorServices, job As IJob) As JobOutcome Implements IJobHandler.Execute

        End Function

        Public Sub OnJobProcessorShutdown(context As IJobProcessorServices) Implements IJobHandler.OnJobProcessorShutdown

        End Sub

        Public Sub OnJobProcessorSleep(context As IJobProcessorServices) Implements IJobHandler.OnJobProcessorSleep

        End Sub

        Public Sub OnJobProcessorStartup(context As IJobProcessorServices) Implements IJobHandler.OnJobProcessorStartup

        End Sub

        Public Sub OnJobProcessorWake(context As IJobProcessorServices) Implements IJobHandler.OnJobProcessorWake

        End Sub
#End Region

#Region "IWebServiceExtension implementation"
        Public Sub OnLoad() Implements IWebServiceExtension.OnLoad

        End Sub
#End Region



    End Class
End Namespace
