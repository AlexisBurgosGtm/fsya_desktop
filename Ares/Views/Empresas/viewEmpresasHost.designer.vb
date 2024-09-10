<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewEmpresasHost
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gridHOSTING = New DevExpress.XtraGrid.GridControl()
        Me.GridViewHOSTING = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.cmBCATALOGO = New System.Windows.Forms.ComboBox()
        Me.btnGUARDAR = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCANCELAR = New DevExpress.XtraEditors.SimpleButton()
        Me.cmBHABILITADA = New System.Windows.Forms.ComboBox()
        Me.cmBDOMICILIO = New System.Windows.Forms.ComboBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNOMSUCURSAL = New DevExpress.XtraEditors.TextEdit()
        Me.txtCODSUCURSAL = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridHOSTING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewHOSTING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.txtNOMSUCURSAL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCODSUCURSAL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gridHOSTING)
        Me.GroupControl1.Location = New System.Drawing.Point(28, 77)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(842, 602)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "EMPRESAS EN EL HOSTING"
        '
        'gridHOSTING
        '
        Me.gridHOSTING.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridHOSTING.Location = New System.Drawing.Point(2, 20)
        Me.gridHOSTING.MainView = Me.GridViewHOSTING
        Me.gridHOSTING.Name = "gridHOSTING"
        Me.gridHOSTING.Size = New System.Drawing.Size(838, 580)
        Me.gridHOSTING.TabIndex = 1
        Me.gridHOSTING.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewHOSTING})
        '
        'GridViewHOSTING
        '
        Me.GridViewHOSTING.GridControl = Me.gridHOSTING
        Me.GridViewHOSTING.Name = "GridViewHOSTING"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(433, 18)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(452, 33)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "GESTION DE EMPRESAS EN HOSTING"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.LabelControl6)
        Me.GroupControl3.Controls.Add(Me.cmBCATALOGO)
        Me.GroupControl3.Controls.Add(Me.btnGUARDAR)
        Me.GroupControl3.Controls.Add(Me.btnCANCELAR)
        Me.GroupControl3.Controls.Add(Me.cmBHABILITADA)
        Me.GroupControl3.Controls.Add(Me.cmBDOMICILIO)
        Me.GroupControl3.Controls.Add(Me.LabelControl5)
        Me.GroupControl3.Controls.Add(Me.LabelControl4)
        Me.GroupControl3.Controls.Add(Me.LabelControl3)
        Me.GroupControl3.Controls.Add(Me.LabelControl2)
        Me.GroupControl3.Controls.Add(Me.txtNOMSUCURSAL)
        Me.GroupControl3.Controls.Add(Me.txtCODSUCURSAL)
        Me.GroupControl3.Location = New System.Drawing.Point(876, 77)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(440, 602)
        Me.GroupControl3.TabIndex = 3
        Me.GroupControl3.Text = "DATOS DE LA EMPRESA"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(176, 123)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "CATALOGO"
        '
        'cmBCATALOGO
        '
        Me.cmBCATALOGO.FormattingEnabled = True
        Me.cmBCATALOGO.Items.AddRange(New Object() {"A", "B", "C", "D"})
        Me.cmBCATALOGO.Location = New System.Drawing.Point(176, 142)
        Me.cmBCATALOGO.Name = "cmBCATALOGO"
        Me.cmBCATALOGO.Size = New System.Drawing.Size(128, 21)
        Me.cmBCATALOGO.TabIndex = 12
        '
        'btnGUARDAR
        '
        Me.btnGUARDAR.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGUARDAR.Location = New System.Drawing.Point(234, 251)
        Me.btnGUARDAR.Name = "btnGUARDAR"
        Me.btnGUARDAR.Size = New System.Drawing.Size(125, 55)
        Me.btnGUARDAR.TabIndex = 11
        Me.btnGUARDAR.Text = "GUARDAR"
        '
        'btnCANCELAR
        '
        Me.btnCANCELAR.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCANCELAR.Location = New System.Drawing.Point(74, 251)
        Me.btnCANCELAR.Name = "btnCANCELAR"
        Me.btnCANCELAR.Size = New System.Drawing.Size(125, 55)
        Me.btnCANCELAR.TabIndex = 10
        Me.btnCANCELAR.Text = "CANCELAR"
        '
        'cmBHABILITADA
        '
        Me.cmBHABILITADA.FormattingEnabled = True
        Me.cmBHABILITADA.Items.AddRange(New Object() {"FARMASALUD", "CERRADA"})
        Me.cmBHABILITADA.Location = New System.Drawing.Point(25, 188)
        Me.cmBHABILITADA.Name = "cmBHABILITADA"
        Me.cmBHABILITADA.Size = New System.Drawing.Size(128, 21)
        Me.cmBHABILITADA.TabIndex = 9
        '
        'cmBDOMICILIO
        '
        Me.cmBDOMICILIO.FormattingEnabled = True
        Me.cmBDOMICILIO.Items.AddRange(New Object() {"0", "1"})
        Me.cmBDOMICILIO.Location = New System.Drawing.Point(25, 142)
        Me.cmBDOMICILIO.Name = "cmBDOMICILIO"
        Me.cmBDOMICILIO.Size = New System.Drawing.Size(128, 21)
        Me.cmBDOMICILIO.TabIndex = 8
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(25, 169)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "HABILITADA"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 123)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "DOMICILIO"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(25, 78)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(128, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "NOMBRE DE LA SUCURSAL"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(112, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "CODIGO DE SUCURSAL"
        '
        'txtNOMSUCURSAL
        '
        Me.txtNOMSUCURSAL.Location = New System.Drawing.Point(25, 97)
        Me.txtNOMSUCURSAL.Name = "txtNOMSUCURSAL"
        Me.txtNOMSUCURSAL.Size = New System.Drawing.Size(393, 20)
        Me.txtNOMSUCURSAL.TabIndex = 1
        '
        'txtCODSUCURSAL
        '
        Me.txtCODSUCURSAL.Enabled = False
        Me.txtCODSUCURSAL.Location = New System.Drawing.Point(25, 52)
        Me.txtCODSUCURSAL.Name = "txtCODSUCURSAL"
        Me.txtCODSUCURSAL.Size = New System.Drawing.Size(393, 20)
        Me.txtCODSUCURSAL.TabIndex = 0
        '
        'viewEmpresasHost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewEmpresasHost"
        Me.Size = New System.Drawing.Size(1340, 696)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gridHOSTING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewHOSTING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.txtNOMSUCURSAL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCODSUCURSAL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridHOSTING As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewHOSTING As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmBHABILITADA As ComboBox
    Friend WithEvents cmBDOMICILIO As ComboBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNOMSUCURSAL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCODSUCURSAL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnGUARDAR As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCANCELAR As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmBCATALOGO As ComboBox
End Class
