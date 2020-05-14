using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class User
    {
        public int id { get; set; }

        public string email { get; set; }

        public string role { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string pesel { get; set; }

        public string idCardNumber { get; set; }

        public bool isActive { get; set; }

        public int? agencyId { get; set; }
    }
}
