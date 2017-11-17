using LicencePlateApp.Models;
using System.Collections.Generic;

namespace LicencePlateApp.ViewModels
{
    public class CarList
    {
        public string Result { get; set; }
        public List<LicencePlate> Data { get; set; }
    }
}
