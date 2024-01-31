using ISAProjekat23.Database;
using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Domain.Enums;
using ISAProjekat23.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISAProjekat23.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private DatabaseContext databaseContext;

        public UsersRepository(DatabaseContext dc)
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
            var userDto = await databaseContext.Users.Include(x => x.Manages).FirstOrDefaultAsync(u =>
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

            if (userDto != null)
            {
                User user = CreateDomainFromEntity(userDto);

                return user;
            }


            return null;
        }

        public async Task<UserDto> RegisterUser(User potentialUser, EUserRole role = EUserRole.Registered)
        {
            //TODO: povući listu mejlova i proveriti da li mejl potencijalnog novog korisnika već postoji u bazi
            UserDto userDto = new UserDto()
            {
                Email = potentialUser.Email,
                Password = potentialUser.Password,
                Role = (byte)role,
                FirstName = potentialUser.FirstName,
                LastName = potentialUser.LastName,
                City = potentialUser.City,
                Country = potentialUser.Country,
                Phone = potentialUser.Phone,
                Occupation = potentialUser.Occupation,
                Workplace = potentialUser.Workplace,
                Status = 0,
                PenaltyPoints = 0
            };

            databaseContext.Users.Add(userDto);
            await databaseContext.SaveChangesAsync();

            return userDto;
        }

        public async Task<bool> VerifyUser(string id, string name)
        {
            var userToVerify = await databaseContext.Users.FirstOrDefaultAsync(u =>
                u.Id == Int32.Parse(id));

            if (userToVerify != null && Equals(userToVerify.FirstName, name))
            {
                userToVerify.Status = (ushort)EUserStatus.Verified;
                databaseContext.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<List<User>> GetAllCompanyAdmins(int companyId)
        {
            return await databaseContext.Manages
                .Include(x => x.CompAdmin)
                .Where(x => x.CompanyId == companyId)
                .Select(x => new User()
                {
                    Id = x.CompAdminId,
                    FirstName = x.CompAdmin.FirstName,
                    LastName = x.CompAdmin.LastName
                })
                .ToListAsync();
        }

        public static User? CreateDomainFromEntity(UserDto userDto)
        {
            if (userDto != null)
            {
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
                    PenaltyPoints = userDto.PenaltyPoints,
                    ManagesCompanyId = userDto.Manages.FirstOrDefault()?.CompanyId
                };

                return user;
            }

            return null;

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
