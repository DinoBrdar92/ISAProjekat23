using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext databaseContext;

        public UserRepository(DatabaseContext dc)
        {
            databaseContext = dc;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await databaseContext.Users.Select(u => new User()
            {
                Id = u.Id,
                Username = u.Username,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            })
            .ToListAsync();
        }
    }
}
