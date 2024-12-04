namespace BarbershopManagementSystem.WebUI.Models.Entity
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Status Status { get; set; }
    }
    public enum Status
    {
        Scheduled,
        Completed,
        Cancelled,
        NoShow,
        InProgress,
        Rescheduled
    }
}
