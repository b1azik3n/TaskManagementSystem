using DomainLayer.Model;
using DomainLayer.ViewModels;

namespace TaskManagementSystem.Services.Authentication
{
    public interface IAuthService
    {
        User FindUser(UserLoginVM user);
        bool RegisterUser(RegisterUserVM user);
    }
}
