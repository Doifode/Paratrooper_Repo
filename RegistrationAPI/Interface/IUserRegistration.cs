using RegistrationAPI.Models;

namespace RegistrationAPI.Interface
{
    public interface IUserRegistration
    {
        void Add(UserRegistration user);
        bool Login(string username,  string password);
    }
}
