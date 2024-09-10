<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewClientesRptParametros
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
        Me.txtFechaInicial = New DevExpress.XtraEditors.DateEdit()
        Me.DateTimeChartRangeControlClient1 = New DevExpress.XtraEditors.DateTimeChartRangeControlClient()
        Me.txtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeChartRangeControlClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.EditValue = Nothing
        Me.txtFechaInicial.Location = New System.Drawing.Point(90, 85)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Size = New System.Drawing.Size(116, 20)
        Me.txtFechaInicial.TabIndex = 0
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.EditValue = Nothing
        Me.txtFechaFinal.Location = New System.Drawing.Point(254, 85)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Size = New System.Drawing.Size(116, 20)
        Me.txtFechaFinal.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(90, 66)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Fecha Inicial:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(254, 66)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Fecha Final:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(89, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(269, 23)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Parámetros para el Reporte:"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito1
        Me.btnAceptar.Location = New System.Drawing.Point(266, 130)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(151, 46)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(64, 130)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(151, 46)
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'viewClientesRptParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtFechaFinal)
        Me.Controls.Add(Me.txtFechaInicial)
        Me.Name = "viewClientesRptParametros"
        Me.Size = New System.Drawing.Size(461, 188)
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeChartRangeControlClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFechaInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateTimeChartRangeControlClient1 As DevExpress.XtraEditors.DateTimeChartRangeControlClient
    Friend WithEvents txtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
