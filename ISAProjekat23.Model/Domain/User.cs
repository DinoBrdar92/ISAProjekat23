using ISAProjekat23.Model.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public EUserRole Role { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string JMBG { get; set; } = null!;

        public EUserGender Gender { get; set; }

        public string? Occupation { get; set; }

        public string? Workplace { get; set; }

        public bool IsSurveyed { get; set; }

        public EUserStatus Status { get; set;  }
    }
}
