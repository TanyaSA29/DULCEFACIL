using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ClienteCompraDetalleDTO
    {
        public string NombreCliente { get; set; }
        public List<string> ProductosComprados { get; set; }
        public int CantidadTotalProductos { get; set; }
        public decimal TotalGastado { get; set; }
    }
}
