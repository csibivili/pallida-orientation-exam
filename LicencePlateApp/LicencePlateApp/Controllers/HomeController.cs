using LicencePlateApp.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LicencePlateApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private LicencePlateService LicencePlateService;

        public HomeController(LicencePlateService licencePlateService)
        {
            LicencePlateService = licencePlateService;
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult Search(string q, int police, int diplomat)
        {
            return View();
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult BrandSearch(string brand)
        {
            return View();
        }

        [HttpGet]
        [Route("/api/search/{brand}")]
        public IActionResult ApiBrandSearch(string brand)
        {
            return View();
        }
    }
}
