using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.ToServerDto
{
    public class NewRentalDto
    {
        public string carVin;

        public int deposit;

        public string rentStartDate;

        public string rentEndDate;

        public int startMileage;

        public int targetAgencyId;

        public int userId;
    }
}
