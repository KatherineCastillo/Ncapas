using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using KatherineCastilloEntidadNegocio;
namespace KatherineCastilloAccesoDatos
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet <Categoria> categoria { get; set; }
        public DbSet <Producto> producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
               .HasOne(k => k.categoria)
               .WithMany(c => c.Producto)
               .HasForeignKey(k => k.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
        }



    }
    
   
}
