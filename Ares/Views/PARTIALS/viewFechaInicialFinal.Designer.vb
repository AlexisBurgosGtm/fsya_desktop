<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewFechaInicialFinal
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaInicial = New DevExpress.XtraEditors.DateEdit()
        Me.DateTimeChartRangeControlClient1 = New DevExpress.XtraEditors.DateTimeChartRangeControlClient()
        Me.txtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeChartRangeControlClient1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(29, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(277, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Seleccione las fechas Inicial y Final (Del, al)"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(29, 53)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Del:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(189, 53)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Al:"
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.EditValue = Nothing
        Me.txtFechaInicial.EnterMoveNextControl = True
        Me.txtFechaInicial.Location = New System.Drawing.Point(65, 50)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Size = New System.Drawing.Size(118, 20)
        Me.txtFechaInicial.TabIndex = 3
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.EditValue = Nothing
        Me.txtFechaFinal.EnterMoveNextControl = True
        Me.txtFechaFinal.Location = New System.Drawing.Point(219, 50)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Size = New System.Drawing.Size(118, 20)
        Me.txtFechaFinal.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito1
        Me.btnAceptar.Location = New System.Drawing.Point(224, 97)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(113, 57)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(80, 97)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(113, 57)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        '
        'viewFechaInicialFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtFechaFinal)
        Me.Controls.Add(Me.txtFechaInicial)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewFechaInicialFinal"
        Me.Size = New System.Drawing.Size(364, 168)
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeChartRangeControlClient1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateTimeChartRangeControlClient1 As DevExpress.XtraEditors.DateTimeChartRangeControlClient
    Friend WithEvents txtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
End Class
