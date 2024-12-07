using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
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

    public async Task<PaginatedResponse<PositionViewModel>> GetAllPositionsAsync(string? search = null, int? pageNumber = 1)
    {
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<PositionViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        return response;
    }

    public async Task<PositionViewModel> GetPositionByIdAsync(int id)
    {
        var position = await _client.GetAsync<PositionViewModel>($"{URL}/{id}");

        return position;
    }

    public async Task<PositionViewModel> CreatePositionAsync(PositionViewModel positionForCreate)
    {
        var entity = positionForCreate.ToEntity();

        var createdPosition = await _client
            .PostAsync<PositionViewModel, Position>(URL, entity);

        return createdPosition;
    }

    public async Task UpdatePositionAsync(PositionViewModel positionForUpdate)
    {
        var entity = positionForUpdate.ToEntity();

        await _client.PutAsync(URL, entity);
    }

    public async Task DeletePositionAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
