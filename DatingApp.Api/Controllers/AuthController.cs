using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Domain.Contracts.Users;
using DatingApp.Domain.Models.Auth;
using DatingApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // post api/v1/auth/register
        [HttpPost("register"), MapToApiVersion("1")]
        public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
        {
            var user = await _authService.Register(request);

            return new UserRegisterResponse()
            {
                User = user
            };
        }
    }
}
