using DulceFacil.Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class RutaEntregaRepositorioImpl : RepositorioImpl<RutaEntrega>, IRutaEntregaRepositorio
    {
        public RutaEntregaRepositorioImpl(BDDulceFacilContext context) : base(context)
        {
        }
    }   
   
}
