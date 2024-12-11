using BarbershopManagementSystem.WebUI.Extension;
using BarbershopManagementSystem.WebUI.Models.Enums;

namespace BarbershopManagementSystem.WebUI.ViewModels;

public class EnrollmentViewModel
{
    public int Id { get; set; } 
    public int CustomerId { get; set; }
    public string Customer { get; set; }
    public int EmployeeId { get; set; }
    public string Employee { get; set; }
    public int ServiceId { get; set; }
    public string Service { get; set; }
    public DateTime Date { get; set; }
    public EnrollmentStatus Status { get; set; }
    public string GetStatusString()
    {
        switch (Status)
        {
            case EnrollmentStatus.Scheduled:
                return "Scheduled";
            case EnrollmentStatus.Completed:
                return "Completed";
            case EnrollmentStatus.Cancelled:
                return "Cancelled";
            case EnrollmentStatus.NoShow:
                return "No Show";
            case EnrollmentStatus.InProgress:
                return "In Progress";
            case EnrollmentStatus.Rescheduled:
                return "Rescheduled";
            default:
                return "Unknown Status";
        }
    }
}


