﻿using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Stores.Interfaces;

public interface IPositionStore
{
    Task<List<PositionViewModel>> GetAllPositionsAsync(string? search = null);
    Task<PositionViewModel> GetPositionByIdAsync(int id);
    Task<PositionViewModel> CreatePositionAsync(PositionViewModel positionForCreate);
    Task UpdatePositionAsync(PositionViewModel positionForUpdate);
    Task DeletePositionAsync(int id);
}