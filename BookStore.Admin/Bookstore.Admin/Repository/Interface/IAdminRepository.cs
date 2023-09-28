using Bookstore.Admin.Model;

namespace Bookstore.Admin.Repository.Interface
{
    public interface IAdminRepository
    {
        Task<AdminEntity> AdminRegisteration(RegistrationAdminModel model);
        Task<IEnumerable<AdminEntity>> GetAllAdmins();
        Task<AdminEntity> GetById(long adminId);
        Task<AdminLoginResult> Login(AdminLoginModel model);
        Task<string> ForgetPassword(string email);
        Task<bool> ResetPassword(long AdminId, string Pass, string CPass);
    }
}
