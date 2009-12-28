Imports PluginManager
Public Class Main : Implements IPlugin

    Dim CodeInterface As PluginManager.IPluginFunctions

    Public ReadOnly Property Author() As String Implements PluginManager.IPlugin.Author
        Get
            Return "Skaty"
        End Get
    End Property

    Public ReadOnly Property Desc() As String Implements PluginManager.IPlugin.Desc
        Get
            Return "This application shows useful statistics about the code"
        End Get
    End Property

    ' This is called when SAMPCE first starts
    Public Sub LoadPlugin() Implements PluginManager.IPlugin.LoadPlugin

    End Sub

    ' This is called when the main GUI interface is needed.
    Public Sub LoadPluginGUI(ByVal obj As Object, ByVal e As System.EventArgs) Implements PluginManager.IPlugin.LoadPluginGUI
        Dim gui As New GUI(CodeInterface)
        gui.Show()
    End Sub

    Public Function LoadPluginSettings() As System.Windows.Forms.UserControl Implements PluginManager.IPlugin.LoadPluginSettings
        Dim cfg As New Config()
        Return cfg
    End Function

    Public ReadOnly Property Name() As String Implements PluginManager.IPlugin.Name
        Get
            Return "Statistics"
        End Get
    End Property

    Public Property parent() As PluginManager.IPluginFunctions Implements PluginManager.IPlugin.parent
        Get
            Return CodeInterface
        End Get
        Set(ByVal value As PluginManager.IPluginFunctions)
            CodeInterface = value
        End Set
    End Property

    Public Sub UnloadPlugin() Implements PluginManager.IPlugin.UnloadPlugin

    End Sub

    Public ReadOnly Property Version() As String Implements PluginManager.IPlugin.Version
        Get
            Return "1.00"
        End Get
    End Property
End Class
