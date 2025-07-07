using DulceFacil.Aplicacion.Servicios;
using DulceFacil.Dominio.Modelo.Abstracciones;
using DulceFacil.Infraestructura.AccesoDatos;
using DulceFacil.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Aplicacion.ServicioImpl
{
    public class ProductoServicioImpl : IProductoServicio
    {
        private IProductoRepositorio _productoRepositorio;

        public ProductoServicioImpl(BDDulceFacilContext _BDDulceFacilContext)
        {
            this._productoRepositorio = new ProductoRepositorioImpl(_BDDulceFacilContext);
        }

        public async Task AddProductoAsync(Producto nuevoproducto)
        {
            await _productoRepositorio.AddAsync(nuevoproducto);
        }
        public async Task DeleteProductoAsync(int id)
        {
            await _productoRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Producto>> GetAllProductoAsync()
        {
            return await _productoRepositorio.GetAllAsync();
        }

        public Task<Producto> GetByIdProductoAsync(int id)
        {
            return _productoRepositorio.GetByIdAsync(id);
        }

        public Task<List<Producto>> ListarProductosConStock()
        {
            return _productoRepositorio.ListarProductosConStock();
        }

        public async Task UpdateProductoAsync(Producto entidad)
        {
            await _productoRepositorio.UpdateAsync(entidad);
        }

        
    }
}