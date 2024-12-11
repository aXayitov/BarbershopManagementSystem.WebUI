namespace BarbershopManagementSystem.WebUI.ViewModels;

public class PositionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<EmployeeViewModel>? Employees { get; set; }
}
