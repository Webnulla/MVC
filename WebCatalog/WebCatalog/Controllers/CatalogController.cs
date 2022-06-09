using Microsoft.AspNetCore.Mvc;
using WebCatalog.Domain.Entity;

namespace WebCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private static Catalog _catalog = new Catalog();

        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult Products([FromForm] Products model)
        {
            _catalog.AddItem(model);
            return View(_catalog);
        }

        [HttpGet]
        public IActionResult ViewProducts()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult RemoveProducts([FromForm] Products model)
        {
            _catalog.RemoveItem(model);
            return View(_catalog);
        }

        [HttpGet]
        public IActionResult RemoveProducts()
        {
            return View(_catalog);
        }


    }
}
