using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ProductoClientesDTO
    {
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
        public List<string> Clientes { get; set; }
    }
}
