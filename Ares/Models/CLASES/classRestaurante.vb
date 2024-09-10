
Imports System.Data.SqlClient

Public Class classRestaurante
    Sub New()

    End Sub

    Public Property DesError As String


    Public Function fcnEliminarPedido(ByVal empnit As String, ByVal idMesa As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_COMANDA WHERE EMPNIT = @E AND IDMESA = @M;
                                        UPDATE RESTAURANTE_MESAS SET OCUPADA='NO', CUENTA='NO' WHERE EMPNIT = @E AND ID = @M;", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@M", idMesa)
                cmd.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try

        End Using

        Return r

    End Function

    Public Function fcnFacturarComanda(ByVal Coddoc As String, ByVal idMesa As Integer) As Boolean

        Dim result As Boolean

        'NAVEGA A LA VENTANA DE FACTURACION PARA PREPARAR LOS CORRELATIVOS
        NAVEGAR("VENTAS")


        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd0 As New SqlCommand("DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC = 'FAC')", cn)
                cmd0.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd0.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd0.ExecuteNonQuery()
                cmd0.Dispose()

                'ASIGNA LOS VALORES DEL ENCABEZADO DEL PEDIDO A LA VENTANA DE FACTURACIÓN
                'Form1.txtVentasCodCliente.Text = ""
                Form1.txtVentasNitClie.Text = "CF"
                'Form1.txtVentasNombre.Text = drw.Item(5).ToString
                'Form1.cmbVentasVendedor.SelectedValue = Integer.Parse(drw.Item(2))
                'Form1.cmbVentasVendedor.Text = drw.Item(3).ToString
                'VentasCodRepartidor = CType(drw.Item(16), Integer)
                VentasObs = "SN"
            End Using

            GoTo DetallePedido

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
            Call NAVEGAR("COMANDAS")
            GoTo Finalizar
        End Try


DetallePedido:


        'CARGA LOS DATOS DEL DETALLE A LA TABLA TEMP_VENTAS
        Try
            Using cnHost As New SqlConnection(strSqlConectionString)
                If cnHost.State <> ConnectionState.Open Then
                    cnHost.Open()
                End If

                Dim sql As String
                sql = "SELECT CODPROD,DESPROD,CODMEDIDA,CANTIDAD,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,EQUIVALE,OBS FROM TEMP_COMANDA WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND IDMESA=@IDMESA"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@IDMESA", idMesa)

                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read

                    'ASIGNA EL CODIGO DEL REPARTIDOR SI EXISTE
                    VentasCodRepartidor = 0
                    Using cn As New SqlConnection(strSqlConectionString)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If


                        Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas 
                       (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALBONIF,EXENTO,USUARIO,OBS) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@TOTALBONIF,@EXENTO,@USUARIO,@OBS)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                        cmd.Parameters.AddWithValue("@DESPROD", dr(1).ToString)
                        cmd.Parameters.AddWithValue("@CODMEDIDA", dr(2).ToString)
                        cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(dr(3)))
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(dr(4)))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(dr(5)))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(dr(6)))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(dr(7)))
                        cmd.Parameters.AddWithValue("@EXENTO", 0)
                        cmd.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(dr(8)))
                        cmd.Parameters.AddWithValue("@TOTALUNIDADES", Integer.Parse(dr(8)) * Double.Parse(dr(3)))
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                        cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                        cmd.Parameters.AddWithValue("@OBS", dr(9).ToString)

                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            Dim oInv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            oInv.fcn_InsertarSalidaProducto(dr(0).ToString, Integer.Parse(dr(8)) * Double.Parse(dr(3)))
                        End If
                        cmd.Dispose()

                    End Using
                Loop

                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                cnHost.Close()

            End Using

            Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Form1.txtVentasCorrelativo.Text))
            Call CargarGridTempVentas()

            result = True

        Catch ex As Exception
            MsgBox("Error al cargar el detalle . " & ex.ToString)
            GlobalDesError = ex.ToString
            result = False
            Call NAVEGAR("COMANDAS")

        End Try

Finalizar:


        Return result

    End Function


    Public Function insertMesa(ByVal empnit As String, ByVal codigo As String, ByVal descripcion As String) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO RESTAURANTE_MESAS (EMPNIT,CODMESA,DESMESA,OCUPADA,CUENTA) VALUES (@E,@C,@D,'NO','NO')", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codigo)
                cmd.Parameters.AddWithValue("@D", descripcion)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    Public Function updateMesa(ByVal id As Integer, ByVal codigo As String, ByVal descripcion As String) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE RESTAURANTE_MESAS SET CODMESA=@C,DESMESA=@D WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@C", codigo)
                cmd.Parameters.AddWithValue("@D", descripcion)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    Public Function desocuparMesa(ByVal id As Integer) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE RESTAURANTE_MESAS SET OCUPADA='NO',CUENTA='NO' WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", id)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    Public Function deleteMesa(ByVal id As Integer) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM RESTAURANTE_MESAS WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", id)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function


End Class
