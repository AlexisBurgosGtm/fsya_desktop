<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewBONOSDEP
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewBONOSDEP))
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmpleado = New System.Windows.Forms.ComboBox()
        Me.btnCargarPRIMERA = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlPRODUCTOS = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPRODUCTOS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.txtTOTALBONO = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCargarSEGUNDA = New DevExpress.XtraEditors.SimpleButton()
        Me.dtBONOS = New DevExpress.XtraEditors.DateEdit()
        Me.btnCargarcCUARTA = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCargarTERCERA = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControlPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtBONOS.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtBONOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl3.Location = New System.Drawing.Point(11, 42)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(86, 19)
        Me.LabelControl3.TabIndex = 257
        Me.LabelControl3.Text = "Empleado:"
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpleado.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.Location = New System.Drawing.Point(103, 41)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(150, 25)
        Me.cmbEmpleado.TabIndex = 256
        '
        'btnCargarPRIMERA
        '
        Me.btnCargarPRIMERA.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargarPRIMERA.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btnCargarPRIMERA.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargarPRIMERA.Appearance.Options.UseBackColor = True
        Me.btnCargarPRIMERA.Appearance.Options.UseFont = True
        Me.btnCargarPRIMERA.Appearance.Options.UseForeColor = True
        Me.btnCargarPRIMERA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargarPRIMERA.Image = CType(resources.GetObject("btnCargarPRIMERA.Image"), System.Drawing.Image)
        Me.btnCargarPRIMERA.Location = New System.Drawing.Point(259, 42)
        Me.btnCargarPRIMERA.Name = "btnCargarPRIMERA"
        Me.btnCargarPRIMERA.Size = New System.Drawing.Size(100, 24)
        Me.btnCargarPRIMERA.TabIndex = 253
        Me.btnCargarPRIMERA.Text = "Semana 1"
        '
        'GridControlPRODUCTOS
        '
        Me.GridControlPRODUCTOS.Location = New System.Drawing.Point(11, 72)
        Me.GridControlPRODUCTOS.MainView = Me.GridViewPRODUCTOS
        Me.GridControlPRODUCTOS.Name = "GridControlPRODUCTOS"
        Me.GridControlPRODUCTOS.Size = New System.Drawing.Size(922, 446)
        Me.GridControlPRODUCTOS.TabIndex = 252
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
        Me.LabelControl4.Location = New System.Drawing.Point(342, 6)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(243, 24)
        Me.LabelControl4.TabIndex = 259
        Me.LabelControl4.Text = "REPORTE DE NARANJAS"
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
        Me.cmdRPTVatras.TabIndex = 258
        '
        'txtTOTALBONO
        '
        Me.txtTOTALBONO.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtTOTALBONO.Location = New System.Drawing.Point(804, 42)
        Me.txtTOTALBONO.Name = "txtTOTALBONO"
        Me.txtTOTALBONO.Size = New System.Drawing.Size(129, 24)
        Me.txtTOTALBONO.TabIndex = 260
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(687, 44)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(111, 19)
        Me.LabelControl1.TabIndex = 261
        Me.LabelControl1.Text = "Total BONOS:"
        '
        'btnCargarSEGUNDA
        '
        Me.btnCargarSEGUNDA.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargarSEGUNDA.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btnCargarSEGUNDA.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargarSEGUNDA.Appearance.Options.UseBackColor = True
        Me.btnCargarSEGUNDA.Appearance.Options.UseFont = True
        Me.btnCargarSEGUNDA.Appearance.Options.UseForeColor = True
        Me.btnCargarSEGUNDA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargarSEGUNDA.Image = CType(resources.GetObject("btnCargarSEGUNDA.Image"), System.Drawing.Image)
        Me.btnCargarSEGUNDA.Location = New System.Drawing.Point(365, 44)
        Me.btnCargarSEGUNDA.Name = "btnCargarSEGUNDA"
        Me.btnCargarSEGUNDA.Size = New System.Drawing.Size(100, 24)
        Me.btnCargarSEGUNDA.TabIndex = 262
        Me.btnCargarSEGUNDA.Text = "Semana 2"
        '
        'dtBONOS
        '
        Me.dtBONOS.EditValue = Nothing
        Me.dtBONOS.Location = New System.Drawing.Point(41, 3)
        Me.dtBONOS.Name = "dtBONOS"
        Me.dtBONOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtBONOS.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtBONOS.Size = New System.Drawing.Size(100, 20)
        Me.dtBONOS.TabIndex = 264
        Me.dtBONOS.Visible = False
        '
        'btnCargarcCUARTA
        '
        Me.btnCargarcCUARTA.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargarcCUARTA.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btnCargarcCUARTA.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargarcCUARTA.Appearance.Options.UseBackColor = True
        Me.btnCargarcCUARTA.Appearance.Options.UseFont = True
        Me.btnCargarcCUARTA.Appearance.Options.UseForeColor = True
        Me.btnCargarcCUARTA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargarcCUARTA.Image = CType(resources.GetObject("btnCargarcCUARTA.Image"), System.Drawing.Image)
        Me.btnCargarcCUARTA.Location = New System.Drawing.Point(577, 42)
        Me.btnCargarcCUARTA.Name = "btnCargarcCUARTA"
        Me.btnCargarcCUARTA.Size = New System.Drawing.Size(100, 24)
        Me.btnCargarcCUARTA.TabIndex = 265
        Me.btnCargarcCUARTA.Text = "Semana 4"
        '
        'btnCargarTERCERA
        '
        Me.btnCargarTERCERA.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargarTERCERA.Appearance.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.btnCargarTERCERA.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargarTERCERA.Appearance.Options.UseBackColor = True
        Me.btnCargarTERCERA.Appearance.Options.UseFont = True
        Me.btnCargarTERCERA.Appearance.Options.UseForeColor = True
        Me.btnCargarTERCERA.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargarTERCERA.Image = CType(resources.GetObject("btnCargarTERCERA.Image"), System.Drawing.Image)
        Me.btnCargarTERCERA.Location = New System.Drawing.Point(471, 42)
        Me.btnCargarTERCERA.Name = "btnCargarTERCERA"
        Me.btnCargarTERCERA.Size = New System.Drawing.Size(100, 24)
        Me.btnCargarTERCERA.TabIndex = 266
        Me.btnCargarTERCERA.Text = "Semana 3"
        '
        'viewBONOSDEP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCargarTERCERA)
        Me.Controls.Add(Me.btnCargarcCUARTA)
        Me.Controls.Add(Me.dtBONOS)
        Me.Controls.Add(Me.btnCargarSEGUNDA)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtTOTALBONO)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmbEmpleado)
        Me.Controls.Add(Me.btnCargarPRIMERA)
        Me.Controls.Add(Me.GridControlPRODUCTOS)
        Me.Name = "viewBONOSDEP"
        Me.Size = New System.Drawing.Size(946, 531)
        CType(Me.GridControlPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtBONOS.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtBONOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmpleado As ComboBox
    Friend WithEvents btnCargarPRIMERA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlPRODUCTOS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPRODUCTOS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtTOTALBONO As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCargarSEGUNDA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtBONOS As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnCargarcCUARTA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCargarTERCERA As DevExpress.XtraEditors.SimpleButton
End Class
