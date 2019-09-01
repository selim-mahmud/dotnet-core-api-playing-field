using System.Threading.Tasks;
using DatingApp.Domain.Models.Entities;

namespace DatingApp.Domain.Contracts.Users
{
    public interface IAuthRepository
    {
        /// <summary>
        /// register a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<User> Register(User user);

        /// <summary>
        /// get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<User> FindUserByUsername(string username);

        /// <summary>
        /// check if a user exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> UserExists(string username);
    }
}
