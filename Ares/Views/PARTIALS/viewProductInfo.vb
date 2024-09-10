Imports System.Data.SqlClient

Public Class viewProductInfo

    Sub New(ByVal _empnit As String, ByVal _codprod As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        empnit = _empnit
        codprod = _codprod

    End Sub

    Dim empnit, codprod As String


    Private Sub viewProductInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox(empnit + codprod)
        Call LoadData()

    End Sub

    Private Sub LoadData()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, MARCAS.DESMARCA, PRODUCTOS.VENCIMIENTO, PRODUCTOS_FOTOS.FOTO, CLASIFICACIONUNO.DESCLAUNO
                            FROM PRODUCTOS LEFT OUTER JOIN
                         PRODUCTOS_FOTOS ON PRODUCTOS.CODPROD = PRODUCTOS_FOTOS.CODPROD AND PRODUCTOS.EMPNIT = PRODUCTOS_FOTOS.EMPNIT LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT
                        WHERE (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.CODPROD = @CODPROD) OR
                         (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.CODPROD2 = @CODPROD)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtProductoCodigo.Text = dr(0).ToString
                    Me.txtProductoCodigo2.Text = dr(1).ToString
                    Me.txtProductoDescripcion.Text = dr(2).ToString
                    Me.txtProductoDescripcion2.Text = dr(3).ToString
                    Me.txtProductoDescripcion3.Text = dr(4).ToString
                    Me.txtMarca.Text = dr(5).ToString
                    Me.txtProductoFechaVence.DateTime = dr(6)
                    Me.imgProducto.Image = ObtenerImgSql(dr(7))
                End If
                dr.Close()
                cmd.Dispose()

                cn.Close()


            Catch ex As Exception
                MsgBox("Error en datos de producto. Error: " + ex.ToString)
            End Try

        End Using


    End Sub


End Class
