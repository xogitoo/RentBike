namespace BikeRental.Data.Model
{
    public class Rent
    {
        //ЕНТИТИТА 
        public int Id { get; set; } 
        public DateTime StartData { get; set; }
        public string UserId{ get; set; }
        public int BikeId { get; set; }
        public virtual Bike Bike { get; set; }
        public DateTime EndDate { get; set; }
        public double Total { get; set; }
        
    }
}
