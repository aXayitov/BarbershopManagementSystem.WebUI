using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class DashboardStore : IDashboardStore
{
    private readonly ApiClient _client;
    public DashboardStore(ApiClient client)
    {
        _client = client;
    }
    public async Task<DashboardViewModel> GetDashboardAsync()
    {
        var response = await _client.GetAsync<DashboardViewModel>("dashboard");

        return response;
    }
}
