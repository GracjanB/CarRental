using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class UsersResource
    {
        public List<User> body { get; set; }

        public Pageable pageable { get; set; }

        public int totalPages { get; set; }

        public int totalElements { get; set; }

        public bool last { get; set; }

        public bool first { get; set; }

        public Sort sort { get; set; }

        public int number { get; set; }

        public int numberOfElements { get; set; }

        public int size { get; set; }

        public bool empty { get; set; }
    }
}
