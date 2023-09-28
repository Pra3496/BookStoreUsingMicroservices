using Bookstore.User.Repository;

namespace Bookstore.User.Model
{
    public class UserLoginResult
    {
        public UserEntity User { get; set; }

        public string Token { get; set; }
    }
}
