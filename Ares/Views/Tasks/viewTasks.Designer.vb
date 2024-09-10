<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewTasks
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
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement7 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement8 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement9 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement10 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewTasks))
        Me.colFECHA = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colRESPONSABLE = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colPRIORIDAD = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colTAREA = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.GridTareas = New DevExpress.XtraGrid.GridControl()
        Me.TblTasksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.TileViewTareas = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.colID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.btnGuardarTarea = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnCancelarTarea = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMinuto = New System.Windows.Forms.ComboBox()
        Me.cmbHora = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbPrioridad = New System.Windows.Forms.ComboBox()
        Me.cmbResponsable = New System.Windows.Forms.ComboBox()
        Me.txtTarea = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.FlyoutPanelNuevaTarea = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControlNueva = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnNuevaTarea = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.GridTareas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTasksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewTareas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelNuevaTarea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelNuevaTarea.SuspendLayout()
        CType(Me.FlyoutPanelControlNueva, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControlNueva.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 1
        Me.colFECHA.Width = 79
        '
        'colRESPONSABLE
        '
        Me.colRESPONSABLE.FieldName = "RESPONSABLE"
        Me.colRESPONSABLE.Name = "colRESPONSABLE"
        Me.colRESPONSABLE.Visible = True
        Me.colRESPONSABLE.VisibleIndex = 3
        Me.colRESPONSABLE.Width = 195
        '
        'colPRIORIDAD
        '
        Me.colPRIORIDAD.FieldName = "PRIORIDAD"
        Me.colPRIORIDAD.Name = "colPRIORIDAD"
        Me.colPRIORIDAD.Visible = True
        Me.colPRIORIDAD.VisibleIndex = 4
        Me.colPRIORIDAD.Width = 110
        '
        'colTAREA
        '
        Me.colTAREA.FieldName = "TAREA"
        Me.colTAREA.Name = "colTAREA"
        Me.colTAREA.Visible = True
        Me.colTAREA.VisibleIndex = 2
        Me.colTAREA.Width = 415
        '
        'GridTareas
        '
        Me.GridTareas.DataSource = Me.TblTasksBindingSource
        Me.GridTareas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTareas.Location = New System.Drawing.Point(2, 20)
        Me.GridTareas.MainView = Me.TileViewTareas
        Me.GridTareas.Name = "GridTareas"
        Me.GridTareas.Size = New System.Drawing.Size(793, 484)
        Me.GridTareas.TabIndex = 0
        Me.GridTareas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileViewTareas})
        '
        'TblTasksBindingSource
        '
        Me.TblTasksBindingSource.DataMember = "tblTasks"
        Me.TblTasksBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TileViewTareas
        '
        Me.TileViewTareas.Appearance.ItemNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TileViewTareas.Appearance.ItemNormal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TileViewTareas.Appearance.ItemNormal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TileViewTareas.Appearance.ItemNormal.Options.UseBackColor = True
        Me.TileViewTareas.Appearance.ItemNormal.Options.UseBorderColor = True
        Me.TileViewTareas.Appearance.ItemNormal.Options.UseForeColor = True
        Me.TileViewTareas.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TileViewTareas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colFECHA, Me.colTAREA, Me.colRESPONSABLE, Me.colPRIORIDAD})
        Me.TileViewTareas.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TileViewTareas.GridControl = Me.GridTareas
        Me.TileViewTareas.Name = "TileViewTareas"
        Me.TileViewTareas.OptionsFind.FindNullPrompt = "Escriba para filtrar..."
        Me.TileViewTareas.OptionsTiles.AllowItemHover = True
        Me.TileViewTareas.OptionsTiles.ColumnCount = 1
        Me.TileViewTareas.OptionsTiles.HighlightFocusedTileOnGridLoad = True
        Me.TileViewTareas.OptionsTiles.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TileViewTareas.OptionsTiles.IndentBetweenItems = 5
        Me.TileViewTareas.OptionsTiles.ItemPadding = New System.Windows.Forms.Padding(12, 5, 12, 8)
        Me.TileViewTareas.OptionsTiles.ItemSize = New System.Drawing.Size(750, 70)
        Me.TileViewTareas.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileViewTareas.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top
        Me.TileViewTareas.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        TileViewItemElement6.Appearance.Normal.BackColor = System.Drawing.Color.Yellow
        TileViewItemElement6.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        TileViewItemElement6.Appearance.Normal.ForeColor = System.Drawing.Color.DimGray
        TileViewItemElement6.Appearance.Normal.Options.UseBackColor = True
        TileViewItemElement6.Appearance.Normal.Options.UseFont = True
        TileViewItemElement6.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement6.Column = Me.colFECHA
        TileViewItemElement6.StretchHorizontal = True
        TileViewItemElement6.Text = "colFECHA"
        TileViewItemElement7.Column = Me.colRESPONSABLE
        TileViewItemElement7.Text = "colRESPONSABLE"
        TileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement7.TextLocation = New System.Drawing.Point(100, 0)
        TileViewItemElement8.Column = Me.colPRIORIDAD
        TileViewItemElement8.Text = "colPRIORIDAD"
        TileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight
        TileViewItemElement9.Column = Me.colTAREA
        TileViewItemElement9.Text = "colTAREA"
        TileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement9.TextLocation = New System.Drawing.Point(0, 20)
        TileViewItemElement10.Image = CType(resources.GetObject("TileViewItemElement10.Image"), System.Drawing.Image)
        TileViewItemElement10.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight
        TileViewItemElement10.Text = ""
        Me.TileViewTareas.TileTemplate.Add(TileViewItemElement6)
        Me.TileViewTareas.TileTemplate.Add(TileViewItemElement7)
        Me.TileViewTareas.TileTemplate.Add(TileViewItemElement8)
        Me.TileViewTareas.TileTemplate.Add(TileViewItemElement9)
        Me.TileViewTareas.TileTemplate.Add(TileViewItemElement10)
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'btnGuardarTarea
        '
        Me.btnGuardarTarea.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardarTarea.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnGuardarTarea.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardarTarea.Appearance.Options.UseBackColor = True
        Me.btnGuardarTarea.Appearance.Options.UseFont = True
        Me.btnGuardarTarea.Appearance.Options.UseForeColor = True
        Me.btnGuardarTarea.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnGuardarTarea.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardarTarea.Location = New System.Drawing.Point(203, 318)
        Me.btnGuardarTarea.Name = "btnGuardarTarea"
        Me.btnGuardarTarea.Size = New System.Drawing.Size(135, 53)
        Me.btnGuardarTarea.TabIndex = 6
        Me.btnGuardarTarea.Text = "GUARDAR"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnCancelarTarea)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.cmbMinuto)
        Me.GroupControl1.Controls.Add(Me.cmbHora)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.cmbPrioridad)
        Me.GroupControl1.Controls.Add(Me.cmbResponsable)
        Me.GroupControl1.Controls.Add(Me.txtTarea)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtFecha)
        Me.GroupControl1.Controls.Add(Me.btnGuardarTarea)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 58)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(380, 399)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Nueva Tarea"
        '
        'btnCancelarTarea
        '
        Me.btnCancelarTarea.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCancelarTarea.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.btnCancelarTarea.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelarTarea.Appearance.Options.UseBackColor = True
        Me.btnCancelarTarea.Appearance.Options.UseFont = True
        Me.btnCancelarTarea.Appearance.Options.UseForeColor = True
        Me.btnCancelarTarea.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelarTarea.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelarTarea.Location = New System.Drawing.Point(37, 318)
        Me.btnCancelarTarea.Name = "btnCancelarTarea"
        Me.btnCancelarTarea.Size = New System.Drawing.Size(135, 53)
        Me.btnCancelarTarea.TabIndex = 12
        Me.btnCancelarTarea.Text = "CANCELAR"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(21, 40)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Fecha y hora:"
        '
        'cmbMinuto
        '
        Me.cmbMinuto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMinuto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMinuto.FormattingEnabled = True
        Me.cmbMinuto.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55"})
        Me.cmbMinuto.Location = New System.Drawing.Point(283, 40)
        Me.cmbMinuto.Name = "cmbMinuto"
        Me.cmbMinuto.Size = New System.Drawing.Size(55, 21)
        Me.cmbMinuto.TabIndex = 10
        '
        'cmbHora
        '
        Me.cmbHora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbHora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbHora.FormattingEnabled = True
        Me.cmbHora.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cmbHora.Location = New System.Drawing.Point(228, 40)
        Me.cmbHora.Name = "cmbHora"
        Me.cmbHora.Size = New System.Drawing.Size(52, 21)
        Me.cmbHora.TabIndex = 9
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(21, 222)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Prioridad:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(21, 187)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Responsable:"
        '
        'cmbPrioridad
        '
        Me.cmbPrioridad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPrioridad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPrioridad.FormattingEnabled = True
        Me.cmbPrioridad.Items.AddRange(New Object() {"BAJA", "MEDIA", "ALTA"})
        Me.cmbPrioridad.Location = New System.Drawing.Point(94, 219)
        Me.cmbPrioridad.Name = "cmbPrioridad"
        Me.cmbPrioridad.Size = New System.Drawing.Size(121, 21)
        Me.cmbPrioridad.TabIndex = 5
        '
        'cmbResponsable
        '
        Me.cmbResponsable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbResponsable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.Location = New System.Drawing.Point(94, 184)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(180, 21)
        Me.cmbResponsable.TabIndex = 4
        '
        'txtTarea
        '
        Me.txtTarea.Location = New System.Drawing.Point(25, 100)
        Me.txtTarea.MaxLength = 250
        Me.txtTarea.Multiline = True
        Me.txtTarea.Name = "txtTarea"
        Me.txtTarea.Size = New System.Drawing.Size(313, 53)
        Me.txtTarea.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(21, 81)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Tarea:"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(113, 41)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(107, 20)
        Me.txtFecha.TabIndex = 2
        '
        'FlyoutPanelNuevaTarea
        '
        Me.FlyoutPanelNuevaTarea.Controls.Add(Me.FlyoutPanelControlNueva)
        Me.FlyoutPanelNuevaTarea.Location = New System.Drawing.Point(30, 21)
        Me.FlyoutPanelNuevaTarea.Name = "FlyoutPanelNuevaTarea"
        Me.FlyoutPanelNuevaTarea.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Left
        Me.FlyoutPanelNuevaTarea.Options.CloseOnOuterClick = True
        Me.FlyoutPanelNuevaTarea.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left
        Me.FlyoutPanelNuevaTarea.OwnerControl = Me
        Me.FlyoutPanelNuevaTarea.Size = New System.Drawing.Size(406, 549)
        Me.FlyoutPanelNuevaTarea.TabIndex = 3
        '
        'FlyoutPanelControlNueva
        '
        Me.FlyoutPanelControlNueva.Controls.Add(Me.GroupControl1)
        Me.FlyoutPanelControlNueva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControlNueva.FlyoutPanel = Me.FlyoutPanelNuevaTarea
        Me.FlyoutPanelControlNueva.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControlNueva.Name = "FlyoutPanelControlNueva"
        Me.FlyoutPanelControlNueva.Size = New System.Drawing.Size(406, 549)
        Me.FlyoutPanelControlNueva.TabIndex = 0
        '
        'btnNuevaTarea
        '
        Me.btnNuevaTarea.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnNuevaTarea.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnNuevaTarea.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaTarea.Appearance.Options.UseBackColor = True
        Me.btnNuevaTarea.Appearance.Options.UseFont = True
        Me.btnNuevaTarea.Appearance.Options.UseForeColor = True
        Me.btnNuevaTarea.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnNuevaTarea.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevaTarea.Location = New System.Drawing.Point(638, 3)
        Me.btnNuevaTarea.Name = "btnNuevaTarea"
        Me.btnNuevaTarea.Size = New System.Drawing.Size(162, 56)
        Me.btnNuevaTarea.TabIndex = 4
        Me.btnNuevaTarea.Text = "Nueva Tarea"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridTareas)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 64)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(797, 506)
        Me.GroupControl2.TabIndex = 5
        Me.GroupControl2.Text = "Listado de Tareas - Doble clic para eliminar"
        '
        'viewTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.btnNuevaTarea)
        Me.Controls.Add(Me.FlyoutPanelNuevaTarea)
        Me.Name = "viewTasks"
        Me.Size = New System.Drawing.Size(805, 601)
        CType(Me.GridTareas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTasksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewTareas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelNuevaTarea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelNuevaTarea.ResumeLayout(False)
        CType(Me.FlyoutPanelControlNueva, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControlNueva.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridTareas As DevExpress.XtraGrid.GridControl
    Friend WithEvents btnGuardarTarea As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblTasksBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbPrioridad As ComboBox
    Friend WithEvents cmbResponsable As ComboBox
    Friend WithEvents txtTarea As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbMinuto As ComboBox
    Friend WithEvents cmbHora As ComboBox
    Friend WithEvents btnCancelarTarea As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FlyoutPanelNuevaTarea As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControlNueva As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnNuevaTarea As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TileViewTareas As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colTAREA As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colRESPONSABLE As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colPRIORIDAD As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
End Class
