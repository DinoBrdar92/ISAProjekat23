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
                Address = u.Address,
                City = u.City,
                Country = u.Country,
                Phone = u.Phone,
                JMBG = u.JMBG,
                Gender = (EUserGender)u.Gender,
                Occupation = u.Occupation,
                Workplace = u.Workplace
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

        public async Task<User?> GetUser(string Id)
        {
            var userDto = await databaseContext.Users.FirstOrDefaultAsync(u =>
                u.Id.ToString() == Id);

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
                Address  = potentialUser.Address,
                City = potentialUser.City,
                Country = potentialUser.Country,
                Phone = potentialUser.Phone,
                JMBG = potentialUser.JMBG,
                Gender = (byte)potentialUser.Gender,
                Occupation  = potentialUser.Occupation,
                Workplace = potentialUser.Workplace,
                IsSurveyed = false,
                Status = 0
            };

            databaseContext.Users.Add(userDto);
            await databaseContext.SaveChangesAsync();

            return true;
        }

        public User CreateDomainFromEntity(UserDto userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                Role = (EUserRole)userDto.Role,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                City = userDto.City,
                Country = userDto.Country,
                Phone = userDto.Phone,
                JMBG = userDto.JMBG,
                Gender = (EUserGender)userDto.Gender,
                Occupation = userDto.Occupation,
                Workplace = userDto.Workplace,
                IsSurveyed = userDto.IsSurveyed,
                Status = (EUserStatus)userDto.Status
            };

            return user;
        }

        public UserDto CreateEntityFromDomain(User user)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = (byte)user.Role,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                Phone = user.Phone,
                JMBG = user.JMBG,
                Gender = (byte)user.Gender,
                Occupation = user.Occupation,
                Workplace = user.Workplace,
                IsSurveyed = user.IsSurveyed,
                Status = (ushort)user.Status
            };

            return userDto;
        }
    }
}
