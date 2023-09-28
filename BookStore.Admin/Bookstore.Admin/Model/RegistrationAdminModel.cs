using System.Text.Json.Serialization;

namespace Bookstore.Admin.Model
{
    public class RegistrationAdminModel
    {
        [JsonIgnore]
        public long AdminId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
