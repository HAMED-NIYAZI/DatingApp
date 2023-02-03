using Application.Services.Interfaces;
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
        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }


        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
        return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByUserIdAsync(int userId)
        {
            return await _userRepository.GetUserByUserIdAsync(userId);
        }
    }
}
