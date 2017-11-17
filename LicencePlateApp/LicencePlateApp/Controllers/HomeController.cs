using LicencePlateApp.Models;
using LicencePlateApp.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            List<LicencePlate> cars = new List<LicencePlate>();
            if (q != null)
            {
                cars.Add(LicencePlateService.SearchForCarByPlate(q));
            }
            if (police == 1)
            {
                cars = LicencePlateService.PoliceCars();
            }
            if (diplomat == 1)
            {
                cars = LicencePlateService.DiplomatCars();
            }
            return View(cars);
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
