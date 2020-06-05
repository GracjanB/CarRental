using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.Models
{
    public class RentalForm
    {
        public string carVin { get; set; }

        public int deposit { get; set; }

        public string rentStartDate { get; set; }

        public string rentEndDate { get; set; }

        public int startMileage { get; set; }

        public int targetAgencyId { get; set; }

        public int userId { get; set; }
    }
}
