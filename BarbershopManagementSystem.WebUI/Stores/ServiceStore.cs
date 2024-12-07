using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
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
        

        public async Task<PaginatedResponse<ServiceViewModel>> GetAllServicesAsync(string? search = null, int? pageNumber = 1)
        {
            search ??= string.Empty;
            pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

            var response = await _client.GetAsync<PaginatedResponse<ServiceViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

            return response;
        }

        public async Task<ServiceViewModel> GetServiceByIdAsync(int id)
        {
            var service = await _client.GetAsync<ServiceViewModel>($"{URL}/{id}");

            return service;
        }

        public async Task<ServiceViewModel> CreateServiceAsync(ServiceViewModel serviceForCreate)
        {
            var entity = serviceForCreate.ToEntity();

            var createdService = await _client
            .PostAsync<ServiceViewModel, Service>(URL, entity);

            return createdService;
        }

        public async Task UpdateServiceAsync(ServiceViewModel serviceForUpdate)
        {
            var entity = serviceForUpdate.ToEntity();

            await _client.PutAsync(URL, entity);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _client.DeleteAsync(URL, id);
        }
    }
}
