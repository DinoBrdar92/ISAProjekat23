using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public ushort Duration { get; set; }

        public User? ReservedBy { get; set; }

    }
}
