using Application.Services.Interfaces;
using DatingApp.Api.Services.Interface;
using Domain.DTOs.Account;
using Domain.DTOs.Account.User;
using Domain.DTOs.Common;
using Domain.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DatingApp.Api.Controllers
{

    public class AccountController : BaseSiteController
    {
        #region  ctor
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        #endregion

        #region  Login

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            LoginResult res = await _userService.LoginUserAsync(loginDto);
            switch (res)
            {
                case LoginResult.Success:
                    var user = await _userService.GetUserByEmailAsync (loginDto.Email);
                    if (user is null)
                        return new JsonResult(new ResponseResult(false, "Account Doesn't Exists"));

                    return new JsonResult(new ResponseResult(true, "Loged in successfully", new UserDto
                    {
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user),
                    }));
                case LoginResult.Error:
                    return new JsonResult(new ResponseResult(false, "An Error Occurred"));
                case LoginResult.UserNotFound:
                    return new JsonResult(new ResponseResult(false, "User Doesn't Exists."));
                case LoginResult.EmailNotActive:
                    return new JsonResult(new ResponseResult(false, "Account Is not Active."));
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
                List<string> errors = new List<string>();
                foreach (var modelError in ModelState.Values)
                    foreach (var error in modelError.Errors)
                        errors.Add(error.ErrorMessage);

                                return new JsonResult(new ResponseResult(false, "", errors));
            }

            #endregion Validation


            RegisterResult res = await _userService.RegisterUserAsync(registerDto);

            switch (res)
            {
                case RegisterResult.Success:
                    var user = await _userService.GetUserByEmailAsync(registerDto.Email);
                    if (user is null)
                        return new JsonResult(new ResponseResult(false, "Account Doesn't Exists"));
                    return new JsonResult(new ResponseResult(true, "Account Created Successfully", new UserDto
                    {
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user),
                    }));

                case RegisterResult.Error:
                    return new JsonResult(new ResponseResult(false, "An Error Occurred."));
                case RegisterResult.EmailIsExist:
                    return new JsonResult(new ResponseResult(false, "This Email Already Exists."));
                default:
                    break;
            }


            return new JsonResult(new ResponseResult(false,"An Error Accurred."));

        }
        #endregion

        #region  ForgotPassword

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            return Ok();
        }
        #endregion

        #region  LogOut

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return new JsonResult(new ResponseResult(true, "Logout was successful."));
        }
        #endregion
    }
}
