Imports DevExpress.XtraGrid.Views.Grid

Public Class viewInventarioOnline

    Sub New(ByVal _empnit As String, ByVal _codprod As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        empnit = _empnit
        codprod = _codprod

    End Sub

    Dim empnit, codprod As String


    Private Sub viewInventarioOnline_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

        If NivelUsuario = 2 Then
            Me.GridView1.Columns.Item(1).Visible = False
            Me.GridView1.Columns.Item(4).Visible = False
            Me.GridView1.Columns.Item(5).Visible = False
        Else
            Me.GridView1.Columns.Item(1).Visible = True
            Me.GridView1.Columns.Item(4).Visible = True
            Me.GridView1.Columns.Item(5).Visible = True
        End If
    End Sub


    Private Sub CargarGrid()
        Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
        Me.GridListado.DataSource = Nothing
        Me.GridListado.DataSource = objs.tblInventarioProductoEmpresas(empnit, codprod)


    End Sub

    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("SALDO"))
            If category = 0 Then
                e.Appearance.BackColor = Color.LightSalmon
                e.HighPriority = True
            End If
            If category < 0 Then
                e.Appearance.BackColor = Color.FromArgb(255, 204, 153)
                e.HighPriority = True
            End If
        End If
    End Sub

End Class
