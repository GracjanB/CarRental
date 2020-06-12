using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Events
{
    public class AgencySelectedEvent
    {
        public AgencyModel Agency { get; private set; }

        public AgencySelectedEvent(AgencyModel agencyModel)
        {
            Agency = agencyModel;
        }
    }
}
