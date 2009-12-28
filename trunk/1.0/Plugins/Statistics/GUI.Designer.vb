<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim cbxObject As System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblGoa = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblPOC = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblVC = New System.Windows.Forms.Label
        Me.gbAdvice = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbxVehicle = New System.Windows.Forms.CheckBox
        cbxObject = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.gbAdvice.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblVC)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblPOC)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblGoa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 95)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Location = New System.Drawing.Point(12, 185)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(268, 23)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh Statistics"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(159, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Max global objects created:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGoa
        '
        Me.lblGoa.AutoSize = True
        Me.lblGoa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoa.Location = New System.Drawing.Point(171, 16)
        Me.lblGoa.Name = "lblGoa"
        Me.lblGoa.Size = New System.Drawing.Size(91, 25)
        Me.lblGoa.TabIndex = 1
        Me.lblGoa.Text = "254/254"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Max player objects created:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPOC
        '
        Me.lblPOC.AutoSize = True
        Me.lblPOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPOC.Location = New System.Drawing.Point(171, 41)
        Me.lblPOC.Name = "lblPOC"
        Me.lblPOC.Size = New System.Drawing.Size(91, 25)
        Me.lblPOC.TabIndex = 3
        Me.lblPOC.Text = "254/254"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Max vehicles created:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVC
        '
        Me.lblVC.AutoSize = True
        Me.lblVC.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVC.Location = New System.Drawing.Point(147, 66)
        Me.lblVC.Name = "lblVC"
        Me.lblVC.Size = New System.Drawing.Size(115, 25)
        Me.lblVC.TabIndex = 5
        Me.lblVC.Text = "2000/2000"
        '
        'gbAdvice
        '
        Me.gbAdvice.Controls.Add(Me.cbxVehicle)
        Me.gbAdvice.Controls.Add(cbxObject)
        Me.gbAdvice.Controls.Add(Me.Label4)
        Me.gbAdvice.Location = New System.Drawing.Point(12, 113)
        Me.gbAdvice.Name = "gbAdvice"
        Me.gbAdvice.Size = New System.Drawing.Size(268, 66)
        Me.gbAdvice.TabIndex = 2
        Me.gbAdvice.TabStop = False
        Me.gbAdvice.Text = "Advice"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "You may need:"
        '
        'cbxObject
        '
        cbxObject.AutoCheck = False
        cbxObject.AutoSize = True
        cbxObject.Location = New System.Drawing.Point(103, 15)
        cbxObject.Name = "cbxObject"
        cbxObject.Size = New System.Drawing.Size(113, 17)
        cbxObject.TabIndex = 1
        cbxObject.Text = "an object streamer"
        cbxObject.UseVisualStyleBackColor = True
        '
        'cbxVehicle
        '
        Me.cbxVehicle.AutoCheck = False
        Me.cbxVehicle.AutoSize = True
        Me.cbxVehicle.Location = New System.Drawing.Point(103, 38)
        Me.cbxVehicle.Name = "cbxVehicle"
        Me.cbxVehicle.Size = New System.Drawing.Size(112, 17)
        Me.cbxVehicle.TabIndex = 2
        Me.cbxVehicle.Text = "a vehicle streamer"
        Me.cbxVehicle.UseVisualStyleBackColor = True
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 220)
        Me.Controls.Add(Me.gbAdvice)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistics for"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbAdvice.ResumeLayout(False)
        Me.gbAdvice.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblGoa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPOC As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblVC As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbAdvice As System.Windows.Forms.GroupBox
    Friend WithEvents cbxVehicle As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
