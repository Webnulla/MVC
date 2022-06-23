using Microsoft.AspNetCore.Mvc;
using WebCatalog.DAL.Repository.Interfaces;
using WebCatalog.Domain.EmailSender;
using WebCatalog.Domain.Entity;

namespace WebCatalog.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly EmailService _emailService;

        public CatalogController(EmailService emailService, ICatalogRepository catalogRepository)
        {
            _emailService = emailService;
            _catalogRepository = catalogRepository;
        }

        [HttpGet]
        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Products([FromForm] Products products)
        {
            _catalogRepository.Add(products);
            return View(products);
        }

        [HttpGet]
        public IActionResult ViewProducts()
        {
            var product = _catalogRepository.GetAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult RemoveProducts(int id)
        {
            _catalogRepository.Delete(id);
            return View();
        }

        [HttpGet]
        public IActionResult RemoveProducts()
        {
            return View();
        }

        public async Task<IActionResult> SendMessage()
        {
            await _emailService.SendEmail("muselsps@ya.ru", "New", "Test"); //SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond
            return RedirectToAction("Products");
        }
    }
}
