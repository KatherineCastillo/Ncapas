using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KatherineCastilloEntidadNegocio;

namespace KatherineCastilloAccesoDatos
{
    internal class ProductoDAL
    {
        private readonly AppDbContext _appDbContext;

        public ProductoDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateProductoAsync(Producto kProducto)
        {
            var producto = new Producto
            {
                Nombre = kProducto.Nombre,
                Precio = kProducto.Precio,
                CategoriaId = kProducto.CategoriaId,

            };
            _appDbContext.Add(producto);
            return await _appDbContext.SaveChangesAsync();
        }
        public async Task<int> EditProductoAsync(Producto kProducto)
        {
            var producto = await _appDbContext.producto.FirstOrDefaultAsync(k => k.Id == kProducto.Id);
            if (producto != null)
            {
                producto.Nombre = kProducto.Nombre;
                producto.Precio = kProducto.Precio;
                producto.CategoriaId = kProducto.CategoriaId;
                return await _appDbContext.SaveChangesAsync();
            };
            return 0;
        }


        public async Task<int> UpdateProductoAsync(Producto kProducto)
        {
            var producto = await _appDbContext.producto.FirstOrDefaultAsync(k => k.Id == kProducto.Id);
            if (producto != null)
            {
                producto.Nombre = kProducto.Nombre;
                producto.Precio = kProducto.Precio;
                producto.CategoriaId = kProducto.CategoriaId;
                return await _appDbContext.SaveChangesAsync();
            };
            return 0;
        }

        public async Task<int> DeleteProductoAsync(Producto kProducto)
        {
            var producto = await _appDbContext.producto.FirstOrDefaultAsync(k => k.Id == kProducto.Id);
            if (producto != null)
            {
                _appDbContext.producto.Remove(producto);
                return await _appDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Producto> GetByIdAsync(Producto kProducto)
        {
            var producto = await _appDbContext.producto
                .Include(k => k.categoria)
                .FirstOrDefaultAsync(k => k.Id == kProducto.Id);

            if (producto != null)
            {
                return new Producto
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    CategoriaId = producto.CategoriaId,
                };
            }
            return new Producto();
        }

        public async Task<List<Producto>> GetAllAsync(Producto kProducto)
        {
            var producto = await _appDbContext.producto.ToListAsync();
            if (producto != null && producto.Count > 0)
            {
                var list = new List<Producto>();
                producto.ForEach(c => list.Add(new Producto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Precio = c.Precio,
                    CategoriaId = c.CategoriaId,

                }));
                return list;
            }
            return new List<Producto>();
        }
    }
}
