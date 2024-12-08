using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.Stores;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        ViewBag.SearchString = searchString;
        ViewBag.CurrentPage = pageNumber ?? 1;
        ViewBag.TotalPages = employees.PagesCount;

        return View(employees.Data);
    }

    // GET: EmployeeController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var employee = await _employeeStore.GetEmployeeByIdAsync(id);
        var position = await _positionStore.GetPositionByIdAsync(employee.PositionId);

        employee.Position = position.Name;

        return View(employee);
    }

    // GET: EmployeeController/Create
    public async Task<ActionResult> Create()
    {
        var positions = await GetPositions();

        ViewData["Positions"] = new SelectList(positions, "Id", "Name");

        return View();
    }

    // POST: EmployeeController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("FullName, PhoneNumber, PositionId")] EmployeeViewModel employee)
    {
        var createdEmployee = await _employeeStore.CreateEmployeeAsync(employee);
        var positions = await GetPositions();

        ViewData["Positions"] = new SelectList(positions.ToList(), "Id", "Name", employee.PositionId);

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
        var positions = await GetPositions();

        ViewData["Positions"] = new SelectList(positions, "Id", "Name", employee.Id);

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

        var positions = await GetPositions();

        ViewData["Positions"] = new SelectList(positions, "Id", "Name", employee.Id);

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
    [HttpPost, ActionName(nameof(Delete))]
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
