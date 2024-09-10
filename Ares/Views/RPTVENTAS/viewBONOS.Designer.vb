<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewBONOS
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewBONOS))
        Me.btnExportarDataProductos = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCargar = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlPRODUCTOS = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPRODUCTOS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbSUCURSALES = New System.Windows.Forms.ComboBox()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDatePickFinal = New System.Windows.Forms.DateTimePicker()
        Me.txtDatePickInicial = New System.Windows.Forms.DateTimePicker()
        CType(Me.GridControlPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExportarDataProductos
        '
        Me.btnExportarDataProductos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarDataProductos.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnExportarDataProductos.Appearance.Options.UseBackColor = True
        Me.btnExportarDataProductos.Appearance.Options.UseForeColor = True
        Me.btnExportarDataProductos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarDataProductos.Image = CType(resources.GetObject("btnExportarDataProductos.Image"), System.Drawing.Image)
        Me.btnExportarDataProductos.Location = New System.Drawing.Point(803, 45)
        Me.btnExportarDataProductos.Name = "btnExportarDataProductos"
        Me.btnExportarDataProductos.Size = New System.Drawing.Size(78, 21)
        Me.btnExportarDataProductos.TabIndex = 246
        Me.btnExportarDataProductos.Text = "Exportar"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl6.Location = New System.Drawing.Point(553, 44)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(35, 19)
        Me.LabelControl6.TabIndex = 245
        Me.LabelControl6.Text = "Año:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl3.Location = New System.Drawing.Point(387, 45)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(33, 19)
        Me.LabelControl3.TabIndex = 244
        Me.LabelControl3.Text = "Mes:"
        '
        'btnCargar
        '
        Me.btnCargar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargar.Appearance.Options.UseBackColor = True
        Me.btnCargar.Appearance.Options.UseForeColor = True
        Me.btnCargar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.Location = New System.Drawing.Point(719, 46)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(78, 21)
        Me.btnCargar.TabIndex = 243
        Me.btnCargar.Text = "Cargar"
        '
        'GridControlPRODUCTOS
        '
        Me.GridControlPRODUCTOS.Location = New System.Drawing.Point(12, 71)
        Me.GridControlPRODUCTOS.MainView = Me.GridViewPRODUCTOS
        Me.GridControlPRODUCTOS.Name = "GridControlPRODUCTOS"
        Me.GridControlPRODUCTOS.Size = New System.Drawing.Size(869, 456)
        Me.GridControlPRODUCTOS.TabIndex = 240
        Me.GridControlPRODUCTOS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPRODUCTOS})
        '
        'GridViewPRODUCTOS
        '
        Me.GridViewPRODUCTOS.GridControl = Me.GridControlPRODUCTOS
        Me.GridViewPRODUCTOS.Name = "GridViewPRODUCTOS"
        Me.GridViewPRODUCTOS.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(447, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(205, 24)
        Me.LabelControl4.TabIndex = 239
        Me.LabelControl4.Text = "REPORTE DE BONOS"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl7.Location = New System.Drawing.Point(12, 43)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(242, 19)
        Me.LabelControl7.TabIndex = 248
        Me.LabelControl7.Text = "Seleccione la Sucursal a consultar:"
        '
        'cmbSUCURSALES
        '
        Me.cmbSUCURSALES.FormattingEnabled = True
        Me.cmbSUCURSALES.Location = New System.Drawing.Point(260, 44)
        Me.cmbSUCURSALES.Name = "cmbSUCURSALES"
        Me.cmbSUCURSALES.Size = New System.Drawing.Size(121, 21)
        Me.cmbSUCURSALES.TabIndex = 247
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
        Me.cmdRPTVatras.TabIndex = 249
        '
        'txtDatePickFinal
        '
        Me.txtDatePickFinal.CustomFormat = "yyy-MM-d"
        Me.txtDatePickFinal.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.txtDatePickFinal.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtDatePickFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDatePickFinal.Location = New System.Drawing.Point(594, 43)
        Me.txtDatePickFinal.Name = "txtDatePickFinal"
        Me.txtDatePickFinal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatePickFinal.Size = New System.Drawing.Size(119, 24)
        Me.txtDatePickFinal.TabIndex = 251
        '
        'txtDatePickInicial
        '
        Me.txtDatePickInicial.CustomFormat = "yyyy-MM-d"
        Me.txtDatePickInicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.txtDatePickInicial.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtDatePickInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDatePickInicial.Location = New System.Drawing.Point(426, 43)
        Me.txtDatePickInicial.Name = "txtDatePickInicial"
        Me.txtDatePickInicial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatePickInicial.Size = New System.Drawing.Size(119, 24)
        Me.txtDatePickInicial.TabIndex = 250
        '
        'viewBONOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Controls.Add(Me.txtDatePickFinal)
        Me.Controls.Add(Me.txtDatePickInicial)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.cmbSUCURSALES)
        Me.Controls.Add(Me.btnExportarDataProductos)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.GridControlPRODUCTOS)
        Me.Controls.Add(Me.LabelControl4)
        Me.Name = "viewBONOS"
        Me.Size = New System.Drawing.Size(894, 537)
        CType(Me.GridControlPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExportarDataProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCargar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlPRODUCTOS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPRODUCTOS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbSUCURSALES As ComboBox
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtDatePickFinal As DateTimePicker
    Friend WithEvents txtDatePickInicial As DateTimePicker
End Class
