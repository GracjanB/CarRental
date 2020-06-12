using CarRentalWPF.Library2.FromServerDto;

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

        public void SetUserData2(UserInfoDto user)
        {
            Id = user.user.id;
            FirstName = user.user.firstName;
            LastName = user.user.lastName;
            Email = user.user.email;
            IdCardNumber = user.user.idCardNumber;
            PESEL = user.user.pesel;
            Role = user.user.role;
            AgencyId = (int)user.user.agencyId;
            isActive = true;
        }

        public void ClearUserData()
        {
            Id = 0;
            FirstName = null;
            LastName = null;
            Email = null;
            IdCardNumber = null;
            PESEL = null;
            Role = null;
            AgencyId = 0;
            isActive = false;
        }
    }
}
