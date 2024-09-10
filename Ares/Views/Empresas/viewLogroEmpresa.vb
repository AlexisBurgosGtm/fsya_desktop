Imports System.Data.SqlClient

Public Class viewLogroEmpresa



    Sub New(ByVal _mes As Integer, ByVal _anio As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mes = _mes
        anio = _anio

    End Sub

    Dim anio, mes As Integer

    Private Sub viewLogroEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call getObjetivoVenta()

    End Sub

    Public Function getObjetivoVenta() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT   EMPRESAS.EMPNOMBRE, 
                                                    SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, 
                                                    SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, 
                                                    ISNULL(EMPRESAS.OBJETIVO_VENTAS,0) AS OBJETIVO_VENTAS
                                        FROM DOCUMENTOS LEFT OUTER JOIN
                                             TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN
                                             EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                                        WHERE (DOCUMENTOS.STATUS = 'O') AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M)
                                        GROUP BY EMPRESAS.EMPNOMBRE, EMPRESAS.OBJETIVO_VENTAS", cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@A", anio)
                cmd.Parameters.AddWithValue("@M", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.lbVentas.Text = FormatNumber(dr(2), 2)
                    Me.lbObjetivo.Text = FormatNumber(dr(3), 2)
                    Me.lbLogro.Text = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(3))) * 100, 2) + " %"
                    'Me.ProgressBar1.Value = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(3))) * 100, 2)
                    Me.ProgressBarControl1.Position = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(3))) * 100, 2)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r
    End Function



End Class
