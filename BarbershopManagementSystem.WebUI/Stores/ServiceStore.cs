using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores
{
    public class ServiceStore : IServiceStore
    {
        private const string URL = "services";
        private readonly ApiClient _client;

        public ServiceStore(ApiClient client)
        {
            _client = client;
        }
        

        public async Task<List<ServiceViewModel>> GetAllServicesAsync(string? search = null)
        {
            var response = await _client.GetAsync<PaginatedResponse<ServiceViewModel>>($"{URL}?search={search}");

            return response.Data;
        }

        public async Task<ServiceViewModel> GetServiceByIdAsync(int id)
        {
            var service = await _client.GetAsync<ServiceViewModel>($"{URL}/{id}");

            return service;
        }

        public async Task<ServiceViewModel> CreateServiceAsync(ServiceViewModel serviceForCreate)
        {
            var createdService = await _client
            .PostAsync<ServiceViewModel, ServiceViewModel>(URL, serviceForCreate);

            return createdService;
        }

        public async Task UpdateServiceAsync(ServiceViewModel serviceForUpdate)
        {
            await _client.PutAsync(URL, serviceForUpdate);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _client.DeleteAsync(URL, id);
        }
    }
}
