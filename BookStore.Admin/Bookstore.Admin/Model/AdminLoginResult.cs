using Bookstore.Admin.Repository;

namespace Bookstore.Admin.Model
{
    public class AdminLoginResult
    {
        public AdminEntity admmin { get; set; }

        public string Token { get; set; }
    }
}
