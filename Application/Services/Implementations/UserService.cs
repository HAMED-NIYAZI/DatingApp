using Application.Convertors;
using Application.Security.PasswordHelper;
using Application.Senders.Mail;
using Application.Services.Interfaces;
using Domain.DTOs.Account;
using Domain.Entities.User;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;
        private readonly ISendMail _sendMail;
       // private readonly IViewRender _viewRender;
        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper,
           /* IViewRender viewRender,*/ ISendMail sendMail)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
            //_viewRender = viewRender;
            _sendMail = sendMail;
        }


        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByUserIdAsync(int userId)
        {
            return await _userRepository.GetUserByUserIdAsync(userId);
        }

        #region Account

        public async Task<RegisterResult> RegisterUserAsync(RegisterDto registerDto)
        {
            #region
            if (await _userRepository.CkeckExistingEmailAsync(registerDto.Email))
                return RegisterResult.EmailIsExist;

            #endregion

            var user = new User
            {
                Email = registerDto.Email,
                Avatar = "Default.png",
                IsEmailActive = false,
                Mobile = null,
                Password = _passwordHelper.EncodePasswordMd5(registerDto.Password),
                RegisterDate = DateTime.Now,
                UserName = registerDto.Email.Split('@')[0]
            };
            #region InserUser

            await _userRepository.InsertUserAsync(user);
            await _userRepository.SaveChangesAsync();
            #endregion


            #region Send Email

            //string body = _viewRender.RenderToStringAsync("", new { });
            _sendMail.Send(user.Email, "فعال سازی حساب کاربری", "");
            #endregion
            return RegisterResult.Success;
        }
        #endregion
        public async Task<LoginResult> LoginUserAsync(LoginDto loginDto)
        {
            try
            {
                var hashpassword = _passwordHelper.EncodePasswordMd5(loginDto.Password);
                User? user = await _userRepository.GetUserByEmailAndPasswordAsync(loginDto.Email, hashpassword);
                if (user is null) return LoginResult.UserNotFound;
                if (!user.IsEmailActive) return LoginResult.EmailNotActive;
            }
            catch (Exception)
            {
                return LoginResult.Error;
            }

            return LoginResult.Success;
        }

        public async Task<User?> GetUserByEmailAsync(string email) 
            => await _userRepository.GetUserByEmailAsync(email);
    }
}
