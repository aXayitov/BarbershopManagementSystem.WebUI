using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class EnrollmentStore : IEnrollmentStore
{
    private const string URL = "enrollments";
    private readonly ApiClient _client;

    public EnrollmentStore(ApiClient client)
    {
        _client = client;
    }

    public async Task<List<EnrollmentViewModel>> GetAllEnrollmentsAsync(string? search = null)
    {
        var response = await _client.GetAsync<PaginatedResponse<EnrollmentViewModel>>($"{URL}?search={search}");

        return response.Data;
    }

    public async Task<EnrollmentViewModel> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _client.GetAsync<EnrollmentViewModel>($"{URL}/{id}");

        return enrollment;
    }

    public async Task<EnrollmentViewModel> CreateEnrollmentAsync(EnrollmentViewModel enrollmentForCreate)
    {
        var createdEnrollment = await _client
            .PostAsync<EnrollmentViewModel, EnrollmentViewModel>(URL, enrollmentForCreate);

        return createdEnrollment;
    }

    public async Task UpdateEnrollmentAsync(EnrollmentViewModel enrollmentForUpdate)
    {
        await _client.PutAsync(URL, enrollmentForUpdate);
    }

    public async Task DeleteEnrollmentAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
