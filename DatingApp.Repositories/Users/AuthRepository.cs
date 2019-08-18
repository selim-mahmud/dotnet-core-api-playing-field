using DatingApp.Database;
using DatingApp.Database.Entities.Users;
using DatingApp.Domain.Contracts.Users;
using DatingApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Repositories.Users
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatabaseContext _context;

        public AuthRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            var userEntity = new UserEntity()
            {
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> FindUserByUsername(string username)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (userEntity == null)
                return null;

            return new User()
            {
                Id = userEntity.Id,
                Username = userEntity.Username
            };
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}
