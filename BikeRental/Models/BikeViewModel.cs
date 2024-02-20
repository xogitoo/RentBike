using BikeRental.Data.Model;
using System.Security.Cryptography.X509Certificates;

namespace BikeRental.Models
{
    public class BikeViewModel
    {
        public int BikeId { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
    }
}
