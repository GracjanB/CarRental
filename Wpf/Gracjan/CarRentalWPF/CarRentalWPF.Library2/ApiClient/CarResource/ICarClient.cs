using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.CarResource
{
    public interface ICarClient
    {
        Task<bool> CreateCar(NewCarContent car, string token_type, string access_token);

        Task<int> CreatePriceList(int price, string token_type, string access_token);

        Task<CarsResource> GetCars(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25);

        Task<CalculatedCost> CalculateCost(CalculateCostContent content, string token_type, string access_token);
    }
}