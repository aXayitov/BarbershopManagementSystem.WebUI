using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces
{
    public interface IDashboardStore
    {
        Task<DashboardViewModel> GetDashboardAsync();
    }
}
