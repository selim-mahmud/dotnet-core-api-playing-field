using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Domain.Models.Auth
{
    public class UserRegisterRequest
    {
        /// <summary>
        /// username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 8 characters.")]
        public string Password { get; set; }
    }
}
