using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.CarResource
{
    public class CarClient : ICarClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private HttpClient _client { get; set; }

        public CarClient()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateCar(NewCarContent car, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(car);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/car";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ArgumentException("Authorization error \nError content:\n" + result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);
                }
                else
                {
                    throw new ArgumentException("Other error\nError content:\n" + result);
                }
            }
        }

        public async Task<int> CreatePriceList(int price, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(new { dailyPrice = price });
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/priceList";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var priceListContent = JsonConvert.DeserializeObject<PriceListContent>(result);

                    return priceListContent.id;
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ArgumentException("Authorization error \nError content:\n" + result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);
                }
                else
                {
                    throw new ArgumentException("Other error\nError content:\n" + result);
                }
            }
        }
    }
}