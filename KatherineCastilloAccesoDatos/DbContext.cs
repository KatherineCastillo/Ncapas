using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using KatherineCastilloEntidadNegocio;
namespace KatherineCastilloAccesoDatos
{
    public class DbContext: DbContext
    {
        public DbContext(DbContextOptions<DbContext>options) : base(options)
        {

        }
        public DbSet <Categoria> Categorias { get; set; }
        public DbSet <Producto> Productos { get; set; }

        

    }
    
   
}
