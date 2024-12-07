using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IEnrollmentStore
{
    Task<PaginatedResponse<EnrollmentViewModel>> GetAllEnrollmentsAsync(string? search=null, int? pageNumber = null);
    Task<EnrollmentViewModel> GetEnrollmentByIdAsync(int id);
    Task<EnrollmentViewModel> CreateEnrollmentAsync(EnrollmentViewModel enrollmentForCreate);
    Task UpdateEnrollmentAsync(EnrollmentViewModel enrollmentForUpdate);
    Task DeleteEnrollmentAsync(int id);
}
