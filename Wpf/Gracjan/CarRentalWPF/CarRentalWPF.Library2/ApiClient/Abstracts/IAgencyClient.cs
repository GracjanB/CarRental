using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public interface IAgencyClient
    {
        Task<bool> CreateAgencyAsync(NewAgencyDto content, string token_type, string access_token);

        Task<AgenciesDto> GetAgenciesAsync(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id");

        Task<AgencyDto> GetAgencyByIdAsync(int id, string tokenType, string accessToken);
    }
}