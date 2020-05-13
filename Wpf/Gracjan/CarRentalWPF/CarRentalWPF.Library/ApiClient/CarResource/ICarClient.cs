using CarRentalWPF.Library.Models;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.CarResource
{
    public interface ICarClient
    {
        Task<bool> CreateCar(NewCarContent car, string token_type, string access_token);
        Task<int> CreatePriceList(int price, string token_type, string access_token);
    }
}