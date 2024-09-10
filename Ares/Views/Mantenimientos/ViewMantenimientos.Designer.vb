<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewMantenimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewMantenimientos))
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Me.cmdMantenimientosBodegas = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl212 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdMantenimientosCajas = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl208 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl207 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdMantenimientosRutas = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMantenimientosCancelarEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupMantenientos = New DevExpress.XtraEditors.GroupControl()
        Me.txtMantenimientosCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.cmdMantenimientosGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbMantenimientosDescripcion = New DevExpress.XtraEditors.LabelControl()
        Me.lbMantenimientosCodigo = New DevExpress.XtraEditors.LabelControl()
        Me.txtMantenimientosDescripcion = New System.Windows.Forms.TextBox()
        Me.GridMantenimientos = New DevExpress.XtraGrid.GridControl()
        Me.TileViewMantenimientos = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.cmdMantenimientosClaseTres = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMantenimientosClaseDos = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMantenimientosClaseUno = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMantenimientosMedidas = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMantenimientosMarcas = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl194 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl182 = New DevExpress.XtraEditors.LabelControl()
        Me.RadMenMantenimientos = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.cmdRadMenMantenimientosEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdRadMenMantenimientosEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.GroupMantenientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupMantenientos.SuspendLayout()
        CType(Me.txtMantenimientosCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridMantenimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewMantenimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenMantenimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdMantenimientosBodegas
        '
        Me.cmdMantenimientosBodegas.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosBodegas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosBodegas.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosBodegas.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosBodegas.Appearance.Options.UseFont = True
        Me.cmdMantenimientosBodegas.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosBodegas.Image = CType(resources.GetObject("cmdMantenimientosBodegas.Image"), System.Drawing.Image)
        Me.cmdMantenimientosBodegas.Location = New System.Drawing.Point(25, 163)
        Me.cmdMantenimientosBodegas.Name = "cmdMantenimientosBodegas"
        Me.cmdMantenimientosBodegas.Size = New System.Drawing.Size(151, 39)
        Me.cmdMantenimientosBodegas.TabIndex = 200
        Me.cmdMantenimientosBodegas.TabStop = False
        Me.cmdMantenimientosBodegas.Text = "Bodegas"
        '
        'LabelControl212
        '
        Me.LabelControl212.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl212.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl212.Location = New System.Drawing.Point(27, 93)
        Me.LabelControl212.Name = "LabelControl212"
        Me.LabelControl212.Size = New System.Drawing.Size(80, 16)
        Me.LabelControl212.TabIndex = 199
        Me.LabelControl212.Text = "Documentos"
        '
        'cmdMantenimientosCajas
        '
        Me.cmdMantenimientosCajas.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosCajas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosCajas.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosCajas.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosCajas.Appearance.Options.UseFont = True
        Me.cmdMantenimientosCajas.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosCajas.Image = CType(resources.GetObject("cmdMantenimientosCajas.Image"), System.Drawing.Image)
        Me.cmdMantenimientosCajas.Location = New System.Drawing.Point(25, 115)
        Me.cmdMantenimientosCajas.Name = "cmdMantenimientosCajas"
        Me.cmdMantenimientosCajas.Size = New System.Drawing.Size(151, 39)
        Me.cmdMantenimientosCajas.TabIndex = 198
        Me.cmdMantenimientosCajas.TabStop = False
        Me.cmdMantenimientosCajas.Text = "Cajas"
        '
        'LabelControl208
        '
        Me.LabelControl208.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl208.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl208.Location = New System.Drawing.Point(29, 290)
        Me.LabelControl208.Name = "LabelControl208"
        Me.LabelControl208.Size = New System.Drawing.Size(66, 16)
        Me.LabelControl208.TabIndex = 197
        Me.LabelControl208.Text = "Productos"
        '
        'LabelControl207
        '
        Me.LabelControl207.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl207.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl207.Location = New System.Drawing.Point(27, 219)
        Me.LabelControl207.Name = "LabelControl207"
        Me.LabelControl207.Size = New System.Drawing.Size(51, 16)
        Me.LabelControl207.TabIndex = 196
        Me.LabelControl207.Text = "Clientes"
        Me.LabelControl207.Visible = False
        '
        'cmdMantenimientosRutas
        '
        Me.cmdMantenimientosRutas.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosRutas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosRutas.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosRutas.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosRutas.Appearance.Options.UseFont = True
        Me.cmdMantenimientosRutas.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosRutas.Location = New System.Drawing.Point(25, 241)
        Me.cmdMantenimientosRutas.Name = "cmdMantenimientosRutas"
        Me.cmdMantenimientosRutas.Size = New System.Drawing.Size(151, 39)
        Me.cmdMantenimientosRutas.TabIndex = 195
        Me.cmdMantenimientosRutas.TabStop = False
        Me.cmdMantenimientosRutas.Text = "Grupos"
        Me.cmdMantenimientosRutas.Visible = False
        '
        'cmdMantenimientosCancelarEdit
        '
        Me.cmdMantenimientosCancelarEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosCancelarEdit.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosCancelarEdit.Appearance.Options.UseFont = True
        Me.cmdMantenimientosCancelarEdit.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosCancelarEdit.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdMantenimientosCancelarEdit.AppearanceHovered.Options.UseBackColor = True
        Me.cmdMantenimientosCancelarEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdMantenimientosCancelarEdit.Image = Global.Ares.My.Resources.Resources.CANCELAR_BT
        Me.cmdMantenimientosCancelarEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdMantenimientosCancelarEdit.Location = New System.Drawing.Point(1138, 24)
        Me.cmdMantenimientosCancelarEdit.Name = "cmdMantenimientosCancelarEdit"
        Me.cmdMantenimientosCancelarEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdMantenimientosCancelarEdit.Size = New System.Drawing.Size(182, 75)
        Me.cmdMantenimientosCancelarEdit.TabIndex = 194
        Me.cmdMantenimientosCancelarEdit.Text = "CANCELAR" & Global.Microsoft.VisualBasic.ChrW(13) & " (F2)"
        Me.cmdMantenimientosCancelarEdit.Visible = False
        '
        'GroupMantenientos
        '
        Me.GroupMantenientos.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupMantenientos.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupMantenientos.AppearanceCaption.Options.UseFont = True
        Me.GroupMantenientos.AppearanceCaption.Options.UseForeColor = True
        Me.GroupMantenientos.Controls.Add(Me.txtMantenimientosCodigo)
        Me.GroupMantenientos.Controls.Add(Me.cmdMantenimientosGuardar)
        Me.GroupMantenientos.Controls.Add(Me.lbMantenimientosDescripcion)
        Me.GroupMantenientos.Controls.Add(Me.lbMantenimientosCodigo)
        Me.GroupMantenientos.Controls.Add(Me.txtMantenimientosDescripcion)
        Me.GroupMantenientos.Location = New System.Drawing.Point(184, 105)
        Me.GroupMantenientos.Name = "GroupMantenientos"
        Me.GroupMantenientos.Size = New System.Drawing.Size(1136, 136)
        Me.GroupMantenientos.TabIndex = 193
        Me.GroupMantenientos.Text = "Mantenimientos"
        '
        'txtMantenimientosCodigo
        '
        Me.txtMantenimientosCodigo.Location = New System.Drawing.Point(181, 46)
        Me.txtMantenimientosCodigo.Name = "txtMantenimientosCodigo"
        Me.txtMantenimientosCodigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMantenimientosCodigo.Properties.Appearance.Options.UseFont = True
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Size = New System.Drawing.Size(181, 22)
        Me.txtMantenimientosCodigo.TabIndex = 181
        '
        'cmdMantenimientosGuardar
        '
        Me.cmdMantenimientosGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosGuardar.Appearance.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.cmdMantenimientosGuardar.Appearance.Options.UseFont = True
        Me.cmdMantenimientosGuardar.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosGuardar.Image = Global.Ares.My.Resources.Resources.btsave1
        Me.cmdMantenimientosGuardar.Location = New System.Drawing.Point(927, 33)
        Me.cmdMantenimientosGuardar.Name = "cmdMantenimientosGuardar"
        Me.cmdMantenimientosGuardar.Size = New System.Drawing.Size(182, 83)
        Me.cmdMantenimientosGuardar.TabIndex = 180
        Me.cmdMantenimientosGuardar.Text = "Guardar"
        '
        'lbMantenimientosDescripcion
        '
        Me.lbMantenimientosDescripcion.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMantenimientosDescripcion.Location = New System.Drawing.Point(96, 87)
        Me.lbMantenimientosDescripcion.Name = "lbMantenimientosDescripcion"
        Me.lbMantenimientosDescripcion.Size = New System.Drawing.Size(79, 16)
        Me.lbMantenimientosDescripcion.TabIndex = 179
        Me.lbMantenimientosDescripcion.Text = "Descripción:"
        '
        'lbMantenimientosCodigo
        '
        Me.lbMantenimientosCodigo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMantenimientosCodigo.Location = New System.Drawing.Point(96, 49)
        Me.lbMantenimientosCodigo.Name = "lbMantenimientosCodigo"
        Me.lbMantenimientosCodigo.Size = New System.Drawing.Size(48, 16)
        Me.lbMantenimientosCodigo.TabIndex = 178
        Me.lbMantenimientosCodigo.Text = "Código:"
        '
        'txtMantenimientosDescripcion
        '
        Me.txtMantenimientosDescripcion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMantenimientosDescripcion.Location = New System.Drawing.Point(181, 84)
        Me.txtMantenimientosDescripcion.Name = "txtMantenimientosDescripcion"
        Me.txtMantenimientosDescripcion.Size = New System.Drawing.Size(436, 23)
        Me.txtMantenimientosDescripcion.TabIndex = 177
        '
        'GridMantenimientos
        '
        Me.GridMantenimientos.Location = New System.Drawing.Point(184, 254)
        Me.GridMantenimientos.MainView = Me.TileViewMantenimientos
        Me.GridMantenimientos.Name = "GridMantenimientos"
        Me.GridMantenimientos.Size = New System.Drawing.Size(1136, 423)
        Me.GridMantenimientos.TabIndex = 192
        Me.GridMantenimientos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileViewMantenimientos})
        '
        'TileViewMantenimientos
        '
        Me.TileViewMantenimientos.GridControl = Me.GridMantenimientos
        Me.TileViewMantenimientos.Name = "TileViewMantenimientos"
        Me.TileViewMantenimientos.OptionsFind.AlwaysVisible = True
        Me.TileViewMantenimientos.OptionsFind.FindNullPrompt = "Escriba para Buscar...."
        Me.TileViewMantenimientos.OptionsTiles.ColumnCount = 3
        Me.TileViewMantenimientos.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileViewMantenimientos.OptionsTiles.RowCount = 100
        TileViewItemElement1.Text = "001"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement1.TextLocation = New System.Drawing.Point(80, 0)
        TileViewItemElement2.Text = "Marca Tucan"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement2.TextLocation = New System.Drawing.Point(0, 50)
        TileViewItemElement3.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        TileViewItemElement3.Appearance.Normal.Options.UseFont = True
        TileViewItemElement3.Text = "Código:"
        TileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement4.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        TileViewItemElement4.Appearance.Normal.Options.UseFont = True
        TileViewItemElement4.Text = "Descripción:"
        TileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement4.TextLocation = New System.Drawing.Point(0, 30)
        Me.TileViewMantenimientos.TileTemplate.Add(TileViewItemElement1)
        Me.TileViewMantenimientos.TileTemplate.Add(TileViewItemElement2)
        Me.TileViewMantenimientos.TileTemplate.Add(TileViewItemElement3)
        Me.TileViewMantenimientos.TileTemplate.Add(TileViewItemElement4)
        '
        'cmdMantenimientosClaseTres
        '
        Me.cmdMantenimientosClaseTres.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosClaseTres.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosClaseTres.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosClaseTres.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosClaseTres.Appearance.Options.UseFont = True
        Me.cmdMantenimientosClaseTres.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosClaseTres.Image = CType(resources.GetObject("cmdMantenimientosClaseTres.Image"), System.Drawing.Image)
        Me.cmdMantenimientosClaseTres.Location = New System.Drawing.Point(27, 475)
        Me.cmdMantenimientosClaseTres.Name = "cmdMantenimientosClaseTres"
        Me.cmdMantenimientosClaseTres.Size = New System.Drawing.Size(151, 44)
        Me.cmdMantenimientosClaseTres.TabIndex = 191
        Me.cmdMantenimientosClaseTres.TabStop = False
        Me.cmdMantenimientosClaseTres.Text = "Clasificación Dos"
        '
        'cmdMantenimientosClaseDos
        '
        Me.cmdMantenimientosClaseDos.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosClaseDos.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosClaseDos.Appearance.ForeColor = System.Drawing.Color.White
        Me.cmdMantenimientosClaseDos.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosClaseDos.Appearance.Options.UseFont = True
        Me.cmdMantenimientosClaseDos.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosClaseDos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdMantenimientosClaseDos.Location = New System.Drawing.Point(3, 552)
        Me.cmdMantenimientosClaseDos.Name = "cmdMantenimientosClaseDos"
        Me.cmdMantenimientosClaseDos.Size = New System.Drawing.Size(32, 44)
        Me.cmdMantenimientosClaseDos.TabIndex = 190
        Me.cmdMantenimientosClaseDos.TabStop = False
        Me.cmdMantenimientosClaseDos.Text = "Clasificación Dos"
        Me.cmdMantenimientosClaseDos.Visible = False
        '
        'cmdMantenimientosClaseUno
        '
        Me.cmdMantenimientosClaseUno.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosClaseUno.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosClaseUno.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosClaseUno.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosClaseUno.Appearance.Options.UseFont = True
        Me.cmdMantenimientosClaseUno.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosClaseUno.Image = CType(resources.GetObject("cmdMantenimientosClaseUno.Image"), System.Drawing.Image)
        Me.cmdMantenimientosClaseUno.Location = New System.Drawing.Point(27, 417)
        Me.cmdMantenimientosClaseUno.Name = "cmdMantenimientosClaseUno"
        Me.cmdMantenimientosClaseUno.Size = New System.Drawing.Size(151, 44)
        Me.cmdMantenimientosClaseUno.TabIndex = 189
        Me.cmdMantenimientosClaseUno.TabStop = False
        Me.cmdMantenimientosClaseUno.Text = "Fabricantes"
        '
        'cmdMantenimientosMedidas
        '
        Me.cmdMantenimientosMedidas.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosMedidas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosMedidas.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosMedidas.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosMedidas.Appearance.Options.UseFont = True
        Me.cmdMantenimientosMedidas.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosMedidas.Image = CType(resources.GetObject("cmdMantenimientosMedidas.Image"), System.Drawing.Image)
        Me.cmdMantenimientosMedidas.Location = New System.Drawing.Point(27, 362)
        Me.cmdMantenimientosMedidas.Name = "cmdMantenimientosMedidas"
        Me.cmdMantenimientosMedidas.Size = New System.Drawing.Size(151, 44)
        Me.cmdMantenimientosMedidas.TabIndex = 188
        Me.cmdMantenimientosMedidas.TabStop = False
        Me.cmdMantenimientosMedidas.Text = "Medidas"
        '
        'cmdMantenimientosMarcas
        '
        Me.cmdMantenimientosMarcas.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMantenimientosMarcas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMantenimientosMarcas.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdMantenimientosMarcas.Appearance.Options.UseBackColor = True
        Me.cmdMantenimientosMarcas.Appearance.Options.UseFont = True
        Me.cmdMantenimientosMarcas.Appearance.Options.UseForeColor = True
        Me.cmdMantenimientosMarcas.Image = CType(resources.GetObject("cmdMantenimientosMarcas.Image"), System.Drawing.Image)
        Me.cmdMantenimientosMarcas.Location = New System.Drawing.Point(27, 312)
        Me.cmdMantenimientosMarcas.Name = "cmdMantenimientosMarcas"
        Me.cmdMantenimientosMarcas.Size = New System.Drawing.Size(151, 44)
        Me.cmdMantenimientosMarcas.TabIndex = 187
        Me.cmdMantenimientosMarcas.TabStop = False
        Me.cmdMantenimientosMarcas.Text = "Marcas"
        '
        'LabelControl194
        '
        Me.LabelControl194.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl194.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl194.Location = New System.Drawing.Point(75, 49)
        Me.LabelControl194.Name = "LabelControl194"
        Me.LabelControl194.Size = New System.Drawing.Size(553, 19)
        Me.LabelControl194.TabIndex = 186
        Me.LabelControl194.Text = "Edición de Marcas, Medidas y Clasificaciones Uno, Dos y Tres, Grupos Clientes"
        '
        'LabelControl182
        '
        Me.LabelControl182.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl182.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl182.Location = New System.Drawing.Point(75, 18)
        Me.LabelControl182.Name = "LabelControl182"
        Me.LabelControl182.Size = New System.Drawing.Size(188, 33)
        Me.LabelControl182.TabIndex = 185
        Me.LabelControl182.Text = "Mantenimientos"
        '
        'RadMenMantenimientos
        '
        Me.RadMenMantenimientos.AutoExpand = True
        Me.RadMenMantenimientos.Glyph = CType(resources.GetObject("RadMenMantenimientos.Glyph"), System.Drawing.Image)
        Me.RadMenMantenimientos.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadMenMantenimientos.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.cmdRadMenMantenimientosEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.cmdRadMenMantenimientosEliminar)})
        Me.RadMenMantenimientos.Manager = Me.BarManager1
        Me.RadMenMantenimientos.Name = "RadMenMantenimientos"
        '
        'cmdRadMenMantenimientosEditar
        '
        Me.cmdRadMenMantenimientosEditar.Caption = "Editar"
        Me.cmdRadMenMantenimientosEditar.CloseRadialMenuOnItemClick = True
        Me.cmdRadMenMantenimientosEditar.Glyph = CType(resources.GetObject("cmdRadMenMantenimientosEditar.Glyph"), System.Drawing.Image)
        Me.cmdRadMenMantenimientosEditar.Id = 0
        Me.cmdRadMenMantenimientosEditar.Name = "cmdRadMenMantenimientosEditar"
        '
        'cmdRadMenMantenimientosEliminar
        '
        Me.cmdRadMenMantenimientosEliminar.Caption = "Eliminar"
        Me.cmdRadMenMantenimientosEliminar.CloseRadialMenuOnItemClick = True
        Me.cmdRadMenMantenimientosEliminar.Glyph = CType(resources.GetObject("cmdRadMenMantenimientosEliminar.Glyph"), System.Drawing.Image)
        Me.cmdRadMenMantenimientosEliminar.Id = 1
        Me.cmdRadMenMantenimientosEliminar.Name = "cmdRadMenMantenimientosEliminar"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmdRadMenMantenimientosEditar, Me.cmdRadMenMantenimientosEliminar})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1340, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 696)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1340, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 696)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1340, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 696)
        '
        'ViewMantenimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdMantenimientosBodegas)
        Me.Controls.Add(Me.LabelControl212)
        Me.Controls.Add(Me.cmdMantenimientosCajas)
        Me.Controls.Add(Me.LabelControl208)
        Me.Controls.Add(Me.LabelControl207)
        Me.Controls.Add(Me.cmdMantenimientosRutas)
        Me.Controls.Add(Me.cmdMantenimientosCancelarEdit)
        Me.Controls.Add(Me.GroupMantenientos)
        Me.Controls.Add(Me.GridMantenimientos)
        Me.Controls.Add(Me.cmdMantenimientosClaseTres)
        Me.Controls.Add(Me.cmdMantenimientosClaseDos)
        Me.Controls.Add(Me.cmdMantenimientosClaseUno)
        Me.Controls.Add(Me.cmdMantenimientosMedidas)
        Me.Controls.Add(Me.cmdMantenimientosMarcas)
        Me.Controls.Add(Me.LabelControl194)
        Me.Controls.Add(Me.LabelControl182)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ViewMantenimientos"
        Me.Size = New System.Drawing.Size(1340, 696)
        CType(Me.GroupMantenientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupMantenientos.ResumeLayout(False)
        Me.GroupMantenientos.PerformLayout()
        CType(Me.txtMantenimientosCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridMantenimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewMantenimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenMantenimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdMantenimientosBodegas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl212 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdMantenimientosCajas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl208 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl207 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdMantenimientosRutas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMantenimientosCancelarEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupMantenientos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtMantenimientosCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdMantenimientosGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbMantenimientosDescripcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbMantenimientosCodigo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMantenimientosDescripcion As TextBox
    Friend WithEvents GridMantenimientos As DevExpress.XtraGrid.GridControl
    Friend WithEvents TileViewMantenimientos As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents cmdMantenimientosClaseTres As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMantenimientosClaseDos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMantenimientosClaseUno As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMantenimientosMedidas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMantenimientosMarcas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl194 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl182 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadMenMantenimientos As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cmdRadMenMantenimientosEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdRadMenMantenimientosEliminar As DevExpress.XtraBars.BarButtonItem
End Class
