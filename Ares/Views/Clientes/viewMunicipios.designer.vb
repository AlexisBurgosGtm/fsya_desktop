<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewMunicipios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewMunicipios))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gridDepartamentos = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDepartamentos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gridMunicipios = New DevExpress.XtraGrid.GridControl()
        Me.GridViewMunicipios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGuardarDepto = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDesDepto = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodDepto = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGuardarMunicipio = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDesMun = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodMun = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDepartamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gridMunicipios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMunicipios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.txtDesDepto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodDepto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.txtDesMun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodMun.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gridDepartamentos)
        Me.GroupControl1.Location = New System.Drawing.Point(29, 149)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(443, 333)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Listado de Departamentos (Doble clic Eliminar)"
        '
        'gridDepartamentos
        '
        Me.gridDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDepartamentos.Location = New System.Drawing.Point(2, 21)
        Me.gridDepartamentos.MainView = Me.GridViewDepartamentos
        Me.gridDepartamentos.Name = "gridDepartamentos"
        Me.gridDepartamentos.Size = New System.Drawing.Size(439, 310)
        Me.gridDepartamentos.TabIndex = 0
        Me.gridDepartamentos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDepartamentos})
        '
        'GridViewDepartamentos
        '
        Me.GridViewDepartamentos.GridControl = Me.gridDepartamentos
        Me.GridViewDepartamentos.Name = "GridViewDepartamentos"
        Me.GridViewDepartamentos.OptionsBehavior.Editable = False
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.gridMunicipios)
        Me.GroupControl2.Location = New System.Drawing.Point(516, 149)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(440, 333)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Listado de Municipios (Doble clic Eliminar)"
        '
        'gridMunicipios
        '
        Me.gridMunicipios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMunicipios.Location = New System.Drawing.Point(2, 21)
        Me.gridMunicipios.MainView = Me.GridViewMunicipios
        Me.gridMunicipios.Name = "gridMunicipios"
        Me.gridMunicipios.Size = New System.Drawing.Size(436, 310)
        Me.gridMunicipios.TabIndex = 1
        Me.gridMunicipios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMunicipios})
        '
        'GridViewMunicipios
        '
        Me.GridViewMunicipios.GridControl = Me.gridMunicipios
        Me.GridViewMunicipios.Name = "GridViewMunicipios"
        Me.GridViewMunicipios.OptionsBehavior.Editable = False
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.btnGuardarDepto)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Controls.Add(Me.LabelControl1)
        Me.GroupControl3.Controls.Add(Me.txtDesDepto)
        Me.GroupControl3.Controls.Add(Me.txtCodDepto)
        Me.GroupControl3.Location = New System.Drawing.Point(29, 22)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(443, 121)
        Me.GroupControl3.TabIndex = 2
        Me.GroupControl3.Text = "Datos del Nuevo Departamento"
        '
        'btnGuardarDepto
        '
        Me.btnGuardarDepto.Image = CType(resources.GetObject("btnGuardarDepto.Image"), System.Drawing.Image)
        Me.btnGuardarDepto.Location = New System.Drawing.Point(316, 76)
        Me.btnGuardarDepto.Name = "btnGuardarDepto"
        Me.btnGuardarDepto.Size = New System.Drawing.Size(109, 40)
        Me.btnGuardarDepto.TabIndex = 4
        Me.btnGuardarDepto.Text = "Agregar"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(123, 28)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 16)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Descripción"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(17, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Código"
        '
        'txtDesDepto
        '
        Me.txtDesDepto.Location = New System.Drawing.Point(123, 50)
        Me.txtDesDepto.Name = "txtDesDepto"
        Me.txtDesDepto.Size = New System.Drawing.Size(302, 20)
        Me.txtDesDepto.TabIndex = 1
        '
        'txtCodDepto
        '
        Me.txtCodDepto.Location = New System.Drawing.Point(17, 50)
        Me.txtCodDepto.Name = "txtCodDepto"
        Me.txtCodDepto.Properties.Mask.EditMask = "n0"
        Me.txtCodDepto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCodDepto.Size = New System.Drawing.Size(89, 20)
        Me.txtCodDepto.TabIndex = 0
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.btnGuardarMunicipio)
        Me.GroupControl4.Controls.Add(Me.LabelControl3)
        Me.GroupControl4.Controls.Add(Me.LabelControl4)
        Me.GroupControl4.Controls.Add(Me.txtDesMun)
        Me.GroupControl4.Controls.Add(Me.txtCodMun)
        Me.GroupControl4.Location = New System.Drawing.Point(516, 22)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(440, 121)
        Me.GroupControl4.TabIndex = 3
        Me.GroupControl4.Text = "Datos del Nuevo Municipio"
        '
        'btnGuardarMunicipio
        '
        Me.btnGuardarMunicipio.Image = CType(resources.GetObject("btnGuardarMunicipio.Image"), System.Drawing.Image)
        Me.btnGuardarMunicipio.Location = New System.Drawing.Point(313, 76)
        Me.btnGuardarMunicipio.Name = "btnGuardarMunicipio"
        Me.btnGuardarMunicipio.Size = New System.Drawing.Size(109, 40)
        Me.btnGuardarMunicipio.TabIndex = 8
        Me.btnGuardarMunicipio.Text = "Agregar"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(120, 28)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(74, 16)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Descripción"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(14, 28)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Código"
        '
        'txtDesMun
        '
        Me.txtDesMun.Location = New System.Drawing.Point(120, 50)
        Me.txtDesMun.Name = "txtDesMun"
        Me.txtDesMun.Size = New System.Drawing.Size(302, 20)
        Me.txtDesMun.TabIndex = 5
        '
        'txtCodMun
        '
        Me.txtCodMun.Location = New System.Drawing.Point(14, 50)
        Me.txtCodMun.Name = "txtCodMun"
        Me.txtCodMun.Properties.Mask.EditMask = "n0"
        Me.txtCodMun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCodMun.Size = New System.Drawing.Size(89, 20)
        Me.txtCodMun.TabIndex = 4
        '
        'viewMunicipios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewMunicipios"
        Me.Size = New System.Drawing.Size(980, 499)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gridDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDepartamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gridMunicipios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMunicipios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.txtDesDepto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodDepto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.txtDesMun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodMun.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridDepartamentos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDepartamentos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridMunicipios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMunicipios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDesDepto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodDepto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnGuardarDepto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardarMunicipio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDesMun As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodMun As DevExpress.XtraEditors.TextEdit
End Class
