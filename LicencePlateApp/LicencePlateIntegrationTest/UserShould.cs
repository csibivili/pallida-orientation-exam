using LicencePlateApp.Entities;
using LicencePlateApp.Models;
using LicencePlateApp.Repository;
using LicencePlateApp.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LicencePlateIntegrationTest
{
    public class UserShould
    {
        private readonly DbContextOptionsBuilder<LicencePlateContext> optionsBuilder;

        public UserShould()
        {
            optionsBuilder = new DbContextOptionsBuilder<LicencePlateContext>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LicencePlateDb;Integrated Security=True;Connect Timeout=30;");
        }

        [Fact]
        public void SearchForPoliceCars()
        {
            using (var licencePlateContext = new LicencePlateContext(optionsBuilder.Options))
            {
                var licencePlateService = new LicencePlateService(new LicencePlateRepository(licencePlateContext));

                List<LicencePlate> policeCars = licencePlateService.PoliceCars();

                Assert.Equal(policeCars.First().Plate.Substring(0,2), "RB");
                Assert.Equal(policeCars.Last().Plate.Substring(0, 2), "RB");
            }
        }

        [Fact]
        public void SearchForDiplomatCars()
        {
            using (var licencePlateContext = new LicencePlateContext(optionsBuilder.Options))
            {
                var licencePlateService = new LicencePlateService(new LicencePlateRepository(licencePlateContext));

                List<LicencePlate> policeCars = licencePlateService.DiplomatCars();

                Assert.Equal(policeCars.First().Plate.Substring(0, 2), "DT");
                Assert.Equal(policeCars.Last().Plate.Substring(0, 2), "DT");
            }
        }

        [Fact]
        public void SearchForCarByPartOfAPlate()
        {
            using (var licencePlateContext = new LicencePlateContext(optionsBuilder.Options))
            {
                var licencePlateService = new LicencePlateService(new LicencePlateRepository(licencePlateContext));

                List<LicencePlate> cars = licencePlateService.SearchForCarByPlate("CI");
                List<LicencePlate> cars2 = licencePlateService.SearchForCarByPlate("1");
                List<LicencePlate> cars3 = licencePlateService.SearchForCarByPlate("CI-1");

                Assert.Equal(true, cars.First().Plate.Contains("CI"));
                Assert.Equal(true, cars2.First().Plate.Contains("1"));
                Assert.Equal(true, cars3.First().Plate.Contains("1") && cars3.First().Plate.Contains("CI"));
            }
        }
    }
}
