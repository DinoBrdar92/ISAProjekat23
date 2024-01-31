using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAProjekat23.Model.Entities
{
    public class ManagesDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int CompAdminId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public CompanyDto Company { get; set; } = null!;

        [ForeignKey(nameof(CompAdminId))]
        public UserDto CompAdmin { get; set; } = null!;
    }
}
