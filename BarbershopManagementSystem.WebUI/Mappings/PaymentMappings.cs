using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings;

public static class PaymentMappings
{
    public static PaymentViewModel ToViewModel(this Payment payment)
    {
        return new PaymentViewModel
        {
            Id = payment.Id,
            EnrollmentId = payment.EnrollmentId,
            CustomerId = payment.Enrollment.CustomerId,
            Customer = payment.Enrollment.Customer.FirstName + " " + payment.Enrollment.Customer.LastName,
            EmployeeId = payment.Enrollment.EmployeeId,
            Employee = payment.Enrollment.Employee.FirstName + " " + payment.Enrollment.Employee.LastName,
            Amount = payment.Amount,
            PaymentDate = payment.PaymentDate,
            PaymentType = payment.PaymentType
        };
    }

    public static Payment ToEntity(this PaymentViewModel paymentViewModel)
    {
        return new Payment
        {
            Id = paymentViewModel.Id,
            EnrollmentId = paymentViewModel.EnrollmentId,
            Amount = paymentViewModel.Amount,
            PaymentDate = paymentViewModel.PaymentDate,
            PaymentType = paymentViewModel.PaymentType
        };
    }
}
