using Domain.DTOs.Account;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Account

        Task<RegisterResult> RegisterUserAsync(RegisterDto registerDto);
        Task<LoginResult> LoginUserAsync(LoginDto loginDto);

        #endregion

        #region User

        Task<User?> GetUserByUserIdAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User?> GetUserByEmailAsync(string email);
        #endregion
    }
}
