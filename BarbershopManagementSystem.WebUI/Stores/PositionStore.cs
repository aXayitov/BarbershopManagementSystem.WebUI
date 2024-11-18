using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class PositionStore : IPositionStore
{
    private const string URL = "positions";
    private readonly ApiClient _client;

    public PositionStore(ApiClient client)
    {
        _client = client;
    }    

    public async Task<List<PositionViewModel>> GetAllPositionsAsync(string? search = null)
    {
        var response = await _client.GetAsync<PaginatedResponse<PositionViewModel>>($"{URL}?search={search}");

        return response.Data;
    }

    public async Task<PositionViewModel> GetPositionByIdAsync(int id)
    {
        var position = await _client.GetAsync<PositionViewModel>($"{URL}/{id}");

        return position;
    }

    public async Task<PositionViewModel> CreatePositionAsync(PositionViewModel positionForCreate)
    {
        var createdPosition = await _client
            .PostAsync<PositionViewModel, PositionViewModel>(URL, positionForCreate);

        return createdPosition;
    }

    public async Task UpdatePositionAsync(PositionViewModel positionForUpdate)
    {
        await _client.PutAsync(URL, positionForUpdate);
    }

    public async Task DeletePositionAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
