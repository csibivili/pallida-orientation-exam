using LicencePlateApp.Models;
using LicencePlateApp.Service;
using LicencePlateApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LicencePlateApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private LicencePlateService LicencePlateService;
        List<LicencePlate> Cars;

        public HomeController(LicencePlateService licencePlateService)
        {
            LicencePlateService = licencePlateService;
            Cars = new List<LicencePlate>();
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult Search(string q, int police, int diplomat)
        {
            if (q != null)
            {
                Cars = LicencePlateService.SearchForCarByPlate(q);
            }
            if (police == 1)
            {
                Cars = LicencePlateService.PoliceCars();
            }
            if (diplomat == 1)
            {
                Cars = LicencePlateService.DiplomatCars();
            }
            return View("Plates",Cars);
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult BrandSearch(string brand)
        {
            Cars = LicencePlateService.CarsWithSameBrand(brand);
            return View("Plates", Cars);
        }

        [HttpGet]
        [Route("/api/search/{brand}")]
        public IActionResult ApiBrandSearch(string brand)
        {
            CarList carList = new CarList();
            Cars = LicencePlateService.CarsWithSameBrand(brand);
            if (Cars.Count != 0)
            {
                carList.Result = "ok";
                carList.Data = Cars;
            }
            else
            {
                carList.Result = "notfound";
                carList.Data = Cars;
            }
            return Json(carList);
        }
    }
}
