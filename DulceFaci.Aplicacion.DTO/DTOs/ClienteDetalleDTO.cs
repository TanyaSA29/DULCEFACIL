using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ClienteDetalleDTO
    {
        public string NombreCliente { get; set; }
        public string PuntoDeVenta { get; set; }
        public List<string> ProductosComprados { get; set; }
        public decimal TotalGastado { get; set; }
    }
}
