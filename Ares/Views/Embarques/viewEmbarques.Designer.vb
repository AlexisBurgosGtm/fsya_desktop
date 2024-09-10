<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewEmbarques
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewEmbarques))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnCancelarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbRepartido = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.TblEmbarquesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New Ares.DataSet1()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.RadMenMenuFinalizar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenMenuEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenMenuProductos = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenMenuDocumentos = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenMenuBoletas = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnRadMenuBoletas = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblEmbarquesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnCancelarTrue)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.txtFecha)
        Me.GroupControl1.Controls.Add(Me.btnGuardar)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.cmbRepartido)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtDescripcion)
        Me.GroupControl1.Controls.Add(Me.txtCodigo)
        Me.GroupControl1.Location = New System.Drawing.Point(24, 24)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(827, 218)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Datos del Embarque"
        '
        'btnCancelarTrue
        '
        Me.btnCancelarTrue.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarTrue.Location = New System.Drawing.Point(733, 26)
        Me.btnCancelarTrue.Name = "btnCancelarTrue"
        Me.btnCancelarTrue.Size = New System.Drawing.Size(71, 32)
        Me.btnCancelarTrue.TabIndex = 3
        Me.btnCancelarTrue.TabStop = False
        Me.btnCancelarTrue.Text = "Cerrar(x)"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(403, 98)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Fecha:"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.EnterMoveNextControl = True
        Me.txtFecha.Location = New System.Drawing.Point(403, 117)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(112, 20)
        Me.txtFecha.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(583, 138)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(155, 61)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "CREAR NUEVO"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(252, 36)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Repartidor/Piloto:"
        '
        'cmbRepartido
        '
        Me.cmbRepartido.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbRepartido.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRepartido.FormattingEnabled = True
        Me.cmbRepartido.Location = New System.Drawing.Point(252, 54)
        Me.cmbRepartido.Name = "cmbRepartido"
        Me.cmbRepartido.Size = New System.Drawing.Size(315, 21)
        Me.cmbRepartido.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 98)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Descripción del Ruteo:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Código de Embarque:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(17, 117)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(367, 20)
        Me.txtDescripcion.TabIndex = 2
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(17, 54)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(211, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'TblEmbarquesBindingSource
        '
        Me.TblEmbarquesBindingSource.DataMember = "tblEmbarques"
        Me.TblEmbarquesBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(762, 136)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 2
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'RadMenMenuFinalizar
        '
        Me.RadMenMenuFinalizar.Caption = "Finalizar"
        Me.RadMenMenuFinalizar.Glyph = CType(resources.GetObject("RadMenMenuFinalizar.Glyph"), System.Drawing.Image)
        Me.RadMenMenuFinalizar.Id = 0
        Me.RadMenMenuFinalizar.Name = "RadMenMenuFinalizar"
        '
        'RadMenMenuEliminar
        '
        Me.RadMenMenuEliminar.Caption = "Eliminar"
        Me.RadMenMenuEliminar.CloseRadialMenuOnItemClick = True
        Me.RadMenMenuEliminar.Glyph = CType(resources.GetObject("RadMenMenuEliminar.Glyph"), System.Drawing.Image)
        Me.RadMenMenuEliminar.Id = 1
        Me.RadMenMenuEliminar.Name = "RadMenMenuEliminar"
        '
        'RadMenMenuProductos
        '
        Me.RadMenMenuProductos.Caption = "Productos"
        Me.RadMenMenuProductos.CloseRadialMenuOnItemClick = True
        Me.RadMenMenuProductos.Glyph = CType(resources.GetObject("RadMenMenuProductos.Glyph"), System.Drawing.Image)
        Me.RadMenMenuProductos.Id = 2
        Me.RadMenMenuProductos.Name = "RadMenMenuProductos"
        '
        'RadMenMenuDocumentos
        '
        Me.RadMenMenuDocumentos.Caption = "Documentos"
        Me.RadMenMenuDocumentos.CloseRadialMenuOnItemClick = True
        Me.RadMenMenuDocumentos.Glyph = CType(resources.GetObject("RadMenMenuDocumentos.Glyph"), System.Drawing.Image)
        Me.RadMenMenuDocumentos.Id = 3
        Me.RadMenMenuDocumentos.Name = "RadMenMenuDocumentos"
        '
        'RadMenMenuBoletas
        '
        Me.RadMenMenuBoletas.Caption = "BOLETAS"
        Me.RadMenMenuBoletas.CloseRadialMenuOnItemClick = True
        Me.RadMenMenuBoletas.Glyph = CType(resources.GetObject("RadMenMenuBoletas.Glyph"), System.Drawing.Image)
        Me.RadMenMenuBoletas.Id = 5
        Me.RadMenMenuBoletas.Name = "RadMenMenuBoletas"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RadMenMenuFinalizar, Me.RadMenMenuEliminar, Me.RadMenMenuProductos, Me.RadMenMenuDocumentos, Me.btnRadMenuBoletas, Me.RadMenMenuBoletas})
        Me.BarManager1.MaxItemId = 6
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(871, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 260)
        Me.barDockControlBottom.Size = New System.Drawing.Size(871, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 260)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(871, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 260)
        '
        'btnRadMenuBoletas
        '
        Me.btnRadMenuBoletas.Caption = "Boletas"
        Me.btnRadMenuBoletas.CloseRadialMenuOnItemClick = True
        Me.btnRadMenuBoletas.Glyph = CType(resources.GetObject("btnRadMenuBoletas.Glyph"), System.Drawing.Image)
        Me.btnRadMenuBoletas.Id = 4
        Me.btnRadMenuBoletas.Name = "btnRadMenuBoletas"
        '
        'viewEmbarques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewEmbarques"
        Me.Size = New System.Drawing.Size(871, 260)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblEmbarquesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbRepartido As ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TblEmbarquesBindingSource As BindingSource
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadMenMenuFinalizar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenMenuEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RadMenMenuProductos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenMenuDocumentos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadMenuBoletas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenMenuBoletas As DevExpress.XtraBars.BarButtonItem
End Class
