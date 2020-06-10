using System.Threading.Tasks;

namespace CarRentalWPF.Library.ApiClient.Implementations
{
    public interface IReportClient
    {
        Task GetReportByDate(string tokenType, string accessToken, string DateFrom, string DateTo);
    }
}