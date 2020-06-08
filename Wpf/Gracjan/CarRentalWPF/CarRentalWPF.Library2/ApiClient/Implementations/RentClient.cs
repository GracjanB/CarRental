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
    public class RentClient : IRentClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public RentClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateRentAsync(NewRentalDto content, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/rent";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }

        public async Task<bool> FinishRentAsync(FinishRentDto content, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "/api/rent/finish";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }

        public async Task<string[]> GetActionsAsync(string token_type, string access_token)
        {
            string endPoint = "api/rent/action";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.GetAsync(URI + endPoint))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var actions = JsonConvert.DeserializeObject<string[]>(result);
                    return actions;
                }

                throw new Exception("Something went wrong.");
            }
        }

        public async Task<CalculatedCostDto> CalculateCostAsync(CalculateCostDto content, string token_type, string access_token)
        {
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/rent/calculateCost";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var calculatedCost = JsonConvert.DeserializeObject<CalculatedCostDto>(result);

                    return calculatedCost;
                }

                throw new Exception("Something went wrong");
            }
        }

        public async Task<RentalsDto> GetRentalsAsync(string tokenType, string accessToken, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id")
        {
            RentalsDto rentalsDto = null;
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/rent/bySpec";
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
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using(var response = await _client.GetAsync(uriBuilder.ToString()))
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    rentalsDto = JsonConvert.DeserializeObject<RentalsDto>(result);

                    return rentalsDto;
                }

                throw new Exception("Something went wrong");
            }
        }

    }
}
