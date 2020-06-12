using System;

namespace CarRentalWPF.Models
{
    public class RentalModel
    {
        public CarModel Car { get; set; }

        public UserModel User { get; set; }

        public AgencyModel TargetAgency { get; set; }

        public string StartRentalDate { get; set; }

        public string EndRentalDate { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalStartTime { get; set; }

        public DateTime RentalEndDate { get; set; }

        public DateTime RentalEndTime { get; set; }

        public int Deposit { get; set; }

        public int StartMileage { get; set; }

        public decimal CalculatedCost { get; set; }
    }
}
