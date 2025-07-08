using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class ClienteVentasDTO
    {
        public string NombreCliente { get; set; }
        public List<int> VentasIDs { get; set; }
    }
}
