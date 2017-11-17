using LicencePlateApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LicencePlateApp.Entities
{
    public class LicencePlateContext : DbContext
    {
        public LicencePlateContext(DbContextOptions<LicencePlateContext> options) : base(options)
        {

        }

        public DbSet<LicencePlate> Licence_plates { get; set; }
    }
}
