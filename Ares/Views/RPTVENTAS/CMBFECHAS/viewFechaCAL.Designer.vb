<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewFechaCAL
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewFechaCAL))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnACEP = New System.Windows.Forms.Button()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarReal = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDatePickFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtDatePickInicial = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Lime
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Location = New System.Drawing.Point(311, 91)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 35)
        Me.btnAceptar.TabIndex = 235
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnACEP
        '
        Me.btnACEP.BackColor = System.Drawing.Color.Red
        Me.btnACEP.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnACEP.FlatAppearance.BorderSize = 0
        Me.btnACEP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnACEP.Location = New System.Drawing.Point(100, 91)
        Me.btnACEP.Name = "btnACEP"
        Me.btnACEP.Size = New System.Drawing.Size(96, 35)
        Me.btnACEP.TabIndex = 234
        Me.btnACEP.Text = "CANCELAR"
        Me.btnACEP.UseVisualStyleBackColor = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(154, 7)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(200, 24)
        Me.LabelControl4.TabIndex = 233
        Me.LabelControl4.Text = "SELECCIONA FECHA"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(257, 39)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(74, 16)
        Me.LabelControl5.TabIndex = 231
        Me.LabelControl5.Text = "Fecha Final:"
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(0, 0)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 232
        '
        'btnAceptarReal
        '
        Me.btnAceptarReal.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarReal.Location = New System.Drawing.Point(382, 150)
        Me.btnAceptarReal.Name = "btnAceptarReal"
        Me.btnAceptarReal.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarReal.TabIndex = 236
        Me.btnAceptarReal.TabStop = False
        Me.btnAceptarReal.Text = "aceptar real"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(50, 39)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(83, 16)
        Me.LabelControl13.TabIndex = 229
        Me.LabelControl13.Text = "Fecha Inicial:"
        '
        'txtDatePickFinal
        '
        Me.txtDatePickFinal.CustomFormat = "yyy-MM-d"
        Me.txtDatePickFinal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.txtDatePickFinal.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtDatePickFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDatePickFinal.Location = New System.Drawing.Point(257, 61)
        Me.txtDatePickFinal.Name = "txtDatePickFinal"
        Me.txtDatePickFinal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatePickFinal.Size = New System.Drawing.Size(200, 24)
        Me.txtDatePickFinal.TabIndex = 238
        '
        'txtDatePickInicial
        '
        Me.txtDatePickInicial.CustomFormat = "yyyy-MM-d"
        Me.txtDatePickInicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.txtDatePickInicial.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtDatePickInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDatePickInicial.Location = New System.Drawing.Point(50, 61)
        Me.txtDatePickInicial.Name = "txtDatePickInicial"
        Me.txtDatePickInicial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatePickInicial.Size = New System.Drawing.Size(200, 24)
        Me.txtDatePickInicial.TabIndex = 237
        '
        'viewFechaCAL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Controls.Add(Me.txtDatePickFinal)
        Me.Controls.Add(Me.txtDatePickInicial)
        Me.Controls.Add(Me.btnAceptarReal)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnACEP)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl13)
        Me.Name = "viewFechaCAL"
        Me.Size = New System.Drawing.Size(507, 134)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnACEP As Button
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptarReal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDatePickFinal As DateTimePicker
    Friend WithEvents txtDatePickInicial As DateTimePicker
End Class
