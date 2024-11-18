using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class CustomerStore : ICustomerStore
{
    private const string URL = "customers";
    private readonly ApiClient _client;

    public CustomerStore(ApiClient client)
    {
        _client = client;
    }

    public async Task<PaginatedResponse<CustomerViewModel>> GetAllCustomersAsync(string? search = null, int? pageNumber = 1)
    {
        // Set default values if parameters are null
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<CustomerViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        // response.Data - list of customers
        // response.TotalItems - total number of records

        return response;
    }


    public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
    {
        var customer = await _client.GetAsync<CustomerViewModel>($"{URL}/{id}");

        return customer;
    }

    public async Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerForCreate)
    {
        var createdCustomer = await _client
            .PostAsync<CustomerViewModel, CustomerViewModel>(URL, customerForCreate);

        return createdCustomer;
    }

    public async Task UpdateCustomerAsync(CustomerViewModel customerForUpdate)
    {
        await _client.PutAsync(URL, customerForUpdate);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
