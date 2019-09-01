using System.Threading.Tasks;
using DatingApp.Domain.Models.Auth;
using DatingApp.Domain.Models.Entities;

namespace DatingApp.Domain.Contracts.Users
{
    public interface IAuthService
    {
        /// <summary>
        /// register a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<User> Register(UserRegisterRequest request);

        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> Login(string username, string password);

        /// <summary>
        /// check if a user exists
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> UserExists(string username);
    }
}
