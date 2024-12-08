using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class EmployeeStore : IEmployeeStore
{
    private const string URL = "employee";
    private readonly ApiClient _client;

    public EmployeeStore(ApiClient client)
    {
        _client = client;
    }

    public async Task<PaginatedResponse<EmployeeViewModel>> GetAllEmployeesAsync(string? search = null, int? pageNumber = 1)
    {
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<EmployeeViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        return response;
    }

    public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
    {
        var employee = await _client.GetAsync<EmployeeViewModel>($"{URL}/{id}");

        return employee;
    }

    public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModel employeeForCreate)
    {
        var entity = employeeForCreate.ToEntity();

        var createdEmployee = await _client
            .PostAsync<EmployeeViewModel, Employee>(URL, entity);

        return createdEmployee;
    }

    public async Task UpdateEmployeeAsync(EmployeeViewModel employeeForUpdate)
    {
        var entity = employeeForUpdate.ToEntity();

        await _client.PutAsync(URL+$"/{employeeForUpdate.Id}", entity);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
