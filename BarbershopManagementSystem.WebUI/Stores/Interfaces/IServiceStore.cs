using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IServiceStore
{
    Task<List<ServiceViewModel>> GetAllServicesAsync(string? search = null);
    Task<ServiceViewModel> GetServiceByIdAsync(int id);
    Task<ServiceViewModel> CreateServiceAsync(ServiceViewModel serviceForCreate);
    Task UpdateServiceAsync(ServiceViewModel serviceForUpdate);
    Task DeleteServiceAsync(int id);
}
