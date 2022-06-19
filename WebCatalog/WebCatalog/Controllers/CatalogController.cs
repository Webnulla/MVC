using Microsoft.AspNetCore.Mvc;
using WebCatalog.Domain.EmailSender;
using WebCatalog.Domain.Entity;

namespace WebCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private static Catalog _catalog = new Catalog();
        private readonly EmailService _emailService;

        public CatalogController(EmailService emailService)
        {
            _emailService = emailService;
        }

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

        public async Task<IActionResult> SendMessage()
        {
            await _emailService.SendEmail("muselsps@ya.ru", "New", "Test"); //SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
            return RedirectToAction("Products");
        }
    }
}
