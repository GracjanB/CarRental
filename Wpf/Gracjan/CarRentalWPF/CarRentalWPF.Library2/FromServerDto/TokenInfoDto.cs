using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library2.FromServerDto
{
    public class TokenInfoDto
    {
        public string access_token;

        public string token_type;

        public string refresh_token;

        public int expires_in;

        public string scope;
    }
}
