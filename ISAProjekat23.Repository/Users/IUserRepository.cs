using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUser(LoginCredentials loginCred);
        Task<User?> GetUser(int Id);
        Task<bool> RegisterUser(User potentialUser);
    }
}
