﻿using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
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
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<CustomerViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        return response;
    }

    public async Task<CustomerViewModel> GetCustomerByIdAsync(int id)
    {
        var customer = await _client.GetAsync<CustomerViewModel>($"{URL}/{id}");

        return customer;
    }

    public async Task<CustomerViewModel> CreateCustomerAsync(CustomerViewModel customerForCreate)
    {
        var entity = customerForCreate.ToEntity();

        var createdCustomer = await _client
            .PostAsync<CustomerViewModel, Customer>(URL, entity);

        return createdCustomer;
    }

    public async Task UpdateCustomerAsync(CustomerViewModel customerForUpdate)
    {
        var entity = customerForUpdate.ToEntity();        

        await _client.PutAsync(URL+$"/{customerForUpdate.Id}", entity);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
