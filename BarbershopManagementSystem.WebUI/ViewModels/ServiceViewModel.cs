namespace BarbershopManagementSystem.WebUI.ViewModels;

public class ServiceViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public TimeSpan? Duration { get; set; }
    public List<EnrollmentViewModel> Enrollments { get; set; }
}
