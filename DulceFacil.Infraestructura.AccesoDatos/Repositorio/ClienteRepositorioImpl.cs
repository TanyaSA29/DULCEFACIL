
﻿using DulceFacil.Dominio.Modelo.Abstracciones;

﻿using DulceFaci.Aplicacion.DTO.DTOs;
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
                             where cli.TipoCliente == "Minorista" 
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

        public async Task<List<ClienteVentasDTO>> ListarClientesConVentas()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta
                                       on c.ClienteID equals v.ClienteID
                                       group v by c.Nombre into grupo
                                       select new ClienteVentasDTO
                                       {
                                           NombreCliente = grupo.Key,
                                           VentasIDs = grupo.Select(v => v.VentaID).ToList()
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes con ventas: " + ex.Message);
            }

        }
        public async Task<List<ClienteCompraDetalleDTO>> ListarDetalleComprasPorCliente()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta on c.ClienteID equals v.ClienteID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       join p in _dbContext.Producto on dv.ProductoID equals p.ProductoID
                                       group new { dv, p } by c.Nombre into grupo
                                       select new ClienteCompraDetalleDTO
                                       {
                                           NombreCliente = grupo.Key,
                                           ProductosComprados = grupo.Select(x => x.p.Nombre).Distinct().ToList(),
                                           CantidadTotalProductos = grupo.Sum(x => x.dv.Cantidad),
                                           TotalGastado = grupo.Sum(x => x.dv.Cantidad * x.dv.PrecioUnitario)
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar detalle de compras por cliente: " + ex.Message);
            }
        }
        public async Task<List<ClienteVentaResumenDTO>> ListarResumenVentasPorCliente()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta on c.ClienteID equals v.ClienteID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       group dv by c.Nombre into grupo
                                       select new ClienteVentaResumenDTO
                                       {
                                           NombreCliente = grupo.Key,
                                           TotalVentas = grupo.Select(x => x.VentaID).Distinct().Count(),
                                           TotalGastado = grupo.Sum(x => x.Cantidad * x.PrecioUnitario),
                                           PromedioPorProducto = grupo.Average(x => x.PrecioUnitario)
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar resumen de ventas por cliente: " + ex.Message);
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
        public async Task<List<ClienteDetalleDTO>> ListarClientesConProductosYPuntoVenta()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta on c.ClienteID equals v.ClienteID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       join p in _dbContext.Producto on dv.ProductoID equals p.ProductoID
                                       join pv in _dbContext.PuntoDeVenta on v.PuntoID equals pv.PuntoID
                                       group new { dv, p, pv } by new { NombreCliente = c.Nombre, NombrePunto = pv.Nombre } into grupo
                                       select new ClienteDetalleDTO
                                       {
                                           NombreCliente = grupo.Key.NombreCliente,
                                           PuntoDeVenta = grupo.Key.NombrePunto,
                                           ProductosComprados = grupo.Select(x => x.p.Nombre).Distinct().ToList(),
                                           TotalGastado = grupo.Sum(x => x.dv.Cantidad * x.dv.PrecioUnitario)
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes: " + ex.Message);
            }
        }
        public async Task<List<ClienteResumenDTO>> ListarResumenClientes()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta on c.ClienteID equals v.ClienteID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       join p in _dbContext.Producto on dv.ProductoID equals p.ProductoID
                                       group dv by c.Nombre into grupo
                                       let totalVentas = grupo.Select(x => x.VentaID).Distinct().Count()
                                       select new ClienteResumenDTO
                                       {
                                           NombreCliente = grupo.Key,
                                           NumeroVentas = totalVentas,
                                           CantidadProductos = grupo.Sum(x => x.Cantidad),
                                           TotalGastado = grupo.Sum(x => x.Cantidad * x.PrecioUnitario),
                                           PromedioPorVenta = totalVentas == 0 ? 0 : grupo.Sum(x => x.Cantidad * x.PrecioUnitario) / totalVentas
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar resumen de clientes: " + ex.Message);
            }
        }
        public async Task<List<ClienteUltimaCompraDTO>> ListarUltimaCompraClientes()
        {
            try
            {
                var resultado = await (from c in _dbContext.Cliente
                                       join v in _dbContext.Venta on c.ClienteID equals v.ClienteID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       join p in _dbContext.Producto on dv.ProductoID equals p.ProductoID
                                       join pv in _dbContext.PuntoDeVenta on v.PuntoID equals pv.PuntoID
                                       orderby v.Fecha descending
                                       group new { v, dv, p, pv } by c.Nombre into grupo
                                       let ultimaVenta = grupo.OrderByDescending(x => x.v.Fecha).FirstOrDefault()
                                       select new ClienteUltimaCompraDTO
                                       {
                                           NombreCliente = grupo.Key,
                                           UltimoProducto = ultimaVenta.p.Nombre,
                                           FechaUltimaVenta = ultimaVenta.v.Fecha,
                                           PuntoDeVenta = ultimaVenta.pv.Nombre
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar última compra de clientes: " + ex.Message);
            }
        }


    }
}
