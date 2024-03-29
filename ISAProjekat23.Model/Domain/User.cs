﻿using ISAProjekat23.Model.Domain.Enums;

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

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Occupation { get; set; }

        public string? Workplace { get; set; }

        public EUserStatus Status { get; set; }

        public ushort PenaltyPoints { get; set; }

        public int? ManagesCompanyId { get; set; }
    }
}
