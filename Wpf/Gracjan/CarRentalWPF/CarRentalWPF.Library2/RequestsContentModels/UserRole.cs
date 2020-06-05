using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class UserRole
    {
        #region Response Content

        public string role { get; set; }

        #endregion


        public bool isSucceded { get; set; }

        public string message { get; set; }
    }
}
