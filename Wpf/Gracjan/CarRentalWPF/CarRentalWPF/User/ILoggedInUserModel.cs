using CarRentalWPF.Library2.FromServerDto;

namespace CarRentalWPF.User
{
    public interface ILoggedInUserModel
    {
        string Email { get; set; }

        string FirstName { get; set; }

        int Id { get; set; }

        string IdCardNumber { get; set; }

        string LastName { get; set; }

        string PESEL { get; set; }

        string Role { get; set; }

        int AgencyId { get; set; }

        bool isActive { get; set; }

        void SetUserData2(UserInfoDto user);

        void ClearUserData();
    }
}