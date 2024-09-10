<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewCorteIEF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewCorteIEF))
        Me.txtTotalReportado = New System.Windows.Forms.TextBox()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnRealizarCorte = New System.Windows.Forms.Button()
        Me.txtCorrelativoCIEF = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCorteIEFFecha = New DevExpress.XtraEditors.DateEdit()
        Me.txtOBSIEF = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.txtCorteIEFFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCorteIEFFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTotalReportado
        '
        Me.txtTotalReportado.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtTotalReportado.Location = New System.Drawing.Point(194, 160)
        Me.txtTotalReportado.Name = "txtTotalReportado"
        Me.txtTotalReportado.Size = New System.Drawing.Size(152, 27)
        Me.txtTotalReportado.TabIndex = 0
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(3, 3)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 254
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl1.Location = New System.Drawing.Point(196, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(273, 66)
        Me.LabelControl1.TabIndex = 253
        Me.LabelControl1.Text = "INGRESE EL EFECTIVO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       EXISTENTE"
        '
        'btnRealizarCorte
        '
        Me.btnRealizarCorte.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.btnRealizarCorte.Location = New System.Drawing.Point(237, 204)
        Me.btnRealizarCorte.Name = "btnRealizarCorte"
        Me.btnRealizarCorte.Size = New System.Drawing.Size(201, 40)
        Me.btnRealizarCorte.TabIndex = 255
        Me.btnRealizarCorte.Text = "REALIZAR CORTE"
        Me.btnRealizarCorte.UseVisualStyleBackColor = True
        '
        'txtCorrelativoCIEF
        '
        Me.txtCorrelativoCIEF.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCorrelativoCIEF.Location = New System.Drawing.Point(194, 95)
        Me.txtCorrelativoCIEF.Name = "txtCorrelativoCIEF"
        Me.txtCorrelativoCIEF.Size = New System.Drawing.Size(152, 27)
        Me.txtCorrelativoCIEF.TabIndex = 256
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(33, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(33, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 19)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "Correlativo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(33, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 19)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Efectivo Reportado:"
        '
        'txtCorteIEFFecha
        '
        Me.txtCorteIEFFecha.EditValue = Nothing
        Me.txtCorteIEFFecha.Location = New System.Drawing.Point(194, 128)
        Me.txtCorteIEFFecha.Name = "txtCorteIEFFecha"
        Me.txtCorteIEFFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCorteIEFFecha.Properties.Appearance.Options.UseFont = True
        Me.txtCorteIEFFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCorteIEFFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCorteIEFFecha.Size = New System.Drawing.Size(152, 26)
        Me.txtCorteIEFFecha.TabIndex = 725
        '
        'txtOBSIEF
        '
        Me.txtOBSIEF.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtOBSIEF.Location = New System.Drawing.Point(352, 123)
        Me.txtOBSIEF.Multiline = True
        Me.txtOBSIEF.Name = "txtOBSIEF"
        Me.txtOBSIEF.Size = New System.Drawing.Size(293, 64)
        Me.txtOBSIEF.TabIndex = 726
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(352, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 19)
        Me.Label4.TabIndex = 727
        Me.Label4.Text = "Observaciones:"
        '
        'viewCorteIEF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOBSIEF)
        Me.Controls.Add(Me.txtCorteIEFFecha)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCorrelativoCIEF)
        Me.Controls.Add(Me.btnRealizarCorte)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtTotalReportado)
        Me.Name = "viewCorteIEF"
        Me.Size = New System.Drawing.Size(670, 278)
        CType(Me.txtCorteIEFFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCorteIEFFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTotalReportado As TextBox
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRealizarCorte As Button
    Friend WithEvents txtCorrelativoCIEF As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCorteIEFFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtOBSIEF As TextBox
    Friend WithEvents Label4 As Label
End Class
