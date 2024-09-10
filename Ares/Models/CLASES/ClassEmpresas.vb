Imports System.Data.SqlClient

Public Class ClassEmpresas
    Sub New()

    End Sub

    Public Function tblListaEmpresas() As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODEMPRESA", GetType(Integer))
            .Add("NOMEMPRESA", GetType(String))
        End With

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT EMPNIT, EMPNOMBRE FROM EMPRESAS", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                dr(0).ToString,'EMPNIT
                                dr(1).ToString'NOM EMPRESA
                               })
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try

    End Function

    Public Function eliminarEmpresa(ByVal empnit As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim qry As String = "DELETE FROM EMPRESAS WHERE EMPNIT=@empnit;
	                                delete from TIPODOCUMENTOS WHERE EMPNIT=@empnit;
	                                delete from CLIENTES WHERE EMPNIT=@empnit;
                                    delete from CLIENTES_VEHICULOS WHERE EMPNIT=@empnit;
	                                delete from SALDOCLIENTES WHERE EMPNIT=@empnit;
	                                delete from DOCUMENTOS WHERE EMPNIT=@empnit;
	                                delete from DOCPRODUCTOS WHERE EMPNIT=@empnit;
                                    delete from DOCUMENTOS_ORDENTRABAJO WHERE EMPNIT=@empnit;
	                                delete from CORTES WHERE EMPNIT=@empnit;
	                                delete from EMPLEADOS WHERE EMPNIT=@empnit;
	                                delete from INVSALDO WHERE EMPNIT=@empnit;
	                                delete from INVCIERRES WHERE EMPNIT=@empnit;
	                                delete from PRODUCTOS WHERE EMPNIT=@empnit;
	                                delete from PRECIOS WHERE EMPNIT=@empnit;
	                                delete from MARCAS WHERE EMPNIT=@empnit;
	                                delete from MEDIDAS WHERE EMPNIT=@empnit;
	                                delete from CLASIFICACIONDOS WHERE EMPNIT=@empnit;
	                                delete from CLASIFICACIONTRES WHERE EMPNIT=@empnit;
	                                delete from CLASIFICACIONUNO WHERE EMPNIT=@empnit;
	                                delete from PROVEEDORES WHERE EMPNIT=@empnit;
	                                delete from SERIES WHERE EMPNIT=@empnit
                                    delete from TASKS WHERE EMPNIT=@empnit;
                                    delete from EMBARQUES WHERE EMPNIT=@empnit;
                                    delete from REPARTIDORES WHERE EMPNIT=@empnit;
                                    "
                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@empnit", empnit)
                cmd.ExecuteNonQuery()
                r = True

                cn.Close()
            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
            End Try

        End Using

        Return r
    End Function

End Class
