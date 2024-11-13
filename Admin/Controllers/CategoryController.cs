using Admin.Managers.Catalog;
using Admin.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryManager.Add(categoryModel))
                {
                    return RedirectToAction("Add");
                }
            }

            return View(categoryModel);
        }
    }
}
