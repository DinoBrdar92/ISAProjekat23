namespace ISAProjekat23.Model.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public ushort Duration { get; set; }

        public int HandledById { get; set; }

        public int CompanyId { get; set; }

        public User? HandledBy { get; set; } = null!;
        public Company? Company { get; set; } = null!;

    }
}
