using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.Models
{
    public class FinishRentContent
    {
        public int endMileage { get; set; }

        public int finalPrice { get; set; }

        public string rentEndDate { get; set; }

        public TechnicalSupportContent technicalSupportContent { get; set; }

        public string vin { get; set; }
    }

    public class TechnicalSupportContent
    {
        public string comment { get; set; }

        public string[] technicalSupportActions { get; set; }

        public int technicalSupportCost { get; set; }
    }
}
