namespace BarbershopManagementSystem.WebUI.Models.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
