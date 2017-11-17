using LicencePlateApp.Models;
using LicencePlateApp.Repository;
using System.Collections.Generic;
using System.Linq;

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
            if (PlateCheck(plate))
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
            return new List<LicencePlate>() { new LicencePlate() { Plate= "Sorry, the submitted licence plate is not valid" } };
        }

        public List<LicencePlate> PoliceCars()
        {
            return LicencePlateRepository.PoliceCars();
        }

        public List<LicencePlate> DiplomatCars()
        {
            return LicencePlateRepository.DiplomatCars();
        }

        public List<LicencePlate> CarsWithSameBrand(string brand)
        {
            return LicencePlateRepository.CarsWithSameBrand(brand);
        }

        public bool PlateCheck(string plate)
        {
            if (plate.Length > 7)
            {
                return false;
            }
            if (plate.IndexOf('-') != -1)
            {
                plate.Remove(plate.IndexOf('-'));
            }           
            return plate.Any(p => char.IsLetterOrDigit(p));
        }
    }
}
