using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.server.MCContext.Entidades
{
    public enum MotivoBajaEnum
    {
        ErrorCargaContraparte = 1,
        ErrorCargaProducto = 2,
        ErrorCargaVencimiento = 3,
        PorDisposiciónBCRA = 4,
        ErrorCargaCantidadPrecio = 5,
        DepuracionBatch = 6,
        Relanzar = 7,
        AnularConfirmacion = 8,
        CanceladoSistemaExterno = 9,
    }
}
