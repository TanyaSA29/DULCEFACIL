using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFaci.Aplicacion.DTO.DTOs
{
    public class PuntoVentaResumenDTO
    {
        public string NombrePunto { get; set; }
        public int TotalVentas { get; set; }
        public decimal TotalRecaudado { get; set; }
    }

}
