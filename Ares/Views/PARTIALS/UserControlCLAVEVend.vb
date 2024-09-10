Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class UserControlCLAVEVend
    Private Sub txtPassVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtPassVendedor.Text <> "" Then

                Using cn As New SqlConnection(strSqlConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If


                        'Dim cmd As New SqlCommand("SELECT NOMVEN, CLAVE, CODVEN FROM VENDEDORES WHERE EMPNIT='" & GlobalEmpNit & "' AND CLAVE='" & Me.txtPassVendedor.Text & "'", cn)
                        Dim cmd As New SqlCommand("SELECT NOMEMPLEADO, CLAVE, CODEMPLEADO FROM EMPLEADOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CLAVE='" & Me.txtPassVendedor.Text & "'", cn)
                        Dim dr As SqlDataReader = cmd.ExecuteReader
                        dr.Read()

                        If dr.HasRows Then

                            GlobalCodVend = CType(dr(2), Integer)

                            Select Case SelectedForm
                                Case "VENTAS"
                                    Form1.cmbVentasVendedor.SelectedValue = GlobalCodVend
                                    Call Form1.VentasAbrirCobro()
                                    Me.SimpleButton1.PerformClick()
                                Case "ENVIOS"
                                    Form1.cmbVentasVendedor.SelectedValue = GlobalCodVend
                                    Call Form1.GuardarVenta()
                                    Me.SimpleButton1.PerformClick()

                            End Select
                        End If

                        dr.Close()
                        cmd.Dispose()

                    Catch ex As Exception
                        Call Form1.Mensaje("La clave indicada es incorrecta")
                    End Try


                End Using


            Else
                Call Form1.Mensaje("La clave indicada es incorrecta")
            End If

        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub UserControlCLAVEVend_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
