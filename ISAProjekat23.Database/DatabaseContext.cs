using ISAProjekat23.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISAProjekat23.Database
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() { }
        //public DatabaseContext(DbContextOptions options) : base(options)
        //{
        //}

        //entities
        public DbSet<UserDto> Users { get; set; }
        public DbSet<ComplaintDto> Complaints { get; set; }
        public DbSet<ReservationDto> Reservations { get; set; }
        public DbSet<CompanyDto> Companies { get; set; }
        public DbSet<ProductDto> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=ISAProjekat;Uid=root;Pwd=asd123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var user1 = new UserDto()
            //{
            //    Id = 1,
            //    FirstName = "User1",
            //    LastName = "User1",
            //    Email = "User1",
            //};

            //var user2 = new UserDto()
            //{
            //    Id = 2,
            //    FirstName = "User2",
            //    LastName = "User2",
            //    Email = "User2",
            //};

            //var user3 = new UserDto()
            //{
            //    Id = 3,
            //    FirstName = "User3",
            //    LastName = "User3",
            //    Email = "User3",
            //};

            //modelBuilder.Entity<UserDto>().HasData(user1, user2, user3);
        }
    }
}
