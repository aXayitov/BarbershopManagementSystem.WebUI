using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers;

public class CustomersController : Controller
{
    private readonly ICustomerStore _customerStore;

    public CustomersController(ICustomerStore customerStore)
    {
        _customerStore = customerStore;
    }

    // GET: Customers
    public async Task<ActionResult> Index(string? searchString, int? pageNumber)
    {
        var customers = await _customerStore.GetAllCustomersAsync(searchString, pageNumber ?? 1);

        ViewBag.SearchString = searchString;
        ViewBag.CurrentPage = pageNumber ?? 1;
        ViewBag.TotalPages = customers.PagesCount;

        return View(customers.Data);
    }

    // GET: CustomerController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var customer = await _customerStore.GetCustomerByIdAsync(id);

        return View(customer);
    }

    // GET: CustomerController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("FullName, PhoneNumber, Email")] CustomerViewModel customer)
    {


        var createdCustomer = await _customerStore.CreateCustomerAsync(customer);

        return RedirectToAction(nameof(Details), new { id = createdCustomer.Id});
    }

    // GET: CustomerController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var customer = await _customerStore.GetCustomerByIdAsync(id);

        if(customer is null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id, FullName, PhoneNumber")] CustomerViewModel customer)
    {
        try
        {
            await _customerStore.UpdateCustomerAsync(customer);

            return RedirectToAction();
        }
        catch
        {
            return View();
        }
    }

    // GET: CustomerController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var customer = await _customerStore.GetCustomerByIdAsync(id);

        if(customer is null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: CustomerController/Delete/5
    [HttpPost, ActionName(nameof(Delete))]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ConfirmDelete(int id)
    {
        try
        {
            await _customerStore.DeleteCustomerAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
