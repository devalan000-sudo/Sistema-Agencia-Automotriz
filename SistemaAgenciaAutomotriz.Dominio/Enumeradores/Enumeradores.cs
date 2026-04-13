namespace SistemaAgenciaAutomotriz.Dominio.Enumeradores;

public enum RolUsuario
{
    Admin = 1,
    Cajero = 2,
    Supervisor = 3
}

public enum MetodoPago
{
    Efectivo = 1,
    Tarjeta = 2,
    Transferencia = 3
}

public enum EstatusVenta
{
    Completada = 1,
    Cancelada = 2,
    Pendiente = 3
}

public enum EstatusCuentaPorCobrar
{
    Pendiente = 1,
    Parcial = 2,
    Liquidada = 3
}

public enum TipoMovimiento
{
    Entrada = 1,
    Salida = 2,
    Ajuste = 3
}

public enum TipoVehiculo
{
    Nuevo = 1,
    Seminuevo = 2,
    Usado = 3
}

public enum EstatusVehiculo
{
    Disponible = 1,
    Reservado = 2,
    Vendido = 3
}

public enum TipoPago
{
    Contado = 1,
    Financiamiento = 2
}