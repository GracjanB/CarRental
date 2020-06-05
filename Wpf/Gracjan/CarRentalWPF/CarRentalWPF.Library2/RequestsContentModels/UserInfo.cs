using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class UserInfo
    {
        public User user { get; set; }

        public bool isSucceded { get; set; }

        public string message { get; set; }
    }
}
