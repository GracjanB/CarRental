using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.FromServerDto
{
    public class UserDto
    {
        public int id;

        public string email;

        public string role;

        public string firstName;

        public string lastName;

        public string pesel;

        public string idCardNumber;

        public bool isActive;

        public int? agencyId;
    }
}
