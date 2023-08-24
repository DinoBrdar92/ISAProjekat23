using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class User
    {
        public enum UserRole
        {
            SysAdmin,
            StaffAdmin,
            Unverified,
            Registered
        }

        public enum UserGender
        {
            Male,
            Female,
            Other
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string JMBG { get; set; }

        public UserGender Gender { get; set; }

        public string? Occupation { get; set; }

        public string? Workplace { get; set; }
    }
}
