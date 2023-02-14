using Application.Services.Interfaces;
using DatingApp.Api.Services.Interface;
using Domain.DTOs.Account;
using Domain.DTOs.Account.User;
using Domain.DTOs.Common;
using Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
 

namespace DatingApp.Api.Controllers
{

    public class AccountController : BaseSiteController
    {
        #region  ctor
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
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
                    var user=await _userService.GetUserByEmailAsync(loginDto.Email);
                    if (user is null)
                        return new JsonResult(new ResponseResult(false,"Account Doesn't Exists"));
                    
                    return new JsonResult(new ResponseResult(true,"Lodged in successfully",new UserDto 
                    {
                       UserName=user.UserName,
                       Token=_tokenService.CreateToken(user),
                    }));
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
                    var user = await _userService.GetUserByEmailAsync(registerDto.Email);
                    if (user is null)
                        return new JsonResult(new ResponseResult(false, "Account Doesn't Exists"));
                    return new JsonResult(new ResponseResult(true, "Account Created Successfully", new UserDto
                    {
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user),
                    }));
 
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
