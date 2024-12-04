using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KatherineCastilloEntidadNegocio;
using KatherineCastilloLogicaNegocio;
namespace KatherineCastiiloSeguridadUI.AppWebCore.Controllers
{
    public class CategoriaController1 : Controller
    {
        private readonly CategoriaBL _categoriaBL;

        public CategoriaController1(CategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }
        // GET: CategoriaController1
        public async Task<IActionResult> Index()
        {
            var categoria = await _categoriaBL.GetAllAsync();
            return View(categoria);
        }

        // GET: CategoriaController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            return View(categoria);
        }

        // GET: CategoriaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria kCategoria)
        {

            await _categoriaBL.CreateCategoriaAsync(kCategoria);
            return Redirect("/Categoria/Index");

        }

        // GET: CategoriaController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: CategoriaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria kCategoria)
        {
            await _categoriaBL.UpdateCategoriaAsync(kCategoria);
            return Redirect("/Categoria/Index");
        }

        // GET: CategoriaController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: CategoriaController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaBL.DeleteCategoriaAsync(id);
            return Redirect("/Categoria/Index");
        }
    }
}
