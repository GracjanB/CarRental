namespace CarRentalWPF.User
{
    public interface IAuthenticatedUser
    {
        string AccessToken { get; set; }

        string RefreshToken { get; set; }

        int TokenExpireTime { get; set; }

        string TokenType { get; set; }

        void Login(string accessToken, string tokenType, string refreshToken, int tokenExpireTime, int agencyId, int userId);
    }
}