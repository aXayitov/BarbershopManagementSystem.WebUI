namespace BarbershopManagementSystem.WebUI.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<EnrollmentViewModel> Enrollments { get; set; }
    }
}
