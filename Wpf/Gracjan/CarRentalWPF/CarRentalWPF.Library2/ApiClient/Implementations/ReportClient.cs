using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarRentalWPF.Library.ApiClient.Implementations
{
    public class ReportClient : IReportClient
    {
        private const string URI = "https://carrental-dev.herokuapp.com/";

        private readonly HttpClient _client;

        public ReportClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(URI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task GetReportByDate(string tokenType, string accessToken, string DateFrom, string DateTo)
        {
            _client.DefaultRequestHeaders.Clear();

            var uriBuilder = new UriBuilder(URI);
            uriBuilder.Path = "api/car/bySpec";
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["startDate"] = DateFrom;
            query["endDate"] = DateTo;
            uriBuilder.Query = query.ToString();

            // Set Authorization
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);

            using (var response = await _client.GetAsync(uriBuilder.ToString()))
            {

            }
        }
    }
}
