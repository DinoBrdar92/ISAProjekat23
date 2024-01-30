using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Entities
{
    public class SurveyDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; } = null!;

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime SurveyFilledOut { get; set; }

        Dictionary<int, bool?> Questions { get; set; } = null!;
    }
}
