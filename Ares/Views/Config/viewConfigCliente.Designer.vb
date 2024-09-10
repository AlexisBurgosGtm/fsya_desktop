<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewConfigCliente
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewConfigCliente))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.switchModoPos = New DevExpress.XtraEditors.ToggleSwitch()
        Me.txtUrl = New DevExpress.XtraEditors.TextEdit()
        Me.SwitchRecordatorios = New DevExpress.XtraEditors.ToggleSwitch()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSaveUrl = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.switchModoPos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUrl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchRecordatorios.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(78, 76)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "MODO POS: "
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(78, 128)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "URL INICIO:"
        '
        'switchModoPos
        '
        Me.switchModoPos.Location = New System.Drawing.Point(218, 71)
        Me.switchModoPos.Name = "switchModoPos"
        Me.switchModoPos.Properties.OffText = "NO"
        Me.switchModoPos.Properties.OnText = "SI"
        Me.switchModoPos.Size = New System.Drawing.Size(95, 24)
        Me.switchModoPos.TabIndex = 2
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(218, 125)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(307, 20)
        Me.txtUrl.TabIndex = 3
        '
        'SwitchRecordatorios
        '
        Me.SwitchRecordatorios.Location = New System.Drawing.Point(218, 178)
        Me.SwitchRecordatorios.Name = "SwitchRecordatorios"
        Me.SwitchRecordatorios.Properties.OffText = "NO"
        Me.SwitchRecordatorios.Properties.OnText = "SI"
        Me.SwitchRecordatorios.Size = New System.Drawing.Size(95, 24)
        Me.SwitchRecordatorios.TabIndex = 5
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(78, 183)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(131, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "RECORDATORIOS DE VOZ:"
        '
        'btnSaveUrl
        '
        Me.btnSaveUrl.Image = CType(resources.GetObject("btnSaveUrl.Image"), System.Drawing.Image)
        Me.btnSaveUrl.Location = New System.Drawing.Point(531, 123)
        Me.btnSaveUrl.Name = "btnSaveUrl"
        Me.btnSaveUrl.Size = New System.Drawing.Size(87, 23)
        Me.btnSaveUrl.TabIndex = 6
        Me.btnSaveUrl.Text = "Actualizar"
        '
        'viewConfigCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnSaveUrl)
        Me.Controls.Add(Me.SwitchRecordatorios)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.switchModoPos)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewConfigCliente"
        Me.Size = New System.Drawing.Size(693, 311)
        CType(Me.switchModoPos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUrl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchRecordatorios.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents switchModoPos As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents txtUrl As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SwitchRecordatorios As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSaveUrl As DevExpress.XtraEditors.SimpleButton
End Class
