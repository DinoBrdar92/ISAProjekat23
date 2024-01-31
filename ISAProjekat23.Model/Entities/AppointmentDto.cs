using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAProjekat23.Model.Entities
{
    public class AppointmentDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public ushort Duration { get; set; }

        [Required]
        public int HandledBy { get; set; }    //id admina kompanije koji će predati pošiljku

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey(nameof(HandledBy))]
        public UserDto? Admin { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public CompanyDto? Company { get; set; }
    }
}
