using CarRentalWPF.Library.Models;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Converters
{
    public class ModelToRequestContentConverter : IModelToRequestContentConverter
    {
        public NewCarContent CarConverter(CarModel carModel, int agencyId, int priceListId)
        {
            var newCarModel = new NewCarContent
            {
                mark = carModel.Mark,
                model = carModel.Model,
                carType = carModel.Type,
                carVersion = carModel.Version,
                engineCapacity = carModel.Engine,
                horsePower = carModel.Power,
                mileage = carModel.Mileage,
                registerPlate = carModel.Plate,
                vin = carModel.VIN,
                agencyId = agencyId,
                priceListId = priceListId
            };

            return newCarModel;
        }
    }
}
