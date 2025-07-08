
﻿using DulceFacil.Infraestructura.AccesoDatos;

﻿using DulceFaci.Aplicacion.DTO.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Dominio.Modelo.Abstracciones
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        Task<List<Producto>> ListarProductosConStock();

        Task<List<ProductoTipoDTO>> ListarProductosPorTipo();
        Task<List<ProductoClientesDTO>> ListarProductosVendidosConClientes();

    }
}
