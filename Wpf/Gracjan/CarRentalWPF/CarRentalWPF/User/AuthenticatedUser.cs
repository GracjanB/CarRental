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

        public void Login(string accessToken, string tokenType, string refreshToken, int tokenExpireTime)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
            this.RefreshToken = refreshToken;
            this.TokenExpireTime = tokenExpireTime;
        }


    }
}
