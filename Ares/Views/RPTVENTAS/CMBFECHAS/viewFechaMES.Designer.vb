<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewFechaMES
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewFechaMES))
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnACEP = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnAceptarReal = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbAnioDocumento = New System.Windows.Forms.ComboBox()
        Me.cmbMesDocumento2 = New System.Windows.Forms.ComboBox()
        Me.cmbMesDocumento = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl5.Location = New System.Drawing.Point(50, 92)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(127, 16)
        Me.LabelControl5.TabIndex = 219
        Me.LabelControl5.Text = "Mes de Finalizacion:"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(50, 39)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(89, 16)
        Me.LabelControl13.TabIndex = 217
        Me.LabelControl13.Text = "Mes de Inicio:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(50, 9)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(200, 24)
        Me.LabelControl4.TabIndex = 221
        Me.LabelControl4.Text = "SELECCIONA FECHA"
        '
        'btnACEP
        '
        Me.btnACEP.BackColor = System.Drawing.Color.Red
        Me.btnACEP.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnACEP.FlatAppearance.BorderSize = 0
        Me.btnACEP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnACEP.Location = New System.Drawing.Point(50, 198)
        Me.btnACEP.Name = "btnACEP"
        Me.btnACEP.Size = New System.Drawing.Size(96, 35)
        Me.btnACEP.TabIndex = 222
        Me.btnACEP.Text = "CANCELAR"
        Me.btnACEP.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Lime
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Location = New System.Drawing.Point(154, 198)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 35)
        Me.btnAceptar.TabIndex = 224
        Me.btnAceptar.Text = "ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnAceptarReal
        '
        Me.btnAceptarReal.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarReal.Location = New System.Drawing.Point(201, 263)
        Me.btnAceptarReal.Name = "btnAceptarReal"
        Me.btnAceptarReal.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarReal.TabIndex = 225
        Me.btnAceptarReal.TabStop = False
        Me.btnAceptarReal.Text = "aceptar real"
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
        Me.cmdRPTVatras.TabIndex = 220
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(50, 145)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(104, 16)
        Me.LabelControl1.TabIndex = 218
        Me.LabelControl1.Text = "Año de Trabajo:"
        '
        'cmbAnioDocumento
        '
        Me.cmbAnioDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAnioDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAnioDocumento.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.cmbAnioDocumento.FormattingEnabled = True
        Me.cmbAnioDocumento.Items.AddRange(New Object() {"2018", "2019", "2020", "2021", "2022", "2023", "2024"})
        Me.cmbAnioDocumento.Location = New System.Drawing.Point(50, 167)
        Me.cmbAnioDocumento.Name = "cmbAnioDocumento"
        Me.cmbAnioDocumento.Size = New System.Drawing.Size(200, 25)
        Me.cmbAnioDocumento.TabIndex = 215
        '
        'cmbMesDocumento2
        '
        Me.cmbMesDocumento2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMesDocumento2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMesDocumento2.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.cmbMesDocumento2.FormattingEnabled = True
        Me.cmbMesDocumento2.Location = New System.Drawing.Point(50, 114)
        Me.cmbMesDocumento2.Name = "cmbMesDocumento2"
        Me.cmbMesDocumento2.Size = New System.Drawing.Size(200, 25)
        Me.cmbMesDocumento2.TabIndex = 216
        '
        'cmbMesDocumento
        '
        Me.cmbMesDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMesDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMesDocumento.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.cmbMesDocumento.FormattingEnabled = True
        Me.cmbMesDocumento.Location = New System.Drawing.Point(50, 61)
        Me.cmbMesDocumento.Name = "cmbMesDocumento"
        Me.cmbMesDocumento.Size = New System.Drawing.Size(200, 25)
        Me.cmbMesDocumento.TabIndex = 214
        '
        'viewFechaMES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Controls.Add(Me.btnAceptarReal)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnACEP)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.cmbMesDocumento2)
        Me.Controls.Add(Me.cmbAnioDocumento)
        Me.Controls.Add(Me.cmbMesDocumento)
        Me.Name = "viewFechaMES"
        Me.Size = New System.Drawing.Size(299, 246)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnACEP As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnAceptarReal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbAnioDocumento As ComboBox
    Friend WithEvents cmbMesDocumento2 As ComboBox
    Friend WithEvents cmbMesDocumento As ComboBox
End Class
