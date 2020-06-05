using CarRentalWPF.Library.RequestsContentModels;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.UserResource
{
    public interface IUserClient
    {
        Task<UsersResource> GetUsers(string token_type, string access_token, string search_field = "", string search_value = "",
            bool isAscending = true, int pageNumber = 0, int pageSize = 25);

        Task<UserContent> GetUserById(string token_type, string access_token, int id);
    }
}