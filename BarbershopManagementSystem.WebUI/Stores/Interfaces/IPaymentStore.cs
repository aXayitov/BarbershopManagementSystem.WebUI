using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IPaymentStore
{
    Task<PaginatedResponse<PaymentViewModel>> GetAllPaymentsAsync(string? search = null, int? pageNumber = null);
    Task<PaymentViewModel> GetPaymentByIdAsync(int id);
    Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel paymentForCreate);
    Task UpdatePaymentAsync(PaymentViewModel paymentForUpdate);
    Task DeletePaymentAsync(int id);
}
