using LicencePlateApp.Models;
using LicencePlateApp.Repository;
using System.Collections.Generic;

namespace LicencePlateApp.Service
{
    public class LicencePlateService
    {
        private LicencePlateRepository LicencePlateRepository;

        public LicencePlateService(LicencePlateRepository licencePlateRepository)
        {
            LicencePlateRepository = licencePlateRepository;
        }

        public LicencePlate SearchForCarByPlate(string plate)
        {
            return LicencePlateRepository.SearchForCarByPlate(plate);
        }

        public List<LicencePlate> PoliceCars()
        {
            return LicencePlateRepository.PoliceCars();
        }

        public List<LicencePlate> DiplomatCars()
        {
            return LicencePlateRepository.DiplomatCars();
        }
    }
}
