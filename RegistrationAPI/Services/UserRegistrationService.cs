using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Data;
using RegistrationAPI.Interface;
using RegistrationAPI.Models;

namespace RegistrationAPI.Services
{
    public class UserRegistrationService:IUserRegistration
    {
        private readonly ApplicationDbContext context;
        public UserRegistrationService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void Add(UserRegistration user)
        {
            // Encrypt the password and confirm password
            user.Password = EncryptPassword(user.Password);
            user.ConfirmPassword = EncryptPassword(user.ConfirmPassword);
            context.Set<UserRegistration>().Add(user);
            context.SaveChanges();
        }
        private string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool Login(string username, string password)
        {
            var user = context.Registration.FirstOrDefault(s => s.UserName == username);
            if (user != null)
            {
                // Compare the hashed password
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return true; // Passwords match
                }
            }
            return false;
        }

    }
}
