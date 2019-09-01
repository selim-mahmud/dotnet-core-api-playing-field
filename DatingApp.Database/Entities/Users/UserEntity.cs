namespace DatingApp.Database.Entities.Users
{
    public class UserEntity : BaseEntity
    {
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
