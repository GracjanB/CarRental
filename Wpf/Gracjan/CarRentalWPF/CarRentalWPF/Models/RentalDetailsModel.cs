using CarRentalWPF.Library2.FromServerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Models
{
    public class RentalDetailsModel
    {
        public int Id { get; set; }

        public int AgencyId { get; set; }

        public int TargetAgencyId { get; set; }

        public decimal Deposit { get; set; }

        public decimal CalculatedPrice { get; set; }

        public decimal? FinalPrice { get; set; }

        public string Status { get; set; }

        public int StartMileage { get; set; }

        public int? EndMileage { get; set; }

        public string RentStartDate { get; set; }

        public string RentEndDate { get; set; }

        public UserModel User { get; set; }

        public CarModel Car { get; set; }

        public AgencyModel Agency { get; set; }

        public AgencyModel TargetAgency { get; set; }
    }
}
