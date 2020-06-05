using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.User
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public string RefreshToken { get; set; }

        public int TokenExpireTime { get; set; }

        public int AgencyId { get; set; }

        public int UserId { get; set; }

        public void Login(string accessToken, string tokenType, string refreshToken, int tokenExpireTime, int agencyId, int userId)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.RefreshToken = refreshToken;
            this.TokenExpireTime = tokenExpireTime;
            this.AgencyId = agencyId;
            this.UserId = userId;
        }

        public void Logout()
        {
            AccessToken = null;
            TokenType = null;
            RefreshToken = null;
            TokenExpireTime = 0;
            AgencyId = 0;
            UserId = 0;
        }

    }
}
