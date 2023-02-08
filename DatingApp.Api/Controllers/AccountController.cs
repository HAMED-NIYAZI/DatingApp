using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
 

namespace DatingApp.Api.Controllers
{

    public class AccountController : BaseSiteController
    {
        #region  ctor
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region  Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            LoginResult res=await _userService.LoginUserAsync(loginDto);
            string message = "";
            switch (res)
            {
                case LoginResult.Success:
                    message = "Success";
                    break;
                case LoginResult.Error:
                    message = "Error";
                    break;
                case LoginResult.UserNotFound:
                    message = "UserNotFound";
                    break;
                case LoginResult.EmailNotActive:
                    message = "EmailNotActive";
                    break;
                default:
                    break;
            }

            return Ok();

        }
        #endregion

        #region  Register

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            #region Validation

            if (!ModelState.IsValid)
            { 
            List<string> strings= new List<string>();
                //foreach (var modelErrors in ModelState.Va)
                //{

                //}
            }




            #endregion


          RegisterResult res= await _userService.RegisterUserAsync(registerDto);

            switch (res)
            {
                case RegisterResult.Success:
                    //TempData["SuccessMessage"] = "";
                  //  TempData["name"] = "Bill";
                    break;
                case RegisterResult.Error:
                    break;
                case RegisterResult.EmailIsExist:
                    break;
                default:
                    break;
            }
            return Ok();

        }
        #endregion

        #region  ForgotPassword

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {

            return Ok();

        }
        #endregion
    }
}
