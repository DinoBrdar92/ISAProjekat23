﻿namespace ISAProjekat23.Model.Domain
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public ushort Rating { get; set; }
    }
}
