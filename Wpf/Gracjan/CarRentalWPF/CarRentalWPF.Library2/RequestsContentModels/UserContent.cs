using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class UserContent
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public User data { get; set; }
    }
}
