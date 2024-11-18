namespace BarbershopManagementSystem.WebUI.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public List<EnrollmentViewModel> Enrollments { get; set; }
    }
}
