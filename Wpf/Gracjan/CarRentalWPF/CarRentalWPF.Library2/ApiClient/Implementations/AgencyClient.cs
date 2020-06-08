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
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id")
        {
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/agency/bySpec";
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

            // Set authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = await _client.GetAsync(uriBuilder.ToString()))
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

        public async Task<AgencyDto> GetAgencyByIdAsync(int id, string tokenType, string accessToken)
        {
            AgencyDto agencyDto = null;
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/agency/";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["id"] = id.ToString();
            uriBuilder.Query = query.ToString();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using(var response = await _client.GetAsync(uriBuilder.ToString()))
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    agencyDto = JsonConvert.DeserializeObject<AgencyDto>(result);

                    return agencyDto;
                }

                throw new Exception("Something went wrong.");
            }
        }
    }
}
