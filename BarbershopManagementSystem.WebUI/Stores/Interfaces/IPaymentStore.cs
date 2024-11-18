using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IPaymentStore
{
    Task<List<PaymentViewModel>> GetAllPaymentsAsync(string? search = null);
    Task<PaymentViewModel> GetPaymentByIdAsync(int id);
    Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel paymentForCreate);
    Task UpdatePaymentAsync(PaymentViewModel paymentForUpdate);
    Task DeletePaymentAsync(int id);
}
