using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ClienteUltimaCompraDTO
    {
        public string NombreCliente { get; set; }
        public string UltimoProducto { get; set; }
        public DateTime FechaUltimaVenta { get; set; }
        public string PuntoDeVenta { get; set; }
    }
}
