using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IEnrollmentStore
{
    Task<List<EnrollmentViewModel>> GetAllEnrollmentsAsync(string? search=null);
    Task<EnrollmentViewModel> GetEnrollmentByIdAsync(int id);
    Task<EnrollmentViewModel> CreateEnrollmentAsync(EnrollmentViewModel enrollmentForCreate);
    Task UpdateEnrollmentAsync(EnrollmentViewModel enrollmentForUpdate);
    Task DeleteEnrollmentAsync(int id);
}
