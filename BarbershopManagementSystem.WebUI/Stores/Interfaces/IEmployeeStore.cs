using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IEmployeeStore
{
    Task<PaginatedResponse<EmployeeViewModel>> GetAllEmployeesAsync(string? search = null, int? pageNumber = null);
    Task<EmployeeViewModel> GetEmployeeByIdAsync(int id);
    Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModel employeeForCreate);
    Task UpdateEmployeeAsync(EmployeeViewModel employeeForUpdate);
    Task DeleteEmployeeAsync(int id);
}
