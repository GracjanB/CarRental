using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CarRentalWPF.Library.RequestsContentModels;
using CarRentalWPF.Library.Models;

namespace CarRentalWPF.Library.ApiClient
{
    public class UserLoginClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private HttpClient _client { get; set; }

        public UserLoginClient()
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

        public async Task<TokenInfo> GetToken(UserLogin login)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("scope", "ui"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", login.username),
                new KeyValuePair<string, string>("password", login.password)
            });

            string endPoint = "api/login";
            TokenInfo tokenInfo = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YnJvd3Nlcjo=");

            try
            {
                using (var response = await _client.PostAsync(URI + endPoint, data))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(result);

                        tokenInfo.isSucceded = true;
                    }
                    else
                    {
                        tokenInfo.isSucceded = false;

                        var resultStatusCode = response.StatusCode.ToString();
                        tokenInfo.message = "An error occured. Status Code: " + resultStatusCode;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured in Try block.");
            }

            return tokenInfo;
        }

        public UserRole GetUserRole(TokenInfo tokenInfo)
        {
            string endPoint = "api/user/checkRole";
            UserRole userRole = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenInfo.token_type, tokenInfo.access_token);

            try
            {
                using (var response = _client.GetAsync(URI + endPoint).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        userRole = JsonConvert.DeserializeObject<UserRole>(result);

                        userRole.isSucceded = true;
                    }
                    else
                    {
                        userRole.isSucceded = false;

                        var resultStatusCode = response.StatusCode.ToString();
                        userRole.message = "An error occured. Status Code: " + resultStatusCode;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured in Try block.");
            }

            return userRole;
        }

        public TokenInfo RefreshToken(TokenInfo tokenInfo)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", tokenInfo.refresh_token)
            });

            string endPoint = "api/login";
            TokenInfo refreshedTokenInfo = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YnJvd3Nlcjo=");

            try
            {
                using (var response = _client.PostAsync(URI + endPoint, data).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        refreshedTokenInfo = JsonConvert.DeserializeObject<TokenInfo>(result);

                        refreshedTokenInfo.isSucceded = true;
                    }
                    else
                    {
                        refreshedTokenInfo.isSucceded = false;

                        string resultStatusCode = response.StatusCode.ToString();
                        refreshedTokenInfo.message = "An error occured with Status Code: " + resultStatusCode;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured in Try block.");
            }

            return refreshedTokenInfo;
        }

        public async Task<UserInfo> GetUserData(string tokenType, string accessToken)
        {
            string endPoint = "api/user";
            UserInfo userInfo = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            try
            {
                using (var response = await _client.GetAsync(URI + endPoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userInfo = JsonConvert.DeserializeObject<UserInfo>(result);

                        userInfo.isSucceded = true;
                    }
                    else
                    {
                        userInfo.isSucceded = false;

                        string resultStatusCode = response.StatusCode.ToString();
                        userInfo.message = "An error occured with Status Code: " + resultStatusCode;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured in Try block.");
            }

            return userInfo;
        }
    }
}
