Module Config

    Public GlobalConfigIVA As Double = 1.12
    Public GlobalInfileUrl As String = "https://report.feel.com.gt/ingfacereport/ingfacereport_documento?uuid="


#Region " Configuraciones Cliente"
    '1) url
    Public varConfigClientUrl As String = "https://www.google.com/"

    '2) modo pos
    Public varConfigClienteModoPos As String = "NO"

    '3) modo tipo cobro
    Public varConfigClienteTipoCobro As String = "NO"

    '4) hora
    Public varConfigClienteHora As String = "SI"

    '5) recordatorios
    Public varConfigClienteRecordatorios As String = "NO"

    '6) ventana inicial
    Public varConfigIntefarce As String

    '7) modo codigos en ventas
    Public varConfigModoCodigoVentas As String = "NO"


#End Region

#Region " DATOS PREDEFINIDOS "

    'CODIGO DE CAJA PREDEFINIDO
    Public GlobalSelectedCodCaja As Integer = 0

    'SERIE FACTURACION PREDEFINIDO
    Public GlobalSelectedCoddocFac As String = ""



#End Region

End Module
