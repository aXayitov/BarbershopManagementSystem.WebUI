using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
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

    public async Task<PaginatedResponse<EnrollmentViewModel>> GetAllEnrollmentsAsync(string? search = null, int? pageNumber = 1)
    {
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<EnrollmentViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        return response;
    }

    public async Task<EnrollmentViewModel> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _client.GetAsync<EnrollmentViewModel>($"{URL}/{id}");

        return enrollment;
    }

    public async Task<EnrollmentViewModel> CreateEnrollmentAsync(EnrollmentViewModel enrollmentForCreate)
    {
        var entity = enrollmentForCreate.ToEntity();

        var createdEnrollment = await _client
            .PostAsync<EnrollmentViewModel, Enrollment>(URL, entity);

        return createdEnrollment;
    }

    public async Task UpdateEnrollmentAsync(EnrollmentViewModel enrollmentForUpdate)
    {
        var entity = enrollmentForUpdate.ToEntity();

        await _client.PutAsync(URL + $"/{enrollmentForUpdate.Id}", entity);
    }

    public async Task DeleteEnrollmentAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
