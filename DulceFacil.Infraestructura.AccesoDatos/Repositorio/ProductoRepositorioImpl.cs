using DulceFacil.Dominio.Modelo.Abstracciones;
using DulceFaci.Aplicacion.DTO.DTOs;
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

        public async Task<List<ProductoTipoDTO>> ListarProductosPorTipo()
        {
            try
            {
                var resultado = await (from prod in _dbContext.Producto
                                       group prod by prod.Descripcion into grupo
                                       select new ProductoTipoDTO
                                       {
                                           TipoProducto = grupo.Key,
                                           NombresProductos = grupo.Select(p => p.Nombre).ToList()
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos por tipo: " + ex.Message);
            }
        }

        public async Task<List<ProductoClientesDTO>> ListarProductosVendidosConClientes()
        {
            try
            {
                var resultado = await (from dv in _dbContext.DetalleVenta
                                       join v in _dbContext.Venta on dv.VentaID equals v.VentaID
                                       join c in _dbContext.Cliente on v.ClienteID equals c.ClienteID
                                       join p in _dbContext.Producto on dv.ProductoID equals p.ProductoID
                                       group new { dv, c } by p.Nombre into grupo
                                       select new ProductoClientesDTO
                                       {
                                           NombreProducto = grupo.Key,
                                           CantidadVendida = grupo.Sum(x => x.dv.Cantidad),
                                           Clientes = grupo.Select(x => x.c.Nombre).Distinct().ToList()
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar productos con clientes: " + ex.Message);
            }
        }

    }
}
