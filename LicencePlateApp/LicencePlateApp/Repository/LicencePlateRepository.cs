using LicencePlateApp.Entities;
using LicencePlateApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LicencePlateApp.Repository
{
    public class LicencePlateRepository
    {
        private LicencePlateContext LicencePlateContext;

        public LicencePlateRepository(LicencePlateContext licencePlateContext)
        {
            LicencePlateContext = licencePlateContext;
        }

        public List<LicencePlate> SearchForCarByPlate(string letters, string numbers)
        {
            return LicencePlateContext.Licence_plates.Where(p => p.Plate.Contains(letters) && p.Plate.Contains(numbers)).ToList();
        }

        public List<LicencePlate> PoliceCars()
        {
            return LicencePlateContext.Licence_plates.Where(p => p.Plate.StartsWith("RB")).ToList();
        }

        public List<LicencePlate> DiplomatCars()
        {
            return LicencePlateContext.Licence_plates.Where(p => p.Plate.StartsWith("DT")).ToList();
        }
    }
}
