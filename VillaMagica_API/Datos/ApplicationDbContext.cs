using Microsoft.EntityFrameworkCore;
using VillaMagica_API.Modelos;

namespace VillaMagica_API.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Nombre = "Casitas",
                    Detalle = "Fernando",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now

                },
                new Villa
                {
                    Id = 2,
                    Nombre = "navarro",
                    Detalle="Mont",
                    ImagenUrl = "",
                    Ocupantes = 10,
                    MetrosCuadrados = 50,
                    Tarifa = 1200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now

                }
              );
        }

    }
}
