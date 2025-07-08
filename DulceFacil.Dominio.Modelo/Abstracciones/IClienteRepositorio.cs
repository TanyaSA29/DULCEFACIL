using DulceFacil.Infraestructura.AccesoDatos;
﻿using DulceFaci.Aplicacion.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Dominio.Modelo.Abstracciones
{
    public interface IClienteRepositorio : IRepositorio<Cliente>    
    {
        public Task<List<Cliente>> ListarClientesActivos();
        Task<List<Cliente>> ListarClientesConVentasDeProductosCostosos(decimal precioMinimo);

        Task<List<ClienteVentaResumenDTO>> ListarResumenVentasPorCliente();

        public Task<List<ClienteCompraDetalleDTO>> ListarDetalleComprasPorCliente();

        public Task<List<ClienteDetalleDTO>> ListarClientesConProductosYPuntoVenta();

        public Task<List<ClienteResumenDTO>> ListarResumenClientes();

        public Task<List<ClienteUltimaCompraDTO>> ListarUltimaCompraClientes();
        public Task<List<ClienteVentasDTO>> ListarClientesConVentas();
    }
}
