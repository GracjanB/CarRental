using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Library.RequestsContentModels
{
    public class CarsResource
    {
        public List<car> content { get; set; }

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

    public class car
    {
        public string vin;

        public string mark;

        public string model;

        public string carVersion;

        public string carType;

        public int mileage;

        public int horsePower;

        public int engineCapacity;

        public string registerPlate;

        public decimal dailyPrice;

        public int parentAgencyId;

        public int currentAgencyId;
    }

    public class Pageable
    {
        public Sort sort;

        public int pageNumber;

        public int pageSize;

        public int offset;

        public bool paged;

        public bool unpaged;
    }

    public class Sort
    {
        public bool sorted;

        public bool unsorted;

        public bool empty;
    }
}
