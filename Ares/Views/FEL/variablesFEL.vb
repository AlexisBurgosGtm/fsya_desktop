Module variablesFEL


    Public GlobalSelectedFEL_UUDI As String = ""
    Public GlobalSelectedFEL_SERIE As String = ""
    Public GlobalSelectedFEL_NUMERO As String = ""
    Public GlobalSelectedFEL_FECHA As String = ""

    Public GlobalSelectedFechaVence As Date
    Public GlobalSelectedCantidadCuotas As Integer = 1

    Public Function getStatusTipoFEl(ByVal tipodoc As String) As Boolean
        Dim r As Boolean

        Select Case tipodoc
            Case "FEF"
                r = True
            Case "FEC"
                r = True
            Case "FNC"
                r = True
            Case Else
                r = False
        End Select

        Return r

    End Function

End Module
