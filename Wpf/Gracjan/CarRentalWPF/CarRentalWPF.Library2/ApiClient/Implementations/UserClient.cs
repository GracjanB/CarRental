using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarRentalWPF.Library2.ApiClient.Implementations
{
    public class UserClient : IUserClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public UserClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UserRoleDto> GetUserRoleAsync(string tokenType, string accessToken)
        {
            string endPoint = "api/user/checkRole";
            UserRoleDto userRole = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using (var response = await _client.GetAsync(URI + endPoint))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    userRole = JsonConvert.DeserializeObject<UserRoleDto>(result);
                    return userRole;
                }

                throw new Exception("Something went wrong");
            }
        }

        public async Task<UserInfoDto> GetUserDataAsync(string tokenType, string accessToken)
        {
            string endPoint = "api/user";
            UserInfoDto userInfoDto = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);


            using (var response = await _client.GetAsync(URI + endPoint))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    userInfoDto = JsonConvert.DeserializeObject<UserInfoDto>(result);
                    return userInfoDto;
                }

                throw new Exception("Something went wrong");
            }
        }

        public async Task<UserInfoDto> GetUserByIdAsync(string token_type, string access_token, int id)
        {
            string endPoint = "api/user/{id}?aLong=" + id.ToString();
            UserInfoDto user = null;
            _client.DefaultRequestHeaders.Clear();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token_type, access_token);

            using (var response = _client.GetAsync(URI + endPoint).Result)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<UserInfoDto>(result);

                    return user;
                }

                throw new Exception("Something went wrong");
            }
        }

        public async Task<UsersDto> GetUsersAsync(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25, string field = "id")
        {
            UsersDto usersDto = null;
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/user/bySpec";
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
                    usersDto = JsonConvert.DeserializeObject<UsersDto>(result);

                    return usersDto;
                }

                throw new Exception("Something went wrong");
            }
        }

        public async Task<bool> CreateUserAsync(NewUserDto userDto, string tokenType, string accessToken)
        {
            var jsonData = JsonConvert.SerializeObject(userDto);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");

            string endPoint = "api/user/registration";
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return true;

                return false;
            }
        }


    }
}