Imports System.Data.SqlClient

Public Class viewConfigUpdater

    Private Function executeQry(ByVal qry As String, ByVal tabla As String) As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand(qry, cn)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i = 1 Then
                    MsgBox(tabla + " actualizado exitosamente")
                Else
                    MsgBox("No se Actualizó la tabla " + tabla)
                End If
            Catch ex As Exception
                MsgBox("No se Actualizó la tabla " + tabla)
            End Try

            cn.Close()

        End Using

        Return True

    End Function


    Private Sub btnTipoDocs_Click(sender As Object, e As EventArgs) Handles btnTipoDocs.Click
        Call executeQry("ALTER TABLE TIPODOCUMENTOS ADD ACTIVO VARCHAR(2) NULL;", "TIPODOCUMENTOS")
        Call executeQry("ALTER TABLE TIPODOCUMENTOS ADD TIPOMOV VARCHAR(10) NULL;", "TIPODOCUMENTOS")
        Call executeQry("ALTER TABLE TIPODOCUMENTOS ADD TIPOM INT NULL;", "TIPODOCUMENTOS")
    End Sub

    Private Sub btnTblProveedores_Click(sender As Object, e As EventArgs) Handles btnTblProveedores.Click
        Call executeQry("ALTER TABLE PROVEEDORES ADD SALDO FLOAT NULL;", "PROVEEDORES")
    End Sub

    Private Sub btnTblDocumentos_Click(sender As Object, e As EventArgs) Handles btnTblDocumentos.Click
        Call executeQry("ALTER TABLE DOCUMENTOS ADD TOTALEXENTO FLOAT NULL;", "DOCUMENTOS")
        Call executeQry("ALTER TABLE DOCUMENTOS ADD LAT FLOAT NULL;", "DOCUMENTOS")
        Call executeQry("ALTER TABLE DOCUMENTOS ADD LONG FLOAT NULL;", "DOCUMENTOS")
        Call executeQry("ALTER TABLE DOCUMENTOS ADD TIPOPAGO VARCHAR(10) NULL;", "DOCUMENTOS")
        Call executeQry("ALTER TABLE DOCUMENTOS ADD NODOCPAGO VARCHAR(15) NULL;", "DOCUMENTOS")
    End Sub


    Private Sub btnTblTempVentas_Click(sender As Object, e As EventArgs) Handles btnTblTempVentas.Click
        Dim dropquery As String = "DROP TABLE TEMP_VENTAS;"
        Dim qry As String = "CREATE TABLE [dbo].[TEMP_VENTAS](
	                            [ID] [int] IDENTITY(1,1) NOT NULL,
	                            [EMPNIT] [varchar](50) NULL,
	                            [CODDOC] [varchar](50) NULL,
	                            [CORRELATIVO] [numeric](18, 0) NULL,
	                            [CODPROD] [varchar](200) NULL,
	                            [DESPROD] [varchar](255) NULL,
	                            [CODMEDIDA] [varchar](50) NULL,
	                            [EQUIVALE] [int] NULL,
	                            [CANTIDAD] [int] NULL,
	                            [TOTALUNIDADES] [int] NULL,
	                            [COSTO] [numeric](18, 3) NULL,
	                            [PRECIO] [numeric](18, 2) NULL,
	                            [UTILIDAD] [numeric](18, 2) NULL,
	                            [TOTALCOSTO] [numeric](18, 3) NULL,
	                            [TOTALPRECIO] [numeric](18, 2) NULL,
	                            [BONIF] [int] NULL,
	                            [TOTALBONIF] [int] NULL,
	                            [NOSERIE] [varchar](100) NULL,
	                            [DESCUENTO] [numeric](18, 2) NULL,
	                            [PORCDESCUENTO] [numeric](18, 2) NULL,
	                            [USUARIO] [varchar](100) NULL,
	                            [EXENTO] [float] NULL,
	                            [NOLOTE] [varchar](100) NULL,
                                [OBS] [varchar](100) NULL,
                            ) ON [PRIMARY]"

        Call executeQry(dropquery + qry, "TEMP_VENTAS")
    End Sub

    Private Sub btnNavegar_Click(sender As Object, e As EventArgs) Handles btnNavegar.Click
        Call executeQry("CREATE TABLE [dbo].[NAVEGAR](
	                        [NAVEGAR] [varchar](50) NOT NULL,
	                        [DESCRIPCION] [varchar](150) NULL,
	                        [ACTIVO] [varchar](2) NULL,
                        CONSTRAINT [PK_NAVEGAR] PRIMARY KEY CLUSTERED 
                        (
	                        [NAVEGAR] ASC
                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                        ) ON [PRIMARY]", "NAVEGAR")
    End Sub

    Private Sub btnPRODUCTOS_Click(sender As Object, e As EventArgs) Handles btnPRODUCTOS.Click
        Dim qry As String

        qry = "ALTER TABLE PRODUCTOS ADD TIPOPROD VARCHAR(1) NULL;"

        Call executeQry(qry, "PRODUCTOS")

    End Sub

    Private Sub btnCortes_Click(sender As Object, e As EventArgs) Handles btnCortes.Click

        Try
            Call executeQry("ALTER TABLE CORTES ADD CODCAJA INT NULL;", "CORTES")
        Catch ex As Exception

        End Try

        Try
            Call executeQry("ALTER TABLE CORTES ADD TOTALTARJETA NUMERIC(18,2) NULL;", "CORTES")
        Catch ex As Exception

        End Try

        Try
            Call executeQry("ALTER TABLE CORTES ADD REPORTADOTARJETA NUMERIC(18,2) NULL;", "CORTES")
        Catch ex As Exception

        End Try

        Try
            Call executeQry("ALTER TABLE CORTES ADD TOTALCHEQUES NUMERIC(18,2) NULL;", "CORTES")
        Catch ex As Exception

        End Try

        Try
            Call executeQry("ALTER TABLE CORTES ADD REPORTADOCHEQUES NUMERIC(18,2) NULL;", "CORTES")
        Catch ex As Exception

        End Try

        Try
            Call executeQry("ALTER TABLE CORTES ADD ENVIADO SMALLINT NULL;", "CORTES")
        Catch ex As Exception

        End Try



    End Sub

End Class
