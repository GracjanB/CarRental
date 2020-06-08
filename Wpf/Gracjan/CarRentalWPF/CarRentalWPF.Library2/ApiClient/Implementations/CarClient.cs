using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public class CarClient : ICarClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public CarClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateCarAsync(NewCarDto car, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(car);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/car";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<CarDto> GetCarByVinAsync(string vin, string tokenType, string accessToken)
        {
            CarDto carDto = null;
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/car/";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["id"] = vin;
            uriBuilder.Query = query.ToString();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using(var response = await _client.GetAsync(uriBuilder.ToString()))
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    carDto = JsonConvert.DeserializeObject<CarDto>(result);

                    return carDto;
                }

                throw new Exception("Something went wrong.");
            }
        }

        public async Task<CarsDto> GetCarsAsync(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "mark")
        {
            CarsDto cars = null;
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/car/bySpec";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["field"] = field;
            query["isAscending"] = isAscending.ToString();
            query["pageNumber"] = pageNumber.ToString();
            query["pageSize"] = pageSize.ToString();

            // Set search field
            if (!string.IsNullOrWhiteSpace(search_field) && !string.IsNullOrWhiteSpace(search_value))
            {
                query["search"] = search_field + "=" + search_value;
            }
            else
                query["search"] = "";
            uriBuilder.Query = query.ToString();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.GetAsync(uriBuilder.ToString()))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    cars = JsonConvert.DeserializeObject<CarsDto>(result);
                    return cars;
                }

                throw new Exception("Something went wrong.");
            }
        }

        public async Task<int> CreatePriceListAsync(decimal price, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(new { dailyPrice = price });
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/priceList";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var priceListContent = JsonConvert.DeserializeObject<PriceListDto>(result);
                    return priceListContent.id;
                }

                throw new Exception("Something went wrong.");
            }
        }
    }
}
