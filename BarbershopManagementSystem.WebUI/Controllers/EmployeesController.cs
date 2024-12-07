using BarbershopManagementSystem.WebUI.Stores;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeStore _employeeStore;
    private readonly IPositionStore _positionStore;

    public EmployeesController(IEmployeeStore employeeStore, IPositionStore positionStore)
    {
        _employeeStore = employeeStore;
        _positionStore = positionStore;
    }
    // GET: Employees
    public async Task<ActionResult> Index(string? searchString, int? pageNumber)
    {
        var employees = await _employeeStore.GetAllEmployeesAsync(searchString, pageNumber ?? 1);
        var positions = await GetPositions();

        ViewBag.Positions = positions;

        ViewBag.SearchString = searchString;
        ViewBag.CurrentPage = pageNumber ?? 1;
        ViewBag.TotalPages = employees.PagesCount;

        return View(employees.Data);
    }

    // GET: EmployeeController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var employee = await _employeeStore.GetEmployeeByIdAsync(id);

        return View(employee);
    }

    // GET: EmployeeController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EmployeeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("FullName, PhoneNumber, PositionId")] EmployeeViewModel employee)
    {
        var createdEmployee = await _employeeStore.CreateEmployeeAsync(employee);

        return RedirectToAction(nameof(Index));
    }

    // GET: EmployeeController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var employee = await _employeeStore.GetEmployeeByIdAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: EmployeeController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id, FullName, PhoneNumber, PositionId")] EmployeeViewModel employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeStore.UpdateEmployeeAsync(employee);
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    // GET: EmployeeController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var employee = await _employeeStore.GetEmployeeByIdAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: EmployeeController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ConfirmDelete(int id)
    {
        try
        {
            await _employeeStore.DeleteEmployeeAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    private async Task<List<PositionViewModel>> GetPositions()
    {
        var position = await _positionStore.GetAllPositionsAsync();

        return position.Data;
    }
}
