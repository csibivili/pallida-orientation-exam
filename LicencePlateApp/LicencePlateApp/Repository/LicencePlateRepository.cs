﻿using LicencePlateApp.Entities;
using LicencePlateApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LicencePlateApp.Repository
{
    public class LicencePlateRepository
    {
        private readonly string ACAB = "RB";
        private readonly string RichPeopleWhoCanUseBusLaneWithoutRealPurpose = "DT";

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
            return LicencePlateContext.Licence_plates.Where(p => p.Plate.StartsWith(ACAB)).ToList();
        }

        public List<LicencePlate> DiplomatCars()
        {
            return LicencePlateContext.Licence_plates.Where(p => p.Plate.StartsWith(RichPeopleWhoCanUseBusLaneWithoutRealPurpose)).ToList();
        }

        public List<LicencePlate> CarsWithSameBrand(string brand)
        {
            return LicencePlateContext.Licence_plates.Where(p => p.Car_brand == brand).ToList();
        }
    }
}
