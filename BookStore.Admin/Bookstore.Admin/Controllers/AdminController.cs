using Bookstore.Admin.Model;
using Bookstore.Admin.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository repository;
        public AdminController(IAdminRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AdminRegistration(RegistrationAdminModel model)
        {
            var result = await repository.AdminRegisteration(model);

            if (result != null)
            {
                return Ok(new { sucess = true, message = "Admin Registration Successfully", data = result });
            }
            else
            {
                return BadRequest(new { sucess = false, message = "Admin Registration Unsuccessfully" });
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AdminLoginModel model)
        {
            var result = await repository.Login(model);

            if (result != null)
            {

                return this.Ok(new { success = true, message = "Login Successful ", data = result });
            }
            else
            {

                return BadRequest(new { Success = false, message = "Login Unsuccessful" });

            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var result = await repository.GetAllAdmins();

            if (result != null)
            {
                return this.Ok(new { success = true, message = "Retrive All Successful ", data = result });

            }
            else
            {
                return this.Ok(new { success = true, message = "Retrive All Unsuccessful " });
            }

        }


        [HttpPost]
        [Route("forgetpassword")]
        public IActionResult ForgetPassword(string email)
        {
            var result = repository.ForgetPassword(email);

            if (result != null)
            {
                return Ok(new { sucess = true, message = "Forget Password Done Successfully", Token = result });
            }
            else
            {
                return BadRequest(new { sucess = false, message = "Forget Password Done Unsuccessfully" });
            }

        }

        [Authorize]
        [HttpPut]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(string pass, string cpass)
        {
            long AdminId = long.Parse(User.FindFirst("AdminId").Value);

            var result = await repository.ResetPassword(AdminId, pass, cpass);

            if (result == true)
            {
                return Ok(new { sucess = true, message = "Password Reset Successfully" });
            }
            else
            {
                return BadRequest(new { sucess = false, message = "Password Reset Unsuccessfully" });
            }
        }
    }
}
