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
            _dbContext= dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return  await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByUserIdAsync(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
