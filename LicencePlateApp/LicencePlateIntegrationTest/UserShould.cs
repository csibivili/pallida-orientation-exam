using LicencePlateApp.Controllers;
using LicencePlateApp.Entities;
using LicencePlateApp.Service;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using LicencePlateApp.Repository;
using LicencePlateApp.Models;
using System.Collections.Generic;
using System.Linq;

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
        public void SearchForCarByPlate()
        {
            using(var licencePlateContext = new LicencePlateContext(optionsBuilder.Options))
            {
                var licencePlateService = new LicencePlateService(new LicencePlateRepository(licencePlateContext));

                var car = licencePlateService.SearchForCarByPlate("CICA-93");

                Assert.Equal("CICA-93", car.Plate);
            }
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
    }
}
