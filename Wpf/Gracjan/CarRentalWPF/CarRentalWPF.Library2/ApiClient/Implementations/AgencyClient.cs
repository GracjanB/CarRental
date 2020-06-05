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

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public class AgencyClient : IAgencyClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public AgencyClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateAgencyAsync(NewAgencyDto content, string token_type, string access_token)
        {
            var JsonData = JsonConvert.SerializeObject(content);
            var data = new StringContent(JsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/agency";
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

        public async Task<AgenciesDto> GetAgenciesAsync(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25)
        {
            string endPoint = "api/agency/bySpec";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            // Set default values for headers
            _client.DefaultRequestHeaders.Add("isAscending", isAscending.ToString());
            _client.DefaultRequestHeaders.Add("pageNumber", pageNumber.ToString());
            _client.DefaultRequestHeaders.Add("pageSize", pageSize.ToString());

            // Search field
            if (!string.IsNullOrWhiteSpace(search_field) && !string.IsNullOrWhiteSpace(search_value))
            {
                _client.DefaultRequestHeaders.Add("search", search_field + "=" + search_value);
            }

            using (var response = await _client.GetAsync(URI + endPoint))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var agencies = JsonConvert.DeserializeObject<AgenciesDto>(result);
                    return agencies;
                }

                throw new Exception("Something went wrong.");
            }
        }
    }
}
