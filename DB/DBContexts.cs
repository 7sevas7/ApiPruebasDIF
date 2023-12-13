using ApiPruebasDIF.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebasDIF.DB
{
    public class DBContexts : DbContext
    {
        //Models
        public DbSet<UnidadesIngresos> UnidadesIngreso { set; get; }
        public DbSet<UnidadesPresupuesto> UnidadesPresupuesto { set; get; }

        public DBContexts(DbContextOptions<DBContexts> opt) : base(opt)
        {
                
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UnidadesIngresos>(entity =>
        //    {
        //        entity.HasKey(col => col.IdUnidades);
        //        entity.Property(col => col.IdUnidades).IsRequired().ValueGeneratedOnAdd();
        //    });
        //    modelBuilder.Entity<UnidadesPresupuesto>(entity =>
        //    {
        //        entity.HasKey(col => col.Id);
        //        entity.Property(col => col.Id).IsRequired().ValueGeneratedOnAdd();
        //    });
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    string conexion = $"Filename={Ruta("SIEBPruebas.db")}";
        //    optionsBuilder.UseSqlite(conexion);

        //}
        //public static string Ruta(string NombreDB)
        //{
        //    string ruta = string.Empty;
           
        //        ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        ruta = Path.Combine(ruta, NombreDB);
            
        //    return ruta;
        //}
    }
}
