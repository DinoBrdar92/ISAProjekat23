using ISAProjekat23.Model.Domain;
using ISAProjekat23.Model.Domain.Enums;
using ISAProjekat23.Model.Entities;

namespace ISAProjekat23.Repository.Users
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(LoginCredentials loginCred);
        Task<User?> GetUser(int Id);
        Task<UserDto> RegisterUser(User potentialUser, EUserRole role = EUserRole.Registered);
        Task<bool> VerifyUser(string id, string name);
        Task<List<User>> GetAllCompanyAdmins(int companyId);
    }
}
