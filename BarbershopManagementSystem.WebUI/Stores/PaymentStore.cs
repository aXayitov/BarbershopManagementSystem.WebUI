using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores;

public class PaymentStore : IPaymentStore
{
    private const string URL = "payments";
    private readonly ApiClient _client;

    public PaymentStore(ApiClient client)
    {
        _client = client;
    }   

    public async Task<List<PaymentViewModel>> GetAllPaymentsAsync(string? search = null)
    {
        var response = await _client.GetAsync<PaginatedResponse<PaymentViewModel>>($"{URL}?search={search}");

        return response.Data;
    }

    public async Task<PaymentViewModel> GetPaymentByIdAsync(int id)
    {
        var payment = await _client.GetAsync<PaymentViewModel>($"{URL}/{id}");

        return payment;
    }

    public async Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel paymentForCreate)
    {
        var createdPayment = await _client
            .PostAsync<PaymentViewModel, PaymentViewModel>(URL, paymentForCreate);

        return createdPayment;
    }

    public async Task UpdatePaymentAsync(PaymentViewModel paymentForUpdate)
    {
        await _client.PutAsync(URL, paymentForUpdate);
    }

    public async Task DeletePaymentAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
