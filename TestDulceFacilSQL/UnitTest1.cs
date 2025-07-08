using DulceFacil.Aplicacion.ServicioImpl;
using DulceFacil.Aplicacion.Servicios;
using DulceFacil.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace TestDulceFacilSQL
{
    public class Tests
    {
        private BDDulceFacilContext _context;
        private IClienteServicio _clienteServicio;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BDDulceFacilContext>()
                .UseSqlServer("Data Source=StephyR;Initial Catalog=BDDulceFacil;Integrated Security=True; Encrypt = true; TrustServerCertificate = true;")
                .Options; //cadena de conexcion a las BD
            _context = new BDDulceFacilContext(options);
            _clienteServicio = new ClienteServicioImpl(_context);

        }
        [Test]
        /*public async Task InsertarCliente()
        {
            var cliente = new Cliente { Nombre = "Juan Pérez", TipoCliente = "Minorista", Direccion = "Calle Arrieros 23", Telefono = "0987654321", Correo = "juan.perez@example.com" };
            await _clienteServicio.AddClienteAsync(cliente);
            var cliente = new Cliente { Nombre = "María Gómez", TipoCliente = "Mayorista", Direccion = "Avenida Siempre Viva 742", Telefono = "0998877665", Correo = "maria.gomez@example.com" };
            await _clienteServicio.AddClienteAsync(cliente);
            var result = await _clienteServicio.GetAllClienteAsync();
            foreach (var cliente in result)
                Assert.Pass();
        }*/
        //CONSULTA COMPLEJA #1
        public async Task ListarClientes()
        {
            var clientes = await _clienteServicio.ListarClientesActivos();
            Assert.IsNotNull(clientes);
        }

        //consulta COMPLEJA #2
        public async Task ListarClientesCostosos()
        {
            decimal precioFiltro = 100m; // por ejemplo
            var clientes = await _clienteServicio.ListarClientesConVentasDeProductosCostosos(precioFiltro);
            // Aquí puedes hacer asserts o imprimir los resultados
        }
        //CONSULTA COMPLEJA #3
        public async Task TestListarDetalleComprasPorCliente()
        {
            var lista = await _clienteServicio.ListarDetalleComprasPorCliente();

            foreach (var cliente in lista)
            {
                Console.WriteLine($"Cliente: {cliente.NombreCliente}");
                Console.WriteLine($"Productos Comprados:");
                foreach (var producto in cliente.ProductosComprados)
                {
                    Console.WriteLine($" - {producto}");
                }
                Console.WriteLine($"Cantidad total productos: {cliente.CantidadTotalProductos}");
                Console.WriteLine($"Total gastado: {cliente.TotalGastado:C}");
                Console.WriteLine("-----");
            }
        }
        //CONSULTA COMPLEJA #4
        public async Task TestListarResumenVentasPorCliente()
        {
            var lista = await _clienteServicio.ListarResumenVentasPorCliente();
            foreach (var cliente in lista)
            {
                Console.WriteLine($"Cliente: {cliente.NombreCliente}");
                Console.WriteLine($"Total ventas: {cliente.TotalVentas}");
                Console.WriteLine($"Total gastado: {cliente.TotalGastado:C}");
                Console.WriteLine($"Promedio por producto: {cliente.PromedioPorProducto:C}");
                Console.WriteLine("-----");
            }
        }
        //Consulta COMPLEJA#5
        public async Task TestListarClientesConProductosYPuntoVenta()
        {
            var lista = await _clienteServicio.ListarClientesConProductosYPuntoVenta();

            Assert.IsNotNull(lista);
            Assert.IsNotEmpty(lista);

            foreach (var cliente in lista)
            {
                Console.WriteLine($"Cliente: {cliente.NombreCliente}");
                Console.WriteLine($"Punto de venta: {cliente.PuntoDeVenta}");
                Console.WriteLine($"Productos: {string.Join(", ", cliente.ProductosComprados)}");
                Console.WriteLine($"Total gastado: {cliente.TotalGastado:C}");
                Console.WriteLine("-----");
            }
        }
        // Consulta COMPLEJA #6
        public async Task TestListarResumenClientes()
        {
            var lista = await _clienteServicio.ListarResumenClientes();

            Assert.IsNotNull(lista);
            Assert.IsNotEmpty(lista);

            foreach (var cliente in lista)
            {
                Console.WriteLine($"Cliente: {cliente.NombreCliente}");
                Console.WriteLine($"Número ventas: {cliente.NumeroVentas}");
                Console.WriteLine($"Cantidad productos: {cliente.CantidadProductos}");
                Console.WriteLine($"Total gastado: {cliente.TotalGastado:C}");
                Console.WriteLine($"Promedio por venta: {cliente.PromedioPorVenta:C}");
                Console.WriteLine("-----");
            }
        }
        //Consulta COMPLEJA #7
        public async Task TestListarUltimaCompraClientes()
        {
            var lista = await _clienteServicio.ListarUltimaCompraClientes();

            Assert.IsNotNull(lista);
            Assert.IsNotEmpty(lista);

            foreach (var cliente in lista)
            {
                Console.WriteLine($"Cliente: {cliente.NombreCliente}");
                Console.WriteLine($"Último producto: {cliente.UltimoProducto}");
                Console.WriteLine($"Fecha última venta: {cliente.FechaUltimaVenta}");
                Console.WriteLine($"Punto de venta: {cliente.PuntoDeVenta}");
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
    

    

