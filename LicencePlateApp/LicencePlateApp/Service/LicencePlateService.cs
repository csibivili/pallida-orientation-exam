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

        public List<LicencePlate> SearchForCarByPlate(string plate)
        {
            string letters = string.Empty;
            string numbers = string.Empty;
            int result = 0;

            string[] plateParts = plate.Split('-');

            if (int.TryParse(plateParts[0], out result))
            {
                numbers = result.ToString();
            }
            else
            {
                if (plateParts.Length > 1)
                {
                    letters = plateParts[0];
                    numbers = plateParts[1];
                }
                letters = plateParts[0];
            }

            return LicencePlateRepository.SearchForCarByPlate(letters, numbers);
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
