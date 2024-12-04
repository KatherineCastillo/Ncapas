
using KatherineCastilloEntidadNegocio;

using KatherineCastilloEntidadNegocio;

namespace KatherineCastilloLogicaNegocio
{
    public class ProductoBL
    {
        private readonly ProductoDAL _productoDAL;

        public ProductoBL(ProductoDAL productoDAL)
        {
            _productoDAL = productoDAL;
        }

        public async Task<int> CreateProductoAsync(Producto kProducto)
        {
          

            return await _productoDAL.CreateProductoAsync(kProducto);
        }

        public async Task<int> EditProductoAsync(Producto kProducto)
        {
            

            return await _productoDAL.EditProductoAsync(kProducto);
        }

        public async Task<Producto> GetByIdAsync(int id)
        {
            

            var producto = await _productoDAL.GetByIdAsync(new Producto { CategoriaId = id });

            

            return producto;
        }

        public async Task<List<Producto>> GetAllAsync()
        {
            return await _productoDAL.GetAllAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            


            var producto = new Producto {CategoriaId = id };

            return await _productoDAL.DeleteAsync(producto);
        }
    }
}
