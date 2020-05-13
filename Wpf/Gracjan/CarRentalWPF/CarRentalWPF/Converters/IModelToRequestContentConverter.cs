using CarRentalWPF.Library.Models;
using CarRentalWPF.Models;

namespace CarRentalWPF.Converters
{
    public interface IModelToRequestContentConverter
    {
        NewCarContent CarConverter(CarModel carModel, int agencyId, int priceListId);
    }
}