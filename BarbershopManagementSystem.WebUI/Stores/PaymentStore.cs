using BarbershopManagementSystem.WebUI.Mappings;
using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Models.Entity;
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

    public async Task<PaginatedResponse<PaymentViewModel>> GetAllPaymentsAsync(string? search = null, int? pageNumber = 1)
    {
        search ??= string.Empty;
        pageNumber = pageNumber.HasValue && pageNumber > 0 ? pageNumber : 1;

        var response = await _client.GetAsync<PaginatedResponse<PaymentViewModel>>($"{URL}?search={search}&pagenumber={pageNumber}");

        return response;
    }

    public async Task<PaymentViewModel> GetPaymentByIdAsync(int id)
    {
        var payment = await _client.GetAsync<PaymentViewModel>($"{URL}/{id}");

        return payment;
    }

    public async Task<PaymentViewModel> CreatePaymentAsync(PaymentViewModel paymentForCreate)
    {
        var entity = paymentForCreate.ToEntity();

        var createdPayment = await _client
            .PostAsync<PaymentViewModel, Payment>(URL, entity);

        return createdPayment;
    }

    public async Task UpdatePaymentAsync(PaymentViewModel paymentForUpdate)
    {
        var entity = paymentForUpdate.ToEntity();

        await _client.PutAsync(URL, entity);
    }

    public async Task DeletePaymentAsync(int id)
    {
        await _client.DeleteAsync(URL, id);
    }
}
