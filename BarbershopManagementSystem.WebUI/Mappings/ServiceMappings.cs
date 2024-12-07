using BarbershopManagementSystem.WebUI.Models.Entity;
using BarbershopManagementSystem.WebUI.ViewModels;

namespace BarbershopManagementSystem.WebUI.Mappings
{
    public static class ServiceMappings
    {
        public static ServiceViewModel ToViewModel(this Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration,
            };
        }

        public static Service ToEntity(this ServiceViewModel serviceViewModel)
        {
            return new Service
            {
                Id = serviceViewModel.Id,
                Name = serviceViewModel.Name,
                Price = serviceViewModel.Price,
                Duration = serviceViewModel.Duration,
            };
        }
    }
}
