using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Domain.Models.Entities
{
    public class User
    {
        /// <summary>
        /// unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password hash of the user password
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// salted password of the user
        /// </summary>
        public byte[] PasswordSalt { get; set; }
    }
}
