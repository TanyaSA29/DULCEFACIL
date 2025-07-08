using DulceFaci.Aplicacion.DTO.DTOs;
using DulceFacil.Aplicacion.Servicios;
using DulceFacil.Dominio.Modelo.Abstracciones;
using DulceFacil.Infraestructura.AccesoDatos;
using DulceFacil.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Aplicacion.ServicioImpl
{
    public class ClienteServicioImpl : IClienteServicio
    {
        private IClienteRepositorio clienteRepositorio;
        public ClienteServicioImpl(BDDulceFacilContext _BDDulceFacilContext)
        {
            this.clienteRepositorio = new ClienteRepositorioImpl(_BDDulceFacilContext);
        }

        public async Task AddClienteAsync(Cliente nuevocliente)
        {
            await clienteRepositorio.AddAsync(nuevocliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await clienteRepositorio.DeleteAsync(id); 
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            return await clienteRepositorio.GetAllAsync();
        }

        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            return clienteRepositorio.GetByIdAsync(id);
        }

        public Task<List<Cliente>> ListarClientesActivos()
        {
            return clienteRepositorio.ListarClientesActivos();
        }

        public Task<List<ClienteDetalleDTO>> ListarClientesConProductosYPuntoVenta()
        {
            return clienteRepositorio.ListarClientesConProductosYPuntoVenta();
        }

        public Task<List<ClienteVentasDTO>> ListarClientesConVentas()
        {
            return clienteRepositorio.ListarClientesConVentas();
        }

        public Task<List<Cliente>> ListarClientesConVentasDeProductosCostosos(decimal precioMinimo)
        {
            return clienteRepositorio.ListarClientesConVentasDeProductosCostosos(precioMinimo);
        }

        public Task<List<ClienteCompraDetalleDTO>> ListarDetalleComprasPorCliente()
        {
            return clienteRepositorio.ListarDetalleComprasPorCliente();
        }

        public Task<List<ClienteResumenDTO>> ListarResumenClientes()
        {
            return clienteRepositorio.ListarResumenClientes();
        }

        public Task<List<ClienteVentaResumenDTO>> ListarResumenVentasPorCliente()
        {
            return clienteRepositorio.ListarResumenVentasPorCliente();
        }

        public Task<List<ClienteUltimaCompraDTO>> ListarUltimaCompraClientes()
        {
            return clienteRepositorio.ListarUltimaCompraClientes();
        }


        public async Task UpdateClienteAsync(Cliente entidad)
        {
            await clienteRepositorio.UpdateAsync(entidad);
        }

    }
}