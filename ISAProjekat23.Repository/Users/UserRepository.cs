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
                Email = u.Email,
                Password = u.Password,
                Role = (User.UserRole)u.Role,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                City = u.City,
                Country = u.Country,
                Phone = u.Phone,
                JMBG = u.JMBG,
                Gender = (User.UserGender)u.Gender,
                Occupation = u.Occupation,
                Workplace = u.Workplace
            })
            .ToListAsync();
        }

        public async Task<User?> GetUser(User potentialUser)
        {
            // moze i Where
            var userDto = await databaseContext.Users.FirstOrDefaultAsync(u => 
                u.Email == potentialUser.Email && u.Password == potentialUser.Password);

            if (userDto != null)
            {
                User user = new User()
                {
                    Email = userDto.Email,
                    Password = userDto.Password,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                };

                return user;

            } 
            else
            {
                return null;
            }
        }

        public async Task<User> SetUser(User potentialNewUser)
        {
            //TODO: povući listu mejlova i proveriti da li mejl potencijalnog novog korisnika već postoji u bazi
            return null;
        }
    }
}
