Imports System.Data.SqlClient

Public Class ClassProductos
    Sub New()

    End Sub

    Public Function deleteBackupProductosSync(ByVal empnit As String) As Boolean
        Dim r As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM PRODUCTOS WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM PRECIOS WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM INVSALDO WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM MEDIDAS WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM MARCAS WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM CLASIFICACIONUNO WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM CLASIFICACIONDOS WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM CLASIFICACIONTRES WHERE EMPNIT LIKE 'BACKUP%';
                                        DELETE FROM PROVEEDORES WHERE EMPNIT LIKE 'BACKUP%';", cn)
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                r = False
            End Try

        End Using
        Return r

    End Function


    Public Function getPrecioProducto(ByVal codprod As String) As Double

        Dim precio As Double = 0
        'retorna el precio de un producto y asigna el valor del costo, 
        'el costo lo agregué de esa forma porque no lo consideré inicialmente
        'igual el costo solo me sirve para comprobar el precio
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TOP 1 PRECIO, COSTO 
                                    FROM PRECIOS    
                                    WHERE EMPNIT=@E AND CODPROD=@C 
                                    ORDER BY EQUIVALE", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    precio = CType(dr(0), Double)
                    GlobalVentasModoCodigoCosto = CType(dr(1), Double)
                Else
                    precio = 0
                    GlobalVentasModoCodigoCosto = 0
                End If

            Catch ex As Exception
                precio = 0
                GlobalVentasModoCodigoCosto = 0
            End Try
        End Using

        Return precio

    End Function

    '******************************************************************************
    'RUTINA SIN TERMINAR - CAMBIA COSTOS DE PRODUCTOS SEGÚN UNA COMPRA ESPECÍFICA
    '******************************************************************************

    Public Function setCostosProductosCompra(ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INICIA UN BUCLE PARA LEER LOS COSTOS UNITARIOS DE LA TABLA PRODUCTOS
                Dim cmd As New SqlCommand("SELECT CODPROD, COSTO FROM PRODUCTOS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.CommandTimeout = 0
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read

                    Dim codProd As String = dr(0).ToString
                    Dim costoUnitario As Double = Double.Parse(dr(1))

                    Dim cmd0 As New SqlCommand("SELECT EMPNIT, CODPROD, CODMEDIDA, EQUIVALE, COSTO, PRECIO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & codProd & "'", cn)
                    Dim dr7 As SqlDataReader = cmd0.ExecuteReader
                    Do While dr7.Read
                        If fcn_UpdateCostosProducto(GlobalEmpNit, dr7(1).ToString, dr7(2).ToString, Math.Round((Integer.Parse(dr7(3)) * costoUnitario), 4), Math.Round(Integer.Parse(dr7(3)) * (dr7(5) - costoUnitario), 2)) = True Then
                        End If
                    Loop
                Loop

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    '******************************************************************************
    '******************************************************************************

    Public Function setCostosProductos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INICIA UN BUCLE PARA LEER LOS COSTOS UNITARIOS DE LA TABLA PRODUCTOS
                Dim cmd As New SqlCommand("SELECT CODPROD, COSTO FROM PRODUCTOS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.CommandTimeout = 0
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read

                    Dim codProd As String = dr(0).ToString
                    Dim costoUnitario As Double = Double.Parse(dr(1))

                    Dim cmd0 As New SqlCommand("SELECT EMPNIT, CODPROD, CODMEDIDA, EQUIVALE, COSTO, PRECIO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & codProd & "'", cn)
                    Dim dr7 As SqlDataReader = cmd0.ExecuteReader
                    Do While dr7.Read
                        If fcn_UpdateCostosProducto(GlobalEmpNit, dr7(1).ToString, dr7(2).ToString, Math.Round((Integer.Parse(dr7(3)) * costoUnitario), 4), Math.Round(Integer.Parse(dr7(3)) * (dr7(5) - costoUnitario), 2)) = True Then
                        End If
                    Loop
                Loop

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'RUTINA QUE ACTUALIZA LOS COSTOS POR CADA PRECIO DEL PRODUCTO

    Private Function InsertarTempCosto(ByVal codprod As String, ByVal costo As Double, ByVal Precio As Double) As Boolean

        Dim result As Boolean



        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'SELECCIONA LOS PRECIOS DEL PRODUCTO SELECCIONADO

            Try

                Dim cmd0 As New SqlCommand("SELECT EMPNIT, CODPROD, CODMEDIDA, EQUIVALE, COSTO, PRECIO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & codprod & "'", cn)
                Dim dr7 As SqlDataReader = cmd0.ExecuteReader
                Do While dr7.Read
                    If fcn_UpdateCostosProducto(GlobalEmpNit, codprod, dr7(2).ToString, Math.Round((Integer.Parse(dr7(3)) * costo), 4), Math.Round(Integer.Parse(dr7(3)) * (Precio - costo), 2)) = True Then
                    End If
                Loop
                'dr7.Close()
                'cmd0.Dispose()

                '-------------nuevo --------------------------
                'actualiza el costo unitario de la tabla productos

                Dim cmdUP As New SqlCommand("UPDATE PRODUCTOS SET COSTO=@COSTO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmdUP.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdUP.Parameters.AddWithValue("@CODPROD", codprod)
                cmdUP.Parameters.AddWithValue("@COSTO", costo)
                cmdUP.ExecuteNonQuery()
                'cmdUP.Dispose()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using



        Return result
    End Function


    Private Function fcn_UpdateCostosProducto(ByVal empnit As String, ByVal codprod As String, ByVal codmedida As String, ByVal costo As Double, ByVal utilidad As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Dim objConection As New classConection(cn)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd1 As New SqlCommand("UPDATE PRECIOS SET COSTO=@COSTO, UTILIDAD=@UTILIDAD, PORCUTILIDAD=@PORCUTILIDAD WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)
                cmd1.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd1.Parameters.AddWithValue("@COSTO", costo)
                cmd1.Parameters.AddWithValue("@UTILIDAD", utilidad)
                cmd1.Parameters.AddWithValue("@PORCUTILIDAD", 0)

                result = objConection.EjecutarComandoSql(cmd1)

            Catch ex As Exception
                GlobalDesError = "Error al actualizar costos de producto. " & ex.ToString
                MsgBox(GlobalDesError)
                result = False
            End Try

        End Using





        Return result

    End Function








    Public Function setCatalogoProductosTodasEmpresas(ByVal empnitorigen As String) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'ELIMINA LOS CATÁLOGOS EN LAS EMPRESAS
                Dim cmdeliminar As New SqlCommand("DELETE FROM PRODUCTOS WHERE EMPNIT<>@E;
                                                   DELETE FROM PRODUCTOS_RECETAS WHERE EMPNIT<>@E;
                                                   DELETE FROM PRECIOS WHERE EMPNIT<>@E;
                                                   DELETE FROM INVSALDO WHERE EMPNIT<>@E;
                                                   DELETE FROM MEDIDAS WHERE EMPNIT<>@E;
                                                   DELETE FROM MARCAS WHERE EMPNIT<>@E;
                                                   DELETE FROM CLASIFICACIONUNO WHERE EMPNIT<>@E;
                                                   DELETE FROM CLASIFICACIONDOS WHERE EMPNIT<>@E;
                                                   DELETE FROM CLASIFICACIONTRES WHERE EMPNIT<>@E;
                                                   DELETE FROM PROVEEDORES WHERE EMPNIT<>@E;", cn)
                cmdeliminar.Parameters.AddWithValue("@E", empnitorigen)
                cmdeliminar.CommandTimeout = 0
                cmdeliminar.ExecuteNonQuery()


                'INICIA UN BUCLE PARA LEER TODAS LAS EMPRESAS EXISTENTES
                Dim cmd As New SqlCommand("SELECT EMPNIT FROM EMPRESAS WHERE EMPNIT<>@E", cn)
                cmd.Parameters.AddWithValue("@E", empnitorigen)
                cmd.CommandTimeout = 0
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read


                    'RECETAS
                    Dim cmdR As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, MAINCODPROD, CODPROD, DESPROD, CODMEDIDA, CANTIDAD, EQUIVALE, TOTALUNIDADES, COSTO, TOTALCOSTO FROM PRODUCTOS_RECETAS WHERE EMPNIT=@EMPNIT", cn)
                    cmdR.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdR.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim tblRecetas As New DataTable
                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmdR
                    da.Fill(tblRecetas)
                    Dim bcCopyR As New SqlBulkCopy(strSqlConectionString)
                    bcCopyR.DestinationTableName = "PRODUCTOS_RECETAS"
                    bcCopyR.WriteToServer(tblRecetas)



                    'MEDIDAS
                    Dim cmdMedidas As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODMEDIDA, TIPOPRECIO FROM MEDIDAS WHERE EMPNIT=@EMPNIT", cn)
                    cmdMedidas.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdMedidas.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drMedidas As SqlDataReader = cmdMedidas.ExecuteReader
                    Dim bcCopyMedidas As New SqlBulkCopy(strSqlConectionString)
                    bcCopyMedidas.DestinationTableName = "MEDIDAS"
                    bcCopyMedidas.WriteToServer(drMedidas)
                    drMedidas.Close()

                    'MARCAS
                    Dim cmdMarcas As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODMARCA, DESMARCA FROM MARCAS WHERE EMPNIT=@EMPNIT", cn)
                    cmdMarcas.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdMarcas.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drMarcas As SqlDataReader = cmdMarcas.ExecuteReader
                    Dim bcCopyMarcas As New SqlBulkCopy(strSqlConectionString)
                    bcCopyMarcas.DestinationTableName = "MARCAS"
                    bcCopyMarcas.WriteToServer(drMarcas)
                    drMarcas.Close()


                    'CLASIFICACION UNO
                    Dim cmdClaseUno As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODCLAUNO, DESCLAUNO FROM CLASIFICACIONUNO WHERE EMPNIT=@EMPNIT", cn)
                    cmdClaseUno.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdClaseUno.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drClaseUno As SqlDataReader = cmdClaseUno.ExecuteReader
                    Dim bcCopyClaseUno As New SqlBulkCopy(strSqlConectionString)
                    bcCopyClaseUno.DestinationTableName = "CLASIFICACIONUNO"
                    bcCopyClaseUno.WriteToServer(drClaseUno)
                    drClaseUno.Close()

                    'CLASIFICACION DOS
                    Dim cmdClaseDos As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODCLADOS, DESCLADOS FROM CLASIFICACIONDOS WHERE EMPNIT=@EMPNIT", cn)
                    cmdClaseDos.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdClaseDos.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drClaseDos As SqlDataReader = cmdClaseDos.ExecuteReader
                    Dim bcCopyClaseDos As New SqlBulkCopy(strSqlConectionString)
                    bcCopyClaseDos.DestinationTableName = "CLASIFICACIONDOS"
                    bcCopyClaseDos.WriteToServer(drClaseDos)
                    drClaseDos.Close()

                    'CLASIFICACION TRES
                    Dim cmdClaseTres As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODCLATRES, DESCLATRES FROM CLASIFICACIONTRES WHERE EMPNIT=@EMPNIT", cn)
                    cmdClaseTres.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdClaseTres.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drClaseTres As SqlDataReader = cmdClaseTres.ExecuteReader
                    Dim bcCopyClaseTres As New SqlBulkCopy(strSqlConectionString)
                    bcCopyClaseTres.DestinationTableName = "CLASIFICACIONTRES"
                    bcCopyClaseTres.WriteToServer(drClaseTres)
                    drClaseTres.Close()

                    'PROVEEDORES
                    Dim cmdProveedores As New SqlCommand("SELECT @DESTEMPNIT AS EMPNIT, CODPROV, EMPRESA, RAZONSOCIAL, DIRECCION, TELEMPRESA, CONTACTO, TELCONTACTO, NIT, 0 AS SALDO FROM PROVEEDORES WHERE EMPNIT=@EMPNIT", cn)
                    cmdProveedores.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdProveedores.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    Dim drProveedores As SqlDataReader = cmdProveedores.ExecuteReader
                    Dim bcCopyProveedores As New SqlBulkCopy(strSqlConectionString)
                    bcCopyProveedores.DestinationTableName = "PROVEEDORES"
                    bcCopyProveedores.WriteToServer(drProveedores)
                    drProveedores.Close()


                    'PRODUCTOS
                    Dim cmdh As New SqlCommand("SELECT 0 AS ID, @DESTEMPNIT AS EMPNIT, CODPROD,CODPROD2,DESPROD,DESPROD2,DESPROD3,UXC,CODMEDIDACOMPRA,COSTO,CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,HABILITADO,NULL AS FOTO,VENCIMIENTO,SERIE,BONO,INVMINIMO,INVMAXIMO,EXENTO,NF,TIPOPROD FROM PRODUCTOS WHERE EMPNIT=@EMPNIT", cn)
                    cmdh.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdh.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    cmdh.CommandTimeout = 0
                    Dim tblProductos As New DataTable
                    Dim daProductos As New SqlDataAdapter
                    daProductos.SelectCommand = cmdh
                    daProductos.Fill(tblProductos)
                    Dim bcCopy As New SqlBulkCopy(strSqlConectionString)
                    bcCopy.DestinationTableName = "PRODUCTOS"
                    bcCopy.WriteToServer(tblProductos)


                    'PRECIOS
                    Dim cmdP As New SqlCommand("SELECT 0 AS ID, @DESTEMPNIT AS EMPNIT, CODPROD, CODMEDIDA, EQUIVALE, COSTO, PRECIO, UTILIDAD, PORCUTILIDAD, HABILITADO, MAYOREOA, MAYOREOB, MAYOREOC, PESO FROM PRECIOS WHERE EMPNIT=@EMPNIT", cn)
                    cmdP.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdP.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    cmdP.CommandTimeout = 0
                    Dim tblPrecios As New DataTable
                    Dim daPrecios As New SqlDataAdapter
                    daPrecios.SelectCommand = cmdP
                    daPrecios.Fill(tblPrecios)
                    Dim bcCopyP As New SqlBulkCopy(strSqlConectionString)
                    bcCopyP.DestinationTableName = "PRECIOS"
                    bcCopyP.WriteToServer(tblPrecios)


                    'INVSALDO
                    Dim cmdI As New SqlCommand("SELECT 0 AS ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, CODPROD, 0 AS SALDOINICIAL, 0 AS ENTRADAS, 0 AS SALIDAS, 0 AS SALDO, 1 AS CODBODEGA, NOLOTE FROM INVSALDO WHERE EMPNIT=@EMPNIT AND ANIO=0", cn)
                    cmdI.Parameters.AddWithValue("@DESTEMPNIT", dr(0).ToString)
                    cmdI.Parameters.AddWithValue("@EMPNIT", empnitorigen)
                    cmdI.CommandTimeout = 0
                    Dim tblInvsaldo As New DataTable
                    Dim daInvsaldo As New SqlDataAdapter
                    daInvsaldo.SelectCommand = cmdI
                    daInvsaldo.Fill(tblInvsaldo)
                    Dim bcCopyI As New SqlBulkCopy(strSqlConectionString)
                    bcCopyI.DestinationTableName = "INVSALDO"
                    bcCopyI.WriteToServer(tblInvsaldo)

                    'realiza un reset de inventario // quitar esto despues
                    Dim objInventarios As New classInventario(dr(0).ToString, GlobalAnioProceso, GlobalMesProceso)
                    If objInventarios.fcn_existencias_cero = True Then
                        If objInventarios.fcn_ActualizarInventarioMes("anio") = True Then
                        End If
                    End If

                Loop


                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    Public Function tblTipoProd(ByVal tipo As String) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TIPO", GetType(String))
            .Add("DESC", GetType(String))
        End With

        Select Case tipo
            Case "VENTAS"
                With tbl.Rows
                    .Add(New Object() {"P", "PROPIOS"})
                    '.Add(New Object() {"E", "EXTERNOS"})
                    .Add(New Object() {"S", "SERVICIOS"})
                    .Add(New Object() {"F", "FABRICADO"})
                End With
            Case "COMPRAS"
                With tbl.Rows
                    .Add(New Object() {"P", "PROPIOS"})
                    '.Add(New Object() {"E", "EXTERNOS"})
                End With
            Case "FELFAC"
                With tbl.Rows
                    .Add(New Object() {"P", "PROPIOS"})
                    .Add(New Object() {"S", "SERVICIOS"})
                End With

            Case Else
                With tbl.Rows
                    .Add(New Object() {"P", "PROPIOS"})
                    '.Add(New Object() {"E", "EXTERNOS"})
                    .Add(New Object() {"S", "SERVICIOS"})
                    .Add(New Object() {"F", "FABRICADO"})
                End With
        End Select

        Return tbl

    End Function




    Public Function tblTipoPrecio() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TIPO", GetType(String))
            .Add("DESC", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"P", "PUBLICO"})
            .Add(New Object() {"C", "MAYOREO C"})
            .Add(New Object() {"B", "MAYOREO B"})
            .Add(New Object() {"A", "MAYOREO A"})
        End With

        Return tbl

    End Function



    Public Function tblClasificacion(ByVal clase As Integer) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("COD", GetType(String))
            .Add("DES", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim sql As String = ""
                Select Case clase
                    Case 1
                        sql = "SELECT CODCLAUNO AS COD, DESCLAUNO AS DES FROM CLASIFICACIONUNO WHERE EMPNIT=@E ORDER BY DESCLAUNO"
                    Case 2
                        sql = "SELECT CODCLADOS AS COD, DESCLADOS AS DES FROM CLASIFICACIONDOS WHERE EMPNIT=@E ORDER BY DESCLADOS"
                    Case 3
                        sql = "SELECT CODCLATRES AS COD, DESCLATRES AS DES FROM CLASIFICACIONTRES WHERE EMPNIT=@E ORDER BY DESCLATRES"
                End Select


                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox("Clasificacion no cargada. Error: " + ex.ToString)
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


    Public Function SelectPreciosProducto(ByVal empnit As String, ByVal codprod As String) As DataTable

        Dim tbl As New DSPRODUCTOS.tblPreciosProductoDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try

                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMEDIDA,EQUIVALE,COSTO,PRECIO FROM PRECIOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    Public Function ProductoHabilitado(ByVal empnit As String, ByVal codprod As String) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT HABILITADO FROM PRODUCTOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD OR CODPROD2=@CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If dr(0).ToString = "SI" Then
                        result = True
                    Else
                        result = False
                    End If
                End If

                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("Error al comprobar el estado del producto. Inténtelo de nuevo. " & GlobalDesError)

            End Try

        End Using

        Return result

    End Function



#Region " ** VENCIMIENTO ** "
    Public Function updateFechaVencimiento(ByVal empnit As String, ByVal codprod As String, ByVal nuevafechavence As Date) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS Set VENCIMIENTO=@VENCE WHERE EMPNIT=@EMPNIT And CODPROD=@CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@VENCE", nuevafechavence)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try


            cn.Close()
        End Using

        Return result
    End Function

    Public Function tblVencimientoProductosVencidosConteo(ByVal empnit As String) As Integer

        Dim contador As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If



            Try
                Dim cmd As New SqlCommand("Select CODPROD, DESPROD, VENCIMIENTO FROM PRODUCTOS 
                                            WHERE EMPNIT = @EMPNIT AND HABILITADO = 'SI' AND VENCIMIENTO<=@MESESVENCE", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@MESESVENCE", Today.Date.AddMonths(GlobalConfigVencimientoMeses))
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    contador = contador + 1
                Loop
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("Conteo vencidos: " & GlobalDesError)
                contador = 0
            End Try

            cn.Close()
        End Using

        Return contador

    End Function

    Public Function tblVencimientoProductosVencidosConteoExistencias(ByVal empnit As String, ByVal anio As Integer, ByVal mes As Integer) As Integer

        Dim contador As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If



            Try
                Dim cmd As New SqlCommand("SELECT PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, INVSALDO.SALDO, PRODUCTOS.VENCIMIENTO
                                            FROM PRODUCTOS LEFT OUTER JOIN INVSALDO ON PRODUCTOS.CODPROD = INVSALDO.CODPROD AND PRODUCTOS.EMPNIT = INVSALDO.EMPNIT
                                            WHERE (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.VENCIMIENTO <= @MESESVENCE) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@MESESVENCE", Today.Date.AddMonths(GlobalConfigVencimientoMeses))
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    contador = contador + Double.Parse(dr(2))
                Loop
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("Conteo vencidos: " & GlobalDesError)
                contador = 0
            End Try

            cn.Close()
        End Using

        Return contador

    End Function


    Public Function tblVencimientoProductosVencidos(ByVal empnit As String, ByVal anio As Integer, ByVal mes As Integer) As DataTable

        Dim tbl As New DSPRODUCTOS.tblVencimientosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If



            Try
                Dim cmd As New SqlCommand("SELECT PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, MARCAS.DESMARCA, INVSALDO.SALDO, PRODUCTOS.VENCIMIENTO
                                            FROM PRODUCTOS LEFT OUTER JOIN MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT LEFT OUTER JOIN
                                            INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                                            WHERE (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.VENCIMIENTO<=@MESESVENCE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                cmd.Parameters.AddWithValue("@MESESVENCE", Today.Date.AddMonths(GlobalConfigVencimientoMeses))
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    dr(0),
                                    dr(1),
                                    dr(2),
                                    dr(3),
                                    Date.Parse(dr(4))
                    })
                Loop
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()
        End Using

        Return tbl

    End Function

    Public Function tblVencimientoProductos(ByVal empnit As String, ByVal anio As Integer, ByVal mes As Integer) As DataTable

        Dim tbl As New DSPRODUCTOS.tblVencimientosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If



            Try
                Dim cmd As New SqlCommand("SELECT PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, MARCAS.DESMARCA, INVSALDO.SALDO, PRODUCTOS.VENCIMIENTO
                                            FROM PRODUCTOS LEFT OUTER JOIN MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT LEFT OUTER JOIN
                                            INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                                            WHERE (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI')", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    dr(0),
                                    dr(1),
                                    dr(2),
                                    dr(3),
                                    Date.Parse(dr(4))
                    })
                Loop
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()
        End Using

        Return tbl

    End Function

#End Region



    Public Function CargarDatosProductoSerie(ByVal empnit As String, ByVal noserie As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim tipoprecio As String
            Select Case Form1.lbVentasTipoPrecio.Text
                Case "PUBLICO"
                    tipoprecio = "PRECIOS.PRECIO"
                Case "MAYOREO A"
                    tipoprecio = "PRECIOS.MAYOREOA"
                Case "MAYOREO B"
                    tipoprecio = "PRECIOS.MAYOREOB"
                Case "MAYOREO C"
                    tipoprecio = "PRECIOS.MAYOREOC"
                Case Else
                    tipoprecio = "PRECIOS.PRECIO"
            End Select

            Try
                Dim cmdp As New SqlCommand("SELECT CODPROD FROM SERIES WHERE NOSERIE=@NOSERIE AND EMPNIT=@EMPNIT AND ST=0", cn)
                cmdp.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdp.Parameters.AddWithValue("@NOSERIE", noserie)
                Dim drp As SqlDataReader = cmdp.ExecuteReader
                drp.Read()
                If drp.HasRows Then

                    Call AbrirConexionSql()
                    Dim cmd As New SqlCommand("SELECT PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, " & tipoprecio & ", INVSALDO.SALDO
                                            FROM PRECIOS LEFT OUTER JOIN PRODUCTOS ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                                INVSALDO ON PRECIOS.CODPROD = INVSALDO.CODPROD AND PRECIOS.EMPNIT = INVSALDO.EMPNIT
                                            WHERE (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRECIOS.EMPNIT = @EMPNIT) AND (PRECIOS.CODPROD = @CODPROD OR PRODUCTOS.CODPROD2=@CODPROD) AND (PRODUCTOS.HABILITADO = 'SI')", cn)
                    'cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmd.Parameters.AddWithValue("@CODPROD", drp(0).ToString)
                    cmd.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                    cmd.Parameters.AddWithValue("@MES", GlobalMesProceso)
                    Dim dr As SqlDataReader
                    dr = cmd.ExecuteReader
                    dr.Read()
                    If dr.HasRows = True Then
                        Try
                            Select Case SelectedForm
                                Case "VENTAS"
                                    VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                                Case "ENVIOS"
                                    VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                                Case "COTIZACIONES"
                                    VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)

                            End Select
                            VentasAnio = GlobalAnioProceso
                            VentasMes = GlobalMesProceso
                            VentasCodProducto = dr(0).ToString
                            VentasDesProducto = dr(1).ToString
                            VentasCodMedida = dr(2).ToString
                            VentasEquivale = Integer.Parse(dr(3).ToString)
                            VentasCostoProducto = Double.Parse(dr(4).ToString)
                            VentasPrecioProducto = Double.Parse(dr(5).ToString)
                            VentasExistencia = Double.Parse(dr(6).ToString)

                            result = True
                        Catch ex As Exception
                            result = False
                        End Try
                    End If

                    cmd.Dispose()
                Else
                    result = False
                End If

                cmdp.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    ''' <summary>
    ''' verifica si el número de serie ya existe en la tabla
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="noserie"></param>
    ''' <returns>True si existe, False si no existe</returns>
    Public Function ComprobarNoSerie(ByVal empnit As String, ByVal noserie As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT NOSERIE FROM SERIES WHERE NOSERIE=@NOSERIE AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@NOSERIE", noserie)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    result = True
                Else
                    result = False
                End If

                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()

        End Using

        Return result

    End Function


    ''' <summary>
    ''' Actualiza a 0 si no tiene serie o 1 si tiene serie
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="codprod"></param>
    ''' <param name="habilitado"></param>
    ''' <returns>retorna true false</returns>
    Public Function update_serieStatus(ByVal empnit As String, ByVal codprod As String, ByVal habilitado As Boolean) As Boolean
        Dim result As Boolean

        Call AbrirConexionSql()

        Try

            Dim serie As Integer
            If habilitado = True Then
                serie = 1
            Else
                serie = 0
            End If


            Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET SERIE=@SERIE WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@SERIE", serie)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            result = True

        Catch ex As Exception
            MsgBox(ex.ToString)
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function

    ''' <summary>
    ''' Inserta un nuevo registro en la tabla de Series
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="codprod"></param>
    ''' <param name="noserie"></param>
    ''' <param name="color"></param>
    ''' <returns>Boolean</returns>
    Public Function insert_Serie(ByVal empnit As String, ByVal codprod As String, ByVal noserie As String, ByVal color As String) As Boolean

        Dim result As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("INSERT INTO SERIES (EMPNIT,CODPROD,NOSERIE,COLOR,ST) VALUES (@EMPNIT,@CODPROD,@NOSERIE,@COLOR,0)", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@NOSERIE", noserie)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@COLOR", color)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            result = True
        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function



    ''' <summary>
    ''' Carga la lista de series del producto
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="codprod"></param>
    ''' <returns>un datatable</returns>
    Public Function tbl_Series(ByVal empnit As String, ByVal codprod As String) As DataTable

        Dim tbl As New DSPRODUCTOS.tblSeriesDataTable

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("SELECT ID,NOSERIE,COLOR FROM SERIES WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ST=0", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                dr(0),
                                dr(1),
                                dr(2)
                })
            Loop
            dr.Close()
            cmd.Dispose()

        Catch ex As Exception
            GlobalDesError = ex.ToString
            tbl = Nothing
        End Try

        cn.Close()

        Return tbl

    End Function


    ''' <summary>
    ''' Elimina el número de serie seleccionado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function delete_Serie(ByVal id As Integer) As Boolean

        Dim result As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("DELETE FROM SERIES WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            result = True
        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function


    ''' <summary>
    ''' Elimina todas las series del producto
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="codprod"></param>
    ''' <returns></returns>
    Public Function deleteall_Series(ByVal empnit As String, ByVal codprod As String) As Boolean

        Dim result As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("DELETE FROM SERIES WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            result = True
        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function


    Public Function tblListaProductos(ByVal Empnit As String) As DataTable
        tblListaProductos = New VENTASDataSet.tblListaProductosDataTable

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT PRODUCTOS.CODPROD AS CODIGO, PRODUCTOS.DESPROD AS DESCRIPCION, PRODUCTOS.DESPROD2 AS DESCRIPCION2, PRECIOS.CODMEDIDA AS MEDIDA, PRECIOS.EQUIVALE, PRECIOS.PRECIO, MARCAS.DESMARCA AS MARCA
                                        FROM PRODUCTOS LEFT OUTER JOIN PRECIOS ON PRODUCTOS.EMPNIT = PRECIOS.EMPNIT AND PRODUCTOS.CODPROD = PRECIOS.CODPROD LEFT OUTER JOIN MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA
                                        WHERE (PRODUCTOS.EMPNIT = '" & Empnit & "') AND (PRODUCTOS.HABILITADO = 'SI')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tblListaProductos.Rows.Add(New Object() {
                                dr(0).ToString,
                                dr(1).ToString,
                                dr(2).ToString,
                                dr(3).ToString,
                                dr(4).ToString,
                                FormatCurrency(dr(5)).ToString,
                                dr(6).ToString
                                                        })

            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function tblProductos(ByVal Empnit As String) As DataTable

        Dim tblListaProductos As New DSPRODUCTOS.tblProdsDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, COSTO FROM PRODUCTOS WHERE EMPNIT = '" & Empnit & "' ", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tblListaProductos)
                'cmd.Dispose()
                'cn.Close()

            Catch ex As Exception
                tblListaProductos = Nothing
            End Try

        End Using

        Return tblListaProductos

    End Function



    Public Function tblListaEtiquetas(ByVal Empnit As String, ByVal CoddocUsuario As String) As DataTable
        tblListaEtiquetas = New VENTASDataSet.tblTempEtiquetasDataTable

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT ID, CODPROD, DESPROD, DESPROD2, CODMEDIDA, PRECIO, PRECIOANTES, CODMEDIDAANTES
                                        FROM TEMP_ETIQUETAS
                                        WHERE (EMPNIT = '" & Empnit & "') AND (CODDOC = '" & CoddocUsuario & "') ORDER BY DESPROD", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tblListaEtiquetas.Rows.Add(New Object() {
                                Integer.Parse(dr(0)),
                                dr(1).ToString,
                                dr(2).ToString,
                                dr(3).ToString,
                                dr(4).ToString,'CODMEDIDA
                                FormatCurrency(dr(5)).ToString,'PRECIO
                                FormatCurrency(dr(6)).ToString,'PRECIO ANTES
                                dr(7).ToString 'CODMEDIDA ANTES
                                                        })

            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception

            Return Nothing
        End Try



    End Function

    Public Function AgregarEtiquetas(ByVal Datos As DataRow, ByVal Cantidad As Integer, ByVal MedidaOferta As String, ByVal PrecioOferta As String) As Boolean
        Call AbrirConexionSql()

        Try
            For x = 1 To Cantidad

                Dim cmd As New SqlCommand("INSERT INTO TEMP_ETIQUETAS (EMPNIT, CODDOC, CODPROD, DESPROD, DESPROD2, CODMEDIDA, PRECIO, PRECIOANTES, CODMEDIDAANTES) VALUES (@EMPNIT, @CODDOC, @CODPROD, @DESPROD, @DESPROD2, @CODMEDIDA, @PRECIO, @PRECIOANTES,@CODMEDIDAANTES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                cmd.Parameters.AddWithValue("@CODPROD", Datos.Item(0).ToString)
                cmd.Parameters.AddWithValue("@DESPROD", Datos.Item(1).ToString)
                cmd.Parameters.AddWithValue("@DESPROD2", Datos.Item(2).ToString)
                cmd.Parameters.AddWithValue("@CODMEDIDA", Datos.Item(3).ToString)
                cmd.Parameters.AddWithValue("@PRECIO", Datos.Item(5).ToString)
                cmd.Parameters.AddWithValue("@PRECIOANTES", PrecioOferta)
                cmd.Parameters.AddWithValue("@CODMEDIDAANTES", MedidaOferta)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Next

            Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try





    End Function

    Public Function EliminarPrecioEtiqueta(ByVal IdPrecio As Integer) As Boolean
        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("DELETE FROM TEMP_ETIQUETAS WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@ID", IdPrecio)

            cmd.ExecuteNonQuery()
            cmd.Dispose()


            Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try

    End Function

    Public Function EliminarEtiquetasTodas(ByVal Empnit As String, ByVal Coddoc As String) As Boolean
        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("DELETE FROM TEMP_ETIQUETAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", Empnit)
            cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try

    End Function


    'carga las medidas de precio de un producto específico
    Public Function tblPreciosProducto(ByVal Empnit As String, ByVal Codprod As String) As DataTable
        tblPreciosProducto = New DataTable
        With tblPreciosProducto.Columns
            .Add("CODMEDIDA", GetType(String))
            .Add("COSTO", GetType(String))
            .Add("PRECIO", GetType(String))
        End With

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT CODMEDIDA, COSTO, PRECIO FROM PRECIOS
                                        WHERE (EMPNIT = '" & Empnit & "') AND (CODPROD = '" & Codprod & "')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tblPreciosProducto.Rows.Add(New Object() {
                                dr(0).ToString,'CODMEDIDA
                                FormatCurrency(dr(1)).ToString,'COSTO
                                FormatCurrency(dr(2)).ToString'PRECIO
                                          })

            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception

            Return Nothing
        End Try

    End Function

    'obtiene el nombre del producto
    Public Function StNomProducto(ByVal Empnit As String, ByVal Codprod As String) As String

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT DESPROD FROM PRODUCTOS
                                        WHERE (EMPNIT = '" & Empnit & "') AND (CODPROD = '" & Codprod & "')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Return dr(0).ToString
            End If
            dr.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception

            Return Nothing
        End Try


    End Function

#Region " ** PRECIOS COMPETENCIA ** "
    Public Function GetPreciosCompetencia(ByVal empnit As String, ByVal codprod As String) As DataTable
        Dim tbl As New DSPRODUCTOS.tblPreciosCompetenciaDataTable

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT,CODPROD, PROVEEDOR,DIRPROVEEDOR,TELPROVEEDOR,PRECIO,REVISION,OBS FROM PRODUCTOS_PRECIOSCOMPETENCIA WHERE CODPROD=@CODPROD AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                        dr(1).ToString, 'CODPROD
                        dr(2).ToString, 'PROVEEDOR
                        dr(3).ToString, 'DIRECCION
                        dr(4).ToString,
                        FormatCurrency(dr(5)).ToString,
                        Date.Parse(dr(6)),
                        dr(7).ToString
                    })
                Loop

                dr.Close()
                cn.Close()

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try

        End Using


        Return tbl

    End Function


    Public Function InsertPrecioCompetencia(ByVal empnit As String, ByVal codprod As String, ByVal proveedor As String, ByVal direccion As String, ByVal telefono As String, ByVal obs As String, ByVal precio As Double, ByVal fecha As Date) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO PRODUCTOS_PRECIOSCOMPETENCIA (EMPNIT,CODPROD,PROVEEDOR,DIRPROVEEDOR,TELPROVEEDOR,PRECIO,REVISION,OBS) VALUES (@E,@COD,@DES,@DIR,@TEL,@PRE,@REV,@OBS)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@COD", codprod)
                cmd.Parameters.AddWithValue("@DES", proveedor)
                cmd.Parameters.AddWithValue("@DIR", direccion)
                cmd.Parameters.AddWithValue("@TEL", telefono)
                cmd.Parameters.AddWithValue("@PRE", precio)
                cmd.Parameters.AddWithValue("@REV", fecha)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                result = False
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
            End Try
        End Using

        Return result

    End Function
    Public Function DeletePrecioCompetencia(ByVal empnit As String, ByVal codprod As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM PRODUCTOS_PRECIOSCOMPETENCIA WHERE EMPNIT=@E AND CODPROD=@COD", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@COD", codprod)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                result = False
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
            End Try
        End Using

        Return result

    End Function


#End Region

End Class
