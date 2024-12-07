using BarbershopManagementSystem.WebUI.Models.Enums;

namespace BarbershopManagementSystem.WebUI.ViewModels;

public class PaymentViewModel
{
    public int Id { get; set; }
    public int EnrollmentId { get; set; }
    public int CustomerId { get; set; }
    public string Customer { get; set; }
    public int EmployeeId { get; set; }
    public string Employee { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentType { get; set; }
}
