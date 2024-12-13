using BarbershopManagementSystem.WebUI.Models.Enums;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarbershopManagementSystem.WebUI.Controllers;

public class EnrollmentsController : Controller
{
    private readonly IEnrollmentStore _enrollmentStore;
    private readonly ICustomerStore _customerStore;
    private readonly IEmployeeStore _employeeStore;
    private readonly IServiceStore _serviceStore;

    public EnrollmentsController(
        IEnrollmentStore enrollmentStore, 
        ICustomerStore customerStore, 
        IEmployeeStore employeeStore, 
        IServiceStore serviceStore)
    {
        _enrollmentStore = enrollmentStore;
        _customerStore = customerStore;
        _employeeStore = employeeStore;
        _serviceStore = serviceStore;
    }

    // GET: EnrollmentsController
    public async Task<ActionResult> Index(string? searchString, int? pageNumber)
    {
        var enrolments = await _enrollmentStore.GetAllEnrollmentsAsync(searchString, pageNumber ?? 1);

        ViewBag.SearchString = searchString;
        ViewBag.CurrentPage = pageNumber ?? 1;
        ViewBag.TotalPages = enrolments.PagesCount;

        return View(enrolments.Data);
    }

    // GET: EnrollmentsController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var enrollment = await _enrollmentStore.GetEnrollmentByIdAsync(id);
        var customer = await _customerStore.GetCustomerByIdAsync(enrollment.CustomerId);
        var employee = await _employeeStore.GetEmployeeByIdAsync(enrollment.EmployeeId);
        var service = await _serviceStore.GetServiceByIdAsync(enrollment.ServiceId);

        enrollment.Customer = customer.FullName;
        enrollment.Employee = employee.FullName;
        enrollment.Service = service.Name; 

        return View(enrollment);
    }

    // GET: EnrollmentsController/Create
    public async Task<ActionResult> Create(string? search)
    {
        var customers = await _customerStore.GetAllCustomersAsync(search);
        var employees = await _employeeStore.GetAllEmployeesAsync();
        var services = await _serviceStore.GetAllServicesAsync();

        ViewData["Customers"] = new SelectList(customers.Data, "Id", "FullName");
        ViewData["Employees"] = new SelectList(employees.Data, "Id", "FullName");
        ViewData["Services"] = new SelectList(services.Data, "Id", "Name");
        ViewBag.Statuses = Enum.GetValues(typeof(EnrollmentStatus)).Cast<EnrollmentStatus>()
                           .Select(s => new SelectListItem
                           {
                               Text = s.ToString(),
                               Value = ((int)s).ToString()
                           }).ToList();

        return View();
    }

    // POST: EnrollmentsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("CustomerId, EmployeeId, ServiceId, Date, Status")]EnrollmentViewModel enrollment)
    {
        var createdEnrollment = await _enrollmentStore.CreateEnrollmentAsync(enrollment);
        var customers = await _customerStore.GetAllCustomersAsync();
        var employees = await _employeeStore.GetAllEmployeesAsync();
        var services = await _serviceStore.GetAllServicesAsync();

        ViewData["Customers"] = new SelectList(customers.Data, "Id", "FullName", enrollment.CustomerId);
        ViewData["Employees"] = new SelectList(employees.Data, "Id", "FullName", enrollment.EmployeeId);
        ViewData["Services"] = new SelectList(services.Data, "Id", "Name", enrollment.ServiceId);
        ViewBag.Statuses = Enum.GetValues(typeof(EnrollmentStatus)).Cast<EnrollmentStatus>()
                           .Select(s => new SelectListItem
                           {
                               Text = s.ToString(),
                               Value = ((int)s).ToString()
                           }).ToList();

        return RedirectToAction(nameof(Index));
    }

    // GET: EnrollmentsController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var enrollment = await _enrollmentStore.GetEnrollmentByIdAsync(id);
        var customers = await _customerStore.GetAllCustomersAsync();
        var employees = await _employeeStore.GetAllEmployeesAsync();
        var services = await _serviceStore.GetAllServicesAsync();

        if(enrollment is null)
        {
            return NotFound();
        }

        ViewData["Customers"] = new SelectList(customers.Data, "Id", "FullName", enrollment.Id);
        ViewData["Employees"] = new SelectList(employees.Data, "Id", "FullName", enrollment.Id);
        ViewData["Services"] = new SelectList(services.Data, "Id", "Name", enrollment.Id);
        ViewBag.Statuses = Enum.GetValues(typeof(EnrollmentStatus)).Cast<EnrollmentStatus>()
                           .Select(s => new SelectListItem
                           {
                               Text = s.ToString(),
                               Value = ((int)s).ToString()
                           }).ToList();

        return View(enrollment);
    }

    // POST: EnrollmentsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id,[Bind("Id, CustomerId, EmployeeId, ServiceId, Data, Status")] EnrollmentViewModel enrollment)
    {
        if (ModelState.IsValid)
        {
            await _enrollmentStore.UpdateEnrollmentAsync(enrollment);
            return RedirectToAction(nameof(Index));
        }

        var customers = await _customerStore.GetAllCustomersAsync();
        var employees = await _employeeStore.GetAllEmployeesAsync();
        var services = await _serviceStore.GetAllServicesAsync();

        ViewData["Customers"] = new SelectList(customers.Data, "Id", "FullName", enrollment.Id);
        ViewData["Employees"] = new SelectList(employees.Data, "Id", "FullName", enrollment.Id);
        ViewData["Services"] = new SelectList(services.Data, "Id", "Name", enrollment.Id);
        ViewBag.Statuses = Enum.GetValues(typeof(EnrollmentStatus)).Cast<EnrollmentStatus>()
                           .Select(s => new SelectListItem
                           {
                               Text = s.ToString(),
                               Value = ((int)s).ToString()
                           }).ToList();

        return View();
    }

    // GET: EnrollmentsController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var enrollment = await _enrollmentStore.GetEnrollmentByIdAsync(id);

        if (enrollment is null)
        {
            return NotFound();
        }
        return View(enrollment);
    }

    // POST: EnrollmentsController/Delete/5
    [HttpPost, ActionName(nameof(Delete))]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ConfirmDelete(int id)
    {
        try
        {
            await _enrollmentStore.DeleteEnrollmentAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
