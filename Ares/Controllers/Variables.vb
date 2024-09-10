Imports System.Data.SqlClient
Imports DevExpress.XtraEditors.Camera

Module Variables

    Public GlobalCorrTras As Integer

    Public PagoTarjeta As Double
    Public PagoEfectivo As Double

    Public GlobalTipoCobro As Integer

    Public GlobalTipoSistema As Integer = 0 '0) sería farmasalud, 1) sería distribuidora

    Public GlobalPathMinimos As String = Application.StartupPath + "\EXPORTS\"

    Public GlobalFELActivo As Integer = 0   '0= activada, 1=desactivada
    Public GlobalCuentaActiva As Integer = 0   '0= activada, 1=desactivada

    Public GlobalFELEnviaCodigoProducto As String = "NO"
    Public GlobalSelectedColor As Integer = 0

    Public GlobalSelectedTipoDocumento As String = ""

    Public boolLoged As Boolean = False
    Public GlobalEmailEnviar As String

    Public GlobalSelectedNitCliente As String = ""
    Public GlobalSelectedNomCliente As String = ""
    Public GlobalSelectedDirCliente As String = ""
    Public globalcorrelativocorte As Double

    Public GlobalSelected_Coddoc As String = ""
    Public GlobalSelected_Correlativo As Double
    Public GlobalSelected_FechaDocumento As Date

    Public GlobalTipoVenta As String = "MOSTRADOR"

    Public GlobalTipoPrecioSucursal As String


#Region " ** PUBLICAS **"

    Public fechapos As Date

    Public globalProv As String
    Public globalNitProv As String
    Public globalDesProv As String

    Public Token As String = "sn" 'token de acceso al host
    Public GlobalUrlFrontEnd As String = ""

    Public GlobalBool As Boolean = False

    'TWILIO
    Public twilioSId As String
    Public twilioToken As String
    Public twilioNumber As String


    Public SelectedForm As String = "LOGIN"
    Public ConfigVerificaExistencias As Boolean

    Public GlobalNomUsuario As String
    Public NivelUsuario As Integer
    Public GlobalNomEmpleado As Integer

    Public cn As SqlConnection

    'Public CnMysql As MySql.Data.MySqlClient.MySqlConnection

    Public FotoCapturada As Image
    Public d As New TakePictureDialog()

    Public Saludar As Boolean = False

    'globales para ver al cliente
    Public GlobalCodCliente As Integer
    Public GlobalNomCliente As String

    Public GlobalEmail As String = "sistemaarespos@gmail.com"

    Public GlobalEmpNit As String = "001"
    Public GlobalNomEmpresa As String
    Public GlobalBodegaCentralEmpnit As String

    Public GlobalTipoProd As String = "P"
    Public GlobalTipoPrecio As String = "PUBLICO"
    Public GlobalObjetivoSucursal As Double = 0

    Public GlobalCorrelComp As String = ""

    Public GlobalCoddoc As String = "FACA1"
    Public GlobalCoddocFEL As String = "FELFAC"
    Public GlobalCoddocENVIOS As String = "ENVIO01"
    Public GlobalCoddocCOMPRA As String = "COMP"
    Public GlobalCoddocORDENCOMPRA As String = "ORDCOMP"
    Public GlobalCoddocCOTIZ As String = "COTIZ"
    Public GlobalCoddocCorteCaja As String = "CAJA"
    Public GlobalCoddocReciboCliente As String = "RECCLIE"
    Public GlobalCoddocTrasSalBodega As String = "TSALBOD"
    Public GlobalCoddocTrasEntradaBodega As String = "TENTBOD"
    Public GlobalCoddocTrasSalSucursal As String = "TSALSUC"
    Public GlobalCoddocTrasEntradaSucursal As String = "TENTSUC"
    Public GlobalCoddocIEF As String = "ING_EFEC"
    Public GlobalCoddocTras As String = "SALIDA"


    Public GlobalCodCaja As Integer = 1

    Public GlobalCodVend As Integer 'codigo de vendedor a nivel global

    Public LogoEmpresa As Image ' logo de la empresa que se usa en todos los formularios
    Public GlobalPathFondo As String = Application.StartupPath + "\Src\fondo.png"  'imagen que se usa de fondo para el inicio


    Public GlobalCantidad As Double 'para representar cantidades en cualquier form

    Public GlobalTipoEmpresa As String
    'los tipos de empresa son para cambiar los labels de que los clientes verán
    'TIPOS:
    'POS - Son los puntos de venta, los labels cambian a descripción, descripción2, des3 por ej.
    'FAR - Son los tipo farmacia, los labels en productos son Descr2=Componente, Descr3=Uso del fármaco
    'RES - Es para los restaurantes
    'DIS - Distribuidoras de pre-venta

    Public GlobalSocketIp As String 'ip de la computadora que ejecuta el sistema
    Public GlobalSocketPort As Integer 'puerto para socket

    Public GlobalTituloReporte As String
    Public GlobalNomFac As String
    Public GlobalVendFac As String
    Public GlobalCodProd As String
    Public GlobalDesProd As String

    Public SelectedCode As Integer
    Public SelectedCordprod As String

    Public GlobalAnioProceso As Integer, GlobalMesProceso As Integer

    Public Mesproceso1 As Integer
    Public Mesproceso2 As Integer
    Public Anioproceso As Integer


    Public GlobalParamMesInicial As Integer
    Public GlobalParamMesFinal As Integer
    Public GlobalParamAnioCurso As Integer
    Public GlobalParamDatePickI As Date
    Public GlobalParamDatePickF As Date
    Public GlobalParamMarca As Integer
    Public GlobalParamProveedor As Integer


    'variables para la generación de cotizaciones al email
    Public ListadosCoddoc As String, ListadosCorrelativo As Double, ListadosFecha As Date

    Public GlobalDesError As String

    Public GlobalInteger As Integer = 0

