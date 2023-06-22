using AgroStore.Shared;
using AgroStore.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AgroStore.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbcontext _dbContext;
        public UserService(AppDbcontext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<User> AddUser(User user )
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }



        public async Task<User?> GetUserByEmail(string Email)
        {
            var user = await _dbContext.user.FirstOrDefaultAsync(u => u.email == Email);
            return user;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _dbContext.user.FindAsync(userId);
            if (user != null)
            {
                _dbContext.user.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAll()
        {
            var list = await _dbContext.user.ToListAsync();
            return list;
        }

        public async Task<User> GetUserById(int userId)
        {
           var userid = await _dbContext.FindAsync<User>(userId);
           return userid;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }


    }

}