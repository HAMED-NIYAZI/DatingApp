using Domain.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DatingApp.Api.Controllers
{

    public class AccountController : BaseSiteController
    {
        #region  ctor

        #endregion

        #region  Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            return Ok();

        }
        #endregion

        #region  Register

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {

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
