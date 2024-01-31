using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAProjekat23.Model.Entities
{
    public class ReservationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductDto? Product { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        public AppointmentDto Appointment { get; set; } = null!;

        [Required]
        public int ReservedBy { get; set; }

        [ForeignKey(nameof(ReservedBy))]
        public UserDto User { get; set; } = null!;

        [Required]
        public DateTime TimeReserved { get; set; }

        public DateTime? TimeCancelled { get; set; }
    }
}
