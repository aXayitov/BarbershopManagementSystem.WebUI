using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers;

public class PositionsController : Controller
{
    private readonly IPositionStore _positionStore;

    public PositionsController(IPositionStore positionStore)
    {
        _positionStore = positionStore;
    }

    public async Task<ActionResult> Index(string? search, int? pageNumber)
    {
        var positions = await _positionStore.GetAllPositionsAsync(search, pageNumber);

        ViewBag.SearchString = search;
        ViewBag.CurrentPage = pageNumber ?? 1;
        ViewBag.TotalPages = positions.PagesCount;

        return View(positions.Data);
    }

    public async Task<ActionResult> Details(int id)
    {
        var position = await _positionStore.GetPositionByIdAsync(id);

        return View(position);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name, Description")] PositionViewModel position)
    {
        var createdPosition = await _positionStore.CreatePositionAsync(position);

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Edit(int id)
    {
        var position = await _positionStore.GetPositionByIdAsync(id);

        if (position is null)
        {
            return NotFound();
        }

        return View(position);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id, Name, Description")] PositionViewModel position)
    {
        if (ModelState.IsValid)
        {
            await _positionStore.UpdatePositionAsync(position);
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public async Task<ActionResult> Delete(int id)
    {
        var position = await _positionStore.GetPositionByIdAsync(id);

        if (position is null)
        {
            return NotFound();
        }

        return View(position);
    }

    [HttpPost, ActionName(nameof(Delete))]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ConfirmDelete(int id)
    {
        try
        {
            await _positionStore.DeletePositionAsync(id);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
