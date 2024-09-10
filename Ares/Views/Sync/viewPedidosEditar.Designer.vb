<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewPedidosEditar
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
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FlyoutPanelEditProducto = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnEditQuitarItem = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditarCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditarAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSubtotal = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCodprod = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridDetallePedido = New DevExpress.XtraGrid.GridControl()
        Me.TblTicketBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDataSet = New Ares.VENTASDataSet()
        Me.GridViewDetallePedido = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCANTIDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODVEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbTotalCosto = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalPrecio = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotaVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.txtDirclie = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNomclie = New DevExpress.XtraEditors.TextEdit()
        Me.txtNit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCoddoc = New DevExpress.XtraEditors.LabelControl()
        Me.lbCorrelativo = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1.SuspendLayout()
        CType(Me.FlyoutPanelEditProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelEditProducto.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTicketBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDirclie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomclie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(598, 75)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(144, 52)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Finalizar Edición"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FlyoutPanelEditProducto)
        Me.GroupBox1.Controls.Add(Me.GridDetallePedido)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(748, 372)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle del Pedido"
        '
        'FlyoutPanelEditProducto
        '
        Me.FlyoutPanelEditProducto.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelEditProducto.Location = New System.Drawing.Point(386, 0)
        Me.FlyoutPanelEditProducto.Name = "FlyoutPanelEditProducto"
        Me.FlyoutPanelEditProducto.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelEditProducto.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutPanelEditProducto.OwnerControl = Me
        Me.FlyoutPanelEditProducto.Size = New System.Drawing.Size(362, 436)
        Me.FlyoutPanelEditProducto.TabIndex = 5
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.btnEditQuitarItem)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnEditarCancelar)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnEditarAceptar)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl13)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl12)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl10)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtSubtotal)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl8)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtPrecio)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl7)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtCantidad)
        Me.FlyoutPanelControl1.Controls.Add(Me.lbDesprod)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl9)
        Me.FlyoutPanelControl1.Controls.Add(Me.lbCodprod)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl2)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelEditProducto
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(362, 436)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'btnEditQuitarItem
        '
        Me.btnEditQuitarItem.Appearance.BackColor = System.Drawing.Color.Red
        Me.btnEditQuitarItem.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnEditQuitarItem.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnEditQuitarItem.Appearance.Options.UseBackColor = True
        Me.btnEditQuitarItem.Appearance.Options.UseFont = True
        Me.btnEditQuitarItem.Appearance.Options.UseForeColor = True
        Me.btnEditQuitarItem.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEditQuitarItem.Image = Global.Ares.My.Resources.Resources.btWarning
        Me.btnEditQuitarItem.Location = New System.Drawing.Point(166, 369)
        Me.btnEditQuitarItem.Name = "btnEditQuitarItem"
        Me.btnEditQuitarItem.Size = New System.Drawing.Size(173, 52)
        Me.btnEditQuitarItem.TabIndex = 24
        Me.btnEditQuitarItem.Text = "QUITAR ITEM"
        '
        'btnEditarCancelar
        '
        Me.btnEditarCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnEditarCancelar.Location = New System.Drawing.Point(29, 270)
        Me.btnEditarCancelar.Name = "btnEditarCancelar"
        Me.btnEditarCancelar.Size = New System.Drawing.Size(123, 52)
        Me.btnEditarCancelar.TabIndex = 23
        Me.btnEditarCancelar.Text = "CANCELAR"
        '
        'btnEditarAceptar
        '
        Me.btnEditarAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnEditarAceptar.Location = New System.Drawing.Point(192, 270)
        Me.btnEditarAceptar.Name = "btnEditarAceptar"
        Me.btnEditarAceptar.Size = New System.Drawing.Size(123, 52)
        Me.btnEditarAceptar.TabIndex = 22
        Me.btnEditarAceptar.Text = "ACEPTAR"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(109, 196)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(9, 16)
        Me.LabelControl13.TabIndex = 21
        Me.LabelControl13.Text = "Q"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(109, 168)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(9, 16)
        Me.LabelControl12.TabIndex = 20
        Me.LabelControl12.Text = "Q"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(29, 199)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl10.TabIndex = 18
        Me.LabelControl10.Text = "Subtotal:"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Enabled = False
        Me.txtSubtotal.Location = New System.Drawing.Point(129, 196)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Properties.Mask.EditMask = "n2"
        Me.txtSubtotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSubtotal.Size = New System.Drawing.Size(108, 20)
        Me.txtSubtotal.TabIndex = 17
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(29, 170)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl8.TabIndex = 16
        Me.LabelControl8.Text = "Precio:"
        '
        'txtPrecio
        '
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Location = New System.Drawing.Point(129, 167)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Properties.Mask.EditMask = "n2"
        Me.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecio.Size = New System.Drawing.Size(108, 20)
        Me.txtPrecio.TabIndex = 15
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(29, 142)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl7.TabIndex = 14
        Me.LabelControl7.Text = "Cantidad:"
        '
        'txtCantidad
        '
        Me.txtCantidad.Enabled = False
        Me.txtCantidad.Location = New System.Drawing.Point(129, 139)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Mask.EditMask = "n"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Size = New System.Drawing.Size(73, 20)
        Me.txtCantidad.TabIndex = 13
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Location = New System.Drawing.Point(12, 76)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(327, 13)
        Me.lbDesprod.TabIndex = 12
        Me.lbDesprod.Text = "DESCRIPCION DEL PRODUCTO DESCRIPCION DEL PRODUCTO"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(12, 57)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl9.TabIndex = 11
        Me.LabelControl9.Text = "Descripción:"
        '
        'lbCodprod
        '
        Me.lbCodprod.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodprod.Location = New System.Drawing.Point(79, 31)
        Me.lbCodprod.Name = "lbCodprod"
        Me.lbCodprod.Size = New System.Drawing.Size(112, 16)
        Me.lbCodprod.TabIndex = 10
        Me.lbCodprod.Text = "00000000000000"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 31)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 9
        Me.LabelControl2.Text = "Código:"
        '
        'GridDetallePedido
        '
        Me.GridDetallePedido.DataSource = Me.TblTicketBindingSource
        Me.GridDetallePedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDetallePedido.Location = New System.Drawing.Point(3, 17)
        Me.GridDetallePedido.MainView = Me.GridViewDetallePedido
        Me.GridDetallePedido.Name = "GridDetallePedido"
        Me.GridDetallePedido.Size = New System.Drawing.Size(742, 352)
        Me.GridDetallePedido.TabIndex = 0
        Me.GridDetallePedido.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetallePedido})
        '
        'TblTicketBindingSource
        '
        Me.TblTicketBindingSource.DataMember = "tblTicket"
        Me.TblTicketBindingSource.DataSource = Me.VENTASDataSet
        '
        'VENTASDataSet
        '
        Me.VENTASDataSet.DataSetName = "VENTASDataSet"
        Me.VENTASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewDetallePedido
        '
        Me.GridViewDetallePedido.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCODMEDIDA, Me.colCANTIDAD, Me.colPRECIO, Me.colTOTALPRECIO, Me.colCODVEN})
        Me.GridViewDetallePedido.GridControl = Me.GridDetallePedido
        Me.GridViewDetallePedido.Name = "GridViewDetallePedido"
        Me.GridViewDetallePedido.OptionsBehavior.Editable = False
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 88
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 282
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 69
        '
        'colCANTIDAD
        '
        Me.colCANTIDAD.FieldName = "CANTIDAD"
        Me.colCANTIDAD.Name = "colCANTIDAD"
        Me.colCANTIDAD.Visible = True
        Me.colCANTIDAD.VisibleIndex = 3
        Me.colCANTIDAD.Width = 62
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 4
        Me.colPRECIO.Width = 104
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 5
        Me.colTOTALPRECIO.Width = 119
        '
        'colCODVEN
        '
        Me.colCODVEN.FieldName = "CODVEN"
        Me.colCODVEN.Name = "colCODVEN"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.lbTotalCosto)
        Me.GroupBox2.Controls.Add(Me.lbTotalPrecio)
        Me.GroupBox2.Controls.Add(Me.lbTotaVenta)
        Me.GroupBox2.Controls.Add(Me.LabelControl6)
        Me.GroupBox2.Controls.Add(Me.txtFecha)
        Me.GroupBox2.Controls.Add(Me.txtDirclie)
        Me.GroupBox2.Controls.Add(Me.LabelControl5)
        Me.GroupBox2.Controls.Add(Me.txtNomclie)
        Me.GroupBox2.Controls.Add(Me.txtNit)
        Me.GroupBox2.Controls.Add(Me.LabelControl4)
        Me.GroupBox2.Controls.Add(Me.LabelControl3)
        Me.GroupBox2.Controls.Add(Me.btnGuardar)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 38)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(748, 133)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle del Documento"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnAgregar.Location = New System.Drawing.Point(444, 75)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(121, 52)
        Me.btnAgregar.TabIndex = 15
        Me.btnAgregar.Text = "Agregar"
        '
        'lbTotalCosto
        '
        Me.lbTotalCosto.Location = New System.Drawing.Point(323, 105)
        Me.lbTotalCosto.Name = "lbTotalCosto"
        Me.lbTotalCosto.Size = New System.Drawing.Size(22, 13)
        Me.lbTotalCosto.TabIndex = 14
        Me.lbTotalCosto.Text = "0.00"
        '
        'lbTotalPrecio
        '
        Me.lbTotalPrecio.Location = New System.Drawing.Point(204, 105)
        Me.lbTotalPrecio.Name = "lbTotalPrecio"
        Me.lbTotalPrecio.Size = New System.Drawing.Size(22, 13)
        Me.lbTotalPrecio.TabIndex = 13
        Me.lbTotalPrecio.Text = "0.00"
        '
        'lbTotaVenta
        '
        Me.lbTotaVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotaVenta.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lbTotaVenta.Location = New System.Drawing.Point(561, 20)
        Me.lbTotaVenta.Name = "lbTotaVenta"
        Me.lbTotaVenta.Size = New System.Drawing.Size(161, 29)
        Me.lbTotaVenta.TabIndex = 12
        Me.lbTotaVenta.Text = "Q 999,999.99"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(519, 22)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Total:"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(243, 27)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(119, 20)
        Me.txtFecha.TabIndex = 10
        '
        'txtDirclie
        '
        Me.txtDirclie.Location = New System.Drawing.Point(74, 79)
        Me.txtDirclie.Name = "txtDirclie"
        Me.txtDirclie.Size = New System.Drawing.Size(344, 20)
        Me.txtDirclie.TabIndex = 9
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(19, 82)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Vendedor:"
        '
        'txtNomclie
        '
        Me.txtNomclie.Location = New System.Drawing.Point(74, 53)
        Me.txtNomclie.Name = "txtNomclie"
        Me.txtNomclie.Size = New System.Drawing.Size(344, 20)
        Me.txtNomclie.TabIndex = 7
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(74, 27)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(163, 20)
        Me.txtNit.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 56)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Cliente:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 30)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "NIT:"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(706, 8)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(65, 23)
        Me.SimpleButton2.TabIndex = 1
        Me.SimpleButton2.TabStop = False
        Me.SimpleButton2.Text = "Cerrar(x)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(340, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Documento:"
        '
        'lbCoddoc
        '
        Me.lbCoddoc.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbCoddoc.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCoddoc.Location = New System.Drawing.Point(404, 13)
        Me.lbCoddoc.Name = "lbCoddoc"
        Me.lbCoddoc.Size = New System.Drawing.Size(21, 13)
        Me.lbCoddoc.TabIndex = 3
        Me.lbCoddoc.Text = "ped"
        '
        'lbCorrelativo
        '
        Me.lbCorrelativo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbCorrelativo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCorrelativo.Location = New System.Drawing.Point(475, 13)
        Me.lbCorrelativo.Name = "lbCorrelativo"
        Me.lbCorrelativo.Size = New System.Drawing.Size(28, 13)
        Me.lbCorrelativo.TabIndex = 4
        Me.lbCorrelativo.Text = "0001"
        '
        'viewPedidosEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbCorrelativo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lbCoddoc)
        Me.Name = "viewPedidosEditar"
        Me.Size = New System.Drawing.Size(778, 560)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.FlyoutPanelEditProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelEditProducto.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.txtSubtotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTicketBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDirclie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomclie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GridDetallePedido As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetallePedido As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbCoddoc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotaVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDirclie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNomclie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalPrecio As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblTicketBindingSource As BindingSource
    Friend WithEvents VENTASDataSet As VENTASDataSet
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCANTIDAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FlyoutPanelEditProducto As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCodprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSubtotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPrecio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnEditarCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditarAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditQuitarItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODVEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
End Class
