using DulceFacil.Dominio.Modelo.Abstracciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class ClienteRepositorioImpl : RepositorioImpl<Cliente>, IClienteRepositorio
    {
        private readonly BDDulceFacilContext _dbContext;
        public ClienteRepositorioImpl(BDDulceFacilContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<List<Cliente>> ListarClientesActivos()
        {
            try
            {
                var result = from cli in _dbContext.Cliente
                             where cli.TipoCliente == "Minorista" // ejemplo de "activo", puedes cambiar
                             select cli;
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes activos: " + ex.Message);
            }
        }
        public async Task<List<Cliente>> ListarClientesConVentasDeProductosCostosos(decimal precioMinimo)
        {
            try
            {
                var query = from cliente in _dbContext.Cliente
                            where cliente.Venta.Any(venta =>
                                venta.DetalleVenta.Any(detalle => detalle.PrecioUnitario > precioMinimo))
                            select cliente;

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes con ventas de productos costosos: " + ex.Message);
            }


        }
    }
}
   
