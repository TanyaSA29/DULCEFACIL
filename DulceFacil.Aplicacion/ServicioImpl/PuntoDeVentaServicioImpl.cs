using DulceFaci.Aplicacion.DTO.DTOs;
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
    public class PuntoDeVentaServicioImpl : IPuntoDeVentaServicio
    {
        private IPuntoDeVentaRepositorio _puntoDeVentaRepositorio;

        public PuntoDeVentaServicioImpl(BDDulceFacilContext _BDDulceFacilContext)
        {
            this._puntoDeVentaRepositorio = new PuntoDeVentaRepositorioImpl(_BDDulceFacilContext);
        }

        public async Task AddPuntoDeVentaAsync(PuntoDeVenta nuevoPunto)
        {
            await _puntoDeVentaRepositorio.AddAsync(nuevoPunto);
        }

        public async Task DeletePuntoDeVentaAsync(int id)
        {
            await _puntoDeVentaRepositorio.DeleteAsync(id);
        }

        public Task<PuntoDeVenta> GetByIdPuntoDeVentaAsync(int id)
        {
            return _puntoDeVentaRepositorio.GetByIdAsync(id);
        }

        public async Task UpdatePuntoDeVentaAsync(PuntoDeVenta entidad)
        {
            await _puntoDeVentaRepositorio.UpdateAsync(entidad);

        }

        public Task<List<PuntoVentaResumenDTO>> ListarResumenPuntosDeVenta()
        {
            return _puntoDeVentaRepositorio.ListarResumenPuntosDeVenta();
        }
        /// //
        public Task AddPuntoDeVentaServicioAsync(PuntoDeVenta nuevopunto)
        {
            return _puntoDeVentaRepositorio.ListarResumenPuntosDeVenta();
        }

        public async Task<IEnumerable<PuntoDeVenta>> GetAllPuntoDeVentaAsync()
        {
            return await _puntoDeVentaRepositorio.GetAllAsync();
        }
    }
}
