using Microsoft.AspNetCore.Mvc;
using WebCatalog.Domain.Entity;

namespace WebCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private Catalog<Products> _catalog = new Catalog<Products>();
        private Catalog<Categories> _categories = new Catalog<Categories>();

        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult Products(Products model)
        {
            _catalog.ProductsList.Add(model);
            return View(_catalog);
        }

        [HttpGet]
        public IActionResult NewCategoryProducts()
        {
            return View(_categories);
        }

        [HttpPost]
        public IActionResult NewCategoryProducts(Categories model)
        {
            _categories.ProductsList.Add(model);
            return View(_categories);
        }
    }
}
