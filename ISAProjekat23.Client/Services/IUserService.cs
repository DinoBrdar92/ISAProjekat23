namespace ISAProjekat23.Client.Services
{
    public interface IUserService
    {
        Model.Domain.User GetUserMethod();
        void SetUserMethod(Model.Domain.User user);
    }
}
