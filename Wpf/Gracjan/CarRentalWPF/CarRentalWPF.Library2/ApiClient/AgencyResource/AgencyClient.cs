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

namespace CarRentalWPF.Library.ApiClient.AgencyResource
{
    public class AgencyClient : IAgencyClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private HttpClient _client { get; set; }

        public AgencyClient()
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

        public async Task<bool> CreateAgency(string token_type, string access_token, NewAgencyContent content)
        {
            // Prepare data
            string endPoint = "api/agency";
            var JsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(JsonData, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
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

        public async Task<AgenciesResource> GetAgencies(string token_type, string access_token)
        {
            string endPoint = "api/agency/bySpec";
            _client.DefaultRequestHeaders.Clear();

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var agencyResource = JsonConvert.DeserializeObject<AgenciesResource>(result);

                    return agencyResource;
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new ArgumentException("Authorization error \nError content:\n" + result);
                if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    throw new ArgumentException("You have no access to this operation.\nError content:\n" + result);
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    throw new ArgumentException("Not Found \nCheck your data and try again\nError content:\n" + result);
                else
                    throw new ArgumentException("Other error\nError content:\n" + result);
            }
        }
    }
}
