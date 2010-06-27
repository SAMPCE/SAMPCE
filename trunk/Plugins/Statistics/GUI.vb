Imports PluginManager
Imports System.IO

Public Class GUI
    Dim ParentFunctions As IPluginFunctions
    Public Sub New(ByVal prt As IPluginFunctions)
        InitializeComponent()
        ParentFunctions = prt
    End Sub

    Private Sub GUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Statistics for " + Path.GetFileName(ParentFunctions.CurrentDocFilePath())
        ShowStats()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        ShowStats()
    End Sub

    Public Sub ShowStats()
        Dim temp As Integer
        temp = ParentFunctions.GetInstancesOfFunction("CreateObject")
        lblGoa.Text = temp.ToString() + "/254"
        If (temp / 254 > 1) Then
            lblGoa.ForeColor = Drawing.Color.Red
        Else
            lblGoa.ForeColor = Drawing.Color.Green
        End If

        temp = ParentFunctions.GetInstancesOfFunction("CreatePlayerObject")
        lblPOC.Text = temp.ToString() + "/254"
        If (temp / 254 > 1) Then
            lblPOC.ForeColor = Drawing.Color.Red
        Else
            lblPOC.ForeColor = Drawing.Color.Green
        End If

        temp = ParentFunctions.GetInstancesOfFunction("CreateVehicle")
        temp += ParentFunctions.GetInstancesOfFunction("AddStaticVehicle")
        temp += ParentFunctions.GetInstancesOfFunction("AddStaticVehicleEx")
        lblVC.Text = temp.ToString() + "/2000"
        If (temp / 2000 > 1) Then
            lblVC.ForeColor = Drawing.Color.Red
        Else
            lblVC.ForeColor = Drawing.Color.Green
        End If
    End Sub
End Class