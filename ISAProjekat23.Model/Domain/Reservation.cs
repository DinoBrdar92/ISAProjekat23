namespace ISAProjekat23.Model.Domain
{
    public class Reservation
    {
        public int Id { get; set; }

        public Product Product { get; set; } = null!;

        public Appointment Appointment { get; set; } = null!;

        public User ReservedBy { get; set; } = null!;

        public DateTime TimeReserved { get; set; }

        public DateTime? TimeCancelled { get; set; }
    }
}
