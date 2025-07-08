using DulceFacil.Aplicacion.ServicioImpl;
using DulceFacil.Aplicacion.Servicios;
using DulceFacil.Infraestructura.AccesoDatos;
using DulceFacil.Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDulceFacilSQL 
{
   public class Test3
    {
        private BDDulceFacilContext _context;
        private IPuntoDeVentaServicio _puntoDeVentaServicio;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BDDulceFacilContext>()
                .UseSqlServer("Data Source=StephyR;Initial Catalog=BDDulceFacil;Integrated Security=True;Encrypt=true;TrustServerCertificate=true;")
                .Options;

            _context = new BDDulceFacilContext(options);
            _puntoDeVentaServicio = new PuntoDeVentaServicioImpl(_context);
        }

        [Test]
//CONSULTA COMPLEJA #10
        public async Task TestListarResumenPuntosDeVenta()
        {
            var resumenes = await _puntoDeVentaServicio.ListarResumenPuntosDeVenta();

            foreach (var punto in resumenes)
            {
                Console.WriteLine($"Punto de venta: {punto.NombrePunto}");
                Console.WriteLine($"Total ventas: {punto.TotalVentas}");
                Console.WriteLine($"Total recaudado: {punto.TotalRecaudado:C}");
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
