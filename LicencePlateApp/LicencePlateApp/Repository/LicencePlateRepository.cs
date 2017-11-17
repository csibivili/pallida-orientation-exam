using LicencePlateApp.Entities;

namespace LicencePlateApp.Repository
{
    public class LicencePlateRepository
    {
        private LicencePlateContext LicencePlateContext;

        public LicencePlateRepository(LicencePlateContext licencePlateContext)
        {
            LicencePlateContext = licencePlateContext;
        }
    }
}
