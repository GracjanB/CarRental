using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.FromServerDto
{
    public class RentalDto
    {
        public int id;

        public string userMail;

        public string carVin;

        public string agencyCity;

        public string targetAgencyCity;

        public string employeeMail;

        public string rentStartDate;

        public string rentEndDate;

        public int startMileage;

        public int? endMileage;

        public decimal deposit;

        public decimal calculatedPrice;

        public decimal? finalPrice;

        public string status;

        public int agencyId;

        public int targetAgencyId;

        public int userId;
    }
}
