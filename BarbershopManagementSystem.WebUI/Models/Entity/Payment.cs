using BarbershopManagementSystem.WebUI.Models.Enums;

namespace BarbershopManagementSystem.WebUI.Models.Entity
{
    public class Payment
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentType { get; set; }
    }
}
