using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Domain.Enums;
using ISAProjekat23.Model.Entities;
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
                Role = (EUserRole)u.Role,
                FirstName = u.FirstName,
                LastName = u.LastName,
                City = u.City,
                Country = u.Country,
                Phone = u.Phone,
                Occupation = u.Occupation,
                Workplace = u.Workplace,
                Status = (EUserStatus)u.Status,
                PenaltyPoints = u.PenaltyPoints,
            })
            .ToListAsync();
        }

        public async Task<User?> GetUser(LoginCredentials loginCred)
        {
            // moze i Where
            var userDto = await databaseContext.Users.FirstOrDefaultAsync(u => 
                u.Email == loginCred.Email && u.Password == loginCred.Password);

            if (userDto != null)
            {
                User user = CreateDomainFromEntity(userDto);

                return user;

            }
            else
            {
                return null;
            }
        }

        public async Task<User?> GetUser(int Id)
        {
            var userDto = await databaseContext.Users.FirstOrDefaultAsync(u =>
                u.Id == Id);

            if ( userDto != null )
            {
                User user = CreateDomainFromEntity(userDto);

                return user;
            }


            return null;
        }

        public async Task<bool> RegisterUser(User potentialUser)
        {
            //TODO: povući listu mejlova i proveriti da li mejl potencijalnog novog korisnika već postoji u bazi
            UserDto userDto = new UserDto()
            {
                Email = potentialUser.Email,
                Password = potentialUser.Password,
                Role = 0,
                FirstName = potentialUser.FirstName,
                LastName = potentialUser.LastName,
                City = potentialUser.City,
                Country = potentialUser.Country,
                Phone = potentialUser.Phone,
                Occupation  = potentialUser.Occupation,
                Workplace = potentialUser.Workplace,
                Status = 0,
                PenaltyPoints = 0
            };

            databaseContext.Users.Add(userDto);
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public static User? CreateDomainFromEntity(UserDto userDto)
        {
            if(userDto == null)
            {
                return null;
            }

            User user = new User()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = (EUserRole)userDto.Role,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                City = userDto.City,
                Country = userDto.Country,
                Phone = userDto.Phone,
                Occupation = userDto.Occupation,
                Workplace = userDto.Workplace,
                Status = (EUserStatus)userDto.Status,
                PenaltyPoints = userDto.PenaltyPoints
            };

            return user;
        }

        public static UserDto CreateEntityFromDomain(User user)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = (byte)user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                Country = user.Country,
                Phone = user.Phone,
                Occupation = user.Occupation,
                Workplace = user.Workplace,
                Status = (ushort)user.Status,
                PenaltyPoints = user.PenaltyPoints
            };

            return userDto;
        }
    }
}
