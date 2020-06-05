using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ToServerDto
{
    public class FinishRentDto
    {
        public int endMileage;

        public int finalPrice;

        public string rentEndDate;

        public TechnicalSupportContent technicalSupportContent;

        public string vin;
    }

    public class TechnicalSupportContent
    {
        public string comment;

        public string[] technicalSupportActions;

        public int technicalSupportCost;
    }
}
