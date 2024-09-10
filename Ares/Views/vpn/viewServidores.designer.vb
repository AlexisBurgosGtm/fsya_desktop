<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewServidores
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridListado = New DevExpress.XtraGrid.GridControl()
        Me.GridViewListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPass = New DevExpress.XtraEditors.TextEdit()
        Me.txtUser = New DevExpress.XtraEditors.TextEdit()
        Me.txtDb = New DevExpress.XtraEditors.TextEdit()
        Me.txtServer = New DevExpress.XtraEditors.TextEdit()
        Me.txtSucursal = New DevExpress.XtraEditors.TextEdit()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridListado)
        Me.GroupControl1.Location = New System.Drawing.Point(16, 152)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(958, 377)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Listado de Servidores"
        '
        'GridListado
        '
        Me.GridListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridListado.Location = New System.Drawing.Point(2, 20)
        Me.GridListado.MainView = Me.GridViewListado
        Me.GridListado.Name = "GridListado"
        Me.GridListado.Size = New System.Drawing.Size(954, 355)
        Me.GridListado.TabIndex = 0
        Me.GridListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListado})
        '
        'GridViewListado
        '
        Me.GridViewListado.GridControl = Me.GridListado
        Me.GridViewListado.Name = "GridViewListado"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.btnGuardar)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.txtPass)
        Me.GroupControl2.Controls.Add(Me.txtUser)
        Me.GroupControl2.Controls.Add(Me.txtDb)
        Me.GroupControl2.Controls.Add(Me.txtServer)
        Me.GroupControl2.Controls.Add(Me.txtSucursal)
        Me.GroupControl2.Controls.Add(Me.btnAceptarTrue)
        Me.GroupControl2.Location = New System.Drawing.Point(98, 15)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(874, 131)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Datos del Servidor"
        '
        'btnGuardar
        '
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(592, 57)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(124, 51)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(301, 95)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Contraseña:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(301, 61)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Usuario:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(24, 95)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Database:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(24, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Server:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Sucursal:"
        '
        'txtPass
        '
        Me.txtPass.EnterMoveNextControl = True
        Me.txtPass.Location = New System.Drawing.Point(371, 93)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(168, 20)
        Me.txtPass.TabIndex = 4
        '
        'txtUser
        '
        Me.txtUser.EnterMoveNextControl = True
        Me.txtUser.Location = New System.Drawing.Point(371, 58)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(168, 20)
        Me.txtUser.TabIndex = 3
        '
        'txtDb
        '
        Me.txtDb.EnterMoveNextControl = True
        Me.txtDb.Location = New System.Drawing.Point(82, 93)
        Me.txtDb.Name = "txtDb"
        Me.txtDb.Size = New System.Drawing.Size(193, 20)
        Me.txtDb.TabIndex = 2
        '
        'txtServer
        '
        Me.txtServer.EnterMoveNextControl = True
        Me.txtServer.Location = New System.Drawing.Point(82, 58)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(193, 20)
        Me.txtServer.TabIndex = 1
        '
        'txtSucursal
        '
        Me.txtSucursal.EnterMoveNextControl = True
        Me.txtSucursal.Location = New System.Drawing.Point(82, 22)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(282, 20)
        Me.txtSucursal.TabIndex = 0
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(422, 161)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptarTrue.TabIndex = 12
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar true"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(901, 7)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(73, 50)
        Me.SimpleButton2.TabIndex = 11
        Me.SimpleButton2.Text = "Cerrar (x)"
        Me.SimpleButton2.Visible = False
        '
        'viewServidores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewServidores"
        Me.Size = New System.Drawing.Size(988, 556)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDb As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSucursal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListado As DevExpress.XtraGrid.Views.Grid.GridView
End Class
