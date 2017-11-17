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
    }
}
