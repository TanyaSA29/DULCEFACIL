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

        //consulta SIMPLE #8
        public async Task ListarProductosConStock()

        {
            var productos = await _productoServicio.ListarProductosConStock();
            Assert.IsNotNull(productos);
            Assert.IsTrue(productos.Any(), "Debe haber al menos un producto con stock");
        }

        public async Task TestListarProductosPorTipo()
        {
            var productos = await _productoServicio.ListarProductosPorTipo();
            foreach (var item in productos)
            {
                Console.WriteLine(item.TipoProducto);
                foreach (var nombre in item.NombresProductos)
                {
                    Console.WriteLine($" - {nombre}");
                }
            }
        }
        //CONSULTA COMPLEJA #9
        public async Task TestListarProductosVendidosConClientes()
        {
            var productos = await _productoServicio.ListarProductosVendidosConClientes();
            foreach (var prod in productos)
            {
                Console.WriteLine($"Producto: {prod.NombreProducto}");
                Console.WriteLine($"Cantidad vendida: {prod.CantidadVendida}");
                Console.WriteLine("Clientes:");
                foreach (var cliente in prod.Clientes)
                {
                    Console.WriteLine($" - {cliente}");
                }
                Console.WriteLine("-----");
            }
        }


        [TearDown]
        public void Limpiar()
        {
            _context.Dispose();

        }
    }
}
   

