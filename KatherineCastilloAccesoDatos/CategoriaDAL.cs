using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using KatherineCastilloEntidadNegocio;
namespace KatherineCastilloAccesoDatos
{
    public class CategoriaDAL
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateCategoriaAsync(Categoria kCategoria)
        {
            var categoria = new Categoria
            {
                Id = kCategoria.Id,
                Nombre = kCategoria.Nombre,
                
            };
            _appDbContext.Add(categoria);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> EditCategoriaAsync(Categoria kCategoria)
        {
            var categoria = await _appDbContext.categoria.FirstOrDefaultAsync(k => k.Id == kCategoria.Id);
            if (categoria != null)
            {
                categoria.Id = kCategoria.Id;
                categoria.Nombre = kCategoria.Nombre;
                
                return await _appDbContext.SaveChangesAsync();
            };
            return 0;
        }


        public async Task<int> UpdateCategoriaAsync(Categoria kCategoria)
        {
            var categoria = await _appDbContext.categoria.FirstOrDefaultAsync(k => k.Id == kCategoria.Id);
            if (categoria != null)
            {
                categoria.Id = kCategoria.Id;
                categoria.Nombre = kCategoria.Nombre;
                return await _appDbContext.SaveChangesAsync();
            };
            return 0;
        }

        public async Task<int> DeleteCategoriaAsync(Categoria kCategoria)
        {
            var categoria = await _appDbContext.categoria.FirstOrDefaultAsync(k => k.Id == kCategoria.Id);
            if (categoria != null)
            {
                _appDbContext.categoria.Remove(categoria);
                return await _appDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Categoria> GetById(Categoria kCategoria)
        {
            var categoria = await _appDbContext.categoria.FirstOrDefaultAsync(k => k.Id == kCategoria.Id);
            if (categoria != null)
            {
                return new Categoria
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    
                };
            }
            return new Categoria();
        }

        public async Task<List<Categoria>> GetAllAsync(Categoria kCategoria)
        {
            var categoria = await _appDbContext.categoria.ToListAsync();
            if (categoria != null && categoria.Count > 0)
            {
                var list = new List<Categoria>();
                categoria.ForEach(c => list.Add(new Categoria
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    
                }));
                return list;
            }
            return new List<Categoria>();
        }
    }
}
