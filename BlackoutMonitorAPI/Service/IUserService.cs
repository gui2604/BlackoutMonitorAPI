using BlackoutMonitorAPI.DTOs;
using BlackoutMonitorAPI.Model;

namespace BlackoutMonitorAPI.Service
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
    }
}