#End Region

#Region " ** VENTAS ** "

    Public CHBOXZ7 As Boolean = False
    Public CHBOXPR As Boolean = False

    Public nitclien As String = "CF"

    Public GlobalTomarDatosTipoDoc As String = ""

    Public GlobalModoPOS As Boolean

    Public ClienteNuevoCargado As Boolean = False 'sirve para que no se abra dos veces el user control de nuevo cliente

    Public VentasCodCaja As Integer = 0
    Public VentasCodProducto As String
    Public VentasDesProducto As String
    Public VentasPrecioProducto As Double
    Public VentasCostoProducto As Double
    Public VentasCodMedida As String
    Public VentasEquivale As Integer
    Public VentasCorrelativo As Double
    Public VentasTotalVenta As Double
    Public VentasExento As Integer
    Public VentasIvaProducto As Double = 0
    Public VentasConCre As String
    Public VentasAnio As Integer
    Public VentasMes As Integer
    Public VentasExistencia As Double

    Public VentasCodRepartidor As Integer = 0 'codigo de repartido público
    Public VentasDirEntrega As String 'establece la dirección de entrega de una factura o pedido
    Public VentasDireccionCliente As String
    Public VentasNoGuia As String = "SN" 'establece el número de guía o documento
    Public VentasFleteEntrega As Double = 0 'establece el valor del flete por entrega
    Public VentasObs As String
    Public VentasDiasCredito As Integer = 0
    Public VentasFechaVencimiento As Date = Today.Date

    Public VentasNoSerie As String

    Public VentasUnidadesAjuste As Double 'total de unidades a ajustar en inv fisico

    Public TotalVentaFAC As Double

    'Se usa para definir la serie final para ventas
    Public GlobalCoddocFinal As String = ""
    Public GlobalFechaFinal As Date
    Public GlobalCorrelativoFinal As Double = 0


    Public GlobalVentasModoCodigoCantidad As Double = 0
    Public GlobalVentasModoCodigoCodprod As String = ""
    Public GlobalVentasModoCodigoCosto As Double = 0
    Public GlobalVentasModoCodigoPrecio As Double = 0


#End Region

#Region " ** COMPRAS ** "
    Public ComprasCodProducto As String
    Public ComprasDesProducto As String
    Public ComprasPrecioProducto As Double
    Public ComprasCostoProducto As Double
    Public ComprasCodMedida As String
    Public ComprasEquivale As Integer
    Public ComprasCorrelativo As Double
    Public ComprasTotalVenta As Double
    Public ComprasConCre As String
    Public ComprasAnio As Integer
    Public ComprasMes As Integer
    Public ComprasExistencia As Double
#End Region

#Region " ** PRODUCTOS ** "
    Public EditarProducto As Boolean = False

    Public ProductosCodprod As String
    Public ProductosCodprod2 As String
    Public ProductosDesProd As String
    Public ProductosDesProd2 As String
    Public ProductosDesProd3 As String
    Public ProductosUxC As Integer
    Public ProductosCosto As Double
    Public ProductosPrecio As Double
    Public ProductosHabilitado As String
    Public ProductosCodMarca As Integer
    Public ProductosCodClaUno As Integer
    Public ProductosCodClaDos As Integer
    Public ProductosCodClaTres As Integer
    Public ProductosDesMarca As String
    Public ProductosDesClaUno As String
    Public ProductosDesClaDos As String
    Public ProductosDesClaTres As String
    Public ProductosFoto As Image
    Public ProductosVencimiento As Date
    Public ProductosSerie As Integer '0) cuando esté activada 1) cuando esté desactivada
    Public ProductosInvMinimo As Double
    Public ProductosExento As Integer
    Public ProductosNF As Integer
    Public ProductosTipoProd As String
    Public ProductosCodmedida As String
    Public ProductosBONO As Double

#End Region


    Public GlobalSelectedCodEmbarque As String = ""

    Public SelectedNomSucursal As String
    Public SelectedDescripcion As String
    Public SelectedCoddoc As String
    Public SelectedFecha As Date
    Public SelectedCosto As Double
    Public SelectedPr As Double

    Public SelectedFechaInicial As Date
    Public SelectedFechaFinal As Date

    Public SelectedCodMedida As String
    Public SelectedPrecio As String

    Public SelectedCorrelativo As Double

    Public CorteTotalGastos As Double


#Region " ** parametros ** "

    Public GlobalParamAnioInicial, GlobalParamAnioFinal As Integer
    Public GlobalConfigVencimientoMeses As Integer = 0
    Public GlobalParamFechaInicial, GlobalParamFechaFinal As Date
    Public GlobalParamMes As Integer = 0
    Public GlobalParamAnio As Integer = 0

#End Region


    Public nitcliente As String
    Public nomclie As String
    Public codclie As String
    Public objDM As String
    Public nomEmpPOS As String
    Public correlPOS As String

End Module
