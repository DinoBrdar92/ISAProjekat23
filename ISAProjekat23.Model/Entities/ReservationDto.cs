using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Entities
{
    public class ReservationDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public ushort Duration { get; set; }

        public int HandledBy { get; set; }    //id admina kompanije koji će predati opremu

        public int? ReservedBy { get; set; }    //id korisnika koji je rezervisao (ako termin nije slobodan)

        [ForeignKey(nameof(HandledBy))]
        public UserDto? Admin { get; set; }

        [ForeignKey(nameof(ReservedBy))]
        public UserDto User { get; set; }
    }
}
