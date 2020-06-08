using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public interface IRentClient
    {
        Task<CalculatedCostDto> CalculateCostAsync(CalculateCostDto content, string token_type, string access_token);
        Task<bool> CreateRentAsync(NewRentalDto content, string token_type, string access_token);
        Task<bool> FinishRentAsync(FinishRentDto content, string token_type, string access_token);
        Task<string[]> GetActionsAsync(string token_type, string access_token);
        Task<RentalsDto> GetRentalsAsync(string tokenType, string accessToken, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id");
    }
}