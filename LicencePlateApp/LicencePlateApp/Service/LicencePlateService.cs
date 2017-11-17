using LicencePlateApp.Models;
using LicencePlateApp.Repository;

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
    }
}
