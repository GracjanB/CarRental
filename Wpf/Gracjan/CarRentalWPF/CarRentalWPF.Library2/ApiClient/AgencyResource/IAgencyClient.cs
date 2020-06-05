using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.AgencyResource
{
    public interface IAgencyClient
    {
        Task<bool> CreateAgency(string token_type, string access_token, NewAgencyContent content);
        Task<AgenciesResource> GetAgencies(string token_type, string access_token);
    }
}