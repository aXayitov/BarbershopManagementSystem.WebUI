using BarbershopManagementSystem.WebUI.Extension;
using BarbershopManagementSystem.WebUI.Models.Enums;

namespace BarbershopManagementSystem.WebUI.ViewModels;

public class EnrollmentViewModel
{
    public int Id { get; set; } 
    public int CustomerId { get; set; }
    public string? Customer { get; set; }
    public int EmployeeId { get; set; }
    public string? Employee { get; set; }
    public int ServiceId { get; set; }
    public string? Service { get; set; }
    public DateTime Date { get; set; }
    public EnrollmentStatus Status { get; set; }
    public string StatusName => Status switch
    {
        EnrollmentStatus.Scheduled => "Scheduled",
        EnrollmentStatus.Completed => "Completed",
        EnrollmentStatus.Cancelled => "Cancelled",
        EnrollmentStatus.NoShow => "No Show",
        EnrollmentStatus.InProgress => "In Progress",
        EnrollmentStatus.Rescheduled => "Rescheduled",
        _ => "Unknown Status"
    };
}


