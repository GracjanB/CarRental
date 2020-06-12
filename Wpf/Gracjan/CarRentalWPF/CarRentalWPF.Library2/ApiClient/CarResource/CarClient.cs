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

        public async Task<CarsResource> GetCars(string token_type, string access_token, string search_field = "", string search_value = "", 
            bool isAscending = true, int pageNumber = 0, int pageSize = 25)
        {
            string endPoint = "api/car/bySpec";
            CarsResource cars = null;
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            // Set default values for headers
            _client.DefaultRequestHeaders.Add("isAscending", isAscending.ToString());
            _client.DefaultRequestHeaders.Add("pageNumber", pageNumber.ToString());
            _client.DefaultRequestHeaders.Add("pageSize", pageSize.ToString());

            // Search field
            if(!string.IsNullOrWhiteSpace(search_field) && !string.IsNullOrWhiteSpace(search_value))
            {
                _client.DefaultRequestHeaders.Add("search", search_field + "=" + search_value);
            }

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    cars = JsonConvert.DeserializeObject<CarsResource>(result);
                    return cars;
                }
                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ArgumentException("Authorization error \nError content:\n" + result);
                }
                if(response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);
                }
                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
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

        public async Task<CalculatedCost> CalculateCost(CalculateCostContent content, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/rent/calculateCost";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using(var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    var calculatedCost = JsonConvert.DeserializeObject<CalculatedCost>(result);

                    return calculatedCost;
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