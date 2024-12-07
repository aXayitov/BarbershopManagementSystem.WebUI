using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class EmployeeStore : IEmployeeStore
{
    private const string URL = "employees";
    private readonly ApiClient _client;

    public EmployeeStore(ApiClient client)
    {
        _client = client;
    }

    public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync(string? search = null)
    {
        var response = await _client.GetAsync<PaginatedResponse<EmployeeViewModel>>($"{URL}?search={search}");

        return response.Data;
    }

    public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
    {
        var employee = await _client.GetAsync<EmployeeViewModel>($"{URL}/{id}");

        return employee;
    }

    public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeViewModel employeeForCreate)
    {
        var createdEmployee = await _client
            .PostAsync<EmployeeViewModel, EmployeeViewModel>(URL, employeeForCreate);

        return createdEmployee;
    }

    public async Task UpdateEmployeeAsync(EmployeeViewModel employeeForUpdate)
    {
        await _client.PutAsync(URL + $"/{employeeForUpdate.Id}", employeeForUpdate);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
