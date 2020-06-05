using CarRentalWPF.Library2.FromServerDto;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient
{
    public interface IAuthenticationService
    {
        Task<TokenInfoDto> GetTokenAsync(UserLoginDto login);

        Task<TokenInfoDto> RefreshTokenAsync(TokenInfoDto tokenInfoDto);
    }
}