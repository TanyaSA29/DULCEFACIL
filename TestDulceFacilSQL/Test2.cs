using DulceFacil.Aplicacion.ServicioImpl;
using DulceFacil.Aplicacion.Servicios;
using DulceFacil.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDulceFacilSQL
{
    public class Tests2
    {
        private BDDulceFacilContext _context;
        private IProductoServicio _productoServicio;
        private DbContextOptions<BDDulceFacilContext> _options;

        [SetUp]
        public async Task Setup()
        {
            _options = new DbContextOptionsBuilder<BDDulceFacilContext>()
                .UseSqlServer("Data Source=StephyR;Initial Catalog=BDDulceFacil;Integrated Security=True;Encrypt=true;TrustServerCertificate=true;")
                .Options;

            _context = new BDDulceFacilContext(_options);
            _productoServicio = new ProductoServicioImpl(_context);

           
            if (!_context.Producto.Any(p => p.Stock > 0))
            {
                _context.Producto.Add(new Producto
                {
                    Nombre = "ProductoTest",
                    Descripcion = "Producto para test",
                    Precio = 10.5m,
                    Stock = 5
                });
                await _context.SaveChangesAsync();
            }
        }

        [Test]
        //consulta #3
        public async Task ListarProductosConStock()
        {
            var productos = await _productoServicio.ListarProductosConStock();
            Assert.IsNotNull(productos);
            Assert.IsTrue(productos.Any(), "Debe haber al menos un producto con stock");
        }

        [TearDown]
        public void Limpiar()
        {
            _context.Dispose();
        }
    }
}
