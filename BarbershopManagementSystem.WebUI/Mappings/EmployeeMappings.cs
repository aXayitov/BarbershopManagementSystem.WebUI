using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings
{
    public static class EmployeeMappings
    {
        public static EmployeeViewModel ToViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                FullName = employee.FirstName + " " + employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                PositionId = employee.PositionId,
                Position = employee.Position.Name
            };
        }

        public static Employee ToEntity(this EmployeeViewModel employeeViewModel)
        {
            return new Employee
            {
                Id = employeeViewModel.Id,
                FirstName = employeeViewModel.FullName.Split(' ')[0],
                LastName = employeeViewModel.FullName.Split(' ')[1],
                PhoneNumber = employeeViewModel.PhoneNumber,
                PositionId = employeeViewModel.PositionId,
            };
        }
    }
}
