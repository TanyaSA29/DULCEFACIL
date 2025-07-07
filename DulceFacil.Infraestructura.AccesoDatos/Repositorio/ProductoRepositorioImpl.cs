using DulceFacil.Dominio.Modelo.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class ProductoRepositorioImpl : RepositorioImpl<Producto>, IProductoRepositorio
    {
        public ProductoRepositorioImpl(BDDulceFacilContext context) : base(context)
        {
        }
    }
}
