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
    public interface IClienteServicio
    {
        [OperationContract]
        Task AddClienteAsync(Cliente nuevocliente);

        [OperationContract]
        Task DeleteClienteAsync(int id);
        [OperationContract]
        Task UpdateClienteAsync(Cliente entidad);
        [OperationContract]
        Task<IEnumerable<Cliente>> GetAllClienteAsync();

        [OperationContract]
        Task<Cliente> GetClienteByIdAsync(int id);
        [OperationContract]
        Task<List<Cliente>> ListarClientesActivos();
        [OperationContract]
        Task<List<Cliente>> ListarClientesConVentasDeProductosCostosos(decimal precioMinimo);



    }
}
