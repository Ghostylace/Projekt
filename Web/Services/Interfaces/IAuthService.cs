using Shared.DTOs.Auth;

namespace Web.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
    }
}
