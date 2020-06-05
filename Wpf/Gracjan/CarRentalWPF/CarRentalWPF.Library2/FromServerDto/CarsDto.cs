using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.FromServerDto
{
    public class CarsDto
    {
        public List<Car> content;
    }

    public class Car
    {
        public string vin;

        public string mark;

        public string model;

        public string carVersion;

        public string carType;

        public int mileage;

        public int horsePower;

        public int engineCapacity;

        public string registerPlate;

        public decimal dailyPrice;

        public int parentAgencyId;

        public int currentAgencyId;
    }
}
