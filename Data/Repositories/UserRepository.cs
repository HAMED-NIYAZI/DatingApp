using Data.Context;
using Domain.Entities.User;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingAppContext _dbContext;

        public UserRepository(DatingAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByUserIdAsync(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<bool> CkeckExistingEmailAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task InsertUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }
        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {

            return await _dbContext.Users.FirstOrDefaultAsync(u=>u.Email==email && u.Password==password);
        
        }

        public async Task SaveChangesAsync() 
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
