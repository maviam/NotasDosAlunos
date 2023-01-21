using Microsoft.EntityFrameworkCore;
using MvcWebGradesApplication.Models;

namespace MvcWebGradesApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<FormadorModel> Formadores { get; set; }
        public DbSet<FormandoModel> Formandos { get; set; }
        public DbSet<UfcdModel> Ufcds { get; set; }
        public DbSet<NotaModel> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaModel>().HasKey(nt => new
            {
                nt.FormandoId,
                nt.CodigoUfcd
            });
        }

    }
}
