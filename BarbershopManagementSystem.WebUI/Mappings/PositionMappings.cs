using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings
{
    public static class PositionMappings
    {
        public static PositionViewModel ToViewModel(this Position position)
        {
            return new PositionViewModel
            {
                Id = position.Id,
                Name = position.Name,
                Description = position.Description,
            };
        }

        public static Position ToEntity(this PositionViewModel positionViewModel)
        {
            return new Position
            {
                Id = positionViewModel.Id,
                Name = positionViewModel.Name,
                Description = positionViewModel.Description,
            };
        }
    }
}
