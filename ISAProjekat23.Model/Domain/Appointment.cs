using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class Appointment
    {
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public ushort Duration { get; set; }

        public User? ReservedBy { get; set; }

    }
}
