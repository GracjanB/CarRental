using CarRentalWPF.Library.RequestsContentModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.UserResource
{
    public class UserClient : IUserClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private HttpClient _client { get; set; }

        public UserClient()
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

        public async Task<UsersResource> GetUsers(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25)
        {
            string endPoint = "api/user/bySpec";
            UsersResource usersResource = null;
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            // Set default values for headers
            _client.DefaultRequestHeaders.Add("isAscending", isAscending.ToString());
            _client.DefaultRequestHeaders.Add("pageNumber", pageNumber.ToString());
            _client.DefaultRequestHeaders.Add("pageSize", pageSize.ToString());

            // Set search field
            if (!string.IsNullOrWhiteSpace(search_field) && !string.IsNullOrWhiteSpace(search_value))
            {
                _client.DefaultRequestHeaders.Add("search", search_field + "=" + search_value);
            }

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    usersResource = JsonConvert.DeserializeObject<UsersResource>(result);

                    return usersResource;
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


        public async Task<UserContent> GetUserById(string token_type, string access_token, int id)
        {
            string endPoint = "api/user/{id}?aLong=" + id.ToString();
            UserContent user = null;
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if(response.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<UserContent>(result);

                    return user;
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
