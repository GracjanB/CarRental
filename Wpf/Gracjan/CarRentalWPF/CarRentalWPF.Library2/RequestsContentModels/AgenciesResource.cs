using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class AgenciesResource
    {
        public List<Agency> content { get; set; }

        public string statusCode { get; set; }

        public int statusCodeValue { get; set; }
    }

    public class Agency
    {
        public int id { get; set; }

        public string street { get; set; }

        public string houseNo { get; set; }

        public string flatNo { get; set; }

        public string city { get; set; }

        public string postalCode { get; set; }

        public string country { get; set; }

        public int maxCarQuantity { get; set; }
    }
}
