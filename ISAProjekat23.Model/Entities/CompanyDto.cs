using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAProjekat23.Model.Entities
{
    public class CompanyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string? Address { get; set; }

        public string? Description { get; set; }

        public float Rating { get; set; }

        public ICollection<OffersDto> Offers { get; set; }

    }
}
