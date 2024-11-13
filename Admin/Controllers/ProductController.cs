using Admin.Managers.Catalog;
using Admin.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IProductManager _productManager;
        public ProductController(ICategoryManager categoryManager,
            IProductManager productManager)
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetProducts(int? year, int? month, int? day)
        {
            var products = await _productManager.GetAllProducts(year, month, day);
            return Json(new { data = products });
        }
        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = await _categoryManager.GetAllCategories();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productManager.Add(productModel))
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = await _categoryManager.GetAllCategories();
            return View(productModel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productModel = await _productManager.GetProduct(id);
            ViewBag.Categories = await _categoryManager.GetAllCategories();
            return View(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productManager.Edit(productModel))
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = await _categoryManager.GetAllCategories();
            return View(productModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productManager.Delete(id))
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}
