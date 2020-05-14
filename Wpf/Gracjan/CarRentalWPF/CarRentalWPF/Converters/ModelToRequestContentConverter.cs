using CarRentalWPF.Library.Models;
using CarRentalWPF.Library.RequestsContentModels;
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

        public List<CarModel> CarResourceConverter(CarsResource carsResource)
        {
            List<CarModel> carModels = new List<CarModel>();

            if(carsResource != null && !carsResource.empty)
            {
                foreach(var carResource in carsResource.content)
                {
                    carModels.Add(new CarModel
                    {
                        VIN = carResource.vin,
                        Mark = carResource.mark,
                        Model = carResource.model,
                        Type = carResource.carType,
                        Version = carResource.carVersion,
                        Engine = carResource.engineCapacity,
                        Power = carResource.horsePower,
                        Mileage = carResource.mileage,
                        Plate = carResource.registerPlate,
                        PricePerDay = carResource.dailyPrice != null ? (int)carResource.dailyPrice : 0
                    });
                }
            }

            return carModels;
        }

        public List<EmployeeModel> UserResourceConverter(UsersResource usersResource)
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();

            if(usersResource != null && !usersResource.empty)
            {
                foreach(var user in usersResource.body)
                {
                    employeeModels.Add(new EmployeeModel
                    {
                        Id = user.id,
                        FirstName = user.firstName,
                        LastName = user.lastName,
                        Email = user.email,
                        Role = user.role,
                        PESEL = user.pesel,
                        IdCardNumber = user.idCardNumber,
                        AgencyId = user.agencyId != null ? (int)user.agencyId : 0
                    });
                }
            }

            return employeeModels;
        }
    }
}
