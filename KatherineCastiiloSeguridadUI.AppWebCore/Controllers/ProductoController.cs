using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KatherineCastilloAccesoDatos;
using KatherineCastilloEntidadNegocio;
using KatherineCastilloLogicaNegocio;

namespace KatherineCastiiloSeguridadUI.AppWebCore.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL _productoBL;

        public ProductoController(ProductoBL productoBL)
        {
            _productoBL = productoBL;
        }


        // GET: ProductoController
        public async Task <ActionResult> Index()
        {
            var producto = await _productoBL.GetAllAsync();
            return View(producto);
        }

        // GET: ProductoController/Details/5
        [HttpGet("{id}")]
        public async Task <IActionResult> Details(int id)
        {
            var categoria = await _productoBL.GetByIdAsync(id);
            return View(categoria);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto kProducto)
        {
            if (string.IsNullOrEmpty(kProducto.Nombre))
            {
                ModelState.AddModelError("Nombre ", "Es obligatorio");
                return View(kProducto);
            }
            int result = await _productoBL.CreateProductoAsync(kProducto);
            return Redirect("/Producto/Index");
        }

        // GET: ProductoController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var producto = await _productoBL.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Producto kProducto)
        {
            if (string.IsNullOrEmpty(kProducto.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(kProducto); // Vuelve a la vista con el error.
            }

            int result = await _productoBL.EditProductoAsync(kProducto);
            return Redirect("/Producto/Index");
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _productoBL.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: ProductoController/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoBL.DeleteAsync(id);
            return Redirect("/Producto/Index");
        }
    }
}
