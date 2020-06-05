using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.FromServerDto
{
    public class AgenciesDto
    {
        public List<Agency> content;
    }

    public class Agency
    {
        public int id;

        public string street;

        public string houseNo;

        public string flatNo;

        public string city;

        public string postalCode;

        public string country;

        public int maxCarQuantity;
    }
}
