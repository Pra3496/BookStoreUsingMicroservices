using Bookstore.Admin.Model;
using Bookstore.Admin.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookstore.Admin.Repository.Service
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration Iconfiguration;

        private readonly ContextDB contextDB;

        public AdminRepository(IConfiguration Iconfiguration, ContextDB contextDB)
        {
            this.Iconfiguration = Iconfiguration;
            this.contextDB = contextDB;
        }


        public async Task<AdminEntity> AdminRegisteration(RegistrationAdminModel model)
        {
            AdminEntity adminEntity = new AdminEntity();

            adminEntity.FirstName = model.FirstName;
            adminEntity.LastName = model.LastName;
            adminEntity.Email = model.Email;
            adminEntity.Password = model.Password;

            await contextDB.Admin.AddAsync(adminEntity);

            await contextDB.SaveChangesAsync();


            if (adminEntity != null)
            {
                return adminEntity;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<AdminEntity>> GetAllAdmins()
        {

            var users = await contextDB.Admin.ToListAsync();


            if (users != null)
            {
                return users;
            }
            else
            {
                return null;
            }


        }

        public async Task<AdminEntity> GetById(long adminId)
        {

            var user = await contextDB.Admin.FirstOrDefaultAsync(x => x.AdminId == adminId);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        public async Task<AdminLoginResult> Login(AdminLoginModel model)
        {
            AdminEntity adminEntity = new AdminEntity();

            adminEntity = await contextDB.Admin.FirstOrDefaultAsync(x => x.Email == model.Email);


            string email = adminEntity.Email;
            string password = adminEntity.Password;
            string AdminId = Convert.ToString(adminEntity.AdminId);

            if (adminEntity != null && password == model.Password)
            {
                return new AdminLoginResult()
                {
                    admmin = adminEntity,
                    Token = GenerateJWTToken(email, AdminId)
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<string> ForgetPassword(string email)
        {
            AdminEntity adminEntity = new AdminEntity();

            adminEntity = await contextDB.Admin.FirstOrDefaultAsync(x => x.Email == email);

            string AdminId = adminEntity.AdminId.ToString();

            if (adminEntity != null)
            {
                string Token = GenerateJWTToken(email, AdminId);

                return Token;
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> ResetPassword(long AdminId, string Pass, string CPass)
        {

            AdminEntity adminEntity = new AdminEntity();

            adminEntity = await contextDB.Admin.FirstOrDefaultAsync(x => x.AdminId == AdminId);

            if (adminEntity != null && Pass == CPass)
            {
                adminEntity.Password = Pass;

                contextDB.Admin.Update(adminEntity);

                await contextDB.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }

        private string GenerateJWTToken(string email, string adminId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(Iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("AdminId", adminId),

                    }

                    ),

                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
