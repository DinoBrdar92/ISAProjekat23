using ISAProjekat23.Model.Domain;

namespace ISAProjekat23.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(User potentialUser);
    }
}
