using LicencePlateApp.Controllers;
using LicencePlateApp.Entities;
using LicencePlateApp.Service;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using LicencePlateApp.Repository;

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
                var homeController = new HomeController(new LicencePlateService(new LicencePlateRepository(licencePlateContext)));

            }
        }
    }
}
