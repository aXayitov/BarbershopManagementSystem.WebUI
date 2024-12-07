using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings
{
    public static class EnrollmentMappings
    {
        public static EnrollmentViewModel ToViewModel(this Enrollment enrollment)
        {
            return new EnrollmentViewModel
            {
                Id = enrollment.Id,
                CustomerId = enrollment.CustomerId,
                Customer = enrollment.Customer.FirstName + " " + enrollment.Customer.LastName,
                EmployeeId = enrollment.EmployeeId,
                Employee = enrollment.Employee.FirstName + " " + enrollment.Employee.LastName,
                ServiceId = enrollment.ServiceId,
                Service = enrollment.Service.Name,
                Date = enrollment.Date,
                Status = enrollment.Status
            };
        }

        public static Enrollment ToEntity(this EnrollmentViewModel enrollmentViewModel)
        {
            return new Enrollment
            {
                Id = enrollmentViewModel.Id,
                CustomerId = enrollmentViewModel.CustomerId,
                EmployeeId = enrollmentViewModel.EmployeeId,
                ServiceId = enrollmentViewModel.ServiceId,
                Status = enrollmentViewModel.Status
            };
        }
    }
}
