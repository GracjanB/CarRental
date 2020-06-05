using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class TokenInfo
    {
        #region Response Content

        public string access_token { get; set; }

        public string token_type { get; set; }

        public string refresh_token { get; set; }

        public int expires_in { get; set; }

        public string scope { get; set; }

        #endregion 


        public bool isSucceded { get; set; }

        public string message { get; set; }

        public string GetFullToken()
        {
            return token_type + ' ' + access_token;
        }
    }
}
