Imports System.Data.SqlClient

Public Class classCompras
    Sub New(ByVal _empnit As String)
        empnit = _empnit
    End Sub

    Dim empnit As String


    Public Function UpdatePrecioCompras(ByVal codprod As String, ByVal codmedida As String, ByVal nuevoprecio As Double, ByVal NmayoreoA As Double, ByVal NmayoreoB As Double, ByVal NmayoreoC As Double, ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE PRECIOS SET PRECIO=@PRECIO,MAYOREOA=@MA,MAYOREOB=@MB, MAYOREOC=@MC WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd.Parameters.AddWithValue("@PRECIO", nuevoprecio)
                cmd.Parameters.AddWithValue("@MA", NmayoreoA)
                cmd.Parameters.AddWithValue("@MB", NmayoreoB)
                cmd.Parameters.AddWithValue("@MC", NmayoreoC)

                cmd.ExecuteNonQuery()

                Try
                    Dim cmd2 As New SqlCommand("UPDATE TEMP_PRECIOSCOMPRA SET PRECIONUEVO=@PRECIO,PRECIONUEVOMA=@MA,PRECIONUEVOMB=@MB,PRECIONUEVOMC=@MC WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                    cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmd2.Parameters.AddWithValue("@CODPROD", codprod)
                    cmd2.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                    cmd2.Parameters.AddWithValue("@PRECIO", nuevoprecio)
                    cmd2.Parameters.AddWithValue("@MA", NmayoreoA)
                    cmd2.Parameters.AddWithValue("@MB", NmayoreoB)
                    cmd2.Parameters.AddWithValue("@MC", NmayoreoC)
                    cmd2.Parameters.AddWithValue("@CODDOC", coddoc)
                    cmd2.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                    cmd2.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("ERROR AL ACTUALIZAR TABLA TEMP " + ex.ToString)
                End Try


                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        Return result

    End Function


    Public Function GenerartblPreciosCompra(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdD As New SqlCommand("DELETE FROM TEMP_PRECIOSCOMPRA WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmdD.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdD.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdD.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmdD.ExecuteNonQuery()

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, MAX(EQUIVALE) AS EQUIVALE, MAX(COSTO) AS COSTO FROM TEMP_VENTAS
                                        GROUP BY CODPROD, DESPROD, CODDOC, CORRELATIVO, EMPNIT, COSTO
                                        HAVING (CODDOC =@CODDOC) AND (CORRELATIVO =@CORRELATIVO) AND (EMPNIT=@EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    If AgregarRowPreciosCompra(dr(0).ToString, (CType(dr(3), Double) / CType(dr(2), Integer)), coddoc, correlativo) = True Then

                    End If
                Loop
                result = True

            Catch ex As Exception
                MsgBox("Error al genera tabla " + ex.ToString)
                GlobalDesError = ex.ToString
                result = False

            End Try

        End Using

        Return result

    End Function

    Private Function AgregarRowPreciosCompra(ByVal codprod As String, ByVal costounitario As Double, ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT PRECIOS.EMPNIT, PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO, PRECIOS.MAYOREOA, PRECIOS.MAYOREOB, PRECIOS.MAYOREOC
                                        FROM PRECIOS LEFT OUTER JOIN PRODUCTOS ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (PRECIOS.EMPNIT = @EMPNIT) AND (PRECIOS.CODPROD = @CODPROD)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim cmdi As New SqlCommand("INSERT INTO TEMP_PRECIOSCOMPRA 
                            (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,COSTOACTUAL,COSTONUEVO,PRECIOACTUAL,PRECIONUEVO,PRECIOACTUALMA,PRECIONUEVOMA,PRECIOACTUALMB,PRECIONUEVOMB,PRECIOACTUALMC,PRECIONUEVOMC)
                     VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@COSTOACTUAL,@COSTONUEVO,@PRECIOACTUAL,@PRECIONUEVO,@PAMA,@PNMA,@PAMB,@PNMB,@PAMC,@PNMC)", cn)

                    cmdi.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmdi.Parameters.AddWithValue("@CODDOC", coddoc)
                    cmdi.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                    cmdi.Parameters.AddWithValue("@CODPROD", dr(1).ToString)
                    cmdi.Parameters.AddWithValue("@DESPROD", dr(2).ToString)
                    cmdi.Parameters.AddWithValue("@CODMEDIDA", dr(3).ToString)
                    cmdi.Parameters.AddWithValue("@EQUIVALE", CType(dr(4), Integer))
                    cmdi.Parameters.AddWithValue("@COSTOACTUAL", CType(dr(5), Double))
                    cmdi.Parameters.AddWithValue("@COSTONUEVO", CType(dr(4), Integer) * costounitario)
                    cmdi.Parameters.AddWithValue("@PRECIOACTUAL", CType(dr(6), Double))
                    cmdi.Parameters.AddWithValue("@PRECIONUEVO", CType(dr(6), Double))

                    cmdi.Parameters.AddWithValue("@PAMA", CType(dr(7), Double))
                    cmdi.Parameters.AddWithValue("@PNMA", CType(dr(7), Double))
                    cmdi.Parameters.AddWithValue("@PAMB", CType(dr(8), Double))
                    cmdi.Parameters.AddWithValue("@PNMB", CType(dr(8), Double))
                    cmdi.Parameters.AddWithValue("@PAMC", CType(dr(9), Double))
                    cmdi.Parameters.AddWithValue("@PNMC", CType(dr(9), Double))

                    cmdi.ExecuteNonQuery()
                Loop
                result = True
            Catch ex As Exception
                MsgBox("Error al agregar linea a tabla temp_precioscompra " + ex.ToString)
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        Return result

    End Function

    Public Function tblPreciosCompra(ByVal coddoc As String, ByVal correlativo As Double) As DataTable
        Dim tbl As New DSPRODUCTOS.tblPreciosCompraDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD,DESPROD,CODMEDIDA,EQUIVALE,COSTOACTUAL,COSTONUEVO,PRECIOACTUAL,PRECIONUEVO,PRECIOACTUALMA AS ACTUAL_MAY_A,PRECIONUEVOMA AS NUEVO_MAY_A,PRECIOACTUALMB AS ACTUAL_MAY_B,PRECIONUEVOMB AS NUEVO_MAY_B,PRECIOACTUALMC AS ACTUAL_MAY_C,PRECIONUEVOMC AS NUEVO_MAY_C FROM TEMP_PRECIOSCOMPRA WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("Error al cargar tabla temp_precioscompra " + GlobalDesError)
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


End Class
