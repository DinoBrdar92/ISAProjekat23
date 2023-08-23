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

        public async Task<User> GetUser(User potentialUser)
        {
            // moze i Where
            var userDto = await databaseContext.Users.FirstOrDefaultAsync(u => 
                u.Email == potentialUser.Email && u.Password == potentialUser.Password);

            if (userDto != null)
            {
                User user = new User()
                {
                    Username = userDto.Username,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Password = userDto.Password
                };

                return user;

            } 
            else
            {
                return null;
            }
        }
    }
}
