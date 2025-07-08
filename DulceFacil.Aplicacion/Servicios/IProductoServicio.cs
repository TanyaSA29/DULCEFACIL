
﻿using DulceFacil.Infraestructura.AccesoDatos;
using DulceFaci.Aplicacion.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Aplicacion.Servicios
{
    [ServiceContract]
    public interface IProductoServicio
    {

        [OperationContract]
        Task AddProductoAsync(Producto nuevoproducto);

        [OperationContract]
        Task DeleteProductoAsync(int id);

        [OperationContract]
        Task UpdateProductoAsync(Producto entidad);

        [OperationContract]
        Task<IEnumerable<Producto>> GetAllProductoAsync();

        [OperationContract]
        Task<Producto> GetByIdProductoAsync(int id);

        [OperationContract]
        Task<List<Producto>> ListarProductosConStock();

        [OperationContract]

        public Task<List<ProductoTipoDTO>> ListarProductosPorTipo();
        [OperationContract]
        public Task<List<ProductoClientesDTO>> ListarProductosVendidosConClientes();
    }
}
