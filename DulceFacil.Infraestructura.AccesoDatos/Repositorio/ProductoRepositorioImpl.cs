using DulceFacil.Dominio.Modelo.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class ProductoRepositorioImpl : RepositorioImpl<Producto>, IProductoRepositorio
    {
        private readonly BDDulceFacilContext _dbContext;
        public ProductoRepositorioImpl(BDDulceFacilContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<List<Producto>> ListarProductosConStock()
        {
            try
            {
                var result = from prod in _dbContext.Producto
                             where prod.Stock > 0
                             select prod;
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos con stock: " + ex.Message);
            }
        }

    }
}
