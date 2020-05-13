using CarRentalWPF.Library.RequestsContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.User
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string IdCardNumber { get; set; }

        public string PESEL { get; set; }

        public string Role { get; set; }

        public int AgencyId { get; set; }

        public bool isActive { get; set; } = false;

        public string FullName
        {
            get
            {
                return FirstName + LastName;
            }
        }

        public void SetUserData(UserInfo userCredentials)
        {
            this.Id = userCredentials.user.id;
            this.FirstName = userCredentials.user.firstName;
            this.LastName = userCredentials.user.lastName;
            this.Email = userCredentials.user.email;
            this.IdCardNumber = userCredentials.user.idCardNumber;
            this.PESEL = userCredentials.user.pesel;
            this.Role = userCredentials.user.role;
            this.AgencyId = userCredentials.user.agencyId;
            this.isActive = true;
        }
    }
}
