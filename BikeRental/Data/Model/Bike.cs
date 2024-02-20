namespace BikeRental.Data.Model
{
    public class Bike
    {
        //ЕНТИТИТА
        public int  Id { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string ImageName { get; set; }
        public string ImageExtension { get; set; }

        public ICollection<Rent> Rents { get; set; }
        //public int BikesId { get; internal set; }
    }
}
