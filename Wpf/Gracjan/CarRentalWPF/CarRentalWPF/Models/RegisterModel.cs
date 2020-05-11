using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string BuildingNo { get; set; }

        public int FlatNo { get; set; }

        public string PostalCode { get; set; }

        public string PESEL { get; set; }

        public string PhoneNumber { get; set; }

        public string IdCardNumber { get; set; }
    }
}
