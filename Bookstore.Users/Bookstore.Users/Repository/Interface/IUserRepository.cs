using Bookstore.User.Model;

namespace Bookstore.User.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserEntity> UserRegisteration(RegistrationModelcs model);

        Task<IEnumerable<UserEntity>> GetAllUsers();

        Task<UserEntity> GetById(long userId);

        Task<UserLoginResult> Login(UserLoginModel userLogin);

        Task<string> ForgetPassword(string email);

        Task<bool> ResetPassword(long UserId, string Pass, string CPass);


    }
}
