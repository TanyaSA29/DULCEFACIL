using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ProductoTipoDTO
    {
        public string TipoProducto { get; set; }
        public string Categoria { get; set; }
        public List<string> NombresProductos { get; set; }
    }
}
