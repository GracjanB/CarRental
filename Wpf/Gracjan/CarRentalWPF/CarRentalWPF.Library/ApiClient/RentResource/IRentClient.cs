using CarRentalWPF.Library.Models;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.RentResource
{
    public interface IRentClient
    {
        Task<int> CalculateCost(CalculateCostContent content, string token_type, string access_token);

        Task<bool> CreateRent(RentalForm rental, string token_type, string access_token);

        Task<bool> FinishRent(FinishRentContent content, string token_type, string access_token);

        Task GetActions(string token_type, string access_token);
    }
}