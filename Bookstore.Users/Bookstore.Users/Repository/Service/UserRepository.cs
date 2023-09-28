using Bookstore.User.Model;
using Bookstore.User.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookstore.User.Repository.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration Iconfiguration;

        private readonly ContextDB contextDB;

        public UserRepository(IConfiguration Iconfiguration, ContextDB contextDB)
        {
            this.Iconfiguration = Iconfiguration;
            this.contextDB = contextDB;
        }

        /// <summary>
        /// This Method is Used for Store the User data in Database.
        /// </summary>
        /// <param name="model">Model has All Parameters Used for Stored the User Information in Database</param>
        /// <returns>UserEntity Model that has All User Information of User Who Add recently</returns>
        public async Task<UserEntity> UserRegisteration(RegistrationModelcs model)
        {
            try
            {
                UserEntity userEntity = new UserEntity();

                userEntity.FirstName = model.FirstName;
                userEntity.LastName = model.LastName;
                userEntity.Address = model.Address;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;

                await contextDB.Users.AddAsync(userEntity);

                await contextDB.SaveChangesAsync();


                if (userEntity != null)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to Retrive All Users Information.
        /// </summary>
        /// <returns>Retrive All Users Information in List Formate</returns>
        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {

            try
            {
                var users = await contextDB.Users.ToListAsync();


                if (users != null)
                {
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

         
        }

        /// <summary>
        /// This Method is used to Retrive Specific User Information
        /// </summary>
        /// <param name="userId">It is used to identify the User in database</param>
        /// <returns>UserEntity Model that has All Information</returns>
        public async Task<UserEntity> GetById(long userId)
        {

            try
            {
                var user = await contextDB.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to Generate JWT Token with Specific User Information
        /// </summary>
        /// <param name="userLogin">This Model has entity to verify user in database</param>
        /// <returns>Jwt Token with User object</returns>
        public async Task<UserLoginResult> Login(UserLoginModel userLogin)
        {
            try
            {
                UserEntity user = new UserEntity();

                user = await contextDB.Users.FirstOrDefaultAsync(x => x.Email == userLogin.Email);


                string email = user.Email;
                string password = user.Password;
                string userId = Convert.ToString(user.UserId);

                if (user != null && password == userLogin.Password)
                {
                    return new UserLoginResult()
                    {
                        User = user,
                        Token = GenerateJWTToken(email, userId)
                    };
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// This Method is used to Generate Token with user specific information for reset password
        /// </summary>
        /// <param name="email">It is used to verify Users account</param>
        /// <returns>Jwt Token with User specific Information</returns>
        public async Task<string> ForgetPassword(string email)
        {
            try
            {
                UserEntity user = new UserEntity();

                user = await contextDB.Users.FirstOrDefaultAsync(x => x.Email == email);

                string userId = user.UserId.ToString();

                if (user != null)
                {
                    string Token = GenerateJWTToken(email, userId);

                    return Token;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to Reset the password of user.
        /// </summary>
        /// <param name="UserId">To verify user Account</param>
        /// <param name="Pass">To store user input</param>
        /// <param name="CPass">To verify user input password</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ResetPassword(long UserId, string Pass, string CPass)
        {

            try
            {
                UserEntity user = new UserEntity();

                user = await contextDB.Users.FirstOrDefaultAsync(x => x.UserId == UserId);

                if (user != null && Pass == CPass)
                {
                    user.Password = Pass;

                    contextDB.Users.Update(user);

                    await contextDB.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method is used to Generate Token.
        /// </summary>
        /// <param name="email">To encode in Token</param>
        /// <param name="userId">To encode in Token</param>
        /// <returns>JWT Token in string formate</returns>
        private string GenerateJWTToken(string email, string userId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var Key = Encoding.ASCII.GetBytes(Iconfiguration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                        {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("UserID", userId),

                        }

                        ),

                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
