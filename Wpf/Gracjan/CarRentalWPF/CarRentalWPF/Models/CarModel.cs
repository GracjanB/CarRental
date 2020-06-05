using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }

        public int Engine { get; set; }

        public int Power { get; set; }

        public int Mileage { get; set; }

        public string Status { get; set; }

        public string Plate { get; set; }

        public string VIN { get; set; }

        public decimal PricePerDay { get; set; }

        public string FullName
        {
            get
            {
                return Mark + " " + Model + " " + Type;
            }
        }

        public CarModel() { }

        public CarModel(CarModel car)
        {
            Id = car.Id;
            Mark = car.Mark;
            Model = car.Model;
            Type = car.Type;
            Version = car.Version;
            Engine = car.Engine;
            Power = car.Power;
            Mileage = car.Mileage;
            Status = car.Status;
            Plate = car.Plate;
            VIN = car.VIN;
            PricePerDay = car.PricePerDay;
        }

    }
}
