using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatherineCastilloAccesoDatos;
using KatherineCastilloEntidadNegocio;

namespace KatherineCastilloLogicaNegocio
{
    public class CategoriaBL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBL(CategoriaDAL categoriaDAL)
        {
            _categoriaDAL = categoriaDAL;
        }

        public async Task<int> CreateCategoriaAsync(Categoria kCategoria)
        {

            return await _categoriaDAL.CreateCategoriaAsync(kCategoria);
        }

        public async Task<int> UpdateCategoriaAsync(Categoria kCategoria)
        {
           

            return await _categoriaDAL.UpdateCategoriaAsync(kCategoria);
        }

        public async Task<int> DeleteCategoriaAsync(int categoriaId)
        {
           

            var categoria = new Categoria { Id = categoriaId };
            return await _categoriaDAL.DeleteCategoriaAsync(categoria);
        }

        public async Task<Categoria> GetByIdAsync(int categoriaId)
        {
           

            var categoria = await _categoriaDAL.GetById(new Categoria { Id = categoriaId });


            return categoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _categoriaDAL.GetAllAsync(new Categoria());
        }

    }
}
