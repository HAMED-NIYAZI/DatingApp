using Application.Convertors;
using Application.Extentions;
using Application.Security.PasswordHelper;
using Application.Senders.Mail;
using Application.Services.Interfaces;
using Azure;
using Domain.DTOs.Account;
using Domain.DTOs.Account.User;
using Domain.DTOs.Photo;
using Domain.Entities.Photo;
using Domain.Entities.User;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
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
            try
            {
                #region validation
                if (await _userRepository.CkeckExistingEmailAsync(registerDto.Email))
                    return RegisterResult.EmailIsExist;

                #endregion validation

                #region set Properites
                var user = new User
                {
                    Email = registerDto.Email.ToLower().Trim(),
                    Avatar = "Default.png",
                    IsEmailActive = false,
                    Mobile = null,
                    Password = _passwordHelper.EncodePasswordMd5(registerDto.Password),
                    RegisterDate = DateTime.Now,
                    UserName = registerDto.Email.ToLower().Trim().Split('@')[0]
                    
                };

                #endregion   set Properites

                #region InserUser

                await _userRepository.InsertUserAsync(user);
                await _userRepository.SaveChangesAsync();
                #endregion InserUser

                #region Send Email

                //string body = _viewRender.RenderToStringAsync("", new { });
                _sendMail.Send(user.Email, "فعال سازی حساب کاربری", "");
                #endregion
                return RegisterResult.Success;
            }
            catch (Exception ex)
            {

                return RegisterResult.Error;
            }


        }
        #endregion
        public async Task<LoginResult> LoginUserAsync(LoginDto loginDto)
        {
            try
            {
                var hashpassword = _passwordHelper.EncodePasswordMd5(loginDto.Password);
                User? user = await _userRepository.GetUserByEmailAndPasswordAsync(loginDto.Email.ToLower().Trim(), hashpassword);

                #region validation
                if (user is null) return LoginResult.UserNotFound;
                if ((bool)!user.IsEmailActive) return LoginResult.EmailNotActive;
                #endregion validation

            }
            catch (Exception)
            {
                return LoginResult.Error;
            }

            return LoginResult.Success;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
            => await _userRepository.GetUserByEmailAsync(email);

        public async Task<List<MemberDto>> GetAllUserInformationAsync()
        {
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                //return users.Select(u => new MemberDto()
                //{
                //    Id = u.Id,
                //    UserName = u.UserName,
                //    age = u.DateOfBirth.CalculateAge(),
                //    Avatar = u.Avatar,
                //    City = u.City,
                //    Country = u.Country,
                //    Email = u.Email,
                //    Gender = u.Gender,
                //    Intrests = u.Intrests,
                //    Introduction = u.Introduction,
                //    IsEmailActive = u.IsEmailActive,
                //    KnownAs = u.KnownAs,
                //    LookingFor = u.LookingFor,
                //    Mobile = u.Mobile,
                //    RegisterDate = u.RegisterDate,
                //    Photos = u.Photos.Select(p => new PhotoDto() { Id = p.Id, IsMain = p.IsMain, Url = p.Url }).ToList()

                //}).ToList();

                foreach (var u in users)
                {

                    var user=new MemberDto();
                    user.Id = u.Id;
                    user.UserName = u.UserName;
                    user.age = u.DateOfBirth.CalculateAge();
                    user.Avatar = u.Avatar;
                    user.City = u.City;
                    user.Country = u.Country;
                    user.Email = u.Email;
                    user.Gender = u.Gender;
                    user.Intrests = u.Intrests;
                    user.Introduction = u.Introduction;
                    user.IsEmailActive = u.IsEmailActive;
                    user.KnownAs = u.KnownAs;
                    user.LookingFor = u.LookingFor;
                    user.Mobile = u.Mobile;
                    user.RegisterDate = u.RegisterDate;
                    user.Photos = u.Photos == null ? null : u.Photos.Select(p => new PhotoDto() { Id = p.Id, IsMain = p.IsMain, Url = p.Url }).ToList();

                }



                 var res= users.Select(u => new MemberDto()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    age = u.DateOfBirth.CalculateAge(),
                    Avatar = u.Avatar,
                    City = u.City,
                    Country = u.Country,
                    Email = u.Email,
                    Gender = u.Gender,
                    Intrests = u.Intrests,
                    Introduction = u.Introduction,
                    IsEmailActive = u.IsEmailActive,
                    KnownAs = u.KnownAs,
                    LookingFor = u.LookingFor,
                    Mobile = u.Mobile,
                    RegisterDate = u.RegisterDate,
                    Photos =u.Photos ==null ? null: u.Photos.Select(p => new PhotoDto() { Id = p.Id, IsMain = p.IsMain, Url = p.Url }).ToList()

                }).ToList();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<MemberDto> GetUserInformationAsync(string userName)
        {
            var user = await _userRepository.GetAsync(userName);
      

            return new MemberDto() {
                Id = user.Id,
                UserName = user.UserName,
                age =  user.DateOfBirth.CalculateAge(),
 
                Avatar = user.Avatar,
                City = user.City,
                Country = user.Country,
                Email = user.Email,
                Gender = user.Gender,
                Intrests = user.Intrests,
                Introduction = user.Introduction,
                IsEmailActive = user.IsEmailActive,
                KnownAs = user.KnownAs,
                LookingFor = user.LookingFor,
                Mobile = user.Mobile,
                RegisterDate = user.RegisterDate,
                Photos = user.Photos.Select(p => new PhotoDto() { Id = p.Id, IsMain = p.IsMain, Url = p.Url }).ToList()
            };
        }
    }
}
