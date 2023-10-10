using Domain.DTOs.Account;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByUserIdAsync(int userId);
        Task<bool> CkeckExistingEmailAsync(string  email);

        Task InsertUserAsync(User user);

        Task<User?> GetUserByEmailAndPasswordAsync(string email,string password);
        Task SaveChangesAsync();

        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetAsync(string userName);

        void UpdateUser(User user);

    }
}
