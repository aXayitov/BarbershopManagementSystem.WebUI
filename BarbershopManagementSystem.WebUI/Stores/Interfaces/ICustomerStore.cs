using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface ICustomerStore
{
    Task<PaginatedResponse<CustomerViewModel>> GetAllCustomersAsync(string? search = null, int? pageNumber = null);
    Task<CustomerViewModel> GetCustomerByIdAsync(int id);
    Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerForCreate);
    Task UpdateCustomerAsync(CustomerViewModel customerForUpdate);
    Task DeleteCustomerAsync(int id);
}
