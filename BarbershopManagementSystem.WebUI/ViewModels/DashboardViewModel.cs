namespace BarbershopManagementSystem.WebUI.ViewModels
{
    public class DashboardViewModel
    {
        public SummaryViewModel Summary { get; set; }
        public List<EnrollmentsByEmployee> EnrollmentsByEmployee { get; set; }
        public List<SplineChart> SplineCharts { get; set; }
        public List<MostValuableEmployees> MostValuableEmployees { get; set; }
    }
    public class SummaryViewModel
    {
        public decimal Revenue { get; set; }
        public int LowQuantityBarbers { get; set; }
        public int CustomersAmount { get; set; }
    }
    public class EnrollmentsByEmployee
    {
        public string Barber { get; set; }
        public int EnrollmentsCount { get; set; }
    }
    public class SplineChart
    {
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Refunds { get; set; }
    }
    public class MostValuableEmployees
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int EnrollmentsCount { get; set; }
        public string Position { get; set; }

    }
}
