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
        public async Task InsertarCliente()
        {
           /* var cliente = new Cliente { Nombre = "Juan Pérez", TipoCliente = "Minorista", Direccion = "Calle Arrieros 23", Telefono = "0987654321", Correo = "juan.perez@example.com" };
            await _clienteServicio.AddClienteAsync(cliente);*/
            var cliente = new Cliente { Nombre = "María Gómez", TipoCliente = "Mayorista", Direccion = "Avenida Siempre Viva 742", Telefono = "0998877665", Correo = "maria.gomez@example.com" };
            await _clienteServicio.AddClienteAsync(cliente);
            /*var result = await _clienteServicio.GetAllClienteAsync();
            foreach (var cliente in result)*/
                Assert.Pass();

        }
        [TearDown]
        public void Limpiar()
        {
            _context.Dispose();
        }

    }
}
