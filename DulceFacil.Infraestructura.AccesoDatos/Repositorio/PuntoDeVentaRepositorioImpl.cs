using DulceFacil.Dominio.Modelo.Abstracciones;

﻿using DulceFaci.Aplicacion.DTO.DTOs;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Infraestructura.AccesoDatos.Repositorio
{
    public class PuntoDeVentaRepositorioImpl: RepositorioImpl<PuntoDeVenta>, IPuntoDeVentaRepositorio
    {

        private readonly BDDulceFacilContext _dbContext;
        public PuntoDeVentaRepositorioImpl(BDDulceFacilContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<List<PuntoVentaResumenDTO>> ListarResumenPuntosDeVenta()
        {
            try
            {
                var resultado = await (from p in _dbContext.PuntoDeVenta
                                       join v in _dbContext.Venta on p.PuntoID equals v.PuntoID
                                       join dv in _dbContext.DetalleVenta on v.VentaID equals dv.VentaID
                                       group dv by p.Nombre into grupo
                                       select new PuntoVentaResumenDTO
                                       {
                                           NombrePunto = grupo.Key,
                                           TotalVentas = grupo.Select(x => x.VentaID).Distinct().Count(),
                                           TotalRecaudado = grupo.Sum(x => x.Cantidad * x.PrecioUnitario)
                                       }).ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar resumen de puntos de venta: " + ex.Message);
            }
        }

    }


}
