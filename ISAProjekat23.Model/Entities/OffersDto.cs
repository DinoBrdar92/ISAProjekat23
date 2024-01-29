using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISAProjekat23.Model.Entities
{
    public class OffersDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public CompanyDto Company { get; set; } = null!;

        [ForeignKey(nameof(ProductId))]
        public ProductDto Product { get; set; } = null!;

    }
}
