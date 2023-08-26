using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Entities
{
    public class ComplaintDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; } = null!;

        public string Description { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public bool ComplaintObject { get; set; }
    }
}
