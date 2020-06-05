using CarRentalWPF.Library2.FromServerDto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ApiClient
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public AuthenticationService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TokenInfoDto> GetTokenAsync(UserLoginDto login)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("scope", "ui"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", login.username),
                new KeyValuePair<string, string>("password", login.password)
            });

            string endPoint = "api/login";
            TokenInfoDto tokenInfoDto = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YnJvd3Nlcjo=");

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    tokenInfoDto = JsonConvert.DeserializeObject<TokenInfoDto>(result);

                    return tokenInfoDto;
                }

                throw new ArgumentException("Unauthorized\nUsername or password are incorrect.");
            }
        }

        public async Task<TokenInfoDto> RefreshTokenAsync(TokenInfoDto tokenInfoDto)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", tokenInfoDto.refresh_token)
            });

            string endPoint = "api/login";
            TokenInfoDto tokenDto = null;

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "YnJvd3Nlcjo=");

            using (var response = await _client.PostAsync(URI + endPoint, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    tokenDto = JsonConvert.DeserializeObject<TokenInfoDto>(result);

                    return tokenDto;
                }

                throw new Exception("Try again");
            }
        }

    }
}