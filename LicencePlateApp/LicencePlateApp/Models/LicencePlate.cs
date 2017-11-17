using System.ComponentModel.DataAnnotations;

namespace LicencePlateApp.Models
{
    public class LicencePlate
    {
        [Key]
        public string Plate { get; set; }
        public string Car_brand { get; set; }
        public string Car_model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
