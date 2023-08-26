using ISAProjekat23.Model.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class Complaint
    {
        public string Subject { get; set; } = null!;

        public string Description { get; set; } = null!;

        public User User { get; set; } = null!;

        public EComplaintObject ComplaintObject { get; set; }
    }
}
