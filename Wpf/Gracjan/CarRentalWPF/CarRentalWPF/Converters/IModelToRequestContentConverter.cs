using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
using CarRentalWPF.Models;
using System.Collections.Generic;

namespace CarRentalWPF.Converters
{
    public interface IModelToRequestContentConverter
    {
        NewCarContent CarConverter(CarModel carModel, int agencyId, int priceListId);

        List<CarModel> CarResourceConverter(CarsResource carsResource);

        List<EmployeeModel> UserResourceConverter(UsersResource usersResource);

        EmployeeModel UserContentConverter(UserContent user);
    }
}