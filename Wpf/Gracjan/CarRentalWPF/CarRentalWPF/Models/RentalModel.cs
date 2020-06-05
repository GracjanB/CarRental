namespace CarRentalWPF.Models
{
    public class RentalModel
    {
        public CarModel Car { get; set; }

        public EmployeeModel User { get; set; }

        public AgencyModel TargetAgency { get; set; }

        public string StartRentalDate { get; set; }

        public string EndRentalDate { get; set; }

        public int Deposit { get; set; }

        public int StartMileage { get; set; }


        // 
        // Additional data
        //

        public int RentalStage { get; private set; }

        public void IncrementStage() { RentalStage++; }

        public void DecrementStage() { RentalStage--; }
    }
}
