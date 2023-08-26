namespace ISAProjekat23.Client.Services
{
    public class UserService : IUserService
    {
        public Model.Domain.User User { get; set; }

        public UserService() {
        }

        public Model.Domain.User GetUserMethod()
        {
            return User;
        }

        public void SetUserMethod(Model.Domain.User user)
        {
            User = user;
        }
    }
}
