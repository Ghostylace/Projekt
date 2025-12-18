using Shared.DTOs.Auth;

namespace Web.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
    }
}
