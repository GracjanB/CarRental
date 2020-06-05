using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public interface IUserClient
    {
        Task<UserInfoDto> GetUserByIdAsync(string token_type, string access_token, int id);

        Task<UserInfoDto> GetUserDataAsync(string tokenType, string accessToken);

        Task<UserRoleDto> GetUserRoleAsync(string tokenType, string accessToken);

        Task<UsersDto> GetUsersAsync(string token_type, string access_token, string search_field = "",
            string search_value = "", bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id");

        Task<bool> CreateUserAsync(NewUserDto userDto, string tokenType, string accessToken);
    }
}