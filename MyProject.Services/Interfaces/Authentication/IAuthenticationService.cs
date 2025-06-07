using MyProject.Services.DTOs.Authentication;

namespace MyProject.Services.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
