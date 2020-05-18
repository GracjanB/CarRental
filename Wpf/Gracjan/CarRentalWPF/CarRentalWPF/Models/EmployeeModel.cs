using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PESEL { get; set; }

        public string IdCardNumber { get; set; }

        public string Role { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string BuildingNo { get; set; }

        public int FlatNo { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }

        public int AgencyId { get; set; }

        public string FullStreet
        {
            get
            {
                return Street + " " + BuildingNo + "/" + FlatNo;
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public EmployeeModel() { }

        public EmployeeModel(EmployeeModel employee)
        {
            Id = employee.Id;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Email = employee.Email;
            PESEL = employee.PESEL;
            IdCardNumber = employee.IdCardNumber;
            Role = employee.Role;
            City = employee.City;
            Country = employee.Country;
            Street = employee.Street;
            BuildingNo = employee.BuildingNo;
            FlatNo = employee.FlatNo;
            PostalCode = employee.PostalCode;
            PhoneNumber = employee.PhoneNumber;
            AgencyId = employee.AgencyId;
        }
    }
}
