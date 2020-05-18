using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.RentResource
{
    public class RentClient : IRentClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private HttpClient _client { get; set; }

        public RentClient()
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

        public async Task<bool> CreateRent(RentalForm rental, string token_type, string access_token)
        {
            // Prepare data
            string endPoint = "/api/rent";
            var jsonData = JsonConvert.SerializeObject(rental);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return true;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new ArgumentException("Authorization error \nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);

                else throw new ArgumentException("Other error\nError content:\n" + result);
            }
        }

        public async Task GetActions(string token_type, string access_token)
        {
            // Prepare data
            string endPoint = "/api/rent/action";
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // 1. Convert to table
                    // 2. Return table of actions
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new ArgumentException("Authorization error \nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);

                else throw new ArgumentException("Other error\nError content:\n" + result);
            }
        }

        public async Task<int> CalculateCost(CalculateCostContent content, string token_type, string access_token)
        {
            // Prepare data
            string endPoint = "/api/rent/calculateCost";
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var cost = JsonConvert.DeserializeObject<EstimatedCostObject>(result);

                    return cost.cost;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new ArgumentException("Authorization error \nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);

                else throw new ArgumentException("Other error\nError content:\n" + result);
            }
        }

        public async Task<bool> FinishRent(FinishRentContent content, string token_type, string access_token)
        {
            // Prepare data
            string endPoint = "/api/rent/finish";
            var jsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.PostAsync(URI + endPoint, data).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return true;

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new ArgumentException("Authorization error \nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);

                else throw new ArgumentException("Other error\nError content:\n" + result);
            }
        }
    }
}
