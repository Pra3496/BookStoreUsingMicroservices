using Bookstore.User.Model;
using Bookstore.User.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        private ResponseModel response;
        public UserController(IUserRepository repository) 
        {
            this.repository = repository;
            this.response = new ResponseModel();
        }

        /// <summary>
        /// This Method use to Register the User with Given Parameter in Model
        /// </summary>
        /// <param name="model">FirstName, LastName, Address, Email and Password</param>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and Data object of User Information</returns>
        [HttpPost]
        [Route("register")]
        public async Task<ResponseModel> UserRegistration(RegistrationModelcs model)
        {
            try
            {
                var result = await repository.UserRegisteration(model);

                if (result != null)
                {
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Register User Unsuccessful";
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// This Method use to Login a User with Given Parameter in Model
        /// </summary>
        /// <param name="userLogin">This Model has Parameter use to Verify the User Account</param>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and Data object of User Information with Jwt Token</returns>
        [HttpPost]
        [Route("login")]
        public async Task<ResponseModel> Login(UserLoginModel userLogin)
        {
            try
            {
                var result = await repository.Login(userLogin);

                if (result != null)
                {

                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Login Unsuccessful";

                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }


        /// <summary>
        /// This Method use for Retrive the List of Users Presnt
        /// </summary>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and List of Users</returns>
        [HttpGet]
        [Route("Users")]
        public async Task<ResponseModel> GetUsers()
        {
            try
            {
                var result = await repository.GetAllUsers();

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Retrive AllUsers Unsuccessful";
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
		
		 /// <summary>
        /// This Method use for Retrive the List of Users Presnt
        /// </summary>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and List of Users</returns>
        [HttpGet]
        [Route("User")]
        public async Task<ResponseModel> GetById(long userId)
        {
            try
            {
                var result = await repository.GetById(userId);

                if (result != null)
                {
                    response.Data = result;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Retrive AllUsers Unsuccessful";
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// This Method use for Generating a Token for existing User to change the Password.
        /// </summary>
        /// <param name="email">Email is used to varify the User</param>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and Data object of Jwt Token</returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("forgetpassword")]
        public async Task<ResponseModel> ForgetPassword(string email)
        {
            try
            {
                var result = repository.ForgetPassword(email);

                if (result != null)
                {
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Forget Password is Unsuccessful";
                }

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
     
        }

        /// <summary>
        /// This Method use for Reset password of User with authorization using JWT token. 
        /// </summary>
        /// <param name="pass">It is use to verify the user input</param>
        /// <param name="cpass">It is use to verify the user input</param>
        /// <returns>Returns the Respose body that Contain IsSuccess, SuccessMessage and Data object of with True Value</returns>
        /// <exception cref="Exception"></exception>
        [Authorize]
        [HttpPut]
        [Route("resetpassword")]
        public async Task<ResponseModel> ResetPassword(string pass, string cpass)
        {
            try
            {
                long userId = long.Parse(User.FindFirst("UserID").Value);

                var result = await repository.ResetPassword(userId, pass, cpass);

                if (result == true)
                {
                    response.Data = result;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Reset Password is Unsuccessful";
                }

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





    }
}
