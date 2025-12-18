using System.Net.Http.Json;
using Shared.DTOs.Auth;
using Web.Interfaces;

namespace Web.Services
{
    /// <summary>
    /// Class for Authorization requests
    /// </summary>
    /// <seealso cref="Web.Interfaces.IAuthService" />
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public AuthService(HttpClient httpClient) //DI
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Logins the asynchronous.
        /// </summary>
        /// <param name="loginRequestDTO">The login request dto.</param>
        /// <returns>Returns a DTO with the Login values</returns>
        public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var responseLogin = await _httpClient.PostAsJsonAsync($"api/Auth/Login", loginRequestDTO);

            if (responseLogin.IsSuccessStatusCode)
            {
                return await responseLogin.Content.ReadFromJsonAsync<AuthResponseDTO>();
            }
            return null;
        }
    }
}
