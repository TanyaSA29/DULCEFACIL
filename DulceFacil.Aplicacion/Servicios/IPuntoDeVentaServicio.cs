using DulceFaci.Aplicacion.DTO.DTOs;
using DulceFacil.Infraestructura.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Aplicacion.Servicios
{
    [ServiceContract]
    public interface IPuntoDeVentaServicio
    {

        [OperationContract]
        Task AddPuntoDeVentaServicioAsync(PuntoDeVenta nuevopunto);

        [OperationContract]
        Task DeletePuntoDeVentaAsync(int id);

        [OperationContract]
        Task UpdatePuntoDeVentaAsync(PuntoDeVenta entidad);

        [OperationContract]
        Task<IEnumerable<PuntoDeVenta>> GetAllPuntoDeVentaAsync();

        [OperationContract]
        Task<PuntoDeVenta> GetByIdPuntoDeVentaAsync(int id);
        [OperationContract]
        Task<List<PuntoVentaResumenDTO>> ListarResumenPuntosDeVenta();

    }
}


