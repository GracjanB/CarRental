using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.Models
{
    public class NewCarContent
    {
        public int agencyId { get; set; }

        public string mark { get; set; }

        public string model { get; set; }

        public string carType { get; set; }

        public string carVersion { get; set; }

        public int engineCapacity { get; set; }

        public int horsePower { get; set; }

        public int mileage { get; set; }

        public int priceListId { get; set; }

        public string registerPlate { get; set; }

        public string vin { get; set; }
    }
}
