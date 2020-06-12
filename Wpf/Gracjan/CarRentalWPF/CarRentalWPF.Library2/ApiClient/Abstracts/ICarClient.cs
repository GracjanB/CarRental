using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public interface ICarClient
    {
        Task<bool> CreateCarAsync(NewCarDto car, string token_type, string access_token);

        Task<int> CreatePriceListAsync(decimal price, string token_type, string access_token);

        Task<CarsDto> GetCarsAsync(string token_type, string access_token, string search_field = "", string search_value = "", bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "mark");

        Task<CarDto> GetCarByVinAsync(string vin, string tokenType, string accessToken);
    }
}