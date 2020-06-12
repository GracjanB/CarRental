using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Models
{
    public class AgencyModel
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string FlatNo { get; set; }

        public string HouseNo { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

        public int maxCarQuantity { get; set; }

        public string FullAddress
        {
            get
            {
                return Street + " " + HouseNo + "/" + FlatNo + "\n" + PostalCode + " " + City + "\n" + Country;
            }
        }

        public string FullStreet
        {
            get
            {
                return Street + " " + HouseNo + "/" + FlatNo;
            }
        }

        public AgencyModel() { }

        public AgencyModel(AgencyModel agency)
        {
            Id = agency.Id;
            City = agency.City;
            Country = agency.Country;
            FlatNo = agency.FlatNo;
            HouseNo = agency.HouseNo;
            PostalCode = agency.PostalCode;
            Street = agency.Street;
            maxCarQuantity = agency.maxCarQuantity;
        }
    }
}
