using LicencePlateApp.Entities;
using LicencePlateApp.Models;

namespace LicencePlateApp.Repository
{
    public class LicencePlateRepository
    {
        private LicencePlateContext LicencePlateContext;

        public LicencePlateRepository(LicencePlateContext licencePlateContext)
        {
            LicencePlateContext = licencePlateContext;
        }

        public LicencePlate SearchForCarByPlate(string plate)
        {
            return LicencePlateContext.Licence_plates.Find(plate);
        }
    }
}
